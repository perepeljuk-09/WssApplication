
namespace WssApplication.Domain.Entities
{
    /// <summary>
    /// Департамент
    /// </summary>
    public class Department : BaseEntity<int>
    {
        /// <summary>
        /// Название депарамента
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Номер позиции для UI
        /// сортировка вывода в UI, по этому полю
        /// При перемещении, меняем позицию и делаем пересчёт позиций для департаментов, у которых позиция больше текущей.
        /// т.е. ставим 5, и для всех департаментов с позицией >= 5, делаем пересчёт позиции
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Айди компании к которой относится департамент
        /// </summary>
        public int CompanyId { get; set; }
        
        /// <summary>
        /// Компания к которой относится департамент
        /// </summary>
        public Company? Company { get; set; }

        /// <summary>
        /// Список отделов департамента
        /// </summary>
        public ICollection<Division>? Divisions { get; set; }
    }
}
