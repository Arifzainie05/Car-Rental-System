using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_System
{
    public partial class Form4 : Form
    {
        private DatabaseConnection db = new DatabaseConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Idris\Documents\FTMK\SEM 4\Event-Driven Programming\Car-Rental-System\Car Rental System\CarRental.mdf;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            var userAdapter = new AutoCarTableAdapters.UsersTableAdapter();
            string FullName = fullname.Text;
            string phone = phoneNo.Text;
            string email = textBox1.Text;
            string ic = textBox2.Text;
            string username = textBox3.Text;
            string password = textBox4.Text;
            string role = "Customer";


            if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("Password and Confirm Password is not the same", "");
            }

            if( string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Please fill in all the requirements needed", "");
            }
            else
            {
                db.Open();

                try
                {
                    userAdapter.Insert1(FullName, phone, email, ic, username, password, role);
                    MessageBox.Show("Running from: " + AppDomain.CurrentDomain.BaseDirectory);

                    MessageBox.Show("User inserted successfully!");

                    Form1 form1 = new Form1();
                    this.Hide();
                    form1.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
