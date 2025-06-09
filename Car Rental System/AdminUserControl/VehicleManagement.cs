using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Car_Rental_System.AdminUserControl
{
    public partial class VehicleManagement : UserControl
    {
        private DatabaseConnection db = new DatabaseConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Idris\Documents\FTMK\SEM 4\Event-Driven Programming\Car-Rental-System\Car Rental System\bin\Debug\CarRental.mdf"";Integrated Security=True");
        public VehicleManagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var carAdapter = new AutoCarTableAdapters.CarsTableAdapter();
            string model = textBox1.Text;
            string Type = textBox2.Text;
            string plateNumber = textBox3.Text;
            string status = "Available";
            decimal rate = 0;

            db.Open();
            try
            {
                carAdapter.InsertCar(model, Type, plateNumber, status, rate);
                MessageBox.Show("Running from: " + AppDomain.CurrentDomain.BaseDirectory);

                MessageBox.Show("Car inserted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void VehicleManagement_Load(object sender, EventArgs e)
        {
            var carAdapter = new AutoCarTableAdapters.CarsTableAdapter();
            carAdapter.Fill(autoCar.Cars);

            carsBindingSource.DataSource = autoCar;
        }
    }
}
