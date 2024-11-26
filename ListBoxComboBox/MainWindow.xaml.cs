using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListBoxComboBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListOfPersons pList = new ListOfPersons();
        public MainWindow()
        {
            InitializeComponent();
            education.ItemsSource = Enum.GetValues(typeof(EducationLevel)).Cast<EducationLevel>();
            pListBox.ItemsSource = pList.Persons;
        }

        private void AddPerson(object sender, RoutedEventArgs e)
        {
            EducationLevel edu = EducationLevel.podstawowe;
            if(!(education.SelectedItem is null))
            {
                edu = Enum.Parse<EducationLevel>(education.SelectedItem.ToString());
            }
            pList.AddPerson(new Person(fName.Text, lName.Text, edu));
        }
        private void EditPerson(object sender, RoutedEventArgs e)
        {
            //TODO nwm
        }
        private void RemovePerson(object sender, RoutedEventArgs e)
        {
            pList.RemovePersonAt(pListBox.SelectedIndex);
        }
    }
}