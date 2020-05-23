using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Game2048
{
    /// <summary>Базовый класс с реализацией INPC </summary>
    public abstract class PropertyChangedClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
