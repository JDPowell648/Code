package gradebook;

import org.junit.Test;
import static org.junit.Assert.*;

public class StudentTest2 {

    @Test
    public void testAStudent(){
        Student TestStudent = new Student("Joshua");
        TestStudent.addQuiz(100, 100);
        TestStudent.addAssignment(100,100);
        TestStudent.addExam(100,100);

        assertEquals(100.0, TestStudent.getFinalScore(), 0.0001);
    }
}