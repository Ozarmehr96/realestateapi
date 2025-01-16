using Ijora.Domain.Interactions.Complexes.Enums;
using System;
using System.Collections.Generic;

namespace Ijora.Domain.Interactions.Complexes.Models
{
    /// <summary>
    /// Представляет жилой комплекс ЖК.
    /// </summary>
    public class ComplexModel
    {
        /// <summary>
        /// Уникальный идентификатор жилого комплекса.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название жилого комплекса.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание жилого комплекса.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Местоположение
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Название застройщика.
        /// </summary>
        public string Developer { get; set; }

        /// <summary>
        /// Год начала строительства.
        /// </summary>
        public int BuildYear { get; set; }

        /// <summary>
        /// Статус строительства (например, "Planned", "UnderConstruction", "Completed").
        /// </summary>
        public ConstructionStatus ConstructionStatus { get; set; }

        /// <summary>
        /// Признак того, что жилой комплекс построен.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Год завершения строительства (если завершено).
        /// </summary>
        public int? CompletionYear { get; set; }

        /// <summary>
        /// Дата создания записи.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего обновления записи.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// ИД сотрудника, который опубликовал
        /// </summary>
        public long PublisherUserId { get; set; }

        /// <summary>
        /// Фотографии ЖК.
        /// </summary>
        public List<string> ImageUrls { get; set; }
    }
}
