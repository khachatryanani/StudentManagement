using GraphQL.Types;
using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.GraphQL.Types
{
    public class UserType: ObjectGraphType<User>
    {
        public UserType()
        {
            Field((user) => user.Id).Description("user id");
            Field((user) => user.FirstName).Description("user first name");
            Field((user) => user.LastName).Description("user last name");
            Field((user) => user.Email).Description("user email");

            Field(typeof(DateTime), "LastViewed", "user last viewed");
        }
    }
}
