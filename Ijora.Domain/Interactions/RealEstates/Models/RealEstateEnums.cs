using System.ComponentModel;

namespace Ijora.Domain.Interactions.RealEstates.Models
{
    /// <summary>
    /// Тип недвижимости/постройки
    /// </summary>
    public enum PropertyType
    {
        [Description("Квартира")]
        Apartment,   // Квартира

        [Description("Дом")]
        House,       // Дом

        [Description("Таунхаус")]
        Townhouse,   // Таунхаус

        [Description("Земельный участок")]
        Land,        // Земельный участок

        [Description("Коммерческая недвижимость")]
        Commercial   // Коммерческая недвижимость
    }

    /// <summary>
    /// Тип собственности (например, Частная, Государственная).
    /// </summary>

    public enum OwnershipType
    {
        [Description("Частная собственность")]
        Private,     // Частная собственность

        [Description("Государственная собственность")]
        Government,  // Государственная собственность

        [Description("Кооператив")]
        Cooperative  // Кооператив
    }

    /// <summary>
    /// Состояние ремонта (например, Дизайнерский, Косметический, Без ремонта).
    /// </summary>
    public enum Renovation
    {
        [Description("Дизайнерский ремонт")]
        Designer,    // Дизайнерский ремонт

        [Description("Косметический ремонт")]
        Cosmetic,    // Косметический ремонт

        [Description("Без ремонта")]
        None         // Без ремонта
    }

    /// <summary>
    /// Материал стен здания (например, Кирпич, Панель, Монолит, Дерево и т.д.).
    /// </summary>
    public enum WallMaterial
    {
        [Description("Кирпич")]
        Brick,       // Кирпич

        [Description("Панель")]
        Panel,       // Панель

        [Description("Монолит")]
        Monolith,    // Монолит

        [Description("Дерево")]
        Wood,        // Дерево

        [Description("Другой материал")]
        Other        // Другой материал
    }

}
