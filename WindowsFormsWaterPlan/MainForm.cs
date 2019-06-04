using ClassLibraryWaterUsePlan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsWaterPlan
{
    public partial class MainForm : Form
    {
        ICropGroupRepository cropGroupRepository = new CropGroupMemoryRepository();
        //ICropRepository cropRepository = new CropMemoryRepository();

        // sqlite
        ICropGroupRepository cropGroupSqliteRepository = new CropGroupSqliteRepository();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitRepositories();

            var cg = cropGroupSqliteRepository.GetCropGroups();            
        }

        #region Обработчики нажатия кнопок меню
        /// <summary>
        /// Обработчик нажатия кнопки меню "Справочники - Группы с/х культур"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemCropGroups_Click(object sender, EventArgs e)
        {
            SetupDataGridView(DataGridViewTableEnum.CropGroups);            
        }

        /// <summary>
        /// Обработчик нажатия кнопки меню "Справочники - С/х культуры"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemCrops_Click(object sender, EventArgs e)
        {
            SetupDataGridView(DataGridViewTableEnum.Crops);
        }

        /// <summary>
        /// Обработчик нажатия кнопки меню "Справочники - С/х культуры Sqlite"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemCropGroupsSqlite_Click(object sender, EventArgs e)
        {
            SetupDataGridView(DataGridViewTableEnum.CropGroupsSqlite);
        }
        #endregion

        /// <summary>
        /// Настраивает столбцы таблицы dataGridView
        /// </summary>
        private void SetupDataGridView(DataGridViewTableEnum dataGridViewTableEnum)
        {
            switch (dataGridViewTableEnum)
            {
                case DataGridViewTableEnum.CropGroups:
                    BindingList<CropGroup> bindingListCropGroup = new BindingList<CropGroup>(cropGroupRepository.GetCropGroups());
                    dataGridView.DataSource = bindingListCropGroup;
                    
                    //dataGridView.Columns[0].HeaderText = "Id";
                    dataGridView.Columns[1].HeaderText = "Наименование группы с/х культур";
                    dataGridView.Columns[1].Width = 400;
                    break;
                case DataGridViewTableEnum.CropGroupsSqlite:
                    BindingList<CropGroup> bindingListCropGroupSqlite = new BindingList<CropGroup>(cropGroupSqliteRepository.GetCropGroups());
                    dataGridView.DataSource = bindingListCropGroupSqlite;

                    //dataGridView.Columns[0].HeaderText = "Id";
                    dataGridView.Columns[1].HeaderText = "Наименование группы с/х культур";
                    dataGridView.Columns[1].Width = 400;
                    break;
                case DataGridViewTableEnum.Crops:                    
                    BindingList<Crop> bindingListCrop = new BindingList<Crop>(new List<Crop>());
                    dataGridView.DataSource = bindingListCrop;

                    //dataGridView.Columns[0].HeaderText = "Id";
                    dataGridView.Columns[1].HeaderText = "Наименование с/х культуры";
                    dataGridView.Columns[1].Width = 400;
                    break;                
                default:
                    break;
            }


            //dataGridView.DataSource = dataSetWaterPlan.CropGroups;

            //dataGridView.Columns[0].HeaderText = "Id";
            //dataGridView.Columns[1].HeaderText = "Наименование группы с/х культур";
            //dataGridView.Columns[1].Width = 400;
        }

        /// <summary>
        /// Инициализация репозиториев
        /// </summary>
        private void InitRepositories()
        {
            // Зерновая группа
            var zernGroup = new CropGroup { CropGroupId = 1, CropGroupName = "Зерновая группа"};
            cropGroupRepository.AddCropGroup(zernGroup);

            var CropsZernGroup = new List<Crop>
            {
                new Crop { CropId=1,  CropName="Озимая пшеница",       WateringRate=800, IrrigationRate=2000, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=2,  CropName="Озимая рожь",          WateringRate=500, IrrigationRate=2500, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=3,  CropName="Озимый ячмень",        WateringRate=500, IrrigationRate=2500, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=4,  CropName="Яровая пшеница",       WateringRate=800, IrrigationRate=2100, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=5,  CropName="Овес",                 WateringRate=500, IrrigationRate=1500, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=6,  CropName="Ячмень",               WateringRate=600, IrrigationRate=2400, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=7,  CropName="Кукуруза  на зерно",   WateringRate=800, IrrigationRate=3400, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=8,  CropName="Просо",                WateringRate=800, IrrigationRate=1600, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=9,  CropName="Сорго",                WateringRate=600, IrrigationRate=3000, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=10, CropName="Рис",                  WateringRate=800, IrrigationRate=8000, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=11, CropName="Гречиха",              WateringRate=500, IrrigationRate=2500, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=12, CropName="Чечевица",             WateringRate=600, IrrigationRate=1800, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=13, CropName="Фасоль",               WateringRate=600, IrrigationRate=1800, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=14, CropName="Горох",                WateringRate=600, IrrigationRate=1800, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=15, CropName="Бобы",                 WateringRate=700, IrrigationRate=1600, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=16, CropName="Яровой ячмень",        WateringRate=700, IrrigationRate=1900, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=17, CropName="Прочие зерновые",      WateringRate=700, IrrigationRate=1600, CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=18, CropName="Овес зерновой",        WateringRate=200, IrrigationRate=400,  CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]},
                new Crop { CropId=19, CropName="Зерновая рожь",        WateringRate=0,   IrrigationRate=0,    CropGroupId=1, CropGroup=cropGroupRepository.GetCropGroups()[0]}
            };
            zernGroup.Crops = CropsZernGroup;

            // Овощная группа
            var ovoshnGroup = new CropGroup { CropGroupId = 2, CropGroupName = "Овощная группа" };
            cropGroupRepository.AddCropGroup(ovoshnGroup);

            var CropsOvoshnGroup = new List<Crop>
            {
                new Crop { CropId=20, CropName="Капуста",           WateringRate=600, IrrigationRate=6000, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]},
                new Crop { CropId=21, CropName="Помидоры",          WateringRate=500, IrrigationRate=4000, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]},
                new Crop { CropId=22, CropName="Баклажаны",         WateringRate=500, IrrigationRate=5000, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]},
                new Crop { CropId=23, CropName="Перец",             WateringRate=500, IrrigationRate=5000, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]},
                new Crop { CropId=24, CropName="Огурцы",            WateringRate=500, IrrigationRate=4000, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]},
                new Crop { CropId=25, CropName="Лук",               WateringRate=500, IrrigationRate=3000, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]},
                new Crop { CropId=26, CropName="Свекла столовая",   WateringRate=600, IrrigationRate=3600, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]},
                new Crop { CropId=27, CropName="Морковь столовая",  WateringRate=600, IrrigationRate=3600, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]},
                new Crop { CropId=28, CropName="Петрушка",          WateringRate=600, IrrigationRate=3600, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]},
                new Crop { CropId=29, CropName="Пастернак",         WateringRate=600, IrrigationRate=3600, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]},
                new Crop { CropId=30, CropName="Картофель",         WateringRate=700, IrrigationRate=2400, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]},
                new Crop { CropId=31, CropName="Овощи",             WateringRate=600, IrrigationRate=4000, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]},
                new Crop { CropId=32, CropName="Прочие овощные",    WateringRate=600, IrrigationRate=4000, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]},
                new Crop { CropId=33, CropName="Картофель поздний", WateringRate=600, IrrigationRate=4000, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]},
                new Crop { CropId=34, CropName="Бахча",             WateringRate=600, IrrigationRate=4000, CropGroupId=2, CropGroup=cropGroupRepository.GetCropGroups()[1]}
            };
            ovoshnGroup.Crops = CropsOvoshnGroup;

            // Техническая группа
            var technGroup = new CropGroup { CropGroupId = 3, CropGroupName = "Техническая группа" };
            cropGroupRepository.AddCropGroup(technGroup);

            var CropsTechGroup = new List<Crop>
            {
                new Crop { CropId=35, CropName="Подсолнечник",        WateringRate=800, IrrigationRate=2400, CropGroupId=3, CropGroup=cropGroupRepository.GetCropGroups()[2]},
                new Crop { CropId=36, CropName="Соя",                 WateringRate=700, IrrigationRate=2800, CropGroupId=3, CropGroup=cropGroupRepository.GetCropGroups()[2]},
                new Crop { CropId=37, CropName="Озимый рапс",         WateringRate=500, IrrigationRate=1500, CropGroupId=3, CropGroup=cropGroupRepository.GetCropGroups()[2]},
                new Crop { CropId=38, CropName="Сахарная свекла",     WateringRate=600, IrrigationRate=3600, CropGroupId=3, CropGroup=cropGroupRepository.GetCropGroups()[2]},
                new Crop { CropId=39, CropName="Кориандр",            WateringRate=500, IrrigationRate=1000, CropGroupId=3, CropGroup=cropGroupRepository.GetCropGroups()[2]},
                new Crop { CropId=40, CropName="Цветы",               WateringRate=500, IrrigationRate=1000, CropGroupId=3, CropGroup=cropGroupRepository.GetCropGroups()[2]},
                new Crop { CropId=41, CropName="Прочие технические",  WateringRate=600, IrrigationRate=2400, CropGroupId=3, CropGroup=cropGroupRepository.GetCropGroups()[2]}
            };
            technGroup.Crops = CropsTechGroup;


            // Кормовая группа
            var kormGroup = new CropGroup { CropGroupId = 4, CropGroupName = "Кормовая группа" };
            cropGroupRepository.AddCropGroup(kormGroup);

            //Прочие
            var prochieGroup = new CropGroup { CropGroupId = 5, CropGroupName = "Прочие" };
            cropGroupRepository.AddCropGroup(prochieGroup);
        }

        

        /// <summary>
        /// Обработчик нажатия на кнопку "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Save_Click(object sender, EventArgs e)
        {
            string text = "";
            var cropGroups = cropGroupRepository.GetCropGroups();
            foreach (var cropGroup in cropGroups)
            {
                text += cropGroup.CropGroupName + "\n";
            }
            MessageBox.Show(text, "");
        }


        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = ((CropGroup)((DataGridView)sender).CurrentRow.DataBoundItem).CropGroupId;
                
                //BindingList<Crop> bindingListCrops = new BindingList<Crop>(cropGroupRepository.GetCropGroup(selectedRow).Crops);
                BindingList<Crop> bindingListCrops = new BindingList<Crop>(cropGroupSqliteRepository.GetCropGroup(selectedRow).Crops);

                dataGridViewCrops.DataSource = bindingListCrops;
            }
            catch(Exception exc)
            {

            }
        }

        
    }
}
