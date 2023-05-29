
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoryWork2.Model
{
    public class Student 
    { 
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public decimal AvgMark { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        [NotMapped]
        public Group StudentGroup
        {
            get
            {
                return DataWorker.GetGroupById(GroupId);
            }
        }
    }
}
