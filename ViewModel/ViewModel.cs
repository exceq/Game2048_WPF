using Game2048.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace Game2048.ViewModel
{
    public class MainWindowViewModel
    {
        Model_Game game;

        public bool GameIsEnd => game.GameIsEnd;
        public int Sum => game.Sum;
        public int Size => game.Size;
        

        public MainWindowViewModel(int size)
        {
            game = new Model_Game(size);
            game.Start();
        }

        public void NextStep(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: game.MoveUp(); break;
                case Direction.Down: game.MoveDown(); break;
                case Direction.Left: game.MoveLeft(); break;
                case Direction.Right: game.MoveRight(); break;
            }
        }

        public void Start()
        {
            game.Start();
        }

        public int GetValueFromMap(int x, int y)
        {
            return game.GetValueFromMap(x, y);
        }
    }
}
