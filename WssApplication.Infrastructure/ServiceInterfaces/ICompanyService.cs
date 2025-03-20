using WssApplication.Shared.Dtos.Company;

namespace WssApplication.Infrastructure.ServiceInterfaces
{
    public interface ICompanyService
    {
        /// <summary>
        /// Получить все компании для отображения со всеми данными
        /// </summary>
        /// <returns></returns>
        Task<ICollection<CompanyDto>> GetCompanies();

        /// <summary>
        /// Получить компанию по Айди для отображения со всеми данными
        /// </summary>
        /// <param name="companyId">Айди компании</param>
        Task<CompanyDto> GetCompanyById(int companyId);

        /// <summary>
        /// Создать компанию
        /// </summary>
        Task<CompanyDto> CreateCompany(CompanyCreationDto companyCreationDto);

        /// <summary>
        /// Обновить данные компании по Айди
        /// </summary>
        /// <param name="companyId">Айди компании</param>
        Task<CompanyDto> UpdateCompany(CompanyUpdateDto companyUpdateDto, int companyId);

        /// <summary>
        /// Удалить компанию по Айди
        /// </summary>
        /// <param name="companyId">Айди компании</param>
        Task DeleteCompany(int companyId);
    }
}
