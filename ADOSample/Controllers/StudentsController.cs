using ADOSample.Models;
using ADOSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADOSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService stservice;

        public StudentsController(StudentService stservice)
        {
            this.stservice = stservice;
        }

        //get all
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            var students = stservice.GetAllStudent();
            return Ok(students);
        }

        //add student
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            stservice.CreateStudent(student);
            return Ok();
        }

        //get by id
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = stservice.GetStudentById(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            return Ok(student);
        }

        //update student
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest("id");
            }
            stservice.UpdateStudent(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            stservice.DeleteStudent(id);
            return NoContent();
        }
      

    }
}
