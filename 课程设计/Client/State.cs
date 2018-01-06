using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class State : Form
    {
        public State()
        {
            InitializeComponent();
        }

        private void State_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StOnLine_Click(object sender, EventArgs e)
        {
            
        }

        private void StWaite_Click(object sender, EventArgs e)
        {

        }

        private void StLeave_Click(object sender, EventArgs e)
        {

        }

        private void StBusy_Click(object sender, EventArgs e)
        {

        }

        private void StRefuse_Click(object sender, EventArgs e)
        {

        }

        private void StInvisible_Click(object sender, EventArgs e)
        {

        }

        private void State_Load(object sender, EventArgs e)
        {
            this.Close();
        }

        private void State_ClientSizeChanged(object sender, EventArgs e)
        {

        }
    }
}
