using System;
using System.Runtime.InteropServices;          //Library
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataBase
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.database1DataSet.customer);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void customerBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void comapanyNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string customer_id = c_id.Text;
            string company_name = com_name.Text;
            string contact_name = c_name.Text;
            string phone = p_no.Text;

            string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\University Work\Visual Porgramming\Lab Tasks\PRACTICE\DataBase\DataBase\Database1.mdf"";Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionstring);
            string query="INSERT into customer(CustomerID,ComapanyName,ContactName,Phone) VALUES('" + customer_id + "', '" + company_name + "', '" + contact_name + "','" + phone + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            int i = cmd.ExecuteNonQuery();
            if(i>0)
            {
                MessageBox.Show("Data Inserted");
                c_id.Clear();
                com_name.Clear();
                c_name.Clear();
                p_no.Clear();

            }
            else if(i==0)
            {
                MessageBox.Show("Sorry ! No insertion ");
            }


        }

        //private SqlCommand SqlCommand(string query, SqlConnection con)
        //{
            //throw new NotImplementedException();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\University Work\Visual Porgramming\Lab Tasks\PRACTICE\DataBase\DataBase\Database1.mdf"";Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from customer", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
