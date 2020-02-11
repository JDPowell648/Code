package gradebook;

public class Student
{
    private int assignmentEarned, assignmentPossible;
    private int quizEarned, quizPossible;
    private int examEarned, examPossible;
    private String studentName;

    public Student( String name )
    {
        studentName = name;
    }

    public double getFinalScore( )
    {
        return 40.0 * ( (double) assignmentEarned / assignmentPossible)
                + 30.0 * ( (double) quizEarned / quizPossible)
                + 30.0 * ( (double) examEarned / examPossible);
    }

    public void addAssignment( int earned, int possible )
    {
        // could have said assignmentEarned += earned;
        assignmentEarned = assignmentEarned + earned;
        assignmentPossible = assignmentPossible + possible;
    }

    public void addQuiz( int earned, int possible )
    {
        quizEarned = quizEarned + earned;
        quizPossible = quizPossible + possible;
    }

    public void addExam( int earned, int possible )
    {
        examEarned = examEarned + earned;
        examPossible = examPossible + possible;
    }

    public String getName( )
    {
        return studentName;
    }

}
