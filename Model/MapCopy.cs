namespace Game2048.Model
{
    class MapCopy
    {
        public int Sum { get; private set; }
        public int [,] Map { get; private set; }
        public bool GameIsEnd { get; private set; }
        public int CountZero { get; private set; }
        public bool WasMoveTo { get; private set; }

        public MapCopy(int sum, int[,] map, bool gameIsEnd, int countZero, bool wasMoveTo)
        {
            Sum = sum;
            Map = map;
            GameIsEnd = gameIsEnd;
            CountZero = countZero;
            WasMoveTo = wasMoveTo;
        }
    }
}
