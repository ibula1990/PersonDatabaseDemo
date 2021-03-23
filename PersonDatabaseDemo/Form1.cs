using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonDatabaseDemo
{
    public partial class personDatabase : Form
    {
        SqlConnection conn = new SqlConnection(@"Server=DESKTOP-BLIQA1L\SQLEXPRESS01;Database=CMS;Trusted_Connection=True;");
        public personDatabase()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SavePerson";

            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
            cmd.Parameters.AddWithValue("@Age", txtAge.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Pin", txtPin.Text);
            cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Saved Successfully");


        }

        public void display()
        {
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "DisplayPerson";
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView2.DataSource = dt;




        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            this.Hide();
            form2 ff = new form2();
            ff.ShowDialog();
        }





    }
}
