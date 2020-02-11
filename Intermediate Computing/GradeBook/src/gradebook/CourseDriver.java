package gradebook;

import java.util.Iterator;

public class CourseDriver {
    public static void main(String[] args){
        Course c1 = new Course();
        c1.addStudent(new Student("Andy"));
        c1.addStudent(new Student("Billy"));

        Iterator<Student> iterator = c1.iterator();

        while(iterator.hasNext()){
            Student s = iterator.next();
            System.out.println(s.getName());
        }

        // for(s Student : c1){
        //      System.out.println(s.getName());
        // }
    }
}
