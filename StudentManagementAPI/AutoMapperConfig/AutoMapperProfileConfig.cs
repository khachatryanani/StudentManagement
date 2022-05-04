using AutoMapper;
using StudentManagementAPI.gRPCServices;
using StudentManagementAPI.GrpcServices;
using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.AutoMapperConfig
{
    public class AutoMapperProfileConfig: Profile
    {
        public AutoMapperProfileConfig()
        {
            CreateMap<List<User>, usersResponse>();
        }
    }
}
