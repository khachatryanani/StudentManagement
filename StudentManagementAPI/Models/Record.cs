using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class Record
    {
        public int StudentId { get; set; }
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }
        public int Grade { get; set; }

        public Record(int stid, int profId, int cId)
        {
            this.StudentId = stid;
            this.ProfessorId = profId;
            this.CourseId = cId;
        }

        public Record()
        {

        }
    }
}
