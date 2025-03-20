
using WssApplication.Shared.Dtos.Department;

namespace WssApplication.Infrastructure.ServiceInterfaces
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Получить все департаменты для компании
        /// </summary>
        /// <param name="departmentId">Айди компании</param>
        Task<ICollection<DepartmentDto>> GetDepartmentsByCompanyId(int companyId);

        /// <summary>
        /// Получить департамент по Айди для отображения со всеми данными
        /// </summary>
        /// <param name="departmentId">Айди отдела</param>
        Task<DepartmentDto> GetDepartmentById(int departmentId);

        /// <summary>
        /// Создать департамент
        /// </summary>
        Task<DepartmentDto> CreateDepartment(DepartmentCreationDto departmentCreationDto);

        /// <summary>
        /// Обновить данные департамента по Айди
        /// </summary>
        /// <param name="companyId">Айди отдела</param>
        Task<DepartmentDto> UpdateDepartment(DepartmentUpdateDto departmentUpdateDto, int departmentId);

        /// <summary>
        /// Удалить департамент по Айди
        /// </summary>
        /// <param name="companyId">Айди отдела</param>
        Task DeleteDepartment(int departmentId);

        /// <summary>
        /// Переместить департамент, для отображения в UI
        /// </summary>
        /// <returns></returns>
        Task Move(DepartmentMoveDto departmentMoveDto);
    }
}
