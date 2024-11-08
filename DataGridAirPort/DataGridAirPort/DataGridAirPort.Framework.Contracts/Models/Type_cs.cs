using System.ComponentModel;

namespace DataGridAirPort.Framework.Contracts.Models
{
    /// <summary>
    /// Перечисление для обозначения марок самолетов
    /// </summary>
    public enum Type_cs
    {
        /// <summary>
        /// Боинг
        /// </summary>
        [Description("Боинг")]
        Boeing = 1,

        /// <summary>
        /// Эйрбас
        /// </summary>
        [Description("Эйрбас")]
        Airbus = 2,

        /// <summary>
        /// ОАК
        /// </summary>
        [Description("ОАК")]
        UAC = 3,
    }
}
