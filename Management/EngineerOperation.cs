using System.Security.Cryptography;
using TflScheduling.CustomCollections;
using TflScheduling.Management;

namespace TflScheduling;

public class EngineerOperation : IEngineer
{
    public static CLinkedList<Line> LineList { get; set; }

    private static bool continueAddSelecting = true;

    private static bool continueRemoveSelecting = true;

    private static bool continueCloseTrackSection = true;

    private static bool continueOpenTrackSection = true;

    private static bool continuePrintClosedTrackSection = true;


    public EngineerOperation(CLinkedList<Line> lineList)
    {
        LineList = lineList;
    }


    public void AddTimeDelayOnTrack()
    {
        continueAddSelecting = true;

        while (continueAddSelecting)
        {
            Console.WriteLine("\nSelect a line from the list below to add a delay:");
            var currentNode = LineList.GetFirst();
            int index = 1;
            while (currentNode != null)
            {
                Console.WriteLine($"{index}) {currentNode.Item.Name}");
                currentNode = currentNode.Next;
                index++;
            }

            Console.WriteLine($"{index}) Go back");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int lineChoice) && lineChoice > 0 && lineChoice <= index)
            {
                if (lineChoice == index)
                {
                    continueAddSelecting = false;
                }
                else
                {
                    HandleLineSelection(lineChoice);
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please select a valid option.");
            }
        }
    }

    private static void HandleLineSelection(int lineChoice)
    {
        continueAddSelecting = true;
        var currentNode = LineList.GetFirst();
        int currentIndex = 1;
        while (currentNode != null && currentIndex < lineChoice)
        {
            currentNode = currentNode.Next;
            currentIndex++;
        }

        if (currentNode != null)
        {
            Line selectedLine = currentNode.Item;
            Console.WriteLine($"\nYou selected {selectedLine.Name}. Here are the schedules for this line:");

            Console.WriteLine($"\n{new string('=', 46)}");
            Console.Write($"{new string('=', 17)}");
            Console.Write($" Schedules for {selectedLine.Name} ");
            Console.WriteLine($"{new string('=', 17)}");
            Console.WriteLine($"{new string('=', 46)}");

            // Print header for columns
            Console.WriteLine("{0,-20} {1,-20} {2,-15} {3,-20} {4,-20} {5,-20} {6,-20}",
                "From Station", "To Station", "Distance (km)",
                "Running Time(min)", "Am Peak(min)", "Inter Peak(min)", "Delay(min)");
            Console.WriteLine($"{new string('-', 140)}");

            // Display each schedule associated with the line
            var scheduleNode = selectedLine.Schedules.GetFirst();
            int scheduleIndex = 1;
            if (scheduleNode == null)
            {
                Console.WriteLine("No schedules available for this line.");
            }
            else
            {
                while (scheduleNode != null)
                {
                    LineSchedule schedule = scheduleNode.Item;
                    Console.WriteLine("{0}) {1,-18} {2,-20} {3,-15} {4,-21} {5,-19} {6,-19} {7,-19}",
                        scheduleIndex,
                        schedule.FromStation.Name,
                        schedule.ToStation.Name,
                        schedule.Distance.ToString("N2"),
                        schedule.UnimpededRunningTime.ToString("N2"),
                        schedule.AmPeakRunningTime.ToString("N2"),
                        schedule.InterPeakRunningTime.ToString("N2"),
                        schedule.Delay.ToString("N2"));
                    scheduleNode = scheduleNode.Next;
                    scheduleIndex++;
                }
            }

            // Ask the user to select a schedule to modify or to exit
            Console.WriteLine("\nEnter the number of the schedule to add a delay to, or type '0' to exit:");
            int selectedScheduleIndex;
            bool isValidInput = int.TryParse(Console.ReadLine(), out selectedScheduleIndex);

            if (!isValidInput || selectedScheduleIndex < 0 || selectedScheduleIndex > scheduleIndex - 1)
            {
                Console.WriteLine("Invalid input, please select a valid schedule number.");
                return;
            }

            if (selectedScheduleIndex == 0)
            {
                Console.WriteLine("No changes made, returning to the previous menu.");
                return;
            }

            // Move to the selected schedule node
            scheduleNode = selectedLine.Schedules.GetFirst();
            for (int i = 1; i < selectedScheduleIndex; i++)
            {
                scheduleNode = scheduleNode.Next;
            }

            // Prompt for delay
            Console.WriteLine("Enter the number of minutes to delay the schedule:");
            double delay;
            isValidInput = double.TryParse(Console.ReadLine(), out delay);

            if (!isValidInput || delay < 0)
            {
                Console.WriteLine("Invalid input, please enter a valid number of minutes.");
                return;
            }

            // Apply delay
            scheduleNode.Item.AmPeakRunningTime += delay;
            scheduleNode.Item.InterPeakRunningTime += delay;
            scheduleNode.Item.UnimpededRunningTime += delay;
            scheduleNode.Item.Delay += delay;

            Console.WriteLine(
                $"Delay of {delay} minutes added to schedule from {scheduleNode.Item.FromStation.Name} to {scheduleNode.Item.ToStation.Name}.");

            continueAddSelecting = false;
        }
    }


    public void RemoveTimeDelayOnTrack()
    {
        continueRemoveSelecting = true;

        while (continueRemoveSelecting)
        {
            Console.WriteLine("\nSelect a line from the list below to remove a delay:");
            var currentNode = LineList.GetFirst();
            int index = 1;
            while (currentNode != null)
            {
                Console.WriteLine($"{index}) {currentNode.Item.Name}");
                currentNode = currentNode.Next;
                index++;
            }

            Console.WriteLine($"{index}) Go back");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int lineChoice) && lineChoice > 0 && lineChoice <= index)
            {
                if (lineChoice == index)
                {
                    continueRemoveSelecting = false;
                }
                else
                {
                    HandleRemoveLineSelection(lineChoice);
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please select a valid option.");
            }
        }
    }

    private static void HandleRemoveLineSelection(int lineChoice)
    {
        continueRemoveSelecting = true;
        var currentNode = LineList.GetFirst();
        int currentIndex = 1;
        while (currentNode != null && currentIndex < lineChoice)
        {
            currentNode = currentNode.Next;
            currentIndex++;
        }

        if (currentNode != null)
        {
            Line selectedLine = currentNode.Item;
            Console.WriteLine($"\nYou selected {selectedLine.Name}. Here are the schedules with delays for this line:");

            Console.WriteLine($"\n{new string('=', 46)}");
            Console.Write($"{new string('=', 17)}");
            Console.Write($" Delays on {selectedLine.Name} Line");
            Console.WriteLine($"{new string('=', 17)}");
            Console.WriteLine($"{new string('=', 46)}");

            // Print header for columns
            Console.WriteLine("{0,-20} {1,-20} {2,-15} {3,-20} {4,-20} {5,-20} {6,-20}",
                "From Station", "To Station", "Distance (km)",
                "Running Time(min)", "Am Peak(min)", "Inter Peak(min)", "Delay(min)");
            Console.WriteLine($"{new string('-', 140)}");

            // Display each schedule associated with the line
            var scheduleNode = selectedLine.Schedules.GetFirst();
            int scheduleIndex = 1;
            if (scheduleNode == null)
            {
                Console.WriteLine("No delays on this line.");
            }
            else
            {
                bool foundDelay = false;
                while (scheduleNode != null)
                {
                    LineSchedule schedule = scheduleNode.Item;
                    if (schedule.Delay > 0)
                    {
                        foundDelay = true;
                        Console.WriteLine("{0}) {1,-18} {2,-20} {3,-15} {4,-21} {5,-19} {6,-19} {7,-19}",
                            scheduleIndex,
                            schedule.FromStation.Name,
                            schedule.ToStation.Name,
                            schedule.Distance.ToString("N2"),
                            schedule.UnimpededRunningTime.ToString("N2"),
                            schedule.AmPeakRunningTime.ToString("N2"),
                            schedule.InterPeakRunningTime.ToString("N2"),
                            schedule.Delay.ToString("N2"));
                    }

                    scheduleNode = scheduleNode.Next;
                    scheduleIndex++;
                }

                if (!foundDelay)
                {
                    Console.WriteLine("No schedules with delays available for this line.");
                }
            }

            
            Console.WriteLine("\nEnter the number of the schedule to remove a delay from, or type '0' to exit:");
            int selectedScheduleIndex;
            bool isValidInput = int.TryParse(Console.ReadLine(), out selectedScheduleIndex);

            if (!isValidInput || selectedScheduleIndex < 0 || selectedScheduleIndex > scheduleIndex - 1)
            {
                Console.WriteLine("Invalid input, please select a valid schedule number.");
                return;
            }

            if (selectedScheduleIndex == 0)
            {
                Console.WriteLine("No changes made, returning to the previous menu.");
                return;
            }

            
            scheduleNode = selectedLine.Schedules.GetFirst();
            for (int i = 1; i < selectedScheduleIndex; i++)
            {
                scheduleNode = scheduleNode.Next;
            }

            
            Console.WriteLine("Enter the number of minutes to delay the schedule:");
            double delay;
            isValidInput = double.TryParse(Console.ReadLine(), out delay);

            if (!isValidInput || delay > scheduleNode.Item.Delay)
            {
                Console.WriteLine("Invalid input, please enter a valid number of minutes.");
                return;
            }

            
            scheduleNode.Item.AmPeakRunningTime -= delay;
            scheduleNode.Item.InterPeakRunningTime -= delay;
            scheduleNode.Item.UnimpededRunningTime -= delay;
            scheduleNode.Item.Delay -= delay;

            Console.WriteLine(
                $"Delay of {delay} minutes added to schedule from {scheduleNode.Item.FromStation.Name} to {scheduleNode.Item.ToStation.Name}.");

            continueRemoveSelecting = false;
        }
    }

    public void CloseTrackSection()
    {
        continueCloseTrackSection = true;

        while (continueCloseTrackSection)
        {
            Console.WriteLine("\nSelect a line from the list below to add closure:");
            var currentNode = LineList.GetFirst();
            int index = 1;
            while (currentNode != null)
            {
                Console.WriteLine($"{index}) {currentNode.Item.Name}");
                currentNode = currentNode.Next;
                index++;
            }

            Console.WriteLine($"{index}) Go back");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int lineChoice) && lineChoice > 0 && lineChoice <= index)
            {
                if (lineChoice == index)
                {
                    continueCloseTrackSection = false;
                }
                else
                {
                    HandleClosureLineSelection(lineChoice);
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please select a valid option.");
            }
        }
    }

    private static void HandleClosureLineSelection(int lineChoice)
    {
        continueCloseTrackSection = true;
        var currentNode = LineList.GetFirst();
        int currentIndex = 1;
        while (currentNode != null && currentIndex < lineChoice)
        {
            currentNode = currentNode.Next;
            currentIndex++;
        }

        if (currentNode != null)
        {
            Line selectedLine = currentNode.Item;
            Console.WriteLine($"\nYou selected {selectedLine.Name}. Here are the open tracks for this line:");

            Console.WriteLine($"\n{new string('=', 46)}");
            Console.Write($"{new string('=', 17)}");
            Console.Write($" Open tracks on {selectedLine.Name} Line");
            Console.WriteLine($"{new string('=', 17)}");
            Console.WriteLine($"{new string('=', 46)}");

            
            Console.WriteLine("{0,-20} {1,-20} {2,-15} {3,-20} {4,-20} {5,-20} {6,-20}",
                "From Station", "To Station", "Distance (km)",
                "Running Time(min)", "Am Peak(min)", "Inter Peak(min)", "Status");
            Console.WriteLine($"{new string('-', 140)}");

            
            var scheduleNode = selectedLine.Schedules.GetFirst();
            int scheduleIndex = 1;
            if (scheduleNode == null)
            {
                Console.WriteLine("No open tracks on this line.");
            }
            else
            {
                bool foundNonClosure = false;
                while (scheduleNode != null)
                {
                    LineSchedule schedule = scheduleNode.Item;
                    if (!schedule.Closure)
                    {
                        foundNonClosure = true;
                        Console.WriteLine("{0}) {1,-18} {2,-20} {3,-15} {4,-21} {5,-19} {6,-19} {7,-19}",
                            scheduleIndex,
                            schedule.FromStation.Name,
                            schedule.ToStation.Name,
                            schedule.Distance.ToString("N2"),
                            schedule.UnimpededRunningTime.ToString("N2"),
                            schedule.AmPeakRunningTime.ToString("N2"),
                            schedule.InterPeakRunningTime.ToString("N2"),
                            "Open");
                    }

                    scheduleNode = scheduleNode.Next;
                    scheduleIndex++;
                }

                if (!foundNonClosure)
                {
                    Console.WriteLine("No open tracks available for this line.");
                }
            }

            
            Console.WriteLine("\nEnter the number of the track to close, or type '0' to exit:");
            int selectedScheduleIndex;
            bool isValidInput = int.TryParse(Console.ReadLine(), out selectedScheduleIndex);

            if (!isValidInput || selectedScheduleIndex < 0 || selectedScheduleIndex > scheduleIndex - 1)
            {
                Console.WriteLine("Invalid input, please select a valid schedule number.");
                return;
            }

            if (selectedScheduleIndex == 0)
            {
                Console.WriteLine("No changes made, returning to the previous menu.");
                return;
            }

            
            scheduleNode = selectedLine.Schedules.GetFirst();
            for (int i = 1; i < selectedScheduleIndex; i++)
            {
                scheduleNode = scheduleNode.Next;
            }

            
            scheduleNode.Item.Closure = true;

            Console.WriteLine(
                $"Track from {scheduleNode.Item.FromStation.Name} to {scheduleNode.Item.ToStation.Name} closed!!!.");

            continueCloseTrackSection = false;
        }
    }

    public void OpenTrackSection()
    {
        continueOpenTrackSection = true;

        while (continueOpenTrackSection)
        {
            Console.WriteLine("\nSelect a line from the list below to open:");
            var currentNode = LineList.GetFirst();
            int index = 1;
            while (currentNode != null)
            {
                Console.WriteLine($"{index}) {currentNode.Item.Name}");
                currentNode = currentNode.Next;
                index++;
            }

            Console.WriteLine($"{index}) Go back");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int lineChoice) && lineChoice > 0 && lineChoice <= index)
            {
                if (lineChoice == index)
                {
                    continueOpenTrackSection = false;
                }
                else
                {
                    HandleOpenLineSelection(lineChoice);
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please select a valid option.");
            }
        }
    }

    private static void HandleOpenLineSelection(int lineChoice)
    {
        continueOpenTrackSection = true;
        var currentNode = LineList.GetFirst();
        int currentIndex = 1;
        while (currentNode != null && currentIndex < lineChoice)
        {
            currentNode = currentNode.Next;
            currentIndex++;
        }

        if (currentNode != null)
        {
            Line selectedLine = currentNode.Item;
            Console.WriteLine($"\nYou selected {selectedLine.Name}. Here are the closed tracks for this line:");

            Console.WriteLine($"\n{new string('=', 46)}");
            Console.Write($"{new string('=', 17)}");
            Console.Write($" Closed tracks on {selectedLine.Name} Line");
            Console.WriteLine($"{new string('=', 17)}");
            Console.WriteLine($"{new string('=', 46)}");

            // Print header for columns
            Console.WriteLine("{0,-20} {1,-20} {2,-15} {3,-20} {4,-20} {5,-20} {6,-20}",
                "From Station", "To Station", "Distance (km)",
                "Running Time(min)", "Am Peak(min)", "Inter Peak(min)", "Status");
            Console.WriteLine($"{new string('-', 140)}");

            // Display each schedule associated with the line
            var scheduleNode = selectedLine.Schedules.GetFirst();
            int scheduleIndex = 1;
            if (scheduleNode == null)
            {
                Console.WriteLine("No closed tracks on this line.");
            }
            else
            {
                bool foundClosure = false;
                while (scheduleNode != null)
                {
                    LineSchedule schedule = scheduleNode.Item;
                    if (schedule.Closure)
                    {
                        foundClosure = true;
                        Console.WriteLine("{0}) {1,-18} {2,-20} {3,-15} {4,-21} {5,-19} {6,-19} {7,-19}",
                            scheduleIndex,
                            schedule.FromStation.Name,
                            schedule.ToStation.Name,
                            schedule.Distance.ToString("N2"),
                            schedule.UnimpededRunningTime.ToString("N2"),
                            schedule.AmPeakRunningTime.ToString("N2"),
                            schedule.InterPeakRunningTime.ToString("N2"),
                            "Closed");
                    }

                    scheduleNode = scheduleNode.Next;
                    scheduleIndex++;
                }

                if (!foundClosure)
                {
                    Console.WriteLine("No closed tracks available for this line.");
                }
            }

            
            Console.WriteLine("\nEnter the number of the track to open, or type '0' to exit:");
            int selectedScheduleIndex;
            bool isValidInput = int.TryParse(Console.ReadLine(), out selectedScheduleIndex);

            if (!isValidInput || selectedScheduleIndex < 0 || selectedScheduleIndex > scheduleIndex - 1)
            {
                Console.WriteLine("Invalid input, please select a valid schedule number.");
                return;
            }

            if (selectedScheduleIndex == 0)
            {
                Console.WriteLine("No changes made, returning to the previous menu.");
                return;
            }

            
            scheduleNode = selectedLine.Schedules.GetFirst();
            for (int i = 1; i < selectedScheduleIndex; i++)
            {
                scheduleNode = scheduleNode.Next;
            }

            
            scheduleNode.Item.Closure = false;

            Console.WriteLine(
                $"Track from {scheduleNode.Item.FromStation.Name} to {scheduleNode.Item.ToStation.Name} opened!!!.");

            continueOpenTrackSection = false;
        }
    }

    public void PrintClosedTrackSections()
    {
        Console.WriteLine("\nAll Closed Tracks Across All Lines:");
        Console.WriteLine($"\n{new string('=', 80)}");
        Console.WriteLine("{0,-20} {1,-20} {2,-15} {3,-15} {4,-10}",
            "Line", "From Station", "To Station", "Distance (km)", "Status");
        Console.WriteLine($"{new string('-', 80)}");

        var lineNode = LineList.GetFirst();
        bool foundClosure = false;

        while (lineNode != null)
        {
            Line line = lineNode.Item;
            var scheduleNode = line.Schedules.GetFirst();

            while (scheduleNode != null)
            {
                LineSchedule schedule = scheduleNode.Item;
                if (schedule.Closure)
                {
                    foundClosure = true;
                    Console.WriteLine("{0,-20} {1,-20} {2,-15} {3,-15} {4,-10}",
                        line.Name,
                        schedule.FromStation.Name,
                        schedule.ToStation.Name,
                        schedule.Distance.ToString("N2"),
                        "Closed");
                }

                scheduleNode = scheduleNode.Next;
            }

            lineNode = lineNode.Next;
        }

        if (!foundClosure)
        {
            Console.WriteLine("No closed tracks currently.");
        }
    }

    public void PrintDelayedTrainSections()
    {
        Console.WriteLine("\nAll Delayed Schedules Across All Lines:");
        Console.WriteLine($"\n{new string('=', 100)}");
        Console.WriteLine("{0,-20} {1,-20} {2,-15} {3,-20} {4,-20} {5,-20} {6,-20}",
            "Line", "From Station", "To Station",
            "Running Time(min)", "Am Peak(min)", "Inter Peak(min)", "Delay(min)");
        Console.WriteLine($"{new string('-', 100)}");

        var lineNode = LineList.GetFirst();
        bool foundDelay = false;

        while (lineNode != null)
        {
            Line line = lineNode.Item;
            var scheduleNode = line.Schedules.GetFirst();
        
            while (scheduleNode != null)
            {
                LineSchedule schedule = scheduleNode.Item;
                if (schedule.Delay > 0)
                {
                    foundDelay = true;

                    schedule.UnimpededRunningTime -= schedule.Delay;
                    schedule.AmPeakRunningTime -= schedule.Delay;
                    schedule.InterPeakRunningTime -= schedule.Delay;
                    
                    Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20}",
                        line.Name,
                        schedule.FromStation.Name,
                        schedule.ToStation.Name,
                        schedule.UnimpededRunningTime.ToString("N2"),
                        schedule.AmPeakRunningTime.ToString("N2"),
                        schedule.InterPeakRunningTime.ToString("N2"),
                        schedule.Delay.ToString("N2"));
                }
                scheduleNode = scheduleNode.Next;
            }
        
            lineNode = lineNode.Next;
        }

        if (!foundDelay)
        {
            Console.WriteLine("No delayed schedules currently.");
        }
    }
}