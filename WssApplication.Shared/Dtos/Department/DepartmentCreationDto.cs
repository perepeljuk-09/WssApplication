

namespace WssApplication.Shared.Dtos.Department
{
    public class DepartmentCreationDto
    {
        /// <summary>
        /// Название депарамента
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Айди компании к которой относится департамент
        /// </summary>
        public int CompanyId { get; set; }
    }
}
