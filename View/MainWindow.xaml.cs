using Game2048.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Game2048.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindowViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowViewModel();
            DataContext = vm;
        }

        private void GameChange_Click(object sender, RoutedEventArgs e)
        {
            var a = ((MenuItem)sender).Header.ToString();
            vm = new MainWindowViewModel(int.Parse(a.Remove(0,2)));
            DataContext = vm;
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            vm = new MainWindowViewModel(4);
            DataContext = vm;
        }

        private void Key_Up(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up: vm.NextStep(Direction.Up); break;
                case Key.Down: vm.NextStep(Direction.Down); break;
                case Key.Left: vm.NextStep(Direction.Left); break;
                case Key.Right: vm.NextStep(Direction.Right); break;
            }
        }  
    }
}
