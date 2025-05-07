using System;
using System.Windows.Forms;

namespace CounselingOrganizationPlatform.Presentation
{
    public partial class MainForm : Form
    {
        private Button btnUserManagement;
        private Panel sidebarPanel;
        private Panel mainPanel;

        public MainForm()
        {
            InitializeComponent();
            InitializeSidebar();
        }

        private void InitializeComponent()
        {
            this.Text = "Counseling Organization Platform - Main";
            this.Width = 800;
            this.Height = 600;
            this.StartPosition = FormStartPosition.CenterScreen;

            sidebarPanel = new Panel();
            sidebarPanel.Width = 200;
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(sidebarPanel);

            mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            this.Controls.Add(mainPanel);
        }

        private void InitializeSidebar()
        {
            btnUserManagement = new Button();
            btnUserManagement.Text = "User Management";
            btnUserManagement.Width = sidebarPanel.Width - 20;
            btnUserManagement.Height = 40;
            btnUserManagement.Top = 20;
            btnUserManagement.Left = 10;
            btnUserManagement.Click += BtnUserManagement_Click;
            sidebarPanel.Controls.Add(btnUserManagement);
        }

        private void BtnUserManagement_Click(object sender, EventArgs e)
        {
            ShowUserManagement();
        }

        private void ShowUserManagement()
        {
            mainPanel.Controls.Clear();
            UserManagementForm userManagementForm = new UserManagementForm();
            userManagementForm.TopLevel = false;
            userManagementForm.FormBorderStyle = FormBorderStyle.None;
            userManagementForm.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(userManagementForm);
            userManagementForm.Show();
        }
    }
}
