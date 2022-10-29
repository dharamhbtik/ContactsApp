using ContactsApp.Classess;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactsWindow newContactsWindow = new NewContactsWindow();
            newContactsWindow.ShowDialog();
            ReadDatabase();
        }
        void ReadDatabase()
        {
            using (var con = new SQLiteConnection(App.databasePath))
            {
                con.CreateTable<Contact>();
               contacts =  con.Table<Contact>().OrderBy(m=>m.Name).ToList();

            }
            //contactsList.Items.Clear();
            //foreach (var item in contacts)
            //{
            //    contactsList.Items.Add(new ListViewItem
            //    {
            //        Content = item,
            //    });
            //}
            contactsList.ItemsSource = contacts;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox  searchTextBox = sender as TextBox;

            var filteredList = contacts.Where(m => m.Name.StartsWith(searchTextBox.Text,System.StringComparison.InvariantCultureIgnoreCase)).ToList();
            contactsList.ItemsSource = filteredList;
        }

        private void contactsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contactsList.SelectedItem!=null)
            {
                var contact = (Contact)contactsList.SelectedItem;
                var cDetail = new ContactDetailsWindow(contact.Id);
                cDetail.ShowDialog();
                ReadDatabase();
            }
        }
    }
}
