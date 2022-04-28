using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IDataRepository _dataRep;

        public UsersController(IDataRepository dataRepository)
        {
            _dataRep = dataRepository;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _dataRep.GetUsers();
        }

        [HttpGet("{id:int}")]
        public ActionResult<User> GetUser(int id)
        {
            var student = _dataRep.GetUser(id);
            if (student is null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] User user)
        {
            user.Id = _dataRep.AddUser(user);

            ServiceBusClient client = new ServiceBusClient("Endpoint=sb://studentsportalysu.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=FUe+IPKnwWEp6ru9CZwbb5lT81diSjPO4p2GVG1ka3A=");
            ServiceBusSender sender = client.CreateSender("studentportalqueue");
            await sender.SendMessageAsync(new ServiceBusMessage($"{user.FirstName}  {user.LastName} user created."));



            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user.Id);
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateUser(int id, User user)
        {
            user.Id = id;
            _dataRep.UpdateUser(user);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteUser(int id)
        {
            _dataRep.DeleteUser(id);

            return NoContent();
        }
    }
}
