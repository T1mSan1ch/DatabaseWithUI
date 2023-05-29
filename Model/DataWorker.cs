using LaboratoryWork2.Model;
using LaboratoryWork2.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Shapes;

namespace LaboratoryWork2.Model
{
    
    public static class DataWorker
    {
        // создать институт
        public static string CreateInstitute(string name)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Institutes.Any(e1 => e1.Name == name);
                if (!checkIsExist)
                {
                    Institute newInstitute = new Institute { Name = name };
                    db.Institutes.Add(newInstitute);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }
        // создать группу
        public static string CreateGroup(string name, string course, int maxNumber, Institute institute)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            { // проверяум существует ли группа
                bool checkIsExist = db.Groups.Any(el => el.Name == name && el.Course == course);
                if (!checkIsExist)
                {
                    Group newGroup = new Group
                    {
                        Name = name,
                        Course = course,
                        MaxNumber = maxNumber,
                        InsituteId = institute.Id
                    };
                    db.Groups.Add(newGroup);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }
        // создать студента
        public static string CreateStudent(string name, DateTime birthday, decimal avgMark, Group group)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                // проверка студента на наличие его в базе
                bool checkIsExist = db.Students.Any(el => el.FullName == name && el.Birthday == birthday && el.Group == group);
                if (!checkIsExist)
                {
                    Student newStudent = new Student
                    {
                        FullName = name,
                        Birthday = birthday,
                        AvgMark = avgMark,
                        GroupId = group.Id
                    };
                    db.Students.Add(newStudent);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }//удаление института
        public static string DeleteInstitute(Institute institute)
        {
            string result = "Такого института не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Institutes.Remove(institute);
                db.SaveChanges();
                result = "Сделано! Институт " + institute.Name + " удален";
            }
            return result;
        }
        //удаление группы
        public static string DeleteGroup(Group group)
        {
            string result = "Такой группы не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //существует ли группа
                db.Groups.Remove(group);
                db.SaveChanges();
                result = "Сделано! Группа " + group.Name + " удалена";
            }
            return result;
        }
        //удаление студента
        public static string DeleteStudent(Student student)
        {
            string result = "Такого студента не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Students.Remove(student);
                db.SaveChanges();
                result = "Сделано! Студент " + student.FullName + " удалён";
            }
            return result;
        }
        //редактирование института
        public static string EditInstitute(Institute oldInstitute, string newName)
        {
            string result = "Такого института не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Institute institute = db.Institutes.FirstOrDefault(d => d.Id == oldInstitute.Id);
                institute.Name = newName;
                db.SaveChanges();
                result = "Сделано! институт " + institute.Name + " изменен";
            }
            return result;
        }
        //редактирование группы
        public static string EditGroup(Group oldGroup, string newName, int newMaxNumber, string newCourse, Institute newInstitute)
        {
            string result = "Такой группы не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Group group = db.Groups.FirstOrDefault(p => p.Id == oldGroup.Id);
                group.Name = newName;
                group.Course = newCourse;
                group.MaxNumber = newMaxNumber;
                group.InsituteId = newInstitute.Id;
                db.SaveChanges();
                result = "Сделано! Группа " + group.Name + " изменена";
            }
            return result;
        }
        //редактирование студента
        public static string EditStudent(Student oldStudent, string newFullName, decimal newAvgMark, DateTime newBirthday, Group newGroup)
        {
            string result = "Такого студента не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                
                Student student = db.Students.FirstOrDefault(p => p.Id == oldStudent.Id);
                if (student != null)
                {
                    student.FullName = newFullName;
                    student.AvgMark = newAvgMark;
                    student.Birthday = newBirthday;
                    student.GroupId = newGroup.Id;
                    db.SaveChanges();
                    result = "Сделано! Студент " + student.FullName + " изменен";
                }
            }
            return result;
        }
        // получить все Институтты
        public static List<Institute> GetAllInstitutes()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Institutes.ToList();
                string toFile = JsonConvert.SerializeObject(result);
                File.WriteAllText("C:\\Files\\Вуз\\Учёба\\Прога и алгоритмы\\JsonLab2.txt", toFile);
                return result;
            }
        }
        //получить все группы
        public static List<Group> GetAllGroups()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Groups.ToList();
                string toFile = JsonConvert.SerializeObject(result);
                File.WriteAllText("C:\\Files\\Вуз\\Учёба\\Прога и алгоритмы\\JsonLab2.txt", toFile);
                return result;
            }
        }
        //получить всех студентов
        public static List<Student> GetAllStudents()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Students.ToList();
                string toFile = JsonConvert.SerializeObject(result);
                File.WriteAllText("C:\\Files\\Вуз\\Учёба\\Прога и алгоритмы\\JsonLab2.txt", toFile);
                return result;
            }
        }
        //получение группы по id группы
        public static Group GetGroupById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Group pos = db.Groups.FirstOrDefault(p => p.Id == id);
                string toFile = JsonConvert.SerializeObject(pos);
                File.WriteAllText("C:\\Files\\Вуз\\Учёба\\Прога и алгоритмы\\JsonLab2.txt", toFile);
                return pos;
            }
        }
        //получение института по id института
        public static Institute GetInstituteById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Institute pos = db.Institutes.FirstOrDefault(p => p.Id == id);
                string toFile = JsonConvert.SerializeObject(pos);
                File.WriteAllText("C:\\Files\\Вуз\\Учёба\\Прога и алгоритмы\\JsonLab2.txt", toFile);
                return pos;
            }
        }
        //получение всех студентов по id группы
        public static List<Student> GetAllStudentsByGroupId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Student> students = (from student in GetAllStudents() where student.GroupId == id select student).ToList();
                string toFile = JsonConvert.SerializeObject(students);
                File.WriteAllText("C:\\Files\\Вуз\\Учёба\\Прога и алгоритмы\\JsonLab2.txt", toFile);
                return students;
            }
        }
        //получение всех групп по id института
        public static List<Group> GetAllGroupsByInstituteId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
               
                List<Group> groups = (from group1 in GetAllGroups() where group1.InsituteId == id select group1).ToList();
                string toFile = JsonConvert.SerializeObject(groups);
                File.WriteAllText("C:\\Files\\Вуз\\Учёба\\Прога и алгоритмы\\JsonLab2.txt", toFile);
                return groups;
            }
            
        }
    }
}
