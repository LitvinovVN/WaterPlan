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

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitRepositories();
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
            cropGroupRepository.AddCropGroup(new CropGroup { CropGroupId = 1, CropGroupName = "Зерновая группа" });
            cropGroupRepository.AddCropGroup(new CropGroup { CropGroupId = 2, CropGroupName = "Овощная группа" });
            cropGroupRepository.AddCropGroup(new CropGroup { CropGroupId = 3, CropGroupName = "Техническая группа" });
            cropGroupRepository.AddCropGroup(new CropGroup { CropGroupId = 4, CropGroupName = "Кормовая группа" });
            cropGroupRepository.AddCropGroup(new CropGroup { CropGroupId = 5, CropGroupName = "Прочие" });
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
    }
}
