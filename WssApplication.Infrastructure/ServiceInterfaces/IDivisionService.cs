
using WssApplication.Shared.Dtos.Division;

namespace WssApplication.Infrastructure.ServiceInterfaces
{
    public interface IDivisionService
    {
        /// <summary>
        /// Получить все отделы для департамента
        /// </summary>
        /// <param name="departmentId">Айди департамента</param>
        Task<ICollection<DivisionDto>> GetDivisionsByDepartmentId(int departmentId);

        /// <summary>
        /// Получить отдел по Айди для отображения со всеми данными
        /// </summary>
        /// <param name="divisionId">Айди отдела</param>
        Task<DivisionDto> GetDivisionById(int divisionId);

        /// <summary>
        /// Создать отдел
        /// </summary>
        Task<DivisionDto> CreateDivision(DivisionCreationDto divisionCreationDto);

        /// <summary>
        /// Обновить данные отдела по Айди
        /// </summary>
        /// <param name="companyId">Айди отдела</param>
        Task<DivisionDto> UpdateDivision(DivisionUpdateDto divisionUpdateDto, int divisionId);

        /// <summary>
        /// Удалить отдел по Айди
        /// </summary>
        /// <param name="companyId">Айди отдела</param>
        Task DeleteDivision(int divisionId);

        /// <summary>
        /// Переместить отдел, для отображения в UI
        /// </summary>
        /// <returns></returns>
        Task Move(DivisionMoveDto divisionMoveDto);
    }
}
