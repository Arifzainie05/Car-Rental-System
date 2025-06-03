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

namespace Car_Rental_System
{
    public partial class Form1 : Form
    {
        private string Username;
        private string Password;
        private DatabaseConnection db = new DatabaseConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Idris\Documents\FTMK\SEM 4\Event-Driven Programming\Car-Rental-System\Car Rental System\bin\Debug\CarRental.mdf"";Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Username = username.Text;
            this.Password = password.Text;

            if (string.IsNullOrEmpty(this.Username) || string.IsNullOrEmpty(this.Password))
            {
                MessageBox.Show("Your Username or Password is Wrong", "Warning");
            }

            try
            {
                db.Open();

                
                string sql = "SELECT UserID, FullName, Email, Role FROM Users WHERE Username = @Username AND Password = @Password";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", Username),
                    new SqlParameter("password", Password)

                };

                using (SqlDataReader reader = db.ExecuteReader(sql, parameters))
                {
                    
                    if (reader.Read())
                    {
                        
                        if ( reader["Role"].ToString() == "Customer")
                        { 
                            //CustomerMain customerMain = new CustomerMain();
                            //customerMain.Show();
                            //this.Hide();
                            Form2 form2 = new Form2();
                            form2.Show();
                            this.Hide();
                        }
                        else if (reader["Role"].ToString() == "Admin")
                        {
                            AdminMain adminMain = new AdminMain();
                            adminMain.Show();
                            this.Hide();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username or Password");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            Form4 register = new Form4();
            this.Hide();
            register.Show();
        }
    }
}
