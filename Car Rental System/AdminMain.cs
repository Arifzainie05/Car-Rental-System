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
    public partial class AdminMain : Form
    {
        public AdminMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vehicleManagement1.Show();
            vehicleManagement1.BringToFront();
        }

        private void AdminMain_Load(object sender, EventArgs e)
        {
            vehicleManagement1.Hide();
        }
    }
}
