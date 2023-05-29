using LaboratoryWork2.Model;
using LaboratoryWork2.ViewModel;
using System.Windows;

namespace LaboratoryWork2.View
{
    public partial class EditGroupWindow : Window
    {
        public EditGroupWindow(Group groupToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVm();
            DataManageVm.SelectedGroup = groupToEdit;
            DataManageVm.GroupName = groupToEdit.Name;
            DataManageVm.GroupMaxNumber = groupToEdit.MaxNumber;
            DataManageVm.GroupCours = groupToEdit.Course;
        }
    }
}
