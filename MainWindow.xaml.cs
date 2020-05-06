using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game2048_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;
        Label[,] labels;
        Label Sum = new Label { Content = "0" };
        public MainWindow()
        {
            InitializeComponent();
            Start(4);
            KeyDown += Key_Down;
        }

        private void Start(int size)
        {
            game = new Game(size);
            game.Start();
            InitMap(game);
        }

        void InitMap(Game game)
        {
            labels = new Label[game.Size, game.Size];
            Sum = new Label();
            
            Grid.SetColumn(Sum, game.Size);
            Grid.SetRow(Sum, 0);
            Area.Children.Add(Sum);
            for (int i = 0; i < game.Size + 2; i++)
            {
                Area.RowDefinitions.Add(new RowDefinition());
                Area.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int x = 0; x < game.Size; x++)           
                for (int y = 0; y < game.Size; y++)
                {
                    labels[x, y] = new Label { Content = (game.GetValueFromMap(x, y) > 0) ? game.GetValueFromMap(x, y).ToString() : "", Background = Brushes.Aqua};
                    Area.Children.Add(labels[x,y]);
                }          
            Show(game);
        }
        
        void Show(Game game)
        {
            for (int x = 0; x < game.Size; x++)
                for (int y = 0; y < game.Size; y++)
                {
                    var tempLabel = labels[x, y];
                    tempLabel.Content = (game.GetValueFromMap(x, y) > 0) ? game.GetValueFromMap(x, y).ToString() : "";                    
                    tempLabel.FontSize = 20;
                    tempLabel.VerticalAlignment = VerticalAlignment.Center;
                    tempLabel.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetRow(tempLabel, y + 1);
                    Grid.SetColumn(tempLabel, x + 1);
                }
            Sum.Content = "Счёт: " + game.Sum.ToString();
        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            
            if (game.GameIsEnd())
            {
                var label = new Button { Content = "Game over", FontSize = 16 };
                Area.Children.Add(label);
            }
            switch (e.Key)
            {

                case Key.Up:
                    game.MoveUp();
                    break;
                case Key.Down:
                    game.MoveDown();
                    break;
                case Key.Left:
                    game.MoveLeft();
                    break;
                case Key.Right:
                    game.MoveRight();
                    break;
                case Key.Escape:
                    return;
            }
            Show(game);
        }
    }
}
