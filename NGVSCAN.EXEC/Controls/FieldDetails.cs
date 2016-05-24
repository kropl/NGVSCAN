using System;
using System.Windows.Forms;
using NGVSCAN.CORE.Entities;

namespace NGVSCAN.EXEC.Controls
{
    /// <summary>
    /// Элемент управления для отображения детальной информации по установке
    /// </summary>
    public partial class FieldDetails : UserControl
    {
        // Установка
        public Field Field { get; set; }

        // Конструктор элемента управления
        public FieldDetails()
        {
            InitializeComponent();
        }

        // Событие загрузки элемента управления
        private void FieldDetails_Load(object sender, EventArgs e)
        {
            labelName.Text = Field.Name;

            labelDescription.Text = Field.Description;
        }
    }
}
