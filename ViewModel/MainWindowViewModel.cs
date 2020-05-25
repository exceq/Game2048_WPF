using Game2048.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Game2048.ViewModel
{
    public class MainWindowViewModel : PropertyChangedClass
    {
        Model_Game game;
        List<string> ListOfModelProperties;

        public List<Cell> Cells { get; private set; }
        public bool GameIsEnd => game.GameIsEnd;
        public int UndoCount => game.UndoCount;
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
            Type type = typeof(Model_Game);                                             //еее рефлексия типов
            PropertyInfo[] properties = type.GetProperties();
            ListOfModelProperties = properties.Select(prop => prop.Name).ToList();

            if (game != null)
                game.PropertyChanged -= Model_PropertyChanged;
            game = new Model_Game(size);
            game.PropertyChanged += Model_PropertyChanged;

            FillMap();
        }

        public void NextStep(Direction direction)
        {
            game.MakeMove(direction);
            UpdateMap();
        }

        void FillMap()
        {
            Cells = new List<Cell>();
            for (int y = 0; y < Size; y++)
                for (int x = 0; x < Size; x++)
                    Cells.Add(new Cell { Value = GetValueFromMap(x, y) });
        }

        void UpdateMap()
        {
            int i = 0;
            for (int y = 0; y < Size; y++)
                for (int x = 0; x < Size; x++)
                    Cells[i++].Value = GetValueFromMap(x, y);
        }

        public void Undo()
        {
            game.Undo();
            UpdateMap();
        }

        public int GetValueFromMap(int x, int y) => game.GetValueFromMap(x, y);


        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;
            if (string.IsNullOrEmpty(propertyName) || ListOfModelProperties.IndexOf(propertyName) >= 0)
                OnPropertyChanged(propertyName);
        }
    }
}
