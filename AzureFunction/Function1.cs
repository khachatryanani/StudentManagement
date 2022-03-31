using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace StudentManagementAzureFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([BlobTrigger("userimages/{name}", Connection = "PortalYSUStorageConnectionName")] Stream myBlob, string name, ILogger log, [Blob("userimagescopy/{name}", FileAccess.Write, Connection = "PortalYSUStorageConnectionName")] Stream otherBlob)
        {
            myBlob.CopyTo(otherBlob);

            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }

    }
}
