using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHiring.ViewModels.Implementations;

namespace TeacherHiring.ViewModels.Sections
{
    public class CounselRequestDetailPageViewModel : AsyncViewModel
    {
        private string subjectName;
        private DateTime counselDateTime;
        private string studentName;
        private string teacherName;
        private bool isConfirmationDetail = false;

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

        public string TeacherName
        {
            get { return teacherName; }
            set { teacherName = value; }
        }

        public bool IsConfirmationDetail
        {
            get { return isConfirmationDetail; }
            set { OnPropertyChanged(ref isConfirmationDetail, ref value, "IsConfirmationDetail"); }
        }

        public override void OnBusyChange()
        {
            OnPropertyChanged("InputsVisible");
        }
    }
}
