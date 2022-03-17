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
    public class RecordsController : Controller
    {
        private readonly IDataRepository _dataRep;

        public RecordsController(IDataRepository dataRepository)
        {
            _dataRep = dataRepository;
        }

        [HttpPost]
        public ActionResult PostDepartment([FromBody] Record record)
        {
            _dataRep.AddRecord(record);

            return Ok();
        }
    }
}
