using System;
using StudentExercisesContinued.Data;
using StudentExercisesContinued.models;

namespace StudentExercisesContinued
{
    class Program
    {
        static void Main(string[] args)
        { 

            ExerciseRepository ERepo = new ExerciseRepository();
            var EList = ERepo.GetAllExercises();
            foreach (var item in EList)
            {
                Console.WriteLine($"{item.Name}, written in {item.Language}");
            }

            
            Exercise newExercise = new Exercise()
            {
                Name = "Food",
                Language = "JS"

            };


            ERepo.AddExercise(newExercise);

            var EJSList = ERepo.GetAllJSExercises();
            foreach (var item in EJSList)
            {
                Console.WriteLine($"{item.Name}, written in {item.Language}");
            }


        }
    }
}
