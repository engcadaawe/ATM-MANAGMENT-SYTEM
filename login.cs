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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private void login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }//crete puplic fuction
        public static string AccNumber;  /// step (1)view accpunt number of user ....home pge(2)/this code2 copy to home
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMDb;Integrated Security=True;Pooling=False");

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from AccountTbl where AccNum='" + AccNumtb.Text + "' and PIN=" + Pintb.Text + "", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
               // step( 2 )view accnumber of user 
                AccNumber=AccNumtb.Text;
               /////////////
               
                HOME home = new HOME();
                home.Show();
                this.Hide();
                con.Close();
            }
            else
            {
                MessageBox.Show("Fadlan Hubi Account number & Pin Code kaga");
            }
           con.Close();    

        }

        private void label5_Click(object sender, EventArgs e)
        {
            account acc=new account();
            acc.Show();
            this.Hide();   
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
