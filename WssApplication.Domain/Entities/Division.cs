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
        /// Порядковый номер для названия, впринципе можно брать из ID, смотря какую логику вывода хотим реализовать.
        /// Можно на фронте выводить из списка взяв индекс + 1
        /// либо
        /// При добавлении нового отдела, получаем количество неудалённых отделов для данного департамента + 1
        /// </summary>
        //public int NameOrderNumber { get; set; }

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
