using GraphQL.Types;
using StudentManagementAPI.GraphQL.Types;
using StudentManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.GraphQL.Queries
{
    public class UserQuery: ObjectGraphType
    {
        private readonly IDataRepository _dataRep;

        public UserQuery(IDataRepository dataRepository)
        {
            _dataRep = dataRepository;
            Field<ListGraphType<UserType>>("Users", resolve: context =>_dataRep.GetUsers());
        }
    }
}
