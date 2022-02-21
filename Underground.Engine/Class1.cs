namespace Underground.Engine
{
    public class Station
    {
        public string Name { get; }
        public string[] Lines { get; }

        public Station(string name, string[] lines)
        {
            Name = name;
            Lines = lines;
        }

        public string[] CanChangeTo(string currentLine)
        {
            return Lines.Except(new [] { currentLine }).ToArray();
        }

        //TODO : Station should return next x stations that is available, by direction
    }

    public enum LineDirection
    {
        EastWest,
        NorthSouth
    }

    public class Line
    {
        public string Name { get; }
        public Station[] Stations { get; }
        public LineDirection Direction { get; }

        public Line(Station[] stations, string name, LineDirection direction)
        {
            Stations = stations;
            Name = name;
            Direction = direction;
        }
    }

    public enum DirectionOfTravel
    {
        Stationary,
        North,
        East,
        South,
        West
    }

    public class Traveller
    {
        public Line CurrentLine { get; private set; }
        public Station CurrentStation { get; private set; }
        public Station? NextStation { get; private set; }
        public Station? PreviousStation { get; private set; }

        public void StartJourney(Station station, Line line)
        {
            CurrentLine = line;
            CurrentStation = station;
        }

        public void ChangeLines(Line newLine)
        {
            var availableLines = CurrentStation.CanChangeTo(CurrentLine.Name);
            if (!availableLines.Contains(newLine.Name))
            {
                throw new ArgumentException("Cannot change to that line from this station");
            }

            CurrentLine = newLine;
        }
    }
}