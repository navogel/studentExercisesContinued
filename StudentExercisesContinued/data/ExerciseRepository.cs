using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using StudentExercisesContinued.models;

namespace StudentExercisesContinued.Data
{
    /// <summary>
    ///  An object to contain all database interactions.
    /// </summary>
    public class Repository
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
        ///  Returns a list of all departments in the database
        /// </summary>
        public List<Exercise> GetAllDepartments()
        {
           
            using (SqlConnection conn = Connection)
            {
               
                conn.Open();

                
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name, Language FROM Exercise";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int nameColumnPosition = reader.GetOrdinal("Name");
                        string nameValue = reader.GetString(nameColumnPosition);

                        int langColumnPosition = reader.GetOrdinal("Language");
                        string langValue = reader.GetString(langColumnPosition);

                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            Name = nameValue,
                            Language = langValue
                        };

                        exercises.Add(exercise);
                    }

                    reader.Close();

                    return exercises;
                }
            }
        }

        /// <summary>
        ///  Returns a single department with the given id.
        /// </summary>
        public Exercise GetExerciseById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Name, Language FROM Exercise WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Exercise exercise = null;

                    // If we only expect a single row back from the database, we don't need a while loop.
                    if (reader.Read())
                    {
                        exercise = new Exercise
                        {
                            Id = id,
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Language = reader.GetString(reader.GetOrdinal("Language"))
                        };
                    }

                    reader.Close();

                    return exercise;
                }
            }
        }

        /// <summary>
        ///  Add a new department to the database
        ///   NOTE: This method sends data to the database,
        ///   it does not get anything from the database, so there is nothing to return.
        /// </summary>
        public void AddDepartment(Department department)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // These SQL parameters are annoying. Why can't we use string interpolation?
                    // ... sql injection attacks!!!
                    cmd.CommandText = "INSERT INTO Department (DeptName) OUTPUT INSERTED.Id Values (@deptName)";
                    cmd.Parameters.Add(new SqlParameter("@deptName", department.DepartmentName));
                    int id = (int)cmd.ExecuteScalar();

                    department.Id = id;


                }
            }

            // when this method is finished we can look in the database and see the new department.
        }

        /// <summary>
        ///  Updates the department with the given id
        /// </summary>
        public void UpdateDepartment(int id, Department department)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Department
                                     SET DeptName = @deptName
                                     WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@deptName", department.DepartmentName));
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        ///  Delete the department with the given id
        /// </summary>
        public void DeleteDepartment(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Department WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
