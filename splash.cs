using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }
        int starting = 0;

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            starting += 1;
           
        myprogress.Value = starting;
            percentaga.Text=""+starting;
            if (myprogress.Value ==100)
            {
                myprogress.Value = 0;
                timer1.Stop();
                login log =new login();
                log.Show();
                this.Hide();
            }

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
