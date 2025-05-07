using System;
using System.Windows.Forms;
using CounselingOrganizationPlatform.BLL;

namespace CounselingOrganizationPlatform.Presentation
{
    public partial class RegistrationForm : Form
    {
        private AuthService authService = new AuthService();

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (authService.RegisterUser(name, email, password, role))
            {
                MessageBox.Show("Registration successful! Please login.");
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Registration failed. Email might already be in use.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
