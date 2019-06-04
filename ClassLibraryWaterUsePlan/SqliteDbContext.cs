using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ClassLibraryWaterUsePlan
{
    /// <summary>
    /// Контекст данных Sqlite
    /// </summary>
    public class SqliteDbContext
    {
        private string _dbFileName;
        private SQLiteConnection _dbConn;
        private SQLiteCommand _sqlCmd;

        public SqliteDbContext(string dbFileName)
        {
            _dbFileName = dbFileName;

            ConnectToDb();
        }

        public void ConnectToDb()
        {
            _dbConn = new SQLiteConnection(_dbFileName);            
        }

        /// <summary>
        /// Возвращает содержимое таблицы CropGroups
        /// </summary>
        public List<CropGroup> GetCropGroups()
        {
            var cropGroups = _dbConn.Table<CropGroup>().ToList();
            var crops = _dbConn.Table<Crop>().ToList();
            foreach (var crop in cropGroups)
            {
                crop.Crops = crops.Where(c=>c.CropGroupId == crop.CropGroupId).ToList();
            }

            return cropGroups;
        }

        /// <summary>
        /// Возвращает требуемую группу с/х культур
        /// </summary>
        /// <param name="cropGroupId"></param>
        /// <returns></returns>
        public CropGroup GetCropGroup(int cropGroupId)
        {
            CropGroup cropGroup = _dbConn.Table<CropGroup>().FirstOrDefault(cg=>cg.CropGroupId == cropGroupId);
            cropGroup.Crops = _dbConn.Table<Crop>().Where(c => c.CropGroupId == cropGroup.CropGroupId).ToList();

            return cropGroup;
        }
    }
}
