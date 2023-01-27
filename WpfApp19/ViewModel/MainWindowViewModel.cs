using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp19.Model;

namespace WpfApp19.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private double radius;
        public double Radius 
        {
            get => radius;
            set
            { 
                radius = value;
                OnPropertyChanged();
            }
        }
        private double cLength;
        public double CLength
        {
            get => cLength;
            set
            {
                cLength = value;
                OnPropertyChanged();
            }
        }

        public ICommand CircleLengthCommand { get; }
        private void OnCircleLengthCommandExecute(object parameter)
        {
            CLength = Calculator.CircleLength(Radius);
        }
        private bool CanCircleLengthCommandExecuted(object parameter)
        {
            if (Radius > 0) return true;
            return false;
        }
        
        public MainWindowViewModel()
        {
            CircleLengthCommand = new RelayCommand(OnCircleLengthCommandExecute, CanCircleLengthCommandExecuted);
        }
    }
}
