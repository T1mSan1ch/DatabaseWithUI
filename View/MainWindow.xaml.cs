using LaboratoryWork2.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace LaboratoryWork2.View
{
    public partial class MainWindow : Window
    {
        public static ListView AllInstitutesView;
        public static ListView AllGroupsView;
        public static ListView AllStudentsView;


        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVm();
            AllInstitutesView = ViewAllInstitutes;
            AllGroupsView = ViewAllGroups;
            AllStudentsView = ViewAllStudents;
        }
    }
}
