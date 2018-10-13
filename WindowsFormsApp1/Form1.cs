using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Add service reference
        ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();

        public Form1()
        {
            InitializeComponent();
            showdata();
        }
        
        // to show the data in the DataGridView
        private void showdata() 
        {
            DataSet ds = new DataSet();
            ds = obj.SelectUserDetails();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // add type reference
            ServiceReference1.UserDetails objuserdetail = new ServiceReference1.UserDetails();
            objuserdetail.UserName = textBoxUserName.Text;
            objuserdetail.Password = textBoxPassword.Text;
            objuserdetail.Country = textBoxCountry.Text;
            objuserdetail.Email = textBoxEmail.Text;
            obj.InsertUserDetails(objuserdetail);
            showdata();
        }
    }
}
