using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeEntityFramework.Data;
using EmployeeEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext context;
        public EmployeeController(EmployeeDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await context.Employees.ToListAsync(  );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var emp = await context.Employees.FindAsync(id);
            if (emp == null) { return NotFound(); }
            return Ok(emp);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee e)
        {
            context.Employees.Add(e);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployeeById), new { id = e.Id }, e);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id,Employee e)
        {
            if(id != e.Id) { return BadRequest("Employee not found"); }
            context.Entry(e).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployeeById), new { id = e.Id }, e);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var emp = await context.Employees.FindAsync(id);
            if (emp == null) { return NotFound(); }
            context.Remove(emp);
            await context.SaveChangesAsync();
            return NoContent();
        }
        //post put delete save changes
    }
}
