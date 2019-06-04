using System;
using System.Collections.Generic;
using System.IO;

namespace ClassLibraryWaterUsePlan
{
    /// <summary>
    /// Репозиторий группы сельскохозяйственных культур в Sqlite
    /// </summary>
    public class CropGroupSqliteRepository : ICropGroupRepository
    {
        SqliteDbContext sqliteDbContext = new SqliteDbContext("database.db3");               
                
        
        public void AddCropGroup(CropGroup cropGroup)
        {
            throw new NotImplementedException();
        }

        public void RemoveCropGroup(CropGroup cropGroup)
        {
            throw new NotImplementedException();
        }

        public void UpdateCropGroup(CropGroup cropGroup)
        {
            throw new NotImplementedException();
        }

        public CropGroup GetCropGroup(int cropGroupId)
        {
            CropGroup cropGroup = sqliteDbContext.GetCropGroup(cropGroupId);

            return cropGroup;
        }

        public List<CropGroup> GetCropGroups()
        {
            List<CropGroup> cg = sqliteDbContext.GetCropGroups();
            return cg;
        }        
    }
}
