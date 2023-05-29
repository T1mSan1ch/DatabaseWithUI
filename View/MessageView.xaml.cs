using LaboratoryWork2.ViewModel;
using LaboratoryWork2.Model;
using System.Windows;

namespace LaboratoryWork2.View
{
    public partial class MessageView : Window
    {
        public MessageView(string text)
        {
            InitializeComponent();
            MessageText.Text = text;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }      
}
