using System.ComponentModel;
using Tion.MagicAirTester.Contracts.Annotations;

namespace Tion.MagicAirTester.Contracts
{
    public class Breezer3SState : IBreezerState, INotifyPropertyChanged
    {
        private int _speed;
        private bool _isConnected;

        public int Speed
        {
            get { return _speed; }
            set
            {
                if (value != _speed)
                {
                    _speed = value;
                    OnPropertyChanged(nameof(Speed));
                }
            }
        }

        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                if (value != _isConnected)
                {
                    _isConnected = value;
                    OnPropertyChanged(nameof(IsConnected));
                }
            }
        }

        public void ClearState()
        {
            IsConnected = false;
            Speed = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}