using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using StudentManagementWeb.Data;
using StudentManagementWeb.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementWeb.Pages
{
    public partial class EditUser 
    {
        [Inject]
        UserService UserService { get; set; }

        [Inject]
        NavigationManager NavManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        private User user;

        private IBrowserFile File;

        protected override async Task OnInitializedAsync()
        {
            user = await UserService.GetUser(Id);
        }

        public async Task OnUpdate()
        {
            

            try
            {
                if (File != null) 
                {
                    CloudStorageAccount storage = CloudStorageAccount.Parse(Configurations.BlobStorageConnectionString);
                    CloudBlobClient client = storage.CreateCloudBlobClient();

                    CloudBlobContainer container = client.GetContainerReference("userimages");

                    CloudBlockBlob blockBlob = container.GetBlockBlobReference($"image{user.Id}");
                    
                    await blockBlob.UploadFromStreamAsync(File.OpenReadStream());
                    await blockBlob.SetStandardBlobTierAsync(StandardBlobTier.Cool);

                    if (!string.IsNullOrEmpty(blockBlob.Uri.ToString()))
                    {
                        user.ImageUrl = blockBlob.Uri.ToString();
                    }
                }
                
                await UserService.UpdateUser(user);
                NavManager.NavigateTo("/users");
            }
            catch (Exception ex) 
            {
                //
            }
        }

        public void GetFile(InputFileChangeEventArgs e)
        {
            File = e.File;
        }
    }
}
