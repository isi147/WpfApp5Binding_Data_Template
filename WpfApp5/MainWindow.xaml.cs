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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bogus;


namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> Users { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;



            Users = new Faker<User>() 
                .RuleFor(u => u.Firstname, faker => faker.Person.FirstName)
                .RuleFor(u => u.Lastname, faker => faker.Person.LastName)
                .RuleFor(u => u.Gender, faker => faker.Person.Gender.ToString())
                .RuleFor(u => u.Phone, faker => faker.Person.Phone)
                .RuleFor(u => u.ImageUrl, faker => faker.Person.Avatar)
                .RuleFor(u => u.Email, faker => faker.Person.Email)
                .RuleFor(u => u.Address, faker => faker.Person.Address.City)
                .RuleFor(u => u.DateOfBirth, faker => faker.Person.DateOfBirth)
                .Generate(10);

        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = null;
            Users.Add(new User { Firstname = "AAA" });
            listView.ItemsSource = Users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid grid = btn.Parent as Grid;
            StackPanel sp = grid.Children[1] as StackPanel;
            TextBlock textBlock = sp.Children[0] as TextBlock;

            MessageBox.Show(textBlock.Text);
        }
    }
}
