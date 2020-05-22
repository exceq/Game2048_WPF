using Game2048.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.IO;
using System.Text;
using System;

namespace Game2048.ViewModel
{
    public class MainWindowViewModel : PropertyChangedClass
    {
        Model_Game game;
        //List<Cell> cells = new List<Cell>();

        //private IEnumerable<Cell> _cells;
        public List<Cell> Cells { get; private set; }

        public bool GameIsEnd => game.GameIsEnd; 
        public int Sum => game.Sum; 
        public int Size => game.Size;


        public MainWindowViewModel()
        {
            Start(4);
        }

        public MainWindowViewModel(int size)
        {
            Start(size);
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
            int i = 0;
            for (int y = 0; y < game.Size; y++)
                for (int x = 0; x < game.Size; x++)
                    {
                        Cells[i++].Value = GetValueFromMap(x, y);
                    }
            Cells = Cells;
        }

        public void Start(int size)
        {
            Cells = new List<Cell>();
            if (game != null) game.PropertyChanged -= Model_PropertyChanged;
            game = new Model_Game(size);
            game.Start();
            game.PropertyChanged += Model_PropertyChanged;
            for (int x = 0; x < game.Size; x++)
                for (int y = 0; y < game.Size; y++)
                    Cells.Add(new Cell { Value = GetValueFromMap(x, y) });
            Cells = Cells;
        }

        public int GetValueFromMap(int x, int y)
        {
            return game.GetValueFromMap(x, y);
        }


        List<string> modelProperties = new List<string>() { nameof(Model_Game.GameIsEnd), nameof(Model_Game.Sum) };

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;
            if (string.IsNullOrEmpty(propertyName) || modelProperties.IndexOf(propertyName) >= 0)
                OnPropertyChanged(propertyName);
        }
    }
}
