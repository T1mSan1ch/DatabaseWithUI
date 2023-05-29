using LaboratoryWork2.ViewModel;
using LaboratoryWork2.Model;
using System.Windows;


namespace LaboratoryWork2.View
{

    public partial class EditInstituteWindow : Window
    {
        public EditInstituteWindow(Institute instituteToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVm();
            DataManageVm.SelectedInstitute = instituteToEdit;
            DataManageVm.InstituteName = instituteToEdit.Name;
        }
    }
}
