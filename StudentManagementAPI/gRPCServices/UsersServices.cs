using AutoMapper;
using StudentManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementAPI.GrpcServices;

namespace StudentManagementAPI.gRPCServices
{
    public class UsersServices: usersService.usersServiceBase
    {
        private readonly IDataRepository _dataRep;
        private readonly IMapper _mapper;

        public UsersServices(IDataRepository dataRepository, IMapper mapper)
        {
            this._dataRep = dataRepository;
            this._mapper = mapper;
        }

        public usersResponse GetUsers(usersRequest request) 
        {
            return new usersResponse();
            //return _mapper.Map<usersResponse>(_dataRep.GetUsers());
        }
    }
}
