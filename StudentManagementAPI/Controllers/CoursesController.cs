using Microsoft.AspNetCore.Mvc;
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
    public class CoursesController : Controller
    {
        private readonly IDataRepository _dataRep;

        public CoursesController(IDataRepository dataRepository)
        {
            _dataRep = dataRepository;
        }

        [HttpPost]
        public ActionResult PostUser([FromBody] Course course)
        {
            _dataRep.AddCourse(course);

            return Ok();
        }
    }
}
