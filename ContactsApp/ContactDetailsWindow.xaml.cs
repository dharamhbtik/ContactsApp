using ContactsApp.Classess;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact _contact;
        public ContactDetailsWindow(int id)
        {
            InitializeComponent();
            LoadContacts(id);
        }

        private void LoadContacts(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                _contact = connection.Find<Contact>(id);
            }
            txtEmail.Text = _contact.Email;
            txtName.Text = _contact.Name;
            txtPhone.Text = _contact.Phone;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _contact.Name = txtName.Text;
            _contact.Phone = txtPhone.Text;
            _contact.Email = txtEmail.Text;
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(_contact);
            }
            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(_contact);
            }
            Close();
        }
    }
}
