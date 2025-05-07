using System;
using System.Windows.Forms;
using CounselingOrganizationPlatform.BLL;

namespace CounselingOrganizationPlatform.Presentation
{
    public partial class LoginForm : Form
    {
        private AuthService authService = new AuthService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (authService.Login(email, password))
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            regForm.Show();
            this.Hide();
        }
    }
}
