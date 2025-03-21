using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WssApplication.Domain.Entities
{
    /// <summary>
    /// Отдел
    /// </summary>
    public class Division : BaseEntity<int>
    {
        /// <summary>
        /// Название отдела
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Номер позиции для UI
        /// сортировка вывода в UI, по этому полю
        /// При перемещении, меняем позицию и делаем пересчёт позиций для отделов у департамента, у которых позиция больше текущей.
        /// т.е. ставим 5, и для всех отделов с позицией >= 5, делаем пересчёт позиции
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Айди департамента к которому относится отдел
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Департамент к которому относится отдел
        /// </summary>
        public Department? Department { get; set; }
    }
}
