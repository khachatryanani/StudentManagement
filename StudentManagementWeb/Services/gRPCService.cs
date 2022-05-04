using Grpc.Net.Client;
using StudentManagementAPI.GrpcServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementWeb.Services
{
    public class gRPCService
    {
        public async Task<usersResponse> GetUsers()
        {
            GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new usersService.usersServiceClient(channel);
            return await client.GetUsersAsync(new usersRequest());
        }
    }
}
