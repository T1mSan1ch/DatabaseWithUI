using System.Windows;
using LaboratoryWork2.ViewModel;
using LaboratoryWork2.Model;

namespace LaboratoryWork2.View
{
    /// <summary>
    /// Логика взаимодействия для EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {
        public EditStudentWindow(Student userToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVm();
            DataManageVm.SelectedStudent = userToEdit;
            DataManageVm.StudentName = userToEdit.FullName;
            DataManageVm.StudentBirthday = userToEdit.Birthday;
            DataManageVm.StudentAvgMark = userToEdit.AvgMark;
        }
    }
}
