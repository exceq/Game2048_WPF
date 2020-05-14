using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Game2048.ViewModel;

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
            vm = (MainWindowViewModel)DataContext;
            Start(4);
        }

        private void Start(int size)
        {
            labels = new int[size][];
            vm = new MainWindowViewModel(size);
            vm.Start();
            ShowLabelsOnWindow();
        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up: vm.NextStep(Direction.Up); break;
                case Key.Down: vm.NextStep(Direction.Down); break;
                case Key.Left: vm.NextStep(Direction.Left); break;
                case Key.Right: vm.NextStep(Direction.Right); break;
                case Key.Escape: return;
            }
            ShowLabelsOnWindow();
        }

        public void ShowLabelsOnWindow()
        {
            for (int x = 0; x < vm.Size; x++)
                for (int y = 0; y < vm.Size; y++)
                    ShowLabelText("l" + y + x, vm.GetValueFromMap(x, y));
        }

        private void ShowLabelText(string labelName, int value)
        {
            var label = (Label)FindName(labelName);
            label.Content = (value == 0) ? "" : value.ToString();
            label.Style = (Style)FindResource(value.ToString());
        }

        int[][] labels;

        public void FillLabels()
        {
            for (int i = 0; i < vm.Size; i++)
                for (int j = 0; j < vm.Size; j++)
                    labels[i][j] = vm.GetValueFromMap(i, j);
        }       
    }
}
