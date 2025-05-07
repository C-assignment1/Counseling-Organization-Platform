using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;

namespace CounselingOrganizationPlatform.AvaloniaUI.Views
{
    public partial class UserManagementView : UserControl
    {
        public ObservableCollection<User> Users { get; set; }

        public UserManagementView()
        {
            InitializeComponent();

            Users = new ObservableCollection<User>
            {
                new User { Id = 1, Name = "Alice", Email = "alice@example.com", Role = "Admin" },
                new User { Id = 2, Name = "Bob", Email = "bob@example.com", Role = "User" }
            };

            UsersDataGrid.ItemsSource = Users;

            AddUserButton.Click += AddUserButton_Click;
            EditUserButton.Click += EditUserButton_Click;
            DeleteUserButton.Click += DeleteUserButton_Click;
        }

        private void AddUserButton_Click(object? sender, RoutedEventArgs e)
        {
            // TODO: Implement add user logic
            var newUser = new User { Id = Users.Count + 1, Name = "New User", Email = "newuser@example.com", Role = "User" };
            Users.Add(newUser);
        }

        private void EditUserButton_Click(object? sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                // TODO: Implement edit user logic
                selectedUser.Name += " (edited)";
                UsersDataGrid.ItemsSource = null;
                UsersDataGrid.ItemsSource = Users;
            }
        }

        private void DeleteUserButton_Click(object? sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                Users.Remove(selectedUser);
            }
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
