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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(dateTimePicker2.Value.ToString()))
            {
                MessageBox.Show("Please enter all the requirements", "");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'autoCar.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.autoCar.Cars);

        }
    }
}
