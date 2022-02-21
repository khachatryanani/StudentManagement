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
    public class DepartmentController : Controller
    {
        private readonly IDataRepository _dataRep;

        public DepartmentController(IDataRepository dataRepository)
        {
            _dataRep = dataRepository;
        }

        [HttpGet]
        public IEnumerable<Department> GetDepartments()
        {
            return _dataRep.GetDepartments();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Student> GetDepartment(int id)
        {
            var dept = _dataRep.GetDepartment(id);
            if (dept is null)
            {
                return NotFound();
            }

            return Ok(dept);
        }

        [HttpGet("{id:int}/students")]
        public ActionResult<User> GetDeptStudents(int id)
        {
            var dept = _dataRep.GetDepartment(id);
            if (dept is null)
            {
                return NotFound();
            }

            return Ok(dept.Students);
        }

        [HttpGet("{id:int}/courses")]
        public ActionResult<Course> GetDeptCourses(int id)
        {
            var dept = _dataRep.GetDepartment(id);
            if (dept is null)
            {
                return NotFound();
            }

            return Ok(dept.Courses);
        }

        [HttpGet("{id:int}/professors")]
        public ActionResult<Professor> GetDeptProfessors(int id)
        {
            var dept = _dataRep.GetDepartment(id);
            if (dept is null)
            {
                return NotFound();
            }

            return Ok(dept.Professors);
        }


        [HttpPost]
        public ActionResult PostDepartment([FromBody] Department department)
        {
            department.DepartmentId = _dataRep.AddDepartment(department);

            return CreatedAtAction(nameof(GetDepartment), new { id = department.DepartmentId }, department.DepartmentId);
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateDepartment(int id, Department department)
        {

            department.DepartmentId = id;
            _dataRep.UpdateDepartment(department);
            return Ok();
        }

    }
}
