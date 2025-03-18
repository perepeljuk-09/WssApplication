using WssApplication.Domain.Interfaces;

namespace WssApplication.Domain.Entities
{
    /// <summary>
    /// Базовый класс для всех сущностей, с полями которые будут у всех
    /// </summary>
    /// <typeparam name="T">Айди</typeparam>
    public class BaseEntity<T> : ISoftDeletable
    {
        public T Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Айди пользователя, кем создано
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Айди пользователя, кем изменено
        /// </summary>
        public int ModifiedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public int? DeletedBy { get; set; }
    }
}
