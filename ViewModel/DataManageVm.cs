using LaboratoryWork2.Model;
using LaboratoryWork2.View;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LaboratoryWork2.ViewModel
{
    public class DataManageVm : INotifyPropertyChanged
    {
        // все институты
        private List<Institute> allInstitutes = DataWorker.GetAllInstitutes();
        public List<Institute> AllInstitutes
        {
            get { return allInstitutes; }
            set
            {
                allInstitutes = value;
                NotifyPropertyChanged("AllInstitutes");
            }
        }
        // все студенты
        private List<Student> allStudents = DataWorker.GetAllStudents();
        public List<Student> AllStudents
        {
            get { return allStudents; }
            private set
            {
                allStudents = value;
                NotifyPropertyChanged("AllStudent");
            }
        }
        // все группы
        private List<Group> allGroups = DataWorker.GetAllGroups();
        public List<Group> AllGroups
        {
            get
            {
                return allGroups;
            }
            private set
            {
                allGroups = value;
                NotifyPropertyChanged("AllGroups");
            }
        }

        // свойства для института
        public static string InstituteName { get; set; }
        // свойства для групп 
        public static string GroupName { get; set; }
        public static string GroupCours { get; set; }
        public static int GroupMaxNumber { get; set; }
        public static Institute GroupInstitute { get; set; }

        //свойства для студента
        public static string StudentName { get; set; }
        public static DateTime StudentBirthday { get; set; }
        public static decimal StudentAvgMark { get; set; }
        public static Group StudentGroup { get; set; }

        //свойства для выделенных элементов
        public TabItem SelectedTabItem { get; set; }
        public static Student SelectedStudent { get; set; }
        public static Group SelectedGroup { get; set; }
        public static Institute SelectedInstitute { get; set; }

        #region COMMANDS TO ADD
        private RelayCommand addNewInstitute;
        public RelayCommand AddNewInstitute
        {
            get
            {
                return addNewInstitute ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (InstituteName == null || InstituteName.Replace(" ", "").Length == 0)
                    {
                        wnd.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        resultStr = DataWorker.CreateInstitute(InstituteName);
                        UpdateAllDataView();
                        ShowMessageToStudent(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }

                });
            }
        }
        private RelayCommand addNewGroup;
        public RelayCommand AddNewGroup
        {
            get
            {
                return addNewGroup ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (GroupName == null || GroupName.Replace(" ", "").Length == 0)
                    {
                        wnd.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    if (GroupCours == null)
                    {
                        wnd.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    if (GroupMaxNumber == 0)
                    {
                        wnd.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    if (GroupInstitute == null)
                    {
                        MessageBox.Show("Укажите институт");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateGroup(GroupName, GroupCours, GroupMaxNumber, GroupInstitute);
                        UpdateAllDataView();
                        ShowMessageToStudent(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addNewStudent;
        public RelayCommand AddNewStudent
        {
            get
            {
                return addNewStudent ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (StudentName == null || StudentName.Replace(" ", "").Length == 0)
                    {
                        wnd.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    if (StudentBirthday == null)
                    {
                        wnd.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    //if (StudentPhone == null || StudentPhone.Replace(" ", "").Length == 0)
                    //{
                    //    SetRedBlockControll(wnd, "SurNameBlock");
                    //}
                    if (StudentGroup == null)
                    {
                        MessageBox.Show("Укажите позицию");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateStudent(StudentName, StudentBirthday, StudentAvgMark, StudentGroup);
                        UpdateAllDataView();
                        ShowMessageToStudent(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        #endregion

        #region COMMANDS TO EDIT 

        private RelayCommand editStudent;
        public RelayCommand EditStudent
        {
            get
            {
                return editStudent ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран студент";
                    string noGroupStr = "Не выбрана новая должность";
                    if (SelectedStudent != null)
                    {
                        if (StudentGroup != null)
                        {
                            resultStr = DataWorker.EditStudent(SelectedStudent, StudentName, StudentAvgMark, StudentBirthday, StudentGroup);

                            UpdateAllDataView();
                            SetNullValuesToProperties();
                            ShowMessageToStudent(resultStr);
                            window.Close();
                        }
                        else ShowMessageToStudent(noGroupStr);
                    }
                    else ShowMessageToStudent(resultStr);

                }
                );
            }
        }
        private RelayCommand editGroup;
        public RelayCommand EditGroup
        {
            get
            {
                return editGroup ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбрана группа";
                    string noInstituteStr = "Не выбран новый институт";
                    if (SelectedGroup != null)
                    {
                        if (GroupInstitute != null)
                        {
                            resultStr = DataWorker.EditGroup(SelectedGroup, GroupName, GroupMaxNumber, GroupCours, GroupInstitute);

                            UpdateAllDataView();
                            SetNullValuesToProperties();
                            ShowMessageToStudent(resultStr);
                            window.Close();
                        }
                        else ShowMessageToStudent(noInstituteStr);
                    }
                    else ShowMessageToStudent(resultStr);

                }
                );
            }
        }

        private RelayCommand editInstitute;
        public RelayCommand EditInstitute
        {
            get
            {
                return editInstitute ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран институт";
                    if (SelectedInstitute != null)
                    {
                        resultStr = DataWorker.EditInstitute(SelectedInstitute, InstituteName);

                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToStudent(resultStr);
                        window.Close();
                    }
                    else ShowMessageToStudent(resultStr);

                }
                );
            }
        }
        #endregion

        #region COMANDS TO OPEN WINDOW
        private RelayCommand openAddNewInstituteWnd;
        public RelayCommand OpenAddNewInstituteWnd
        {
            get
            {
                return openAddNewInstituteWnd ?? new RelayCommand(obj =>
                {
                    OpenAddInstituteWindowMethod();
                });
            }
        }
        private RelayCommand openAddNewGroupWnd;
        public RelayCommand OpenAddNewGroupWnd
        {
            get
            {
                return openAddNewGroupWnd ?? new RelayCommand(obj =>
                {
                    OpenAddGroupWindowMethod();
                }
                );
            }
        }
        private RelayCommand openAddNewStudentWnd;
        public RelayCommand OpenAddNewStudentWnd
        {
            get
            {
                return openAddNewStudentWnd ?? new RelayCommand(obj =>
                {
                    OpenAddStudentWindowMethod();
                }
                );
            }
        }
        private RelayCommand openEditItemWnd;
        public RelayCommand OpenEditItemWnd
        {
            get
            {
                return openEditItemWnd ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    //если студент
                    if (SelectedTabItem.Name == "StudentsTab" && SelectedStudent != null)
                    {
                        OpenEditStudentWindowMethod(SelectedStudent);
                    }
                    //если группа
                    if (SelectedTabItem.Name == "GroupsTab" && SelectedGroup != null)
                    {
                        OpenEditGroupWindowMethod(SelectedGroup);
                    }
                    //если институт
                    if (SelectedTabItem.Name == "InstitutesTab" && SelectedInstitute != null)
                    {
                        OpenEditInstituteWindowMethod(SelectedInstitute);
                    }
                }
                    );
            }
        }
        #endregion

        #region METHODS TO OPEN WINDOW
        /* public List<Group> AllGroup
         {
             get
             {
                 return allGroups;
             }
             private set
             {
                 allGroups = value;
                 NotifyPropertyChanged("AllGroups");
             }
         }*/
        // открытие окон
        private void OpenAddInstituteWindowMethod()
        {
            AddNewInstituteWindow newInstituteWindow = new AddNewInstituteWindow();
            SetCenteGroupAndOpen(newInstituteWindow);
        }
        private void OpenAddGroupWindowMethod()
        {
            AddNewGroupWindow newGroupWindow = new AddNewGroupWindow();
            SetCenteGroupAndOpen(newGroupWindow);
        }
        private void OpenAddStudentWindowMethod()
        {
            AddNewStudentWindow newStudentWindow = new AddNewStudentWindow();
            SetCenteGroupAndOpen(newStudentWindow);
        }
        // метод открытия окона по центру 
        private void SetCenteGroupAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }
        // окна редактирование
        private void OpenEditInstituteWindowMethod(Institute institute)
        {
            EditInstituteWindow editInstituteWindow = new EditInstituteWindow(institute);
            SetCenterGroupAndOpen(editInstituteWindow);
        }
        private void OpenEditGroupWindowMethod(Group group)
        {
            EditGroupWindow editGroupWindow = new EditGroupWindow(group);
            SetCenterGroupAndOpen(editGroupWindow);
        }
        private void OpenEditStudentWindowMethod(Student student)
        {
            EditStudentWindow editStudentWindow = new EditStudentWindow(student);
            SetCenterGroupAndOpen(editStudentWindow);
        }
        private void SetCenterGroupAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion

        #region UPDATE METHODS
        private void SetNullValuesToProperties()
        {
            //для пользователя
            StudentName = null;
            StudentBirthday = default(DateTime);
            StudentAvgMark = 0;
            StudentGroup = null;
            //для группы
            GroupName = null;
            GroupCours = null;
            GroupMaxNumber = 0;
            GroupInstitute = null;
            //для института
            InstituteName = null;
        }
        private void UpdateAllDataView()
        {
            UpdateAllInstitutesView();
            UpdateAllGroupsView();
            UpdateAllStudentsView();
        }
        private void UpdateAllInstitutesView()
        {
            AllInstitutes = DataWorker.GetAllInstitutes();
            
            MainWindow.AllInstitutesView.ItemsSource = null;
            MainWindow.AllInstitutesView.Items.Clear();
            MainWindow.AllInstitutesView.ItemsSource = AllInstitutes;
            MainWindow.AllInstitutesView.Items.Refresh();
        }
        private void UpdateAllGroupsView()
        {
            AllGroups = DataWorker.GetAllGroups();
            MainWindow.AllGroupsView.ItemsSource = null;
            MainWindow.AllGroupsView.Items.Clear();
            MainWindow.AllGroupsView.ItemsSource = AllGroups;
            MainWindow.AllGroupsView.Items.Refresh();
        }
        private void UpdateAllStudentsView()
        {
            AllStudents = DataWorker.GetAllStudents();
            MainWindow.AllStudentsView.ItemsSource = null;
            MainWindow.AllStudentsView.Items.Clear();
            MainWindow.AllStudentsView.ItemsSource = AllStudents;
            MainWindow.AllStudentsView.Items.Refresh();
        }
        #endregion

        #region COMMAND TO DELETE
        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    //если студент
                    if (SelectedTabItem.Name == "StudentsTab" && SelectedStudent != null)
                    {
                        resultStr = DataWorker.DeleteStudent(SelectedStudent);
                        UpdateAllDataView();
                    }
                    //если группа
                    if (SelectedTabItem.Name == "GroupsTab" && SelectedGroup != null)
                    {
                        resultStr = DataWorker.DeleteGroup(SelectedGroup);
                        UpdateAllDataView();
                    }
                    //если институт
                    if (SelectedTabItem.Name == "InstitutesTab" && SelectedInstitute != null)
                    {
                        resultStr = DataWorker.DeleteInstitute(SelectedInstitute);
                        UpdateAllDataView();
                    }
                    //обновление
                    SetNullValuesToProperties();
                    ShowMessageToStudent(resultStr);
                }
                    );
            }
        }
        #endregion

        private void ShowMessageToStudent(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenteGroupAndOpen(messageView);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /*private void SetRedBlockControll(Window wnd, string blockName) - не работает, но вроде бы заменил через покраску TextBlock
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }*/
    }
}
