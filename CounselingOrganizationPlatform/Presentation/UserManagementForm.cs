using System;
using System.Windows.Forms;

namespace CounselingOrganizationPlatform.Presentation
{
    public partial class UserManagementForm : Form
    {
        private DataGridView dgvUsers;
        private Button btnAddUser;
        private Button btnEditUser;
        private Button btnDeleteUser;

        public UserManagementForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void InitializeComponent()
        {
            this.Text = "User Management";
            this.Dock = DockStyle.Fill;

            dgvUsers = new DataGridView();
            dgvUsers.Dock = DockStyle.Top;
            dgvUsers.Height = 400;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.AutoGenerateColumns = true;
            this.Controls.Add(dgvUsers);

            btnAddUser = new Button();
            btnAddUser.Text = "Add User";
            btnAddUser.Top = dgvUsers.Bottom + 10;
            btnAddUser.Left = 10;
            btnAddUser.Click += BtnAddUser_Click;
            this.Controls.Add(btnAddUser);

            btnEditUser = new Button();
            btnEditUser.Text = "Edit User";
            btnEditUser.Top = dgvUsers.Bottom + 10;
            btnEditUser.Left = btnAddUser.Right + 10;
            btnEditUser.Click += BtnEditUser_Click;
            this.Controls.Add(btnEditUser);

            btnDeleteUser = new Button();
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.Top = dgvUsers.Bottom + 10;
            btnDeleteUser.Left = btnEditUser.Right + 10;
            btnDeleteUser.Click += BtnDeleteUser_Click;
            this.Controls.Add(btnDeleteUser);
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = new[]
            {
                new { Id = 1, Name = "Alice", Email = "alice@example.com", Role = "Admin" },
                new { Id = 2, Name = "Bob", Email = "bob@example.com", Role = "User" }
            };
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add User clicked - implement user creation.");
        }

        private void BtnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                MessageBox.Show("Edit User clicked - implement user editing.");
            }
            else
            {
                MessageBox.Show("Please select a user to edit.");
            }
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                MessageBox.Show("Delete User clicked - implement user deletion.");
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }
    }
}
