using ADOSample.Models;
using Microsoft.Data.SqlClient;
namespace ADOSample.Services
{
    public class StudentService
    {
        private readonly string constr;
        public StudentService(IConfiguration iconfig) 
        { 
            constr = iconfig.GetConnectionString("DefaultConnection");
        }

        //get all student  
        //in adio.net create connection wll b eopdned and clodes in every method
        public List<Student> GetAllStudent()
        {
            var students = new List<Student>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "SELECT * FROM STUDENT";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read()) {
                    var s = new Student
                    {
                        Id = rd.GetInt32(0),
                        Name = rd.GetString(1),
                        Age = rd.GetInt32(2),
                        EnrollmentDate = rd.GetDateTime(3)


                    };
                    students.Add(s);
                }
            }
            return students;
        }

        //add student
        public void CreateStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "INSERT INTO STUDENT(Name, Age, EnrollmentDate) values(@Name, @Age, @EnrollmentDate)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
                cmd.ExecuteNonQuery();
            }
        }

        //update student
        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "update student set Name= @Name, Age= @Age, EnrollmentDate = @EnrollmentDate where id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", student.Id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
                cmd.ExecuteNonQuery();
            }
        }

        //get by id
        public Student GetStudentById(int id)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "SELECT * FROM STUDENT WHERE Id = @ID ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read()) // Advances the reader to the first row
                    {
                        return new Student
                        {
                            Id = rd.GetInt32(0),
                            Name = rd.GetString(1),
                            Age = rd.GetInt32(2),
                            EnrollmentDate = rd.GetDateTime(3)
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
           
        }

        //delete
        public void DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "delete from student where id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
