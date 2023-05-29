using LaboratoryWork2.ViewModel;
using System.Windows;
using System.Text.RegularExpressions;


namespace LaboratoryWork2.View
{
    public partial class AddNewStudentWindow : Window
    {
        public AddNewStudentWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVm();
        }
        /*private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }*/
    }
}
