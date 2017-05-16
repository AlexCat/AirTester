using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using Tion.MagicAirTester.Contracts.Annotations;

namespace Tion.MagicAirTester.Contracts
{
    public interface ILiveParser
    {
        IBreezerState Parse(HidReport data);
    }

    public interface IBreezerState
    {
        int Speed { get; set; }
        bool IsConnected { get; set; }
        void ClearState();
    }

    public interface IMagicAirState
    {
        bool isFound { get; set; }
        void ClearState();
    }

    public class MagicAirState : IMagicAirState
    {
        public bool isFound { get; set; }
        public void ClearState()
        {
            isFound = false;
        }
    }

    public class BreezerState : IBreezerState, INotifyPropertyChanged
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
