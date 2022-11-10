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
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BALANCE bal = new BALANCE();
            this.Hide();
            bal.Show();
        }
        public static string AccNumber;  //(2)passt code//(3)balance load
        private void HOME_Load(object sender, EventArgs e)
        {
            ///( 3) view Account number of user when log in home ...pge(1) log in/
            AccNumlbl.Text = "Account Number:" + login.AccNumber;

            AccNumber = login.AccNumber;
        }

        private void label5_Click(object sender, EventArgs e)
        {
           login login=new login();   
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DIPOSIT diposit = new DIPOSIT();
            diposit.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CHANGEPIN pin=new CHANGEPIN();  
            pin.Show();
            this.Hide(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            withdraw wd = new withdraw();
            wd.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ministatement mini = new ministatement();
            mini.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void AccNumlbl_Click(object sender, EventArgs e)
        {

        }
    }

}
