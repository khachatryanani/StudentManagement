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
    public class EnrollmentsController : Controller
    {
        private readonly IDataRepository _dataRep;

        public EnrollmentsController(IDataRepository dataRepository)
        {
            _dataRep = dataRepository;
        }

        [HttpPost]
        public ActionResult PostEnrollment([FromQuery] int profId, int depid, int cId)
        {
            _dataRep.AddEnrollment(profId, depid, cId);

            return Ok();
        }
    }
}
