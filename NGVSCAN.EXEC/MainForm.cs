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

        // Коллекция вычислителей ROC809 данной установки
        private List<ROC809> rocs;

        // Коллекция точек измерения вычислителей ROC809 данной установки
        private List<ROC809MeasurePoint> rocPoints;

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

            // Если установка была определена ...
            if (field != null)
            {
                // Инициализация коллекции вычислителей ФЛОУТЭК данной установки
                floutecs = field.Estimators.Where(e => e is Floutec).Select(e => e as Floutec).ToList();

                rocs = field.Estimators.Where(e => e is ROC809).Select(e => e as ROC809).ToList();

                // Если коллекция вычислителей ФЛОУТЭК была определена ...
                if (floutecs != null)
                {
                    // Инициализация коллекции линий измерения вычислителей ФЛОУТЭК данной установки
                    floutecLines = new List<FloutecMeasureLine>();
                    floutecs.ForEach((f) =>
                    {
                        floutecLines.AddRange(f.MeasureLines.Select(l => l as FloutecMeasureLine).ToList());
                    });
                }

                // Если коллеция вычислителей ROC809 была определена ...
                if (rocs != null)
                {
                    // Инициализация коллекции точек измерения вычислителей ROC809 данной установки
                    rocPoints = new List<ROC809MeasurePoint>();
                    rocs.ForEach((r) =>
                    {
                        rocPoints.AddRange(r.MeasureLines.Select(p => p as ROC809MeasurePoint).ToList());
                    });
                }
            }          
        }

        /// <summary>
        /// Заполнение дерева объектов на закладке вычислителей ФЛОУТЭК
        /// </summary>
        /// <param name="field">Установка</param>
        /// <param name="floutecs">Коллекция вычислителей</param>
        /// <param name="lines">Коллекция линий измерения</param>
        private void FillFloutecsTree(Field field, List<Floutec> floutecs, List<FloutecMeasureLine> lines, List<ROC809> rocs, List<ROC809MeasurePoint> rocPoints)
        {
            // Очистка дерева
            treeEstimators.Nodes.Clear();

            // Если установка определена ...
            if (field != null)
            {
                // Добавление установки
                TreeNode root = treeEstimators.Nodes.Add(field.Name);

                // Добавление двух групп для вычислителей
                TreeNode floutecsGroup = root.Nodes.Add("floutecsGroup", "Вычислители ФЛОУТЭК");
                TreeNode rocsGroup = root.Nodes.Add("rocsGroup", "Вычислители ROC809");

                // Для каждого вычислителя ФЛОУТЭК
                floutecs.ForEach((f) =>
                {
                    // Если вычислитель определён ...
                    if (f != null)
                    {
                        // Добавление вычислителя в коллекцию вложенных элементов группы вычислителей ФЛОУТЭК
                        TreeNode child = floutecsGroup.Nodes.Add(f.Address + " " + f.Name);

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

                // Для каждого вычислителя ROC809
                rocs.ForEach((r) =>
                {
                    // Если вычислитель определён ...
                    if (r != null)
                    {
                        // Добавление вычислителя в коллекцию вложенных элементов группы вычислителей ROC809
                        TreeNode child = rocsGroup.Nodes.Add(r.Address + " " + r.Port + " " + r.Name);

                        // Для каждой точки измерения
                        rocPoints.ForEach((p) =>
                        {
                            // Если точка определена и принадлежит текущему вычислителю ...
                            if (p != null && p.EstimatorId == r.Id)

                                // Добавление линии в коллекцию дочерных элементов текущего вычислителя
                                child.Nodes.Add(p.Number + " " + p.Name);
                        });
                    }
                });
            }
        }

        #endregion       

        #region События формы

        // Событие загрузки главной формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Заполнение дерева объектов на закладке вычислителей ФЛОУТЭК
            FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
        }

        // Событие открытия контекстного меню дерева объектов на закладке вычислителей ФЛОУТЭК
        private void contextMenuFloutecs_Opening(object sender, CancelEventArgs e)
        {
            // Определение объекта, на котором было вызвано контекстное меню
            TreeNode nodeAtMousePosition = treeEstimators.GetNodeAt(treeEstimators.PointToClient(MousePosition));

            // Определение текущего выбранного объекта
            TreeNode selectedNode = treeEstimators.SelectedNode;

            // Переопределение текущего выбранного объекта
            if (nodeAtMousePosition != null)
            {
                if (nodeAtMousePosition != selectedNode)
                    treeEstimators.SelectedNode = nodeAtMousePosition;
            }

            // Контекстное меню отображается только для всех узлов кроме установки
            e.Cancel = treeEstimators.SelectedNode.Level == 0 ? true : false;

            // Пункт меню "Добавить вычислитель" доступен только для групп вычислителей
            contextMenuEstimators.Items[0].Enabled = treeEstimators.SelectedNode.Level == 1 ? true : false;
            contextMenuEstimators.Items[0].Visible = treeEstimators.SelectedNode.Level == 1 ? true : false;

            // Пункт меню "Добавить нитку" доступен только для вычислителей
            contextMenuEstimators.Items[1].Enabled = treeEstimators.SelectedNode.Level == 2 ? true : false;
            contextMenuEstimators.Items[1].Visible = treeEstimators.SelectedNode.Level == 2 ? true : false;
            contextMenuEstimators.Items[2].Visible = treeEstimators.SelectedNode.Level == 2 ? true : false;

            // Пункт меню "Изменить" доступен для вычислителей и ниток вычислителей
            contextMenuEstimators.Items[3].Enabled = treeEstimators.SelectedNode.Level > 1 ? true : false;
            contextMenuEstimators.Items[3].Visible = treeEstimators.SelectedNode.Level > 1 ? true : false;
            contextMenuEstimators.Items[4].Visible = treeEstimators.SelectedNode.Level > 1 ? true : false;

            // Пункт меню "Удалить" доступен для вычислителей и ниток вычислителей
            contextMenuEstimators.Items[5].Enabled = treeEstimators.SelectedNode.Level > 1 ? true : false;
            contextMenuEstimators.Items[5].Visible = treeEstimators.SelectedNode.Level > 1 ? true : false;
        }

        // Событие выбора объекта в дереве объектов на закладке вычислителей ФЛОУТЭК
        private void treeFloutecs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Очистка содержимого панели свойств выбранного объекта
            groupEstimatorsProperties.Controls.Clear();

            // Вывод информации на панель свойств в зависимости от уровня вложенности выбранного объекта
            switch (treeEstimators.SelectedNode.Level)
            {
                // Для установки (уровень вложенности = 0)
                case 0:
                    {
                        FieldDetails fieldDetails = new FieldDetails();

                        fieldDetails.Dock = DockStyle.Fill;

                        groupEstimatorsProperties.Controls.Add(fieldDetails);

                        break;
                    }
                case 1:
                    {
                        if (treeEstimators.SelectedNode.Name.Equals("floutecsGroup"))
                        {
                            FloutecsGroupDetails floutecsGroupDetails = new FloutecsGroupDetails();

                            floutecsGroupDetails.Dock = DockStyle.Fill;

                            groupEstimatorsProperties.Controls.Add(floutecsGroupDetails);
                        }
                        else if (treeEstimators.SelectedNode.Name.Equals("rocsGroup"))
                        {
                            ROC809sGroupDetails rocsGroupDetails = new ROC809sGroupDetails();

                            rocsGroupDetails.Dock = DockStyle.Fill;

                            groupEstimatorsProperties.Controls.Add(rocsGroupDetails);
                        }

                        break;
                    }
                // Для вычислителей (уровень вложенности = 2)
                case 2:
                    {
                        if (treeEstimators.SelectedNode.Parent.Name.Equals("floutecsGroup"))
                        {
                            // Инициализация экземпляра элемента управления FloutecDetails
                            FloutecDetails floutecDetails = new FloutecDetails();

                            // Вывод элемента будет осуществлятся заполнением
                            floutecDetails.Dock = DockStyle.Fill;

                            // Определение адреса выбранного вычислителя
                            string[] props = treeEstimators.SelectedNode.Text.Split(' ');
                            int address = int.Parse(props[0]);

                            // Выбор вычислителя из коллекции по адресу
                            Floutec floutec = floutecs.Where(f => f.Address == address).SingleOrDefault();

                            // Передача вычислителя в элемент управления
                            floutecDetails.Floutec = floutec;

                            // Добавление элемента управления на панель свойств
                            groupEstimatorsProperties.Controls.Add(floutecDetails);
                        }
                        else if (treeEstimators.SelectedNode.Parent.Name.Equals("rocsGroup"))
                        {
                            ROC809Details rocDetails = new ROC809Details();

                            rocDetails.Dock = DockStyle.Fill;

                            groupEstimatorsProperties.Controls.Add(rocDetails);
                        }

                        break;
                    }
                // Для ниток (уровень вложенности = 3)
                case 3:
                    {
                        if (treeEstimators.SelectedNode.Parent.Parent.Name.Equals("floutecsGroup"))
                        {
                            FloutecLineDetails floutecLineDetails = new FloutecLineDetails();

                            floutecLineDetails.Dock = DockStyle.Fill;

                            groupEstimatorsProperties.Controls.Add(floutecLineDetails);
                        }
                        else if (treeEstimators.SelectedNode.Parent.Parent.Name.Equals("rocsGroup"))
                        {
                            ROC809PointDetails rocPointDetails = new ROC809PointDetails();

                            rocPointDetails.Dock = DockStyle.Fill;

                            groupEstimatorsProperties.Controls.Add(rocPointDetails);
                        }

                        break;
                    }
                // По умолчанию
                default:
                    break;
            }
        }

        // Событие выбора команды контекстного меню
        private void contextMenuFloutecs_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string menuItem = e.ClickedItem.Name;

            if (menuItem.Equals("menuAddEstimator"))
            {
                if (treeEstimators.SelectedNode.Name.Equals("floutecsGroup"))
                {
                    AddFloutecPopup popup = new AddFloutecPopup();

                    popup.IsEdit = false;

                    DialogResult dialogResult = popup.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        Floutec floutec = popup.Floutec;
                        floutec.DateCreated = DateTime.Now;
                        floutec.DateModified = DateTime.Now;

                        field.Estimators.Add(floutec);

                        unitOfWork.Repository<Field>().Update(field);
                        unitOfWork.Commit();

                        UpdateData(unitOfWork);

                        FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                    }
                }
                else if (treeEstimators.SelectedNode.Name.Equals("rocsGroup"))
                {
                    AddROC809Popup popup = new AddROC809Popup();

                    DialogResult dialogResult = popup.ShowDialog();
                }                           
            }
            else if (menuItem.Equals("menuEdit"))
            {
                if (treeEstimators.SelectedNode.Level == 2)
                {
                    if (treeEstimators.SelectedNode.Parent.Name.Equals("floutecsGroup"))
                    {
                        AddFloutecPopup popup = new AddFloutecPopup();

                        popup.IsEdit = true;

                        string[] tokens = treeEstimators.SelectedNode.Text.Split(' ');
                        int address = int.Parse(tokens[0]);

                        var floutec = floutecs.Where(f => f.Address.Equals(address)).SingleOrDefault();

                        popup.Floutec = floutec;

                        DialogResult dialogResult = popup.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            floutec = popup.Floutec;
                            floutec.DateModified = DateTime.Now;

                            unitOfWork.Repository<Floutec>().Update(floutec);
                            unitOfWork.Commit();

                            UpdateData(unitOfWork);

                            FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                        }
                    }
                    else if (treeEstimators.SelectedNode.Parent.Name.Equals("rocsGroup"))
                    {
                        AddROC809Popup popup = new AddROC809Popup();

                        DialogResult dialogResult = popup.ShowDialog();
                    }
                }
                else if (treeEstimators.SelectedNode.Level == 3)
                {
                    if (treeEstimators.SelectedNode.Parent.Parent.Name.Equals("floutecsGroup"))
                    {
                        AddFloutecLinePopup popup = new AddFloutecLinePopup();

                        DialogResult dialogResult = popup.ShowDialog();
                    }
                    else if (treeEstimators.SelectedNode.Parent.Parent.Name.Equals("rocsGroup"))
                    {
                        AddROC809PointPopup popup = new AddROC809PointPopup();

                        DialogResult dialogResult = popup.ShowDialog();
                    }
                }
            }
            else if (menuItem.Equals("menuAddMeasureLine"))
            {
                if (treeEstimators.SelectedNode.Parent.Name.Equals("floutecsGroup"))
                {
                    string[] tokens = treeEstimators.SelectedNode.Text.Split(' ');
                    int address = int.Parse(tokens[0]);

                    var floutec = floutecs.Where(f => f.Address.Equals(address)).SingleOrDefault();

                    AddFloutecLinePopup popup = new AddFloutecLinePopup();

                    popup.IsEdit = false;

                    DialogResult dialogResult = popup.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        FloutecMeasureLine line = popup.FloutecLine;
                        line.DateCreated = DateTime.Now;
                        line.DateModified = DateTime.Now;

                        floutec.MeasureLines.Add(line);

                        unitOfWork.Repository<Floutec>().Update(floutec);
                        unitOfWork.Commit();

                        UpdateData(unitOfWork);

                        FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                    }
                }
                else if (treeEstimators.SelectedNode.Parent.Name.Equals("rocsGroup"))
                {
                    AddROC809PointPopup popup = new AddROC809PointPopup();

                    DialogResult dialogResult = popup.ShowDialog();
                }
            }
            else if (menuItem.Equals("menuDelete"))
            {
                if (treeEstimators.SelectedNode.Level == 2)
                {
                    if (treeEstimators.SelectedNode.Parent.Name.Equals("floutecsGroup"))
                    {
                        string[] tokens = treeEstimators.SelectedNode.Text.Split(' ');
                        int address = int.Parse(tokens[0]);

                        var floutec = floutecs.Where(f => f.Address.Equals(address)).SingleOrDefault();

                        contextMenuEstimators.Close();

                        var confirmResult = MessageBox.Show("Вы действительно хотите удалить вычислитель ФЛОУТЭК с адресом " + floutec.Address, "Удаление вычислителя ФЛОУТЭК", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                        if (confirmResult == DialogResult.Yes)
                        {
                            unitOfWork.Repository<Floutec>().Delete(floutec.Id);
                            unitOfWork.Commit();

                            UpdateData(unitOfWork);

                            FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                        }
                    }
                    else if (treeEstimators.SelectedNode.Parent.Name.Equals("rocsGroup"))
                    {

                    }                  
                }
                else if (treeEstimators.SelectedNode.Level == 3)
                {
                    if (treeEstimators.SelectedNode.Parent.Parent.Name.Equals("floutecsGroup"))
                    {

                    }
                    else if (treeEstimators.SelectedNode.Parent.Parent.Name.Equals("rocsGroup"))
                    {

                    }
                }
            }
        }

        #endregion
    }
}
