using LaboratoryWork2.ViewModel;
using System;
using System.Windows;


namespace LaboratoryWork2.View
{
    
    public partial class AddNewInstituteWindow : Window
    {
        public AddNewInstituteWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVm();
        }
    }
}
