using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NGVSCAN.CORE.Entities;

namespace NGVSCAN.EXEC.Controls
{
    /// <summary>
    /// Элемент управления для отображения детальной информации по вычислителю
    /// </summary>
    public partial class FloutecDetails : UserControl
    {
        // Вычислитель
        public Floutec Floutec { get; set; }

        // Конструктор элемента управления
        public FloutecDetails()
        {
            InitializeComponent();
        }

        // Событие загрузки элемента управления
        private void FloutecDetails_Load(object sender, EventArgs e)
        {
            // Отображение названия и описания установки
            labelField.Text = Floutec.Field.Name + " " + Floutec.Field.Description;

            // Отображение адреса вычислителя
            labelAddress.Text = Floutec.Address.ToString();

            // Отображение названия вычислителя
            labelName.Text = Floutec.Name;

            // Отображение описания вычислителя
            labelDescription.Text = Floutec.Description;

            // Отображение даты и времени создания вычислителя
            labelCreated.Text = Floutec.DateCreated.ToString("dd.MM.yyyy HH:mm:ss");

            // Отображение даты и времени изменения вычислителя
            labelModified.Text = Floutec.DateModified.ToString("dd.MM.yyyy HH:mm:ss");

            // Инициализация поля отображения списка ниток вычислителя
            labelLines.Text = "";

            // Отображение списка ниток вычислителя
            Floutec.MeasureLines.ToList().ForEach((l) => 
            {
                FloutecMeasureLine line = (FloutecMeasureLine)l;
                labelLines.Text += line.Number + " " + line.Name + " ";
            });
        }
    }
}
