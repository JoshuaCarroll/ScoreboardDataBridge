using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FairplayLivescoreBridge
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScoreboardDataBridge.SportData sd = new ScoreboardDataBridge.SportData(textBox1.Text, ScoreboardDataBridge.ScoreboardType.Daktronics_AllSport, ScoreboardDataBridge.Sport.Football);
            Console.WriteLine(sd.GameClock);
        }
    }
}
