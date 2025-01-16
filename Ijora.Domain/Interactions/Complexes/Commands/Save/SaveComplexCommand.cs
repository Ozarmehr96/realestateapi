using Ijora.Domain.Interactions.Complexes.Enums;
using Ijora.Domain.Interactions.Complexes.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ijora.Domain.Interactions.Complexes.Commands.Save
{
    /// <summary>
    /// Обработчик сохранения ЖК (жилого комплекса).
    /// </summary>
    public class SaveComplexCommand : IRequest<ComplexModel>
    {
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
        public ConstructionStatus Status { get; set; }

        /// <summary>
        /// Признак того, что жилой комплекс построен.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Год завершения строительства (если завершено).
        /// </summary>
        public int? CompletionYear { get; set; }

        /// <summary>
        /// Фотографии ЖК.
        /// </summary>
        public List<string> ImagesUrl { get; set; }
    }
}
