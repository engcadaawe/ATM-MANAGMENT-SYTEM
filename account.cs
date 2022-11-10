using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
namespace ATM
{
    public partial class account : Form
    {

        public account()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMDb;Integrated Security=True;Pooling=False");


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void account_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if (AccNametb.Text == "" || AccNumtb.Text == "" || Fanametb.Text == "" || Phonetb.Text == ""  || Addresstb.Text == ""||Occupationtb.Text=="" || Pin.Text == "")

            {
                MessageBox.Show("fadlan buuxi melaha banan");

            }

            else
            {
                con.Open();
                string query = "insert into AccountTbl values('" + AccNumtb.Text + "','" + AccNametb.Text + "','" + Fanametb.Text + "','" + dobdate.Value.Date + "','" + Phonetb.Text + "','" + Addresstb.Text + "','" + Educationtb.SelectedItem.ToString() + "','" + Occupationtb.Text + "','" + Pintb.Text + "','" + bal + "')";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.ExecuteNonQuery();
                con.Close();
                login log=new login();
                log.Show();
                this.Hide();    
                MessageBox.Show("waad is diiwaan galisay mahadsanid");
                {


                    try
                    {

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);

                    }
                }








            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
