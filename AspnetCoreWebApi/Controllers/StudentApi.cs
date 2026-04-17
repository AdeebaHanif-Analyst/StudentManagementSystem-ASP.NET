using AspnetCoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace AspnetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApi : ControllerBase
    {
        private readonly StudentdbContext dbcontext;

        public StudentApi(StudentdbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<ActionResult<List<StudentDetail>>> GetStudents()
        {
            var data = await dbcontext.StudentDetails.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDetail>> GetStudents(int id)
        {
            var data = await dbcontext.StudentDetails.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<StudentDetail>> PostStudents(StudentDetail stud)
        {
            await dbcontext.StudentDetails.AddAsync(stud);
            await dbcontext.SaveChangesAsync();
            return Ok(stud);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDetail>> PutStudents(int id, StudentDetail stud)
        {
            if (id != stud.Id)
            {
                return BadRequest();
            }
            dbcontext.Entry(stud).State = EntityState.Modified;
            await dbcontext.SaveChangesAsync();
            return Ok(stud);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentDetail>> DeleteStudents(int id)
        {
            var stud = await dbcontext.StudentDetails.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }
            dbcontext.StudentDetails.Remove(stud);
            await dbcontext.SaveChangesAsync();
            return Ok();

        }
    }
}
