using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace LaboratoryWork2.Model
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public int MaxNumber { get; set; }
        public List<Student> Students { get; set; }
        public int InsituteId { get; set; }
        public virtual Institute Institute { get; set; }
        [NotMapped]
        public Institute GroupInstitute
        {
            get
            {
                return DataWorker.GetInstituteById(InsituteId);
            }
        }
        [NotMapped]
        public List<Student> GroupStudents
        {
            get
            {
                return DataWorker.GetAllStudentsByGroupId(Id);
            }
        }
    }
}
