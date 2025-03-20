
using Microsoft.AspNetCore.SignalR;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using WssApplication.Infrastructure.ServiceInterfaces;
using WssApplication.Infrastructure.ServiceInterfaces.Hubs;
using WssApplication.Shared.Dtos.Company;
using WssApplication.Shared.Dtos.Hubs;


namespace WssApplication.Api.Hubs
{
    public class CatalogHub : Hub
    {
        private readonly ICatalogHubService _catalogHubService;
        private readonly ICompanyService _companyService;
        public CatalogHub(
            ICatalogHubService catalogHubService,
            ICompanyService companyService)
        {
            _catalogHubService = catalogHubService;
            _companyService = companyService;
        }
        public async Task NotifyWasChanged(NotifyWasChangedDto dto)
        {
            // Данные изменились, запрашиваем новую модель данных и отправляем всем пользователям группы
            // По хорошему надо всю логику вынести в отдельный сервис
            //
            // await _catalogHubService.NotifyWasChanged(dto);

            var company = await _companyService.GetCompanyById(dto.GroupId);

            var newData = JsonSerializer.Serialize(company);

            await Clients.Group(dto.GroupId.ToString()).SendAsync(newData);

        }

        public async Task UserConnected(UserConnectedDto dto)
        {
            // Добавляем нового подключённого пользователя к группе
            await _catalogHubService.UserConnected(dto);
        }

        public async Task UserLeave(UserLeaveDto dto)
        {
            // Пользователь отключился от группы
            await _catalogHubService.UserLeave(dto);
        }
    }
}
