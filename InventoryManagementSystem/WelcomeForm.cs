using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            // Initialize the form
            InitializeComponent();
            // Start the timer
            timer1.Start();
        }

        // Start point for the progress bar
        int startPoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 2;

            // Set the value of the progress bar
            progressBar1.Value = startPoint;

            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();

                // Create new the login form
                LoginForm login = new LoginForm();

                // Hide the welcome form
                this.Hide();

                // Show the login form
                login.ShowDialog();
            }
        }
    }
}
