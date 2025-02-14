public class WritingAssignment : Assignment
{
    private string _title;

    //WritingAssignment constructor has 3 parameters and passes 2 
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        //set any variables specific to the WritingAssignment class
        _title = title;
    }

    public string GetWritingInformation()
    {
        //call the getter because _studentName is private in the base class
        string studentName = GetStudentName();

        return $"{_title} by {studentName}";
    }
}