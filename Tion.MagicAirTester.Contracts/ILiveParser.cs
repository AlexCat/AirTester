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
    }

    public class BreezerState : IBreezerState, INotifyPropertyChanged
    {
        private int _speed;

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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
