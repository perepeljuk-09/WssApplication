using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WssApplication.Shared.Dtos.Hubs;

namespace WssApplication.Infrastructure.ServiceInterfaces.Hubs
{
    public interface ICatalogHubService
    {
        public Task NotifyWasChanged(NotifyWasChangedDto dto);
        public Task UserConnected(UserConnectedDto dto);
        public Task UserLeave(UserLeaveDto dto);
    }
}
