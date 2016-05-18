using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.UnitOfWork;
using NGVSCAN.EXEC.Controls;
using NGVSCAN.EXEC.Popups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGVSCAN.EXEC
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        #region Конструктор и поля

        // Unit of work
        private UnitOfWork unitOfWork;

        // Установка
        private Field field;

        // Коллекция вычислителей ФЛОУТЭК данной установки
        private List<Floutec> floutecs;

        // Коллекция линий измерений вычислителей ФЛОУТЭК данной установки
        private List<FloutecMeasureLine> floutecLines;

        // Конструктор формы
        public MainForm()
        {
            // Инициализация содержимого формы
            InitializeComponent();

            // Инициализация unit of work
            unitOfWork = new UnitOfWork();

            /*
                Обновление данных:
                необходимые данные загружаются в память, и в дальнейшем приложение
                осуществляет доступ к данным не в базе данных, а в памяти
            */
            UpdateData(unitOfWork);
        }

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Обновление данных
        /// </summary>
        /// <param name="unitOfWork">Unit of work</param>
        private void UpdateData(UnitOfWork unitOfWork)
        {
            // Инициализация установки
// FAKE        !!! Имя установки задано жёстко временно !!!
            field = unitOfWork.Repository<Field>().GetAll().Where(f => f.Name.Equals("SEM-SRV")).SingleOrDefault();

            // Инициализация коллекции вычислителей ФЛОУТЭК данной установки
            floutecs = field.Estimators.Where(e => e is Floutec).Select(f => f as Floutec).ToList();

            // Инициализация коллекции линий измерения вычислителей ФЛОУТЭК данной установки
            floutecLines = floutecs.Select(f => f.MeasureLines as FloutecMeasureLine).ToList();
        }

        /// <summary>
        /// Заполнение дерева объектов на закладке вычислителей ФЛОУТЭК
        /// </summary>
        /// <param name="field">Установка</param>
        /// <param name="floutecs">Коллекция вычислителей</param>
        /// <param name="lines">Коллекция линий измерения</param>
        private void FillFloutecsTree(Field field, List<Floutec> floutecs, List<FloutecMeasureLine> lines)
        {
            // Очистка дерева
            treeFloutecs.Nodes.Clear();

            // Если установка определена ...
            if (field != null)
            {
                // Добавление установки
                TreeNode root = treeFloutecs.Nodes.Add(field.Name);

                // Для каждого вычислителя
                floutecs.ForEach((f) =>
                {
                    // Если вычислитель определён ...
                    if (f != null)
                    {
                        // Добавление вычислителя в коллекцию вложенных элементов установки
                        TreeNode child = root.Nodes.Add(f.Address + " " + f.Name);

                        // Для каждой линии измерения
                        lines.ForEach((l) =>
                        {
                            // Если линия определена и принадлежит текущему вычислителю ...
                            if (l != null && l.EstimatorId == f.Id)

                                // Добавление линии в коллекцию дочерных элементов текущего вычислителя
                                child.Nodes.Add(l.Number + " " + l.Name);
                        });
                    }
                });
            }
        }

        #endregion       

        #region События формы

        /// <summary>
        /// Событие загрузки главной формы
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргументы события</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Заполнение дерева объектов на закладке вычислителей ФЛОУТЭК
            FillFloutecsTree(field, floutecs, floutecLines);
        }

        private void contextMenuFloutecs_Opening(object sender, CancelEventArgs e)
        {
            contextMenuFloutecs.Items[0].Enabled = treeFloutecs.SelectedNode.Level == 0 ? true : false;
            contextMenuFloutecs.Items[1].Enabled = treeFloutecs.SelectedNode.Level == 1 ? true : false;
            contextMenuFloutecs.Items[3].Enabled = treeFloutecs.SelectedNode.Level > 0 ? true : false;
        }

        private void treeFloutecs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tree = (TreeView)sender;

            if (tree.SelectedNode.Level == 0)
            {
                

                groupFloutecsProperties.Controls.Clear();
            }
            else if (tree.SelectedNode.Level == 1)
            {
                

                groupFloutecsProperties.Controls.Clear();
                FloutecDetails floutecDetails = new FloutecDetails();
                floutecDetails.Dock = DockStyle.Fill;
                string[] tokens = tree.SelectedNode.Text.Split(' ');
                int address = int.Parse(tokens[0]);

                var floutec = unitOfWork.Repository<Floutec>().GetAll().Where(f => f.Address.Equals(address)).SingleOrDefault();
                floutecDetails.Floutec = floutec;
                groupFloutecsProperties.Controls.Add(floutecDetails);
            }
            else
            {
                

                groupFloutecsProperties.Controls.Clear();
            }
        }

        private void contextMenuFloutecs_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string menuItem = e.ClickedItem.Name;

            TreeView tree = (TreeView)contextMenuFloutecs.SourceControl;

            if (menuItem.Equals("menuAddFloutec"))
            {
                

                var field = unitOfWork.Repository<Field>().GetAll().Where(f => f.Name.Equals(tree.SelectedNode.Text)).SingleOrDefault();

                AddFloutecPopup popup = new AddFloutecPopup();

                DialogResult dialogResult = popup.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    Floutec floutec = popup.Floutec;
                    floutec.DateCreated = DateTime.Now;
                    floutec.DateModified = DateTime.Now;

                    field.Estimators.Add(floutec);

                    unitOfWork.Repository<Field>().Update(field);
                    unitOfWork.Commit();

                    FillFloutecsTree(field, floutecs, floutecLines);
                }
            }
            else if (menuItem.Equals("menuAddFloutecLine"))
            {

            }
            else if (menuItem.Equals("menuDeleteFloutec"))
            {
                if (tree.SelectedNode.Level == 1)
                {
                    string[] tokens = tree.SelectedNode.Text.Split(' ');
                    int address = int.Parse(tokens[0]);

                    var floutec = unitOfWork.Repository<Floutec>().GetAll().Where(f => f.Address.Equals(address)).SingleOrDefault();

                    var confirmResult = MessageBox.Show("Вы действительно хотите удалить вычислитель ФЛОУТЭК с адресом " + floutec.Address, "Удаление вычислителя ФЛОУТЭК", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (confirmResult == DialogResult.Yes)
                    {
                        unitOfWork.Repository<Floutec>().Delete(floutec.Id);
                        unitOfWork.Commit();

                        FillFloutecsTree(field, floutecs, floutecLines);
                    }

                    
                }
            }
        }

        #endregion
    }
}
