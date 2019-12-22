using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyProjectAccount
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string constring = @"Data Source=.\sqlexpress;Initial Catalog=ShumraizDB;Integrated Security=True;Pooling=False";
        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                SqlConnection conn = new SqlConnection(constring);

                string query = "INSERT INTO  StudentsAccount(name,projecttitle,Deal,Amount,Date) values('" + textBox1.Text + "','" + textBox2.Text + "','" + Convert.ToInt32(textBox3.Text) + "','" + Convert.ToInt32(textBox4.Text) + "','" + theDate + "')";

                SqlCommand sqlCmd = new SqlCommand(query, conn);
                conn.Open();
                sqlCmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data is saved");
            }
            catch(Exception exp){

                MessageBox.Show("Data is not in corract formate :"+exp);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string studentID = textBox5.Text;


            SqlConnection con = new SqlConnection(constring);
            //Open database connection to connect to SQL Server
            con.Open();
            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("SELECT  * FROM  StudentsAccount where id ='" + studentID + "' ", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView1.DataSource = dtusers;
            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();

            CountStudentAmont();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            //Open database connection to connect to SQL Server
            con.Open();
            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("SELECT  * FROM  StudentsAccount  ", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            dataGridView1.DataSource = dtusers;
            //Resize the Datagridview column to fit the gridview columns with data in datagridview
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            con.Close();
            countTotalAmount();
        }


        private void countTotalAmount()
        {



            SqlConnection con = new SqlConnection(constring);
        //Open database connection to connect to SQL Server
        con.Open();
        //Data table is used to bind the resultant data
        DataTable dtusers = new DataTable();
        // Create a new data adapter based on the specified query.
        string query = "SELECT  sum(Amount)FROM  StudentsAccount";
        //SQl command builder is used to get data from database based on query
        //  SqlCommandBuilder cmd = new SqlCommandBuilder(da);
        //Fill data table
        // da.Fill(dtusers);
        SqlCommand cmd = new SqlCommand(query, con);
        string address = cmd.ExecuteScalar().ToString();
        label6.Text = "Total Amount "+address;





       
        
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void CountStudentAmont()
        {



            SqlConnection con = new SqlConnection(constring);
            //Open database connection to connect to SQL Server
            con.Open();
            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            string query = "SELECT  sum(Amount)FROM  StudentsAccount where id ='"+textBox5.Text+"'";
            //SQl command builder is used to get data from database based on query
            //  SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            // da.Fill(dtusers);
            SqlCommand cmd = new SqlCommand(query, con);
            string address = cmd.ExecuteScalar().ToString();
            label6.Text = "Total Amount " + address;







        }





    }
}
