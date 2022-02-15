using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementAPI.Models;
using StudentManagementAPI.Data;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Student> GetStudents() 
        {
            return DataRep.GetStudents();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = DataRep.GetStudent(id);
            if (student is null) 
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public ActionResult PostStudnet([FromBody] Student student)
        {
            student.Id = Data.DataRep.AddStudent(student);
          
            return CreatedAtAction(nameof(GetStudent), new { id  = student.Id }, student.Id);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteStudent(int id)
        {
            DataRep.DeleteStudent(id);

            return NoContent();
        }
    }
}
