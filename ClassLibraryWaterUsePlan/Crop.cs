using System;

namespace ClassLibraryWaterUsePlan
{
    /// <summary>
    /// Сельскохозяйственная культура
    /// </summary>
    public class Crop
    {
        /// <summary>
        /// УИД с/х культуры
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование с/х культуры
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Поливная норма
        /// </summary>
        public double WateringRate { get; set; }

        /// <summary>
        /// Оросительная норма
        /// </summary>
        public double IrrigationRate { get; set; }
    }
}
