using System;
using System.Linq;
using System.Windows.Forms;
using NGVSCAN.CORE.Entities;
using NGVSCAN.CORE.Entities.Floutecs;
using NGVSCAN.CORE.Entities.ROC809s;

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

            labelDateCreated.Text = Field.DateModified.ToString("dd.MM.yyyy HH:mm");

            labelFloutecsCount.Text = Field.Estimators.Where(f => f is Floutec).Count().ToString();

            labelRocsCount.Text = Field.Estimators.Where(r => r is ROC809).Count().ToString();
        }
    }
}
