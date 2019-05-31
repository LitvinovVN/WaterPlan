using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryWaterUsePlan
{
    /// <summary>
    /// Репозиторий группы сельскохозяйственных культур в памяти
    /// </summary>
    public class CropGroupMemoryRepository : ICropGroupRepository
    {
        List<CropGroup> _cropGroups = new List<CropGroup>();


        public void AddCropGroup(CropGroup cropGroup)
        {
            _cropGroups.Add(cropGroup);
        }

        public void RemoveCropGroup(CropGroup cropGroup)
        {
            _cropGroups.Remove(cropGroup);
        }

        public void UpdateCropGroup(CropGroup cropGroup)
        {
            throw new NotImplementedException();
        }

        public CropGroup GetCropGroup(int cropGroupId)
        {
            foreach (var cropGroup in _cropGroups)
            {
                if (cropGroup.CropGroupId == cropGroupId)
                    return cropGroup;
            }

            return null;
        }

        public List<CropGroup> GetCropGroups()
        {
            return _cropGroups;
        }        
    }
}
