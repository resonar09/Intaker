using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Intaker.Classes;
using SQLite;

namespace Intaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> _contacts;
        public MainWindow()
        {
            _contacts = new List<Contact>();
            InitializeComponent();
            ReadDatabase();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            ReadDatabase();
        }

        void ReadDatabase()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Contact>();
                //_contacts = (conn.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();
                _contacts = (conn.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();
            }

            if (_contacts != null)
            {
                //foreach (var c in contacts)
                //{
                //    ContactsListView.Items.Add(new ListViewItem()
                //    {
                //        Content = c
                //    });
                //}
                ContactsListView.ItemsSource = _contacts;
            }
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            if (searchTextBox != null)
            {
                List<Contact> filteredList = _contacts.Where(x => x.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                ContactsListView.ItemsSource = filteredList;
            }
        }

        private void ContactsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)ContactsListView.SelectedItem;
            if (selectedContact != null)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
                contactDetailsWindow.ShowDialog();

            }
        }
    }
}
