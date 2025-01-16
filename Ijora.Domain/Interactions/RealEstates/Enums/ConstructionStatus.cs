namespace Ijora.Domain.Interactions.RealEstates.Enums
{
    /// <summary>
    /// Перечисление возможных статусов строительства жилого комплекса.
    /// </summary>
    public enum ConstructionStatus
    {
        /// <summary>
        /// Проект запланирован, но строительство ещё не начато.
        /// </summary>
        Planned,

        /// <summary>
        /// Строительство начато и находится в процессе.
        /// </summary>
        UnderConstruction,

        /// <summary>
        /// Строительство завершено, объект готов к эксплуатации.
        /// </summary>
        Completed,

        /// <summary>
        /// Строительство приостановлено, временно не ведутся работы.
        /// </summary>
        Suspended,

        /// <summary>
        /// Строительство отменено, проект закрыт.
        /// </summary>
        Cancelled
    }
}
