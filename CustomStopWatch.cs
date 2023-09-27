using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StopWatch
{
    internal class CustomStopWatch
    {

        private int _seconds;
        protected int Seconds { 
            get => _seconds; 
            set { _seconds = value; StopWatchValueChanged?.Invoke(_seconds); }  
        }
        private bool _isStarted;
        public event Action<int> StopWatchValueChanged;


        public CustomStopWatch()
        {
            Seconds = 0;
            _isStarted = false;
        }


        public void StartStop()
        {
            if(!_isStarted)
                Seconds = 0;
            ToggleWatch();
        }

        public void PauseContinue() => ToggleWatch();

        private void ToggleWatch()
        {
            if (_isStarted)
                _isStarted = !_isStarted;
            else
            {
                _isStarted = !_isStarted;
                Run();
            }
        }

        private async void Run()
        {
            while (_isStarted) 
            {
                await Task.Delay(1000);
                Seconds++;
            }
        }

    }
}
