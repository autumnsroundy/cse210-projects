public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    //MathAssignment constructor has 4 parameters passing 2 of them to base constructor (assignment class constructor)
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        //set math variables
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}