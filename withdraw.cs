using Microsoft.Data.SqlClient;
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

namespace ATM
{
    public partial class withdraw : Form
    {
        public withdraw()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMDb;Integrated Security=True;Pooling=False");
        string Acc = login.AccNumber;//balance
        int bal;
        private void getbalance()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select Balance   from AccountTbl  where AccNum='" + Acc + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelbl.Text = "Balance: $" + dt.Rows[0][0].ToString();///balance advaible
            bal=Convert.ToInt32(dt.Rows[0][0].ToString()); 
            con.Close();
        }
        private void addtransaction()
        {
            string trType = "withdraw";
            try
            {

                con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + trType + "','" + wdAmtTb.Text + "','" + DateTime.Today.Date.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                HOME home = new HOME();
                home.Show();
                this.Hide();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int  newbalance;
        private void button1_Click(object sender, EventArgs e)
        {
            if (wdAmtTb.Text == "")
            {
                MessageBox.Show(" Buuxi Meelaha Banaanmissing information");

            }
            else if(Convert.ToInt32(wdAmtTb.Text) <= 0)
            {
                MessageBox.Show("Enter Avalid Amount");

            }
            else if(Convert.ToInt32(wdAmtTb.Text) > bal)
            {
                MessageBox.Show(" Balance can not be negative & lacag kugu filan kugu ma jirto ");
            }
            else
            {
                try
                {
                    newbalance = bal + Convert.ToInt32(wdAmtTb.Text);
                    try
                    {
                        con.Open();
                        string query = "update AccountTbl set Balance=" + newbalance + " where Accnum ='" + Acc + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("waad labaxday lacagta,withdraw seccessfully");

                        con.Close();
                        addtransaction();
                        HOME home = new HOME();
                        home.Show();
                        this.Hide();

                       
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            
        }

        private void withdraw_Load(object sender, EventArgs e)
        {
            getbalance();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }
    }
}
