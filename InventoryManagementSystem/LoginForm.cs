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

namespace InventoryManagementSystem
{
    public partial class LoginForm : Form
    {
        //Create a SqlConnection to connect to the database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Korisnik.DESKTOP-JVOQTMK\Downloads\InventoryManagementSystem\InventoryManagementSystem\Tutorial Database\dbIMS.mdf;Integrated Security=True;Connect Timeout=30");

        //Create a SqlCommand to execute the query
        SqlCommand cm = new SqlCommand();

        //Create a SqlDataReader to read the data from the database
        SqlDataReader dr;

        //Create a static string to store the username of the user
        public LoginForm()
        {
            InitializeComponent();
        }

        //  Password checkbox in LoginForm
        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked == false)          //  If the checkbox is unchecked
                txtPass.UseSystemPasswordChar = true;   //  Hide the password
            else                                        //  If the checkbox is checked
                txtPass.UseSystemPasswordChar = false;  //  Show the password
        }

        //  Clear the textboxes in the LoginForm
        private void lblClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPass.Clear();
        }

        //  Close the application
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Applicaton", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // u LoginForm.cs
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("sp_ValidateUser", con);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@username", txtName.Text);
                cm.Parameters.AddWithValue("@password", txtPass.Text);

                con.Open();
                dr = cm.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read(); // Pročitaj red da bi pristupio podacima
                    MessageBox.Show("Welcome " + dr["fullname"].ToString() + " | ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dr.Close(); // Zatvori čitač pre zatvaranja konekcije
                    con.Close();

                    MainForm main = new MainForm();
                    this.Hide();
                    main.ShowDialog();
                }
                else
                {
                    dr.Close(); // Zatvori čitač
                    con.Close();
                    MessageBox.Show("Invalid username or password!", "ACCESS DENITED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
