using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WssApplication.Infrastructure.ServiceInterfaces.Hubs;
using WssApplication.Shared.Dtos.Hubs;

namespace WssApplication.Infrastructure.Services.Hubs
{
    public class CatalogHubService : ICatalogHubService
    {
        public async Task NotifyWasChanged(NotifyWasChangedDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task UserConnected(UserConnectedDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task UserLeave(UserLeaveDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
