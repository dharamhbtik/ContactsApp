using ContactsApp.Classess;
using SQLite;
using System;
using System.IO;
using System.Windows;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for newContactsWindow.xaml
    /// </summary>
    public partial class NewContactsWindow : Window
    {
        public NewContactsWindow()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact
            {
                Email = txtEmail.Text,
                Name = txtName.Text,
                Phone = txtPhone.Text
            };
           
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }
            Close();
        }
    }
}
