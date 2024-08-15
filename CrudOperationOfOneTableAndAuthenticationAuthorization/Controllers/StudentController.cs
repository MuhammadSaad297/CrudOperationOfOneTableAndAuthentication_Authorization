//using CrudOperationOfOneTableAndAuthenticationAuthorization.BasicAuth;
using CrudOperationOfOneTableAndAuthenticationAuthorization.Data;
using CrudOperationOfOneTableAndAuthenticationAuthorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrudOperationOfOneTableAndAuthenticationAuthorization.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _db;

        public StudentController(AppDbContext db)
        {
            _db = db;

        }
        [HttpGet]
        [Route("StudentList")]
        public async Task<IActionResult> GetAll()   //IEnumerable<Category>Get
        {
            // 1:16 minute tk api then add core
            //return NotFound();
            //return BadRequest();
            var a = await _db.Students.ToListAsync();
            return Ok(a);     //ok IActionresult mein ataa hai :Enumerable mein ni
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var a = await _db.Students.FindAsync(id);
            //  var a=_db.Students.First(x => x.Id == id);
            if (a is null)
            {
                return NotFound("Student is not found");
            }
            return Ok(a);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
            return Ok(await GetAll());
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Student student,int id)  //
        {
            var a = await _db.Students.FindAsync(id);
            if (a is null)
            {
                return NotFound("Student is not found");
            }
            a.Name = student.Name;
            a.FName = student.FName;
            a.Email = student.Email;
            a.RollNo = student.RollNo;
            a.PhoneNumber = student.PhoneNumber;
            a.Address = student.Address;

            await _db.SaveChangesAsync();
            return Ok(await _db.Students.ToListAsync());
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var a = await _db.Students.FindAsync(id);
            if (a is null)
            {
                return NotFound("Student is not found");
            }
            _db.Students.Remove(a);
            await _db.SaveChangesAsync();
            return Ok(await _db.Students.ToListAsync());

        }

        }
    }
