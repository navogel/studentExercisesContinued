using System.Collections.Generic;

namespace StudentExercisesContinued.models

{
    public class Instructor : NSSPerson
    {
        public Instructor(string first, string last, string slack, string specialty )
        {
            FirstName = first;
            LastName = last;
            SlackHandle = slack;
            Specialty = specialty;
            
        }
    
        public string Specialty { get; set; }
        public Cohort InstructorCohort { get; set; }

        public int Id { get; set; }

        

        

    }

}