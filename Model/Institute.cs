
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace LaboratoryWork2.Model
{
    public class Institute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Group> Groups { get; set; }
       /* [NotMapped]
        public List<Group> InstitutteGroup
        {
            get
            {
                return DataWorker.GetAllGroupsByInstituteId(Id);
            }
        }*/
    }
}
