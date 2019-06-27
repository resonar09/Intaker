using System.Windows;
using System.Windows.Controls;
using Intaker.Classes;

namespace Intaker.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {

        //NameTextBlock.Text = _contact.Name;
        //EmailTextBlock.Text = _contact.Email;
        //PhoneTextBlock.Text = _contact.Phone;

        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact() {Name="Name", Email="example@domain.com", Phone = "(123) 456-7890"}, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;
            if (control != null)
            {
                control.NameTextBlock.Text = (e.NewValue as Contact)?.Name;
                control.EmailTextBlock.Text = (e.NewValue as Contact)?.Email;
                control.PhoneTextBlock.Text = (e.NewValue as Contact)?.Phone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
