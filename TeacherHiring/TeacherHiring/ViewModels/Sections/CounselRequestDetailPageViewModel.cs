using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHiring.ViewModels.Sections
{
    public class CounselRequestDetailPageViewModel
    {
        private string subjectName;
        private DateTime counselDateTime;
        private string studentName;

        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }

        public DateTime CounselDateTime
        {
            get { return counselDateTime; }
            set { counselDateTime = value; }
        }

        public string CounselDate
        {
            get { return counselDateTime.ToString("dd/MM/yyyy"); }
        }

        public string CounselTime
        {
            get { return counselDateTime.ToString("hh:mm tt"); }
        }

        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }
    }
}
