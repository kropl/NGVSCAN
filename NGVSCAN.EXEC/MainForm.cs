using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.UnitOfWork;
using NGVSCAN.EXEC.Common;
using NGVSCAN.EXEC.Controls;
using NGVSCAN.EXEC.Popups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
            Settings.Get();

            // Инициализация содержимого формы
            InitializeComponent();

            Logger.Log(listLogMessages, "Программа запущена", LogType.Info);
            Logger.Log(listLogMessages, "Проверка логирования сообщения об успешном выполнении", LogType.Success);
            Logger.Log(listLogMessages, "Программа запущена", LogType.Warning);
            Logger.Log(listLogMessages, "Программа запущена", LogType.Error);
            Logger.Log(listLogMessages, "Программа запущена", LogType.Info);
            Logger.Log(listLogMessages, "Проверка логирования сообщения об успешном выполнении", LogType.Success);
            Logger.Log(listLogMessages, "Программа запущена", LogType.Warning);
            Logger.Log(listLogMessages, "Программа запущена", LogType.Error);
            Logger.Log(listLogMessages, "Программа запущена", LogType.Info);
            Logger.Log(listLogMessages, "Проверка логирования сообщения об успешном выполнении", LogType.Success);
            Logger.Log(listLogMessages, "Программа запущена", LogType.Warning);
            Logger.Log(listLogMessages, "Программа запущена", LogType.Error);

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
                floutecs = field.Estimators.Where(e => e is Floutec).Select(e => e as Floutec).OrderBy(o => o.Address).ToList();

                rocs = field.Estimators.Where(e => e is ROC809).Select(e => e as ROC809).ToList();

                // Если коллекция вычислителей ФЛОУТЭК была определена ...
                if (floutecs != null)
                {
                    // Инициализация коллекции линий измерения вычислителей ФЛОУТЭК данной установки
                    floutecLines = new List<FloutecMeasureLine>();
                    floutecs.ForEach((f) =>
                    {
                        floutecLines.AddRange(f.MeasureLines.Select(l => l as FloutecMeasureLine).OrderBy(o => o.Number).ToList());
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
                root.Tag = field;
                root.ImageIndex = 0;
                root.SelectedImageIndex = 0;

                // Добавление двух групп для вычислителей
                TreeNode floutecsGroup = root.Nodes.Add("floutecsGroup", "Вычислители ФЛОУТЭК");
                floutecsGroup.ImageIndex = 1;
                floutecsGroup.SelectedImageIndex = 1;

                TreeNode rocsGroup = root.Nodes.Add("rocsGroup", "Вычислители ROC809");
                rocsGroup.ImageIndex = 1;
                rocsGroup.SelectedImageIndex = 1;

                // Для каждого вычислителя ФЛОУТЭК
                floutecs.ForEach((f) =>
                {
                    // Если вычислитель определён ...
                    if (f != null)
                    {
                        // Добавление вычислителя в коллекцию вложенных элементов группы вычислителей ФЛОУТЭК
                        TreeNode child = floutecsGroup.Nodes.Add(f.Address + " " + f.Name);
                        child.Tag = f;
                        child.NodeFont = f.IsDeleted ? new Font(new FontFamily("Microsoft Sans Serif"), 8, FontStyle.Strikeout) : null;
                        child.ImageIndex = 2;
                        child.SelectedImageIndex = 2;

                        // Для каждой линии измерения
                        lines.ForEach((l) =>
                        {
                            TreeNode subchild;

                            // Если линия определена и принадлежит текущему вычислителю ...
                            if (l != null && l.EstimatorId == f.Id)
                            {
                                // Добавление линии в коллекцию дочерных элементов текущего вычислителя
                                subchild = child.Nodes.Add(l.Number + " " + l.Name);
                                subchild.Tag = l;
                                subchild.NodeFont = l.IsDeleted ? new Font(new FontFamily("Microsoft Sans Serif"), 8, FontStyle.Strikeout) : null;
                                subchild.ImageIndex = 4;
                                subchild.SelectedImageIndex = 4;
                            }
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
                        child.Tag = r;
                        child.ImageIndex = 3;
                        child.SelectedImageIndex = 3;

                        // Для каждой точки измерения
                        rocPoints.ForEach((p) =>
                        {
                            TreeNode subchild;

                            // Если точка определена и принадлежит текущему вычислителю ...
                            if (p != null && p.EstimatorId == r.Id)
                            {
                                // Добавление линии в коллекцию дочерных элементов текущего вычислителя
                                subchild = child.Nodes.Add(p.Number + " " + p.Name);
                                subchild.Tag = p;
                                subchild.ImageIndex = 4;
                                subchild.SelectedImageIndex = 4;
                            }
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

            backgroundWorker.RunWorkerAsync();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker.CancelAsync();
            backgroundWorker.Dispose();
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

            Floutec selectedFloutec = null;
            FloutecMeasureLine selectedFloutecLine = null;

            if (treeEstimators.SelectedNode.Tag is Floutec)
            {
                selectedFloutec = (Floutec)treeEstimators.SelectedNode.Tag;
            }
            else if (treeEstimators.SelectedNode.Tag is FloutecMeasureLine)
            {
                selectedFloutec = (Floutec)treeEstimators.SelectedNode.Parent.Tag;
                selectedFloutecLine = (FloutecMeasureLine)treeEstimators.SelectedNode.Tag;
            }

            // Контекстное меню отображается только для всех узлов кроме установки
            e.Cancel = treeEstimators.SelectedNode.Level == 0 ? true : false;

            // Пункт меню "Добавить вычислитель" доступен только для групп вычислителей
            contextMenuEstimators.Items[0].Enabled = treeEstimators.SelectedNode.Level == 1 ? true : false;
            contextMenuEstimators.Items[0].Visible = treeEstimators.SelectedNode.Level == 1 ? true : false;

            // Пункт меню "Добавить нитку" доступен только для вычислителей, не отмеченных как удалённые
            contextMenuEstimators.Items[1].Enabled = treeEstimators.SelectedNode.Level == 2 && !selectedFloutec.IsDeleted ? true : false;
            contextMenuEstimators.Items[1].Visible = treeEstimators.SelectedNode.Level == 2 && !selectedFloutec.IsDeleted ? true : false;
            contextMenuEstimators.Items[2].Visible = treeEstimators.SelectedNode.Level == 2 && !selectedFloutec.IsDeleted ? true : false;

            // Пункт меню "Изменить" доступен для вычислителей и ниток вычислителей, не отмеченных как удалённые
            contextMenuEstimators.Items[3].Enabled = treeEstimators.SelectedNode.Level == 2 && !selectedFloutec.IsDeleted || treeEstimators.SelectedNode.Level == 3 && !selectedFloutecLine.IsDeleted ? true : false;
            contextMenuEstimators.Items[3].Visible = treeEstimators.SelectedNode.Level == 2 && !selectedFloutec.IsDeleted || treeEstimators.SelectedNode.Level == 3 && !selectedFloutecLine.IsDeleted ? true : false;
            contextMenuEstimators.Items[4].Visible = treeEstimators.SelectedNode.Level == 2 && !selectedFloutec.IsDeleted || treeEstimators.SelectedNode.Level == 3 && !selectedFloutecLine.IsDeleted ? true : false;

            // Пункт меню "Удалить" доступен для вычислителей и ниток вычислителей
            contextMenuEstimators.Items[5].Enabled = treeEstimators.SelectedNode.Level > 1 ? true : false;
            contextMenuEstimators.Items[5].Visible = treeEstimators.SelectedNode.Level > 1 ? true : false;

            // Пункт меню "Восстановить" доступен для вычислителей и ниток вычислителей, отмеченных как удалённые
            contextMenuEstimators.Items[6].Visible = treeEstimators.SelectedNode.Level == 2 && selectedFloutec.IsDeleted || treeEstimators.SelectedNode.Level == 3 && selectedFloutecLine.IsDeleted ? true : false;
            contextMenuEstimators.Items[7].Enabled = treeEstimators.SelectedNode.Level == 2 && selectedFloutec.IsDeleted || treeEstimators.SelectedNode.Level == 3 && selectedFloutecLine.IsDeleted ? true : false;
            contextMenuEstimators.Items[7].Visible = treeEstimators.SelectedNode.Level == 2 && selectedFloutec.IsDeleted || treeEstimators.SelectedNode.Level == 3 && selectedFloutecLine.IsDeleted ? true : false;
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

                        fieldDetails.Field = field;

                        groupEstimatorsProperties.Controls.Add(fieldDetails);

                        groupEstimatorsProperties.Text = "Свойства установки";

                        break;
                    }
                case 1:
                    {
                        if (treeEstimators.SelectedNode.Name.Equals("floutecsGroup"))
                        {
                            FloutecsGroupDetails floutecsGroupDetails = new FloutecsGroupDetails();

                            floutecsGroupDetails.Dock = DockStyle.Fill;

                            floutecsGroupDetails.Floutecs = floutecs;

                            groupEstimatorsProperties.Controls.Add(floutecsGroupDetails);

                            groupEstimatorsProperties.Text = "Свойства группы вычислителей ФЛОУТЭК";
                        }
                        else if (treeEstimators.SelectedNode.Name.Equals("rocsGroup"))
                        {
                            ROC809sGroupDetails rocsGroupDetails = new ROC809sGroupDetails();

                            rocsGroupDetails.Dock = DockStyle.Fill;

                            groupEstimatorsProperties.Controls.Add(rocsGroupDetails);

                            groupEstimatorsProperties.Text = "Свойства группы вычислителей ROC809";
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
                            int address = ((Floutec)treeEstimators.SelectedNode.Tag).Address;

                            // Выбор вычислителя из коллекции по адресу
                            Floutec floutec = floutecs.Where(f => f.Address == address).SingleOrDefault();

                            // Передача вычислителя в элемент управления
                            floutecDetails.Floutec = floutec;

                            // Добавление элемента управления на панель свойств
                            groupEstimatorsProperties.Controls.Add(floutecDetails);

                            groupEstimatorsProperties.Text = "Свойства вычислителя ФЛОУТЭК";
                        }
                        else if (treeEstimators.SelectedNode.Parent.Name.Equals("rocsGroup"))
                        {
                            ROC809Details rocDetails = new ROC809Details();

                            rocDetails.Dock = DockStyle.Fill;

                            groupEstimatorsProperties.Controls.Add(rocDetails);

                            groupEstimatorsProperties.Text = "Свойства вычислителя ROC809";
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

                            int address = ((Floutec)treeEstimators.SelectedNode.Parent.Tag).Address;
                            int number = ((FloutecMeasureLine)treeEstimators.SelectedNode.Tag).Number;

                            FloutecMeasureLine line = floutecLines.Where(l => l.Number == number && ((Floutec)l.Estimator).Address == address).SingleOrDefault();

                            floutecLineDetails.FloutecLine = line;

                            groupEstimatorsProperties.Controls.Add(floutecLineDetails);

                            groupEstimatorsProperties.Text = "Свойства нитки измерения вычислителя ФЛОУТЭК";
                        }
                        else if (treeEstimators.SelectedNode.Parent.Parent.Name.Equals("rocsGroup"))
                        {
                            ROC809PointDetails rocPointDetails = new ROC809PointDetails();

                            rocPointDetails.Dock = DockStyle.Fill;

                            groupEstimatorsProperties.Controls.Add(rocPointDetails);

                            groupEstimatorsProperties.Text = "Свойства точки измерения вычислителя ROC809";
                        }

                        break;
                    }
                // По умолчанию
                default:
                    groupEstimatorsProperties.Text = "Свойства";
                    break;
            }
        }

        // Событие выбора команды контекстного меню
        private void contextMenuFloutecs_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string menuItem = e.ClickedItem.Name;

            Floutec selectedFloutec = null;
            FloutecMeasureLine selectedFloutecLine = null;

            if (treeEstimators.SelectedNode.Tag is Floutec)
            {
                selectedFloutec = (Floutec)treeEstimators.SelectedNode.Tag;
            }
            else if (treeEstimators.SelectedNode.Tag is FloutecMeasureLine)
            {
                selectedFloutec = (Floutec)treeEstimators.SelectedNode.Parent.Tag;
                selectedFloutecLine = (FloutecMeasureLine)treeEstimators.SelectedNode.Tag;
            }

            if (menuItem.Equals("menuAddEstimator"))
            {
                if (treeEstimators.SelectedNode.Name.Equals("floutecsGroup"))
                {
                    AddFloutecPopup popup = new AddFloutecPopup();

                    popup.IsEdit = false;

                    popup.Floutecs = floutecs;

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

                        popup.Floutecs = floutecs;

                        popup.Floutec = selectedFloutec;

                        DialogResult dialogResult = popup.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            selectedFloutec = popup.Floutec;
                            selectedFloutec.DateModified = DateTime.Now;

                            unitOfWork.Repository<Floutec>().Update(selectedFloutec);
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

                        popup.IsEdit = true;

                        popup.FloutecLine = selectedFloutecLine;

                        popup.FloutecLines = floutecLines.Where(l => l.EstimatorId == selectedFloutec.Id).ToList();

                        DialogResult dialogResult = popup.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            selectedFloutecLine = popup.FloutecLine;
                            selectedFloutecLine.DateModified = DateTime.Now;                            

                            unitOfWork.Repository<FloutecMeasureLine>().Update(selectedFloutecLine);
                            unitOfWork.Commit();

                            UpdateData(unitOfWork);

                            FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                        }
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
                    AddFloutecLinePopup popup = new AddFloutecLinePopup();

                    popup.IsEdit = false;

                    popup.FloutecLines = floutecLines.Where(l => l.EstimatorId == selectedFloutec.Id).ToList();

                    DialogResult dialogResult = popup.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        FloutecMeasureLine line = popup.FloutecLine;
                        line.DateCreated = DateTime.Now;
                        line.DateModified = DateTime.Now;

                        selectedFloutec.MeasureLines.Add(line);

                        unitOfWork.Repository<Floutec>().Update(selectedFloutec);
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
                        contextMenuEstimators.Close();

                        if (selectedFloutec.IsDeleted)
                        {
                            var confirmResult = MessageBox.Show(
                                "Вы действительно хотите удалить вычислитель ФЛОУТЭК с адресом " + 
                                selectedFloutec.Address + "? Вычислитель и его нитки будут удалены без возможности восстановления", 
                                "Удаление вычислителя ФЛОУТЭК", 
                                MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Warning, 
                                MessageBoxDefaultButton.Button2);

                            if (confirmResult == DialogResult.Yes)
                            {
                                unitOfWork.Repository<Floutec>().Delete(selectedFloutec.Id);

                                unitOfWork.Commit();

                                UpdateData(unitOfWork);

                                FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                            }
                        }
                        else
                        {
                            var confirmResult = MessageBox.Show(
                                "Вы действительно хотите отметить вычислитель ФЛОУТЭК с адресом " +
                                selectedFloutec.Address + " как удалённый? Вычислитель и его нитки будут изъяты из очереди опроса с возможностью восстановления",
                                "Удаление вычислителя ФЛОУТЭК",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);

                            if (confirmResult == DialogResult.Yes)
                            {
                                selectedFloutec.IsDeleted = true;
                                selectedFloutec.DateDeleted = DateTime.Now;
                                unitOfWork.Repository<Floutec>().Update(selectedFloutec);

                                unitOfWork.Commit();

                                UpdateData(unitOfWork);

                                FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                            }
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
                        contextMenuEstimators.Close();

                        if (selectedFloutecLine.IsDeleted)
                        {
                            var confirmResult = MessageBox.Show(
                                "Вы действительно хотите удалить нитку измерения №" + selectedFloutecLine.Number + " вычислителя ФЛОУТЭК с адресом " +
                                selectedFloutec.Address + "? Нитка будет удалена без возможности восстановления",
                                "Удаление нитки вычислителя ФЛОУТЭК",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);

                            if (confirmResult == DialogResult.Yes)
                            {
                                unitOfWork.Repository<FloutecMeasureLine>().Delete(selectedFloutecLine.Id);

                                unitOfWork.Commit();

                                UpdateData(unitOfWork);

                                FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                            }
                        }
                        else
                        {
                            var confirmResult = MessageBox.Show(
                                "Вы действительно хотите отметить нитку измерения №" + selectedFloutecLine.Number + " вычислителя ФЛОУТЭК с адресом " +
                                selectedFloutec.Address + " как удалённую? Нитка будет изъята из очереди опроса с возможностью восстановления",
                                "Удаление вычислителя ФЛОУТЭК",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);

                            if (confirmResult == DialogResult.Yes)
                            {
                                selectedFloutecLine.IsDeleted = true;
                                selectedFloutecLine.DateDeleted = DateTime.Now;
                                unitOfWork.Repository<FloutecMeasureLine>().Update(selectedFloutecLine);

                                unitOfWork.Commit();

                                UpdateData(unitOfWork);

                                FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                            }
                        }
                    }
                    else if (treeEstimators.SelectedNode.Parent.Parent.Name.Equals("rocsGroup"))
                    {

                    }
                }
            }
            else if (menuItem.Equals("menuRestore"))
            {
                if (treeEstimators.SelectedNode.Level == 2)
                {
                    if (treeEstimators.SelectedNode.Parent.Name.Equals("floutecsGroup"))
                    {
                        contextMenuEstimators.Close();

                        selectedFloutec.IsDeleted = false;
                        unitOfWork.Repository<Floutec>().Update(selectedFloutec);

                        unitOfWork.Commit();

                        UpdateData(unitOfWork);

                        FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                    }
                    else if (treeEstimators.SelectedNode.Parent.Name.Equals("rocsGroup"))
                    {

                    }
                }
                else if (treeEstimators.SelectedNode.Level == 3)
                {
                    if (treeEstimators.SelectedNode.Parent.Parent.Name.Equals("floutecsGroup"))
                    {
                        contextMenuEstimators.Close();

                        selectedFloutecLine.IsDeleted = false;
                        unitOfWork.Repository<FloutecMeasureLine>().Update(selectedFloutecLine);

                        unitOfWork.Commit();

                        UpdateData(unitOfWork);

                        FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                    }
                    else if (treeEstimators.SelectedNode.Parent.Parent.Name.Equals("rocsGroup"))
                    {

                    }
                }
            }
        }

        private void menuSettings_Click(object sender, EventArgs e)
        {
            SettingsPopup popup = new SettingsPopup();

            DialogResult dialogResult = popup.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                Logger.Log(listLogMessages, "Были изменены настройки", LogType.Info);
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            AboutPopup popup = new AboutPopup();

            DialogResult dialogResult = popup.ShowDialog();
        }

        #endregion

        #region Выполнение бизнес-логики

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            FloutecIdentData identData = unitOfWork.FloutecIdentDataRepository.Get(127, 1);

            Debug.WriteLine(DateTime.Now);

            List<FloutecHourlyData> hourlyData = unitOfWork.FloutecHourlyDataRepository.Get(127, 1, new DateTime(2014, 4, 14, 12, 0, 0), new DateTime(2014, 4, 15, 12, 0, 0));

            Debug.WriteLine(DateTime.Now);

            while (true)
            {
                //Debug.WriteLine(DateTime.Now.TimeOfDay);
            }
        }

        #endregion
    }
}
