using System.Windows;
using Intaker.Classes;
using SQLite;

namespace Intaker
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private readonly Contact _contact;


        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            _contact = contact;
            NameTextBox.Text = _contact.Name;
            EmailTextBox.Text = _contact.Email;
            PhoneNumberTextBox.Text = _contact.Phone;
        }

        private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
        {
            _contact.Name = NameTextBox.Text;
            _contact.Email = EmailTextBox.Text;
            _contact.Phone = PhoneNumberTextBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(_contact);
                //connection.Close();
            }
            Close();
        }


        private void DeleteButton_OnClickButton_OnClick(object sender, RoutedEventArgs e)
        {

            using (SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(_contact);
                //connection.Close();
            }
            Close();
        }
    }
}
