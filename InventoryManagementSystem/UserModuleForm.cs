using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagementSystem
{
    public partial class UserModuleForm : Form
    {
        // Create a SqlConnection to connect to the database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Korisnik.DESKTOP-JVOQTMK\Downloads\InventoryManagementSystem\InventoryManagementSystem\Tutorial Database\dbIMS.mdf;Integrated Security=True;Connect Timeout=30");

        // Create a SqlCommand to execute the query
        SqlCommand cm = new SqlCommand();
        
        // Create a SqlDataReader to read the data from the database
        public UserModuleForm()
        {
            InitializeComponent();
        }

        // Load the UserModuleForm
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // Load the UserModuleForm in order to save a new user
        // u UserModuleForm.cs
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text != txtRepass.Text)
                {
                    MessageBox.Show("Password did not Match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to save this user?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Pozovi uskladištenu proceduru
                    cm = new SqlCommand("sp_InsertUser", con);
                    cm.CommandType = CommandType.StoredProcedure; // Važno: naznači da je komanda SP

                    cm.Parameters.AddWithValue("@username", txtUserName.Text);
                    cm.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cm.Parameters.AddWithValue("@password", txtPass.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("User has been successfully saved.");
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Clear the textboxes button
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        public void Clear()
        {
            txtUserName.Clear();
            txtFullName.Clear();
            txtPass.Clear();
            txtRepass.Clear();
            txtPhone.Clear();
        }

        // Load the UserModuleForm in order to update a user
        // u UserModuleForm.cs
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text != txtRepass.Text)
                {
                    MessageBox.Show("Password did not Match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to update this user?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Pozovi uskladištenu proceduru
                    cm = new SqlCommand("sp_UpdateUser", con);
                    cm.CommandType = CommandType.StoredProcedure; // Važno

                    cm.Parameters.AddWithValue("@username", txtUserName.Text); // Sada se šalje kao parametar
                    cm.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cm.Parameters.AddWithValue("@password", txtPass.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been successfully updated!");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
