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
    public partial class BALANCE : Form
    {
        public BALANCE()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMDb;Integrated Security=True;Pooling=False");
        private void getbalance()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select Balance   from AccountTbl  where AccNum='"+AccNumbertbl.Text+"'",con);
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            Balancetbl.Text = "$"+dt.Rows[0][0].ToString();
            con.Close();
        }
        private void BALANCE_Load(object sender, EventArgs e)
        {
            AccNumbertbl.Text=HOME.AccNumber;
            getbalance();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            HOME home = new HOME(); 
            this.Hide();
            home.Show();



        }
    }
}
