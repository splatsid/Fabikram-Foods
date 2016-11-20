using Microsoft.WindowsAzure.MobileServices;
using Moodify.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabikram.DataModels
{
    class OrderManager
    {
        private static OrderManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<Order> DetailsTable;

        private OrderManager()
        {
            this.client = new MobileServiceClient("http://restaurantappcontoso.azurewebsites.net");
            this.DetailsTable = this.client.GetTable<Order>();

        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static OrderManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderManager();
                }

                return instance;
            }
        }


        public async Task AddDetails(Order details)
        {
            await DetailsTable.InsertAsync(details);
        }

        public async Task<List<Order>> GetDetails()
        {
            return await this.DetailsTable.ToListAsync();
        }
    }
}
