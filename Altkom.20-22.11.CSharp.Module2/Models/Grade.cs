using Newtonsoft.Json;

namespace Altkom._20_22._11.CSharp.Module2.Models
{
    public class Grade
    {
        public int StudentID { get; set; }
        public string AssessmentDate { get; set; }
        public string SubjectName { get; set; }
        public string Assessment { get; set; }
        public string Comments { get; set; }

        public bool ShouldSerializeComments()
        {
            return Assessment != "B+";
        }

        //ctrl+. => generate constructor
        public Grade(string assessmentDate, string subjectName, string assessment, string comments)
        {
            AssessmentDate = assessmentDate;
            SubjectName = subjectName;
            Assessment = assessment;
            Comments = comments;
        }

        public Grade()
        {
        }
    }
}
