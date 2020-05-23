using Game2048.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.IO;
using System.Text;
using System;
using System.Threading;

namespace Game2048.ViewModel
{
    public class MainWindowViewModel : PropertyChangedClass
    {
        Model_Game game;

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

        public void Start(int size)
        {
            if (game != null) game.PropertyChanged -= Model_PropertyChanged;
            game = new Model_Game(size);
            game.Start();
            game.PropertyChanged += Model_PropertyChanged;

            Cells = new List<Cell>();
            for (int x = 0; x < game.Size; x++)
                for (int y = 0; y < game.Size; y++)
                    Cells.Add(new Cell { Value = GetValueFromMap(x, y) });
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
            UpdateMap();
        }

        void UpdateMap()
        {
            int i = 0;
            for (int y = 0; y < game.Size; y++)
                for (int x = 0; x < game.Size; x++)
                    Cells[i++].Value = GetValueFromMap(x, y);                
        }


        public int GetValueFromMap(int x, int y) { Thread.Sleep(5); return game.GetValueFromMap(x, y); }


        readonly List<string> modelProperties = new List<string>() { "GameIsEnd", "Sum" };

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;
            if (string.IsNullOrEmpty(propertyName) || modelProperties.IndexOf(propertyName) >= 0)
                OnPropertyChanged(propertyName);
        }
    }
}
