namespace TflScheduling;

using System.ComponentModel;
using TflScheduling.CustomCollections;
using TflScheduling.Enums;

public static class LineFactory
{
    
    
    
    public static Line _createBakeLooLineSchedulesNorthbound()
    {
        var bakerLooLine = new Line(LineName.Bakerloo, LineDirection.Northbound);

        var scheduleList = new CLinkedList<LineSchedule>();
        // Northbound schedules
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Embankment),
            new Station(StationName.CharingCross), bakerLooLine, 0.37, 0.97, 1.00, 1.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CharingCross),
            new Station(StationName.PiccadillyCircus), bakerLooLine, 0.55, 1.60, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.PiccadillyCircus),
            new Station(StationName.OxfordCircus), bakerLooLine, 0.97, 2.02, 2.19, 2.19));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.OxfordCircus),
            new Station(StationName.RegentsPark), bakerLooLine, 0.87, 1.72, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.RegentsPark),
            new Station(StationName.BakerStreet), bakerLooLine, 0.88, 1.65, 2.00, 2.00));

        bakerLooLine.Schedules = scheduleList;

        return bakerLooLine;
    }

    public static Line _createBakeLooLineSchedulesSouthbound()
    {
        var bakerLooLine = new Line(LineName.Bakerloo, LineDirection.Southbound);

        var scheduleList = new CLinkedList<LineSchedule>();
        // Southbound schedules
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.BakerStreet),
            new Station(StationName.RegentsPark), bakerLooLine, 0.88, 1.68, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.RegentsPark),
            new Station(StationName.OxfordCircus), bakerLooLine, 0.87, 1.85, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.OxfordCircus),
            new Station(StationName.PiccadillyCircus), bakerLooLine, 0.97, 1.95, 2.48, 2.48));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.PiccadillyCircus),
            new Station(StationName.CharingCross), bakerLooLine, 0.55, 1.35, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CharingCross),
            new Station(StationName.Embankment), bakerLooLine, 0.37, 0.95, 1.50, 1.50));

        bakerLooLine.Schedules = scheduleList;

        return bakerLooLine;
    }

    public static Line _createNorthernLineSchedulesNorthbound()
    {
        var northernLine = new Line(LineName.Northern, LineDirection.Northbound);

        var scheduleList = new CLinkedList<LineSchedule>();
        // Northbound schedules
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Embankment),
            new Station(StationName.CharingCross), northernLine, 0.27, 0.87, 1.26, 1.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CharingCross),
            new Station(StationName.LeicesterSquare), northernLine, 0.47, 1.17, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LeicesterSquare),
            new Station(StationName.TottenhamCourtRoad), northernLine, 0.40, 1.03, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.TottenhamCourtRoad),
            new Station(StationName.GoodgeStreet), northernLine, 0.63, 1.28, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.GoodgeStreet),
            new Station(StationName.WarrenStreet), northernLine, 0.47, 1.07, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Bank), new Station(StationName.Moorgate),
            northernLine, 0.82, 1.77, 2.50, 2.01));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Moorgate), new Station(StationName.OldStreet),
            northernLine, 0.69, 1.45, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.OldStreet), new Station(StationName.Angel),
            northernLine, 1.45, 2.43, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Angel), new Station(StationName.KingsCross),
            northernLine, 1.38, 2.15, 2.50, 2.50));

        northernLine.Schedules = scheduleList;

        return northernLine;
    }

    public static Line _createNorthernLineSchedulesSouthbound()
    {
        var northernLine = new Line(LineName.Northern, LineDirection.Southbound);

        var scheduleList = new CLinkedList<LineSchedule>();
        // Southbound schedules
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WarrenStreet),
            new Station(StationName.GoodgeStreet), northernLine, 0.47, 1.07, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.GoodgeStreet),
            new Station(StationName.TottenhamCourtRoad), northernLine, 0.63, 1.32, 1.73, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.TottenhamCourtRoad),
            new Station(StationName.LeicesterSquare), northernLine, 0.40, 0.98, 1.00, 1.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LeicesterSquare),
            new Station(StationName.CharingCross), northernLine, 0.47, 1.20, 1.99, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CharingCross),
            new Station(StationName.Embankment), northernLine, 0.27, 0.80, 1.00, 1.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.KingsCross), new Station(StationName.Angel),
            northernLine, 1.38, 2.18, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Angel), new Station(StationName.OldStreet),
            northernLine, 1.45, 2.87, 3.00, 3.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.OldStreet), new Station(StationName.Moorgate),
            northernLine, 0.69, 1.37, 2.00, 1.51));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Moorgate), new Station(StationName.Bank),
            northernLine, 0.82, 1.90, 2.00, 2.00));

        northernLine.Schedules = scheduleList;

        return northernLine;
    }

    public static Line _createVictoriaLineSchedulesNorthbound()
    {
        var victoriaLine = new Line(LineName.Victoria, LineDirection.Northbound);

        var scheduleList = new CLinkedList<LineSchedule>();
        // Northbound schedules
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Brixton), new Station(StationName.Stockwell),
            victoriaLine, 1.46, 2.18, 2.45, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Stockwell), new Station(StationName.Vauxhall),
            victoriaLine, 1.77, 2.23, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Vauxhall), new Station(StationName.Pimlico),
            victoriaLine, 0.80, 1.37, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Pimlico), new Station(StationName.Victoria),
            victoriaLine, 1.19, 2.18, 2.97, 2.51));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Victoria), new Station(StationName.GreenPark),
            victoriaLine, 1.09, 1.95, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.GreenPark),
            new Station(StationName.OxfordCircus), victoriaLine, 1.14, 1.97, 2.47, 2.02));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.OxfordCircus),
            new Station(StationName.WarrenStreet), victoriaLine, 0.90, 1.53, 2.48, 2.04));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WarrenStreet),
            new Station(StationName.Euston), victoriaLine, 0.76, 1.32, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Euston), new Station(StationName.KingsCross),
            victoriaLine, 0.74, 1.35, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.KingsCross),
            new Station(StationName.Highbury), victoriaLine, 2.45, 2.87, 3.00, 3.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Highbury),
            new Station(StationName.FinsburyPark), victoriaLine, 1.93, 2.40, 2.97, 2.56));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.FinsburyPark),
            new Station(StationName.SevenSisters), victoriaLine, 3.15, 4.25, 5.34, 5.76));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.SevenSisters),
            new Station(StationName.TottenhamHale), victoriaLine, 1.05, 1.60, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.TottenhamHale),
            new Station(StationName.BlackhorseRoad), victoriaLine, 1.37, 1.97, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.BlackhorseRoad),
            new Station(StationName.Walthamstow), victoriaLine, 1.45, 2.12, 2.04, 2.01));

        victoriaLine.Schedules = scheduleList;

        return victoriaLine;
    }
    
    public static Line _createVictoriaLineSchedulesSouthbound()
    {
        var victoriaLine = new Line(LineName.Victoria, LineDirection.Southbound);

        var scheduleList = new CLinkedList<LineSchedule>();
        // Southbound schedules
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Walthamstow),
            new Station(StationName.BlackhorseRoad), victoriaLine, 1.45, 2.12, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.BlackhorseRoad),
            new Station(StationName.TottenhamHale), victoriaLine, 1.37, 1.90, 2.36, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.TottenhamHale),
            new Station(StationName.SevenSisters), victoriaLine, 1.05, 2.00, 2.77, 3.28));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.SevenSisters),
            new Station(StationName.FinsburyPark), victoriaLine, 3.15, 3.77, 4.00, 4.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.FinsburyPark),
            new Station(StationName.Highbury), victoriaLine, 1.93, 2.90, 2.89, 2.55));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Highbury),
            new Station(StationName.KingsCross), victoriaLine, 2.45, 2.77, 3.50, 3.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.KingsCross), new Station(StationName.Euston),
            victoriaLine, 0.74, 1.32, 1.92, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Euston),
            new Station(StationName.WarrenStreet), victoriaLine, 0.76, 1.30, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WarrenStreet),
            new Station(StationName.OxfordCircus), victoriaLine, 0.90, 1.72, 2.44, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.OxfordCircus),
            new Station(StationName.GreenPark), victoriaLine, 1.14, 1.78, 2.00, 2.04));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.GreenPark), new Station(StationName.Victoria),
            victoriaLine, 1.09, 1.88, 2.50, 2.54));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Victoria), new Station(StationName.Pimlico),
            victoriaLine, 1.19, 1.83, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Pimlico), new Station(StationName.Vauxhall),
            victoriaLine, 0.80, 1.40, 1.50, 1.54));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Vauxhall), new Station(StationName.Stockwell),
            victoriaLine, 1.77, 2.30, 2.94, 2.52));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Stockwell), new Station(StationName.Brixton),
            victoriaLine, 1.46, 2.03, 2.50, 2.50));

        victoriaLine.Schedules = scheduleList;

        return victoriaLine;
    }

    public static Line _createPiccadillyLineSchedulesEastbound()
    {
        var piccadillyLine = new Line(LineName.Piccadilly, LineDirection.Eastbound);

        var scheduleList = new CLinkedList<LineSchedule>();
        // Eastbound schedules
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.SouthKensington),
            new Station(StationName.Knightsbridge), piccadillyLine, 1.22, 2.48, 3.00, 3.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Knightsbridge),
            new Station(StationName.HydeParkCorner), piccadillyLine, 0.51, 1.10, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.HydeParkCorner),
            new Station(StationName.GreenPark), piccadillyLine, 1.06, 1.73, 2.00, 2.02));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.GreenPark),
            new Station(StationName.PiccadillyCircus), piccadillyLine, 0.56, 1.10, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.PiccadillyCircus),
            new Station(StationName.LeicesterSquare), piccadillyLine, 0.50, 1.17, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LeicesterSquare),
            new Station(StationName.CoventGarden), piccadillyLine, 0.26, 0.77, 1.00, 1.01));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CoventGarden),
            new Station(StationName.Holborn), piccadillyLine, 0.60, 1.40, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Holborn),
            new Station(StationName.RussellSquare), piccadillyLine, 0.72, 1.55, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.RussellSquare),
            new Station(StationName.KingsCross), piccadillyLine, 0.92, 1.90, 2.47, 2.05));

        piccadillyLine.Schedules = scheduleList;

        return piccadillyLine;
    }
    
    public static Line _createPiccadillyLineSchedulesWestbound()
    {
        var piccadillyLine = new Line(LineName.Piccadilly, LineDirection.Westbound);

        var scheduleList = new CLinkedList<LineSchedule>();
        // Westbound schedules
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.KingsCross),
            new Station(StationName.RussellSquare), piccadillyLine, 0.92, 1.67, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.RussellSquare),
            new Station(StationName.Holborn), piccadillyLine, 0.72, 1.37, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Holborn),
            new Station(StationName.CoventGarden), piccadillyLine, 0.60, 1.53, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CoventGarden),
            new Station(StationName.LeicesterSquare), piccadillyLine, 0.26, 0.77, 1.00, 1.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LeicesterSquare),
            new Station(StationName.PiccadillyCircus), piccadillyLine, 0.50, 1.07, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.PiccadillyCircus),
            new Station(StationName.GreenPark), piccadillyLine, 0.56, 1.18, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.GreenPark),
            new Station(StationName.HydeParkCorner), piccadillyLine, 1.06, 1.73, 2.48, 2.02));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.HydeParkCorner),
            new Station(StationName.Knightsbridge), piccadillyLine, 0.51, 1.12, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Knightsbridge),
            new Station(StationName.SouthKensington), piccadillyLine, 1.22, 2.23, 2.50, 2.50));

        piccadillyLine.Schedules = scheduleList;

        return piccadillyLine;
    }

    public static Line _createCentralLineSchedulesEastbound()
    {
        var centralLine = new Line(LineName.Central, LineDirection.Eastbound);

        var scheduleList = new CLinkedList<LineSchedule>();
        // Eastbound schedules
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.NottingHillGate),
            new Station(StationName.QueensWay), centralLine, 0.69, 1.17, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.QueensWay),
            new Station(StationName.LancasterGate), centralLine, 0.90, 1.35, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LancasterGate),
            new Station(StationName.MarbleArch), centralLine, 1.21, 1.92, 2.71, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.MarbleArch),
            new Station(StationName.BondStreet), centralLine, 0.55, 1.00, 1.25, 1.25));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.BondStreet),
            new Station(StationName.OxfordCircus), centralLine, 0.66, 1.10, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.OxfordCircus),
            new Station(StationName.TottenhamCourtRoad), centralLine, 0.58, 0.98, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.TottenhamCourtRoad),
            new Station(StationName.Holborn), centralLine, 0.89, 1.63, 2.21, 2.01));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Holborn),
            new Station(StationName.ChanceryLane), centralLine, 0.40, 0.87, 1.00, 1.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.ChanceryLane),
            new Station(StationName.StPauls), centralLine, 1.03, 1.52, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.StPauls), new Station(StationName.Bank),
            centralLine, 0.74, 1.62, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Bank),
            new Station(StationName.LiverpoolStreet), centralLine, 0.74, 1.62, 2.25, 2.25));

        centralLine.Schedules = scheduleList;

        return centralLine;
    }
    
    public static Line _createCentralLineSchedulesWestbound()
    {
        var centralLine = new Line(LineName.Central, LineDirection.Westbound);

        var scheduleList = new CLinkedList<LineSchedule>();
        // Westbound schedules
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LiverpoolStreet),
            new Station(StationName.Bank), centralLine, 0.74, 1.65, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Bank), new Station(StationName.StPauls),
            centralLine, 0.74, 1.63, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.StPauls),
            new Station(StationName.ChanceryLane), centralLine, 1.03, 1.52, 1.75, 1.75));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.ChanceryLane),
            new Station(StationName.Holborn), centralLine, 0.40, 0.85, 1.46, 1.25));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Holborn),
            new Station(StationName.TottenhamCourtRoad), centralLine, 0.89, 1.38, 1.75, 1.75));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.TottenhamCourtRoad),
            new Station(StationName.OxfordCircus), centralLine, 0.58, 1.02, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.OxfordCircus),
            new Station(StationName.BondStreet), centralLine, 0.66, 1.03, 1.25, 1.25));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.BondStreet),
            new Station(StationName.MarbleArch), centralLine, 0.55, 1.02, 1.66, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.MarbleArch),
            new Station(StationName.LancasterGate), centralLine, 1.21, 1.62, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LancasterGate),
            new Station(StationName.QueensWay), centralLine, 0.90, 1.65, 1.75, 1.75));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.QueensWay),
            new Station(StationName.NottingHillGate), centralLine, 0.69, 1.18, 1.50, 1.50));

        centralLine.Schedules = scheduleList;

        return centralLine;
    }

    public static Line _createJubileeLineSchedulesEastbound()
    {
        var jubileeLine = new Line(LineName.Jubilee, LineDirection.Eastbound);

        var scheduleList = new CLinkedList<LineSchedule>();
        // Eastbound schedules for the Jubilee line
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Stanmore),
            new Station(StationName.CanonsPark), jubileeLine, 1.27, 1.95, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CanonsPark),
            new Station(StationName.Queensbury), jubileeLine, 1.71, 1.93, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Queensbury),
            new Station(StationName.Kingsbury), jubileeLine, 1.33, 1.72, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Kingsbury),
            new Station(StationName.WembleyPark), jubileeLine, 2.85, 3.47, 4.73, 4.56));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WembleyPark),
            new Station(StationName.Neasden), jubileeLine, 2.28, 2.60, 3.03, 3.01));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Neasden), new Station(StationName.DollisHill),
            jubileeLine, 0.85, 1.43, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.DollisHill),
            new Station(StationName.WillesdenGreen), jubileeLine, 1.21, 1.80, 2.11, 2.14));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WillesdenGreen),
            new Station(StationName.Kilburn), jubileeLine, 1.19, 1.68, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Kilburn),
            new Station(StationName.WestHampstead), jubileeLine, 1.09, 1.63, 2.50, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WestHampstead),
            new Station(StationName.FinchleyRoad), jubileeLine, 0.61, 1.25, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.FinchleyRoad),
            new Station(StationName.SwissCottage), jubileeLine, 0.61, 1.18, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.SwissCottage),
            new Station(StationName.StJohnsWood), jubileeLine, 0.92, 1.52, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.StJohnsWood),
            new Station(StationName.BakerStreet), jubileeLine, 2.06, 2.77, 3.50, 3.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.BakerStreet),
            new Station(StationName.BondStreet), jubileeLine, 1.66, 2.10, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.BondStreet),
            new Station(StationName.GreenPark), jubileeLine, 1.37, 1.78, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.GreenPark),
            new Station(StationName.Westminster), jubileeLine, 1.33, 1.87, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Westminster),
            new Station(StationName.Waterloo), jubileeLine, 0.96, 1.38, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Waterloo), new Station(StationName.Southwark),
            jubileeLine, 0.44, 1.02, 1.00, 1.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Southwark),
            new Station(StationName.LondonBridge), jubileeLine, 1.25, 1.65, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LondonBridge),
            new Station(StationName.Bermondsey), jubileeLine, 1.93, 2.25, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Bermondsey),
            new Station(StationName.CanadaWater), jubileeLine, 1.06, 1.48, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CanadaWater),
            new Station(StationName.CanaryWharf), jubileeLine, 2.41, 2.50, 3.00, 3.02));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CanaryWharf),
            new Station(StationName.NorthGreenwich), jubileeLine, 1.71, 2.23, 3.19, 3.49));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.NorthGreenwich),
            new Station(StationName.CanningTown), jubileeLine, 1.71, 2.15, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CanningTown),
            new Station(StationName.WestHam), jubileeLine, 1.58, 2.15, 2.93, 2.58));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WestHam), new Station(StationName.Stratford),
            jubileeLine, 1.54, 3.15, 4.90, 3.77));

        jubileeLine.Schedules = scheduleList;

        return jubileeLine;
    }

    public static Line _createJubileeLineSchedulesWestbound()
    {
        var jubileeLine = new Line(LineName.Jubilee, LineDirection.Westbound);

        var scheduleList = new CLinkedList<LineSchedule>();

        // Westbound schedules
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Stratford), new Station(StationName.WestHam),
            jubileeLine, 1.54, 2.42, 3.50, 3.12));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WestHam),
            new Station(StationName.CanningTown), jubileeLine, 1.58, 2.13, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CanningTown),
            new Station(StationName.NorthGreenwich), jubileeLine, 1.71, 2.17, 3.07, 2.99));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.NorthGreenwich),
            new Station(StationName.CanaryWharf), jubileeLine, 1.71, 1.98, 2.55, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CanaryWharf),
            new Station(StationName.CanadaWater), jubileeLine, 2.41, 2.63, 3.00, 3.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CanadaWater),
            new Station(StationName.Bermondsey), jubileeLine, 1.06, 1.52, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Bermondsey),
            new Station(StationName.LondonBridge), jubileeLine, 1.93, 2.17, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LondonBridge),
            new Station(StationName.Southwark), jubileeLine, 1.25, 1.77, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Southwark), new Station(StationName.Waterloo),
            jubileeLine, 0.44, 0.97, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Waterloo),
            new Station(StationName.Westminster), jubileeLine, 0.96, 1.43, 2.44, 2.01));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Westminster),
            new Station(StationName.GreenPark), jubileeLine, 1.33, 1.82, 2.00, 2.01));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.GreenPark),
            new Station(StationName.BondStreet), jubileeLine, 1.37, 1.82, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.BondStreet),
            new Station(StationName.BakerStreet), jubileeLine, 1.66, 2.28, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.BakerStreet),
            new Station(StationName.StJohnsWood), jubileeLine, 2.06, 2.85, 3.50, 3.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.StJohnsWood),
            new Station(StationName.SwissCottage), jubileeLine, 0.92, 1.52, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.SwissCottage),
            new Station(StationName.FinchleyRoad), jubileeLine, 0.61, 1.18, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.FinchleyRoad),
            new Station(StationName.WestHampstead), jubileeLine, 0.61, 1.20, 1.50, 1.51));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WestHampstead),
            new Station(StationName.Kilburn), jubileeLine, 1.09, 1.55, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Kilburn),
            new Station(StationName.WillesdenGreen), jubileeLine, 1.19, 2.07, 2.32, 2.22));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WillesdenGreen),
            new Station(StationName.DollisHill), jubileeLine, 1.21, 1.67, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.DollisHill), new Station(StationName.Neasden),
            jubileeLine, 0.85, 1.38, 1.62, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Neasden),
            new Station(StationName.WembleyPark), jubileeLine, 2.28, 2.65, 3.76, 3.53));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WembleyPark),
            new Station(StationName.Kingsbury), jubileeLine, 2.85, 3.47, 4.00, 4.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Kingsbury),
            new Station(StationName.Queensbury), jubileeLine, 1.33, 1.85, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Queensbury),
            new Station(StationName.CanonsPark), jubileeLine, 1.71, 2.23, 2.50, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CanonsPark),
            new Station(StationName.Stanmore), jubileeLine, 1.27, 2.87, 3.24, 3.09));

        jubileeLine.Schedules = scheduleList;

        return jubileeLine;
    }

    public static Line _createCircleLineSchedulesInner()
    {
        var circleLine = new Line(LineName.Circle, LineDirection.Inner);

        var scheduleList = new CLinkedList<LineSchedule>();


        //  Inner
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.EdgwareRoad),
            new Station(StationName.PaddingtonCircle), circleLine, 0.82, 1.85, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.PaddingtonCircle),
            new Station(StationName.Bayswater), circleLine, 0.98, 1.65, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Bayswater),
            new Station(StationName.NottingHillGate), circleLine, 0.79, 1.47, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.NottingHillGate),
            new Station(StationName.HighStreetKensington), circleLine, 0.93, 1.58, 3.57, 3.36));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.HighStreetKensington),
            new Station(StationName.GloucesterRoad), circleLine, 0.93, 1.80, 2.66, 2.90));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.GloucesterRoad),
            new Station(StationName.SouthKensington), circleLine, 0.74, 1.43, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.SouthKensington),
            new Station(StationName.SloaneSquare), circleLine, 1.22, 1.98, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.SloaneSquare),
            new Station(StationName.Victoria), circleLine, 1.05, 1.80, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Victoria),
            new Station(StationName.StJamesPark), circleLine, 0.72, 1.42, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.StJamesPark),
            new Station(StationName.Westminster), circleLine, 0.76, 1.50, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Westminster),
            new Station(StationName.Embankment), circleLine, 0.69, 1.37, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Embankment), new Station(StationName.Temple),
            circleLine, 0.71, 1.37, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Temple), new Station(StationName.Blackfriars),
            circleLine, 0.76, 1.40, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Blackfriars),
            new Station(StationName.MansionHouse), circleLine, 0.61, 1.52, 1.95, 1.52));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.MansionHouse),
            new Station(StationName.CannonStreet), circleLine, 0.31, 0.98, 1.00, 1.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CannonStreet),
            new Station(StationName.Monument), circleLine, 0.34, 0.97, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Monument), new Station(StationName.TowerHill),
            circleLine, 0.68, 1.80, 2.00, 2.07));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.TowerHill), new Station(StationName.Aldgate),
            circleLine, 0.50, 1.30, 4.05, 3.18));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Aldgate),
            new Station(StationName.LiverpoolStreet), circleLine, 0.61, 1.75, 2.00, 2.42));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LiverpoolStreet),
            new Station(StationName.Moorgate), circleLine, 0.51, 1.32, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Moorgate), new Station(StationName.Barbican),
            circleLine, 0.64, 1.38, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Barbican),
            new Station(StationName.Farringdon), circleLine, 0.51, 1.20, 1.92, 1.51));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Farringdon),
            new Station(StationName.KingsCrossStPancras), circleLine, 1.85, 3.12, 3.50, 3.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.KingsCrossStPancras),
            new Station(StationName.EustonSquare), circleLine, 0.85, 1.65, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.EustonSquare),
            new Station(StationName.GreatPortlandStreet), circleLine, 0.61, 1.30, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.GreatPortlandStreet),
            new Station(StationName.BakerStreetCircle), circleLine, 0.92, 1.57, 2.90, 2.07));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.BakerStreet),
            new Station(StationName.EdgwareRoad), circleLine, 0.72, 1.88, 3.60, 3.08));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.EdgwareRoad),
            new Station(StationName.PaddingtonHC), circleLine, 0.93, 2.08, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.PaddingtonHC),
            new Station(StationName.RoyalOak), circleLine, 0.64, 1.33, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.RoyalOak),
            new Station(StationName.WestbournePark), circleLine, 0.98, 1.72, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WestbournePark),
            new Station(StationName.LadbrokeGrove), circleLine, 0.79, 1.48, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LadbrokeGrove),
            new Station(StationName.LatimerRoad), circleLine, 0.66, 1.28, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LatimerRoad),
            new Station(StationName.WoodLane), circleLine, 0.54, 0.0, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WoodLane),
            new Station(StationName.ShepherdsBushMarket), circleLine, 0.47, 0.0, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.ShepherdsBushMarket),
            new Station(StationName.GoldhawkRoad), circleLine, 0.51, 1.15, 1.00, 1.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.GoldhawkRoad),
            new Station(StationName.HammersmithHC), circleLine, 0.82, 2.43, 3.07, 3.03));

        circleLine.Schedules = scheduleList;

        return circleLine;
    }
    
    public static Line _createCircleLineSchedulesOuter()
    {
        var circleLine = new Line(LineName.Circle, LineDirection.Outer);

        var scheduleList = new CLinkedList<LineSchedule>();
        //  Outer
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.HammersmithHC),
            new Station(StationName.GoldhawkRoad), circleLine, 0.82, 2.05, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.GoldhawkRoad),
            new Station(StationName.ShepherdsBushMarket), circleLine, 0.51, 1.15, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.ShepherdsBushMarket),
            new Station(StationName.WoodLane), circleLine, 0.47, 0.0, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WoodLane),
            new Station(StationName.LatimerRoad), circleLine, 0.54, 0.0, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LatimerRoad),
            new Station(StationName.LadbrokeGrove), circleLine, 0.66, 1.37, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LadbrokeGrove),
            new Station(StationName.WestbournePark), circleLine, 0.79, 1.48, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.WestbournePark),
            new Station(StationName.RoyalOak), circleLine, 0.98, 1.78, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.RoyalOak),
            new Station(StationName.PaddingtonHC), circleLine, 0.64, 1.52, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.PaddingtonHC),
            new Station(StationName.EdgwareRoad), circleLine, 0.93, 2.33, 3.71, 3.72));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.EdgwareRoad),
            new Station(StationName.BakerStreet), circleLine, 0.72, 1.47, 2.84, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.BakerStreet),
            new Station(StationName.GreatPortlandStreet), circleLine, 0.92, 1.90, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.GreatPortlandStreet),
            new Station(StationName.EustonSquare), circleLine, 0.61, 1.25, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.EustonSquare),
            new Station(StationName.KingsCrossStPancras), circleLine, 0.85, 1.75, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.KingsCrossStPancras),
            new Station(StationName.Farringdon), circleLine, 1.85, 2.98, 3.50, 3.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Farringdon),
            new Station(StationName.Barbican), circleLine, 0.51, 1.22, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Barbican), new Station(StationName.Moorgate),
            circleLine, 0.64, 1.32, 1.53, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Moorgate),
            new Station(StationName.LiverpoolStreet), circleLine, 0.51, 1.18, 1.95, 1.51));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.LiverpoolStreet),
            new Station(StationName.Aldgate), circleLine, 0.61, 2.18, 2.55, 2.51));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Aldgate), new Station(StationName.TowerHill),
            circleLine, 0.50, 1.37, 2.02, 2.10));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.TowerHill), new Station(StationName.Monument),
            circleLine, 0.68, 1.48, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Monument),
            new Station(StationName.CannonStreet), circleLine, 0.34, 0.88, 1.00, 1.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.CannonStreet),
            new Station(StationName.MansionHouse), circleLine, 0.31, 0.93, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.MansionHouse),
            new Station(StationName.Blackfriars), circleLine, 0.61, 1.22, 1.52, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Blackfriars), new Station(StationName.Temple),
            circleLine, 0.76, 1.37, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Temple), new Station(StationName.Embankment),
            circleLine, 0.71, 1.43, 2.00, 2.01));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Embankment),
            new Station(StationName.Westminster), circleLine, 0.69, 1.40, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Westminster),
            new Station(StationName.StJamesPark), circleLine, 0.76, 1.52, 1.50, 1.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.StJamesPark),
            new Station(StationName.Victoria), circleLine, 0.72, 1.33, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Victoria),
            new Station(StationName.SloaneSquare), circleLine, 1.05, 1.75, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.SloaneSquare),
            new Station(StationName.SouthKensington), circleLine, 1.22, 2.00, 2.98, 2.50));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.SouthKensington),
            new Station(StationName.GloucesterRoad), circleLine, 0.74, 1.48, 2.02, 2.54));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.GloucesterRoad),
            new Station(StationName.HighStreetKensington), circleLine, 0.93, 2.23, 3.98, 2.92));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.HighStreetKensington),
            new Station(StationName.NottingHillGate), circleLine, 0.93, 1.68, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.NottingHillGate),
            new Station(StationName.Bayswater), circleLine, 0.79, 1.77, 2.00, 2.00));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.Bayswater),
            new Station(StationName.PaddingtonCircle), circleLine, 0.98, 1.63, 2.45, 2.01));
        scheduleList.InsertAtEnd(new LineSchedule(new Station(StationName.PaddingtonCircle),
            new Station(StationName.EdgwareRoad), circleLine, 0.82, 2.15, 3.71, 3.72));

        circleLine.Schedules = scheduleList;

        return circleLine;
    }


}