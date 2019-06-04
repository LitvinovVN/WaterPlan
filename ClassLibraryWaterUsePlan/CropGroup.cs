using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryWaterUsePlan
{
    /// <summary>
    /// Группа сельскохозяйственных культур
    /// </summary>
    public class CropGroup
    {
        /// <summary>
        /// УИД группы с/х культур
        /// </summary>
        public int CropGroupId { get; set; }

        /// <summary>
        /// Наименование группы с/х культур
        /// </summary>
        public string CropGroupName { get; set; }

        /// <summary>
        /// Список с/х культур
        /// </summary>
        public List<Crop> Crops { get; set; } = new List<Crop>();
    }
}
