package gradebook;

import java.util.ArrayList;
import java.util.Iterator;

public class Course implements Iterable<Student>{
    private ArrayList<Student> roster = new ArrayList<>();
    private float classTotal;

    public void addStudent(Student s){
        roster.add(s);
    }
    public double getAverageGrade() {
        // Student s : roster
        // classTotal += s.getFinalScore
        for (int i = 0; i <= roster.size(); i++) {
            classTotal += roster.get(i).getFinalScore();
        }
        return classTotal / roster.size();
    }
    public Student getStudent (int i){
        return roster.get(i);
    }
    public Iterator<Student> iterator(){
        return roster.iterator();
    }
}