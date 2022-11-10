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
using Microsoft.VisualBasic;
using System.Net.NetworkInformation;

namespace ATM
{
    public partial class DIPOSIT : Form
    {
        public DIPOSIT()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMDb;Integrated Security=True;Pooling=False");
        string Acc = login.AccNumber;//balance
        private void addtransaction()
        {
            string trType = "DIPOSIT";
            try
            {

                con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + trType + "','" + dipositAmtTb.Text + "','" + DateTime.Today.Date.ToString()+ "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                HOME home = new HOME();
                home.Show();
                this.Hide();
            }catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (dipositAmtTb.Text == ""|| Convert.ToInt32 (dipositAmtTb.Text)<=0)
            {
                MessageBox.Show(" fadlan Gali lacagta & enter the Amount To diposit");
            }
            else
            {
                
                newbalance=oldbalance+Convert.ToInt32(dipositAmtTb.Text);   
                try
                { con.Open();
                    string query = "update AccountTbl set Balance=" + newbalance + " where Accnum ='" + Acc + "'";
                    SqlCommand cmd=new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("waad dhigatay lacagta,Diposit seccessfully");


                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                        
                        con.Close();
                    addtransaction();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);    
                }
            }
                


                 


        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int oldbalance, newbalance;
        private void getbalance()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select Balance   from AccountTbl  where AccNum='" + Acc + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           oldbalance= Convert.ToInt32(dt.Rows[0][0].ToString());
            con.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }

        private void DIPOSIT_Load(object sender, EventArgs e)
        {
            getbalance();

        }
    }
}
