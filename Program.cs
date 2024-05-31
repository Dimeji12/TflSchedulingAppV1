// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using TflScheduling.CustomCollections;
using TflScheduling.Enums;
using TflScheduling.Management;

namespace TflScheduling;

public class Program
{
    private static bool _displayCustomerMenuExit = false;

    private static bool _displayEngineerMenuExit = false;

    private static CLinkedList<Line> _lineList = new CLinkedList<Line>();

    private static EngineerOperation _engineerOperation;
    
    private static CustomerOperation _customerOperation;

    public static void Main()
    {
        var bakerLooInCircleNorthbound = LineFactory._createBakeLooLineSchedulesNorthbound();

        var bakerLooInCircleSouthbound = LineFactory._createBakeLooLineSchedulesSouthbound();

        var northernInCircleNorthbound = LineFactory._createNorthernLineSchedulesNorthbound();

        var northernInCircleSouthbound = LineFactory._createNorthernLineSchedulesSouthbound();

        var victoriaLineNorthbound = LineFactory._createVictoriaLineSchedulesNorthbound();

        var victoriaLineSouthbound = LineFactory._createVictoriaLineSchedulesSouthbound();

        var piccadillyInCircleEastbound = LineFactory._createPiccadillyLineSchedulesEastbound();

        var piccadillyInCircleWestbound = LineFactory._createPiccadillyLineSchedulesWestbound();

        var centralInCircleEastbound = LineFactory._createCentralLineSchedulesEastbound();

        var centralInCircleWestbound = LineFactory._createCentralLineSchedulesWestbound();

        var jubileeLineEastbound = LineFactory._createJubileeLineSchedulesEastbound();

        var jubileeLineWestbound = LineFactory._createJubileeLineSchedulesWestbound();

        var circleLineInner = LineFactory._createCircleLineSchedulesInner();

        var circleLineOuter = LineFactory._createCircleLineSchedulesOuter();

        _lineList.InsertAtEnd(bakerLooInCircleNorthbound);
        _lineList.InsertAtEnd(bakerLooInCircleSouthbound);
        _lineList.InsertAtEnd(northernInCircleNorthbound);
        _lineList.InsertAtEnd(northernInCircleSouthbound);
        _lineList.InsertAtEnd(victoriaLineNorthbound);
        _lineList.InsertAtEnd(victoriaLineSouthbound);
        _lineList.InsertAtEnd(piccadillyInCircleEastbound);
        _lineList.InsertAtEnd(piccadillyInCircleWestbound);
        _lineList.InsertAtEnd(centralInCircleEastbound);
        _lineList.InsertAtEnd(centralInCircleWestbound);
        _lineList.InsertAtEnd(jubileeLineEastbound);
        _lineList.InsertAtEnd(jubileeLineWestbound);
        _lineList.InsertAtEnd(circleLineInner);
        _lineList.InsertAtEnd(circleLineOuter);

        _engineerOperation = new EngineerOperation(_lineList);
        _customerOperation = new CustomerOperation(_lineList);
  
        Console.WriteLine("\n");
        Console.Write($"{new string('=', 30)}");
        Console.Write("Welcome to Transport For London");
        Console.Write($"{new string('=', 30)}");

        DisplayCustomerMenu();
    }

    private static LineSchedule? FindLineSchedule(LineName lineName, StationName stationName)
    {
        var currentNode = _lineList.GetFirst();
        while (currentNode != null)
        {
            Line line = currentNode.Item;
            if (line.Name == lineName && line.Schedules != null)
            {
                var scheduleNode = line.Schedules.GetFirst();
                if (scheduleNode != null && scheduleNode.Item.FromStation.Name == stationName)
                {
                    return scheduleNode.Item;
                }
            }

            currentNode = currentNode.Next;
        }

        return null;
    }

    private static void DisplayCustomerMenu()
    {
        while (!_displayCustomerMenuExit)
        {
            //List the menu
            Console.WriteLine($"\n\n{new string('=', 46)}");
            Console.Write($"{new string('=', 15)}");
            Console.Write(" Customer menu: ");
            Console.WriteLine($"{new string('=', 15)}");
            Console.WriteLine($"{new string('=', 46)}");

            Console.WriteLine("Select an option:");
            Console.WriteLine("a) Find a route");
            Console.WriteLine("b) Display tube or overground station info");
            Console.WriteLine("\ns) Switch to Engineer Menu");
            Console.WriteLine("x) Exit App");

            //Get user input
            Console.Write("Enter your choice: ");
            char choice = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            switch (choice)
            {
                case 'a':
                    _customerOperation.FindRoute();
                    break;
                case 'b':
                    _customerOperation.DisplayLineInfo();
                    break;
                case 's':
                    DisplayEngineerMenu();
                    break;
                case 'x':
                    Console.WriteLine("Exiting the application...");
                    ExitApp();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void DisplayEngineerMenu()
    {
        while (!_displayEngineerMenuExit)
        {
            //List the menu
            Console.WriteLine($"\n\n{new string('=', 46)}");
            Console.Write($"{new string('=', 15)}");
            Console.Write(" Engineer menu: ");
            Console.WriteLine($"{new string('=', 15)}");
            Console.WriteLine($"{new string('=', 46)}");

            Console.WriteLine("Select an option:");
            Console.WriteLine("a) Add journey time delay");
            Console.WriteLine("b) Remove journey time delay");
            Console.WriteLine("c) Close track section");
            Console.WriteLine("d) Open track section");
            Console.WriteLine("e) Print list of closed track sections");
            Console.WriteLine("f) Print list of journey time delays");
            Console.WriteLine("\ns) Switch to Customer Menu");
            Console.WriteLine("x) Exit App");

            //Get user input
            Console.Write("Enter your choice: ");
            char choice = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            switch (choice)
            {
                case 'a':
                    _engineerOperation.AddTimeDelayOnTrack();
                    break;
                case 'b':
                    _engineerOperation.RemoveTimeDelayOnTrack();
                    break;
                case 'c':
                    _engineerOperation.CloseTrackSection();
                    break;
                case 'd':
                    _engineerOperation.OpenTrackSection();
                    break;
                case 'e':
                    _engineerOperation.PrintClosedTrackSections();
                    break;
                case 'f':
                    _engineerOperation.PrintDelayedTrainSections();
                    break;
                case 's':
                    Console.WriteLine("Option 'Transactions' selected");
                    DisplayCustomerMenu();
                    break;
                case 'x':
                    Console.WriteLine("Exiting the application...");
                    ExitApp();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }


    private static void ExitApp()
    {
        _displayCustomerMenuExit = true;
        _displayEngineerMenuExit = true;
    }

    public static string GetDescription(Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
        return attribute == null ? value.ToString() : attribute.Description;
    }
}