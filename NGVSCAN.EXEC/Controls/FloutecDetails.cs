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
using NGVSCAN.CORE.Entities.Floutecs;

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

            if (Floutec.MeasureLines.Any())
            {
                labelLines.Text = "Нитки:";

                foreach (FloutecMeasureLine line in Floutec.MeasureLines.Select(l => l as FloutecMeasureLine).OrderBy(o => o.Number))
                {
                    ListViewItem item = new ListViewItem(new[]
                    {
                        line.Number.ToString(),
                        line.Name,
                        line.Description
                    });
                    item.Font = line.IsDeleted ? new Font(new FontFamily("Microsoft Sans Serif"), 8, FontStyle.Strikeout) : null;

                    listLines.Items.Add(item);
                }

                listLines.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                listLines.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
                listLines.Columns[2].Width = listLines.Parent.Parent.Width - listLines.Columns[0].Width - listLines.Columns[1].Width;

                listLines.Width = listLines.Parent.Parent.Width;
                listLines.Height = listLines.Parent.Parent.Height - 116;
                listLines.Location = new Point(0, 116);

                listLines.Visible = true;
            }
            else
            {
                labelLines.Text = "Нитки отсутствуют";
                listLines.Visible = false;
            }
        }
    }
}
