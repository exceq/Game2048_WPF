using System;
using System.Collections.Generic;

namespace Game2048.Model
{
    public class Model_Game : PropertyChangedClass
    {
        bool gameIsEnd = false;
        int sum = 0;
        int countZero = 0;
        int undoCount = 0;
        bool wasMoveTo = false;

        Random rnd = new Random();
        Map map;
        LinkedList<MapCopy> stack;

        public int Size { get { return map.Size; } set { Size = value; } }

        public bool GameIsEnd { get { return GameIsOver(); } private set { gameIsEnd = value; OnPropertyChanged(); } }

        public int Sum { get { return sum; } private set { sum = value; OnPropertyChanged(); } }

        public int UndoCount { get { return undoCount; } private set { undoCount = value; OnPropertyChanged(); } } 

        public Model_Game(int size)
        {
            map = new Map(size);
            stack = new LinkedList<MapCopy>();
            countZero = Size * Size;
            Start();
        }

        public void Start()
        {            
            for (int x = 0; x < Size; x++)
                for (int y = 0; y < Size; y++)
                    map.SetValue(x, y, 0);
            AddRandomValue();
            AddRandomValue();
        }

        void AddRandomValue()
        {
            if (gameIsEnd) return;
            while (true)                                //Метод будет подбирать число, пока не найдет. 
            {                                           //Без while рандомная ячейка иногда встает на другую и в общем итоге
                int x = rnd.Next(0, Size);              //метод не срабатывает, потому что новое значение не добавилось на поле.
                int y = rnd.Next(0, Size);
                if (map.GetValue(x, y) == 0)
                {
                    map.SetValue(x, y, (rnd.NextDouble() < 0.1) ? 4 : 2);
                    countZero--;
                    break;
                }
            }
            gameIsEnd = GameIsOver();
            return;
        }

        void MoveTo(int x, int y, int dx, int dy)
        {
            if (map.GetValue(x, y) > 0)           
                while (map.GetValue(x + dx, y + dy) == 0)
                {
                    map.SetValue(x + dx, y + dy, map.GetValue(x, y));
                    map.SetValue(x, y, 0);
                    x += dx;
                    y += dy;
                    wasMoveTo = true;
                }            
        }

        void Add(int x, int y, int dx, int dy)
        {
            if (map.GetValue(x, y) > 0)
                if (map.GetValue(x + dx, y + dy) == map.GetValue(x, y))
                {
                    int number = map.GetValue(x, y);
                    map.SetValue(x + dx, y + dy, number * 2);
                    Sum += number * 2;
                    while (map.GetValue(x - dx, y - dy) > 0)
                    {                       
                        map.SetValue(x, y, map.GetValue(x - dx, y - dy));
                        x -= dx;
                        y -= dy;
                    }
                    wasMoveTo = true;
                    countZero++;
                    map.SetValue(x, y, 0);
                }
        }

        void MoveUp()
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 1; y < Size; y++)
                    MoveTo(x, y, 0, -1);
                for (int y = 1; y < Size; y++)
                    Add(x, y, 0, -1);
            }
        }

        void MoveDown()
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = Size - 2; y >= 0; y--)
                    MoveTo(x, y, 0, 1);
                for (int y = Size - 2; y >= 0; y--)
                    Add(x, y, 0, +1);
            }
        }

        void MoveLeft()
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = 1; x < Size; x++)
                    MoveTo(x, y, -1, 0);
                for (int x = 1; x < Size; x++)
                    Add(x, y, -1, 0);
            }
        }

        void MoveRight()
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = Size - 2; x >= 0; x--)
                    MoveTo(x, y, +1, 0);
                for (int x = Size - 2; x >= 0; x--)
                    Add(x, y, +1, 0);
            }            
        }

        public void MakeMove(Direction direction)
        {
            if (wasMoveTo) AddMapInStack();
            wasMoveTo = false;
            switch (direction)
            {
                case Direction.Up:      MoveUp();       break;
                case Direction.Down:    MoveDown();     break;
                case Direction.Left:    MoveLeft();     break;
                case Direction.Right:   MoveRight();    break;
            }
            if (wasMoveTo)
                AddRandomValue();           
        }

        void AddMapInStack()
        {
            int[,] kart = new int[Size, Size];
            if (stack.Count >= 20)
                stack.RemoveFirst();
            for (int x = 0; x < Size; x++)
                for (int y = 0; y < Size; y++)
                    kart[x, y] = GetValueFromMap(x, y);
            stack.AddLast(new MapCopy(Sum, kart, GameIsEnd, countZero, wasMoveTo));
            UndoCount = stack.Count;
        }

        public void Undo()
        {
            if (stack.Count > 0)
            {
                var mapCopy = stack.Last.Value;
                stack.RemoveLast();
                Sum -= Sum - mapCopy.Sum;
                GameIsEnd = mapCopy.GameIsEnd;
                countZero = mapCopy.CountZero;
                wasMoveTo = mapCopy.WasMoveTo;
                for (int x = 0; x < Size; x++)
                    for (int y = 0; y < Size; y++)
                        map.SetValue(x, y, mapCopy.Map[x, y]);
            }
            UndoCount = stack.Count;
        }

        private bool GameIsOver()
        {
            if (gameIsEnd)
                return gameIsEnd;
            if (countZero > 0)
                return false;
            for (int x = 0; x < Size; x++)
                for (int y = 0; y < Size; y++)
                    if (map.GetValue(x, y) == map.GetValue(x + 1, y) ||
                        map.GetValue(x, y) == map.GetValue(x, y + 1))
                        return false;
            GameIsEnd = true;
            return gameIsEnd;
        }

        public int GetValueFromMap(int x, int y)
        {
            return map.GetValue(x, y);
        }
    }
}
