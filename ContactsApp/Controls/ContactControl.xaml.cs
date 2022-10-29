using ContactsApp.Classess;
using System.Windows;
using System.Windows.Controls;

namespace ContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(null, (d,e) =>
            {
                ContactControl ctrl = d as ContactControl;
                if (ctrl!=null)
                {
                   ctrl.lblName.Text = (e.NewValue as Contact).Name;
                   ctrl.lblEmail.Text = (e.NewValue as Contact).Email;
                   ctrl.lblPhone.Text = (e.NewValue as Contact).Phone;
                }
            }));


        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
