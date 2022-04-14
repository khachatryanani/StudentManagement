using GraphQL.Types;
using StudentManagementAPI.GraphQL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.GraphQL.Schemas
{
    public class SMSchema: Schema
    {
        public SMSchema(UserQuery userQuery)
        {
            Query = userQuery;
        }
    }
}
