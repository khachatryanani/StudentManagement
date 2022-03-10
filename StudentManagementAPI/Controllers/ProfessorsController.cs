using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : Controller
    {
        private readonly IDataRepository _dataRep;

        public ProfessorsController(IDataRepository dataRepository)
        {
            _dataRep = dataRepository;
        }

        [HttpGet]
        public IEnumerable<Professor> GetProfessors()
        {
            return _dataRep.GetProfessors();
        }

        [HttpGet("{id:int}")]
        public ActionResult<User> GetProfessor(int id)
        {
            var prof = _dataRep.GetProfessor(id);
            if (prof is null)
            {
                return NotFound();
            }

            return Ok(prof);
        }

        [HttpGet("{id:int}/courses")]
        public ActionResult<Course> GetProfCourses(int id)
        {
            var prof = _dataRep.GetProfessor(id);
            if (prof is null)
            {
                return NotFound();
            }

            return Ok(prof.Courses);
        }

        [HttpGet("{id:int}/students")]
        public ActionResult<Course> GetProfStudents(int id)
        {
            var prof = _dataRep.GetProfessor(id);
            if (prof is null)
            {
                return NotFound();
            }

            return Ok(prof.Students);
        }

        [HttpGet("{id:int}/courses/{depId:int}/students")]
        public ActionResult<User> GetProfCourseStudents(int id, int depId)
        {
            var prof = _dataRep.GetProfessor(id);
            if (prof is null)
            {
                return NotFound();
            }

            var dept = prof.Departments.FirstOrDefault(dep => dep.DepartmentId == depId);
            if (dept is null) 
            {
                return NotFound();
            }

            return Ok(dept.Students);
        }

        [HttpPost]
        public ActionResult PostProf([FromBody] Professor prof)
        {
            //prof.Id = _dataRep.AddUser(prof);

            return CreatedAtAction(nameof(GetProfessor), new { id = prof.Id }, prof.Id);
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateProfessor(int id, Professor prof)
        {
            prof.Id = id;
            _dataRep.UpdateProfessor(prof);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteProfessor(int id)
        {
            _dataRep.DeleteProfessor(id);

            return NoContent();
        }
    }
}
