using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WssApplication.Domain.Interfaces
{
    /// <summary>
    /// Мягкое удаление
    /// </summary>
    public interface ISoftDeletable
    {
        /// <summary>
        /// Дата удаления
        /// </summary>
        DateTime? DeletedDate { get; set; }

        /// <summary>
        /// Айди пользователя, кем удалено
        /// </summary>
        int? DeletedBy { get; set; }
    }
}
