using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryWaterUsePlan
{
    /// <summary>
    /// Интерфейс репозитория группы сельскохозяйственных культур
    /// </summary>
    public interface ICropGroupRepository
    {
        void AddCropGroup(CropGroup cropGroup);
        void RemoveCropGroup(CropGroup cropGroup);
        void UpdateCropGroup(CropGroup cropGroup);

        CropGroup GetCropGroup(int cropGroupId);
        List<CropGroup> GetCropGroups();
    }
}
