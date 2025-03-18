using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WssApplication.Domain.Entities
{
    /// <summary>
    /// Компания
    /// </summary>
    public class Company : BaseEntity<int>
    {
        /// <summary>
        /// Название компании
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Список департаментов компании
        /// </summary>
        public ICollection<Department>? Departments { get; set; }
    }
}
