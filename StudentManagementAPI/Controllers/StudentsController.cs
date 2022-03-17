using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementAPI.Models;
using StudentManagementAPI.Data;
using StudentManagementAPI.Services;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDataRepository _dataRep;

        public StudentsController(IDataRepository dataRepository)
        {
            _dataRep = dataRepository;
        }

        [HttpGet]
        public IEnumerable<Student> GetStudents() 
        {
            return _dataRep.GetStudents();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _dataRep.GetStudent(id);
            if (student is null) 
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpGet("{id:int}/Records")]
        public ActionResult<Record> GetStudentRecords(int id)
        {
            var records = _dataRep.GetStudentRecords(id);
            if (records is null)
            {
                return NotFound();
            }

            return Ok(records);
        }

        [HttpPost]
        public ActionResult PostStudnet([FromBody] Student student)
        {
            student.Id = _dataRep.AddStudent(student);
            
            return CreatedAtAction(nameof(GetStudent), new { id  = student.Id }, student.Id);
        }

        //[HttpPut("{id:int}")]
        //public ActionResult UpdateStudent(int id, Student student)
        //{

        //    student.Id = id;
        //    _dataRep.UpdateStudent(student);
        //    return Ok();
        //}

        //[HttpDelete("{id:int}")]
        //public ActionResult DeleteStudent(int id)
        //{
        //    _dataRep.DeleteStudent(id);

        //    return NoContent();
        //}
    }
}
