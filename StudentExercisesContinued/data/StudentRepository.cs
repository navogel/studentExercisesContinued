using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using StudentExercisesContinued.models;

namespace StudentExercisesContinued.Data
{
    /// <summary>
    ///  An object to contain all database interactions.
    /// </summary>
    public class StudentRepository
    {
        /// <summary>
        ///  Represents a connection to the database.
        ///   This is a "tunnel" to connect the application to the database.
        ///   All communication between the application and database passes through this connection.
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SE;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        /// <summary>
        ///  Returns a list of all students in the database
        /// </summary>
        public List<Student> GetAllStudents()
        {

            using (SqlConnection conn = Connection)
            {

                conn.Open();


                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, FirstName, LastName, SlackHandle, CohortId FROM Student";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> students = new List<Student>();

                    while (reader.Read())
                    {

                        Student student = new Student
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            SlackHandle = reader.GetString(reader.GetOrdinal("SlackHandle"))
                        };

                        students.Add(student);
                    }

                    reader.Close();

                    return students;
                }
            }
        }

        /// <summary>
        ///  Returns a single student with the given id.
        /// </summary>
        public Student GetStudentById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, FirstName, LastName, SlackHandle, CohortId FROM Student WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Student student = null;

                    // If we only expect a single row back from the database, we don't need a while loop.
                    if (reader.Read())
                    {
                        student = new Student
                        {
                            Id = id,
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            SlackHandle = reader.GetString(reader.GetOrdinal("SlackHandle"))
                        };
                    }

                    reader.Close();

                    return student;
                }
            }
        }

        /// <summary>
        ///  Add a new student to the database
        ///   NOTE: This method sends data to the database,
        ///   it does not get anything from the database, so there is nothing to return.
        /// </summary>
        public void AddStudent(Student student)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) OUTPUT INSERTED.Id Values (@Name, @Language)";
                    cmd.Parameters.Add(new SqlParameter("@deptName", student.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@Language", student.LastName));
                    int id = (int)cmd.ExecuteScalar();

                    student.Id = id;


                }
            }

        }

        /// <summary>
        ///  Updates the student with the given id
        /// </summary>
        public void UpdateStudent(int id, Student student)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Student
                                     SET Name = @Name, Language = @Language
                                     WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@Name", student.Name));
                    cmd.Parameters.Add(new SqlParameter("@Language", student.Language));
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        ///  Delete the student with the given id
        /// </summary>
        public void DeleteStudent(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Student WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}

