using System.ComponentModel;

namespace Ijora.Domain.Interactions.RealEstates.Models
{
    /// <summary>
    /// Состояние дома (новостройка, вторичка)
    /// </summary>
    public enum PropertyCondition
    {
        NewBuilding,      // Новостройка
        SecondHand,       // Вторичное жилье
        UnderConstruction,// На стадии строительства
        Renovated,        // После ремонта
        RequiresRenovation // Требуется ремонт
    }

    /// <summary>
    /// Тип отопления.
    /// </summary>
    public enum HeatingType
    {
        Central,      // Центральное отопление
        Individual    // Индивидуальное отопление
    }

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

    /// <summary>
    /// Тип недвижимости (продажа, аренда)
    /// </summary>
    public enum PropertyUsageType
    {
        /// <summary>
        /// Продажа недвижимости.
        /// </summary>
        [Description("Продажа")]
        Sale,        // Продажа недвижимости

        /// <summary>
        /// Аренда недвижимости.
        /// </summary>
        [Description("Аренда")]
        Rent,        // Аренда недвижимости

        /// <summary>
        /// Обмен недвижимости.
        /// </summary>
        [Description("Обмен")]
        Exchange,    // Обмен недвижимости

        /// <summary>
        /// Продажа с правом аренды.
        /// </summary>
        [Description("Продажа с правом аренды")]
        SaleWithRent, // Продажа с правом аренды

        /// <summary>
        /// Коммерческое использование недвижимости.
        /// </summary>
        [Description("Коммерческое использование")]
        Commercial   // Коммерческое использование недвижимости
    }

    /// <summary>
    /// Перечисление возможных видов из окон.
    /// </summary>
    public enum WindowViewType
    {
        /// <summary>
        /// Вид на двор.
        /// </summary>
        Courtyard,

        /// <summary>
        /// Вид на улицу.
        /// </summary>
        Street,

        /// <summary>
        /// Вид на реку.
        /// </summary>
        River,

        /// <summary>
        /// Вид на парк.
        /// </summary>
        Park,

        /// <summary>
        /// Вид на горы.
        /// </summary>
        Mountains,

        /// <summary>
        /// Вид на море.
        /// </summary>
        Sea,

        /// <summary>
        /// Вид на другие объекты.
        /// </summary>
        Other
    }
}
