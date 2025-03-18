using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Порядковый номер для названия, впринципе можно брать из ID, смотря какую логику вывода хотим реализовать.
        /// Можно на фронте выводить из списка взяв индекс + 1
        /// либо
        /// При добавлении нового департамента, получаем количество неудалённых департаментов + 1
        /// </summary>
        //public int NameOrderNumber { get; set; }

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
