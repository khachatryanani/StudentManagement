using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string ImageUrl { get; set; }


        public User()
        {

        }

        public User(int id, string fName, string lName, string email, string role, string imageUrl) 
        {
            this.Id = id;
            this.FirstName = fName;
            this.LastName = lName;
            this.Email = email;
            this.Role = role;
            this.ImageUrl = imageUrl;
        }
    }
}
