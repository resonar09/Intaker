using System.Windows;
using Intaker.Classes;
using SQLite;

namespace Intaker
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }
        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Save Contact
            Contact contact = new Contact()
            {
                Name = NameTextBox.Text,
                Email = EmailTextBox.Text,
                Phone = PhoneNumberTextBox.Text
            };


            using (SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
                //connection.Close();
            }
            Close();
        }
    }
}
