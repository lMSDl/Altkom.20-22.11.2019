namespace Altkom._20_22._11.CSharp.Module2.Models
{
    public class Grade
    {
        public int StudentID { get; set; }
        public string AssessmentDate { get; set; }
        public string SubjectName { get; set; }
        public string Assessment { get; set; }
        public string Comments { get; set; }

        //ctrl+. => generate constructor
        public Grade(int studentID, string assessmentDate, string subjectName, string assessment, string comments)
        {
            StudentID = studentID;
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
