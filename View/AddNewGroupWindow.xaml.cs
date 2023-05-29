using LaboratoryWork2.ViewModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;


namespace LaboratoryWork2.View
{
    public partial class AddNewGroupWindow : Window
    {
        public AddNewGroupWindow() 
        { 
            InitializeComponent();
            DataContext = new DataManageVm();
        }
        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
