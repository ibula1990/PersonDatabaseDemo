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
    public partial class form2 : Form
    {
        public form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server = DESKTOP - BLIQA1L\SQLEXPRESS01; Database = CMS; Trusted_Connection = True;");
             conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "GetPerson";

            SqlDataReader reader = cmd.ExecuteReader();
            txtId.Text =Convert.ToString ( cmd.Parameters["@Id"].Value) ;

            while(reader.Read())
            {
                txtName.Text = reader.GetValue(1).ToString();
            }
            reader.Close();
            cmd.ExecuteNonQuery();
            conn.Close();

            
                
                }       
    }
}
