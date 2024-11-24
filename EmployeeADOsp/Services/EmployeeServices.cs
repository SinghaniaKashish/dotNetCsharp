using Microsoft.Data.SqlClient;
using EmployeeADOsp.Models;

namespace EmployeeADOsp.Services
{
    public class EmployeeServices
    {
        public readonly string constr;

        public EmployeeServices(IConfiguration iconfig)
        {
            constr = iconfig.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            var employees = new List<Employee>();
            using(SqlConnection con = new SqlConnection(constr))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("GetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                var dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    Id = dr.
                }
            }
        }

    }
}
