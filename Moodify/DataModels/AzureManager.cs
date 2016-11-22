using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace Moodify.DataModels
{
    class AzureManager
    {

        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<JsonUserModel> DetailsTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("https://restaurantappcontoso.azurewebsites.net");
            this.DetailsTable = this.client.GetTable<JsonUserModel>();

        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }


        public async Task AddDetails(JsonUserModel details)
        {
            await this.DetailsTable.InsertAsync(details);
        }

        public async Task<List<JsonUserModel>> GetDetails()
        {
            return await this.DetailsTable.ToListAsync();
        }

        public async Task Update(JsonUserModel details)
        {
            await this.DetailsTable.UpdateAsync(details);
        }
    }
}
