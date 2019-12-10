using System.Collections.Generic;


namespace StudentExercisesContinued.models
{
    public class Student : NSSPerson
    {

        public Student(string first, string last, string slack, Cohort cohort)
        {
            FirstName = first;
            LastName = last;
            SlackHandle = slack;
            
            
        }

       
       
        public Cohort StudentCohort { get; set; }

        public int Id { get; set; }

        //collection of excercises
        public List<Exercise> StudentsExercises = new List<Exercise>();

    }

}