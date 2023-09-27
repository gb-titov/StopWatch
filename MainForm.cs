using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatch
{
    public partial class MainForm : Form
    {
        private CustomStopWatch _stopWatch;
        public MainForm()
        {
            InitializeComponent();
            _stopWatch = new CustomStopWatch();
            _stopWatch.StopWatchValueChanged += _stopWatch_StopWatchValueChanged;
        }

        private void _stopWatch_StopWatchValueChanged(int sec)
        {
            txtBox.Text = sec.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            (sender as Button).Text = (sender as Button).Text == "Старт" ? "Стоп" : "Старт";
            _stopWatch.StartStop();
            btnPause.Enabled = !btnPause.Enabled;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            (sender as Button).Text = (sender as Button).Text == "Пауза" ? "Продолжить" : "Пауза";
            _stopWatch.PauseContinue();
        }
    }
}
