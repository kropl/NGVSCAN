using NGVSCAN.CORE.Entities;
using NGVSCAN.CORE.Entities.Floutecs;
using NGVSCAN.CORE.Entities.ROC809s;
using NGVSCAN.DAL.Repositories;
using NGVSCAN.EXEC.Common;
using NGVSCAN.EXEC.Controls;
using NGVSCAN.EXEC.Popups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NGVSCAN.EXEC.Scanners;

namespace NGVSCAN.EXEC
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        #region Конструктор и поля

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

        private string sqlConnection;

        Timer scanTimer;

        //Scanner scanner;
        FloutecScanner floutecScanner;
        ROC809Scanner rocScanner;

        // Конструктор формы
        public MainForm()
        {
            Settings.Get();

            // Инициализация содержимого формы
            InitializeComponent();

            InitializeSqlConnection();

            // Обновление данных
            UpdateData();

            scanTimer = new Timer();

            //scanner = new Scanner(sqlConnection);
            floutecScanner = new FloutecScanner(listLogMessages);
            rocScanner = new ROC809Scanner(listLogMessages);

            string[] args = Environment.GetCommandLineArgs();

            if (args.Contains("start"))
                menuRun_Click(this, new EventArgs());
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }

        private void ShowMe()
        {
            Show();

            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        #endregion

        #region Вспомогательные методы

        private void InitializeSqlConnection()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = Settings.SqlServerPath;
            sb.InitialCatalog = Settings.SqlDatabaseName;
            if (string.IsNullOrEmpty(Settings.SqlUserName) || string.IsNullOrEmpty(Settings.SqlUserPassword))
                sb.IntegratedSecurity = true;
            else
            {
                sb.IntegratedSecurity = false;
                sb.UserID = Settings.SqlUserName;
                sb.Password = Settings.SqlUserPassword;
            }
            sb.MultipleActiveResultSets = true;

            sqlConnection = sb.ToString();
        }

        /// <summary>
        /// Обновление данных
        /// </summary>
        private void UpdateData()
        {
            try
            {
                using (SqlRepository<Field> repo = new SqlRepository<Field>(sqlConnection))
                {
                    // Инициализация установки
                    field = repo.GetAll().Where(f => f.Name.Equals(Settings.ServerName)).SingleOrDefault();

                    // Если установка была определена ...
                    if (field != null)
                    {
                        // Инициализация коллекции вычислителей ФЛОУТЭК данной установки
                        floutecs = field.Estimators.Where(e => e is Floutec).Select(e => e as Floutec).OrderBy(o => o.Address).ToList();

                        rocs = field.Estimators.Where(e => e is ROC809).Select(e => e as ROC809).OrderBy(o => o.Address).ToList();

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
                                rocPoints.AddRange(r.MeasureLines.Select(p => p as ROC809MeasurePoint).OrderBy(o => o.HistSegment).OrderBy(o => o.Number).ToList());
                            });
                        }
                    }
                    else
                    {
                        Logger.Log(listLogMessages, new LogEntry { Message = "Указанная установка отсутствует в базе данных", Status = LogStatus.Error, Type = LogType.System, Timestamp = DateTime.Now });
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.System, Timestamp = DateTime.Now });
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
                        TreeNode child = rocsGroup.Nodes.Add(r.Address + " " + r.Name);
                        child.Tag = r;
                        child.NodeFont = r.IsDeleted ? new Font(new FontFamily("Microsoft Sans Serif"), 8, FontStyle.Strikeout) : null;
                        child.ImageIndex = 3;
                        child.SelectedImageIndex = 3;

                        // Для каждой точки измерения
                        rocPoints.ForEach((p) =>
                        {
                            TreeNode subchild;

                            // Если точка определена и принадлежит текущему вычислителю ...
                            if (p != null && p.EstimatorId == r.Id)
                            {
                                // Добавление точки в коллекцию дочерных элементов текущего вычислителя
                                subchild = child.Nodes.Add(p.HistSegment + " " + p.Number + " " + p.Name);
                                subchild.Tag = p;
                                subchild.NodeFont = p.IsDeleted ? new Font(new FontFamily("Microsoft Sans Serif"), 8, FontStyle.Strikeout) : null;
                                subchild.ImageIndex = 4;
                                subchild.SelectedImageIndex = 4;
                            }
                        });
                    }
                });

                treeEstimators.ExpandAll();
            }
            else
            {
                
            }
        }

        #endregion       

        #region События формы

        // Событие загрузки главной формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Заполнение дерева объектов на закладке вычислителей ФЛОУТЭК
            FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);

            //backgroundWorker.RunWorkerAsync();

            
            scanTimer.Interval = 30000;
            scanTimer.Tick += scanner_Tick;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
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

            Estimator selectedEstimator = null;
            MeasureLine selectedMeasureLine = null;

            if (treeEstimators.SelectedNode.Tag is Estimator)
            {
                selectedEstimator = (Estimator)treeEstimators.SelectedNode.Tag;
            }
            else if (treeEstimators.SelectedNode.Tag is MeasureLine)
            {
                selectedEstimator = (Estimator)treeEstimators.SelectedNode.Parent.Tag;
                selectedMeasureLine = (MeasureLine)treeEstimators.SelectedNode.Tag;
            }

            // Контекстное меню отображается только для всех узлов кроме установки
            e.Cancel = treeEstimators.SelectedNode.Level == 0 ? true : false;

            // Пункт меню "Добавить вычислитель" доступен только для групп вычислителей
            contextMenuEstimators.Items[0].Enabled = treeEstimators.SelectedNode.Level == 1 ? true : false;
            contextMenuEstimators.Items[0].Visible = treeEstimators.SelectedNode.Level == 1 ? true : false;

            // Пункт меню "Добавить нитку" доступен только для вычислителей, не отмеченных как удалённые
            contextMenuEstimators.Items[1].Text = treeEstimators.SelectedNode.Tag is Floutec ? "Добавить нитку" : "Добавить точку";
            contextMenuEstimators.Items[1].Enabled = treeEstimators.SelectedNode.Level == 2 && !selectedEstimator.IsDeleted ? true : false;
            contextMenuEstimators.Items[1].Visible = treeEstimators.SelectedNode.Level == 2 && !selectedEstimator.IsDeleted ? true : false;
            contextMenuEstimators.Items[2].Visible = treeEstimators.SelectedNode.Level == 2 && !selectedEstimator.IsDeleted ? true : false;

            // Пункт меню "Изменить" доступен для вычислителей и ниток вычислителей, не отмеченных как удалённые
            contextMenuEstimators.Items[3].Enabled = treeEstimators.SelectedNode.Level == 2 && !selectedEstimator.IsDeleted || treeEstimators.SelectedNode.Level == 3 && !selectedMeasureLine.IsDeleted ? true : false;
            contextMenuEstimators.Items[3].Visible = treeEstimators.SelectedNode.Level == 2 && !selectedEstimator.IsDeleted || treeEstimators.SelectedNode.Level == 3 && !selectedMeasureLine.IsDeleted ? true : false;

            contextMenuEstimators.Items[4].Visible = treeEstimators.SelectedNode.Level == 2 && !selectedEstimator.IsDeleted || 
                treeEstimators.SelectedNode.Level == 3 && !selectedMeasureLine.IsDeleted ? true : false;

            // Пункт меню "Удалить" доступен для вычислителей и ниток вычислителей
            contextMenuEstimators.Items[5].Enabled = treeEstimators.SelectedNode.Level == 2 && !selectedEstimator.IsDeleted || 
                treeEstimators.SelectedNode.Level == 2 && selectedEstimator.IsDeleted && ModifierKeys == Keys.Shift || 
                treeEstimators.SelectedNode.Level == 3 && !selectedMeasureLine.IsDeleted ||
                treeEstimators.SelectedNode.Level == 3 && selectedMeasureLine.IsDeleted && ModifierKeys == Keys.Shift ? true : false;
            contextMenuEstimators.Items[5].Visible = treeEstimators.SelectedNode.Level == 2 && !selectedEstimator.IsDeleted ||
                treeEstimators.SelectedNode.Level == 2 && selectedEstimator.IsDeleted && ModifierKeys == Keys.Shift ||
                treeEstimators.SelectedNode.Level == 3 && !selectedMeasureLine.IsDeleted ||
                treeEstimators.SelectedNode.Level == 3 && selectedMeasureLine.IsDeleted && ModifierKeys == Keys.Shift ? true : false;

            // Пункт меню "Восстановить" доступен для вычислителей и ниток вычислителей, отмеченных как удалённые
            contextMenuEstimators.Items[6].Visible = (treeEstimators.SelectedNode.Level == 2 && selectedEstimator.IsDeleted && ModifierKeys == Keys.Shift) || 
                (treeEstimators.SelectedNode.Level == 3 && selectedMeasureLine.IsDeleted && ModifierKeys == Keys.Shift) ? true : false;

            contextMenuEstimators.Items[7].Enabled = treeEstimators.SelectedNode.Level == 2 && selectedEstimator.IsDeleted || treeEstimators.SelectedNode.Level == 3 && selectedMeasureLine.IsDeleted ? true : false;
            contextMenuEstimators.Items[7].Visible = treeEstimators.SelectedNode.Level == 2 && selectedEstimator.IsDeleted || treeEstimators.SelectedNode.Level == 3 && selectedMeasureLine.IsDeleted ? true : false;
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

                            rocsGroupDetails.ROCs = rocs;

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
                            rocDetails.AutoSize = true;

                            int id = ((ROC809)treeEstimators.SelectedNode.Tag).Id;

                            ROC809 roc = rocs.Where(r => r.Id == id).SingleOrDefault();

                            rocDetails.ROC = roc;

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

                            int rocId = ((ROC809)treeEstimators.SelectedNode.Parent.Tag).Id;
                            int pointId = ((ROC809MeasurePoint)treeEstimators.SelectedNode.Tag).Id;

                            ROC809MeasurePoint point = rocPoints.Where(p => p.Id == pointId && p.EstimatorId == rocId).SingleOrDefault();

                            rocPointDetails.ROCPoint = point;

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
            ROC809 selectedROC = null;
            ROC809MeasurePoint selectedROCPoint = null;

            if (treeEstimators.SelectedNode.Tag is Floutec)
            {
                selectedFloutec = (Floutec)treeEstimators.SelectedNode.Tag;
            }
            else if (treeEstimators.SelectedNode.Tag is FloutecMeasureLine)
            {
                selectedFloutec = (Floutec)treeEstimators.SelectedNode.Parent.Tag;
                selectedFloutecLine = (FloutecMeasureLine)treeEstimators.SelectedNode.Tag;
            }
            else if (treeEstimators.SelectedNode.Tag is ROC809)
            {
                selectedROC = (ROC809)treeEstimators.SelectedNode.Tag;
            }
            else if (treeEstimators.SelectedNode.Tag is ROC809MeasurePoint)
            {
                selectedROC = (ROC809)treeEstimators.SelectedNode.Parent.Tag;
                selectedROCPoint = (ROC809MeasurePoint)treeEstimators.SelectedNode.Tag;
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

                        try
                        {
                            using (SqlRepository<Field> repo = new SqlRepository<Field>(sqlConnection))
                            {
                                Field existingField = repo.Get(field.Id);
                                existingField.Estimators.Add(floutec);
                                repo.Update(existingField);
                            }
                        }
                        catch(Exception ex)
                        {
                            Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.Floutec, Timestamp = DateTime.Now });
                        }

                        UpdateData();

                        FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                    }
                }
                else if (treeEstimators.SelectedNode.Name.Equals("rocsGroup"))
                {
                    AddROC809Popup popup = new AddROC809Popup();

                    popup.IsEdit = false;

                    popup.ROC809s = rocs;

                    DialogResult dialogResult = popup.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        ROC809 roc = popup.ROC809;
                        roc.DateCreated = DateTime.Now;
                        roc.DateModified = DateTime.Now;

                        try
                        {
                            using (SqlRepository<Field> repo = new SqlRepository<Field>(sqlConnection))
                            {
                                Field existingField = repo.Get(field.Id);
                                existingField.Estimators.Add(roc);
                                repo.Update(existingField);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.ROC, Timestamp = DateTime.Now });
                        }

                        UpdateData();

                        FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                    }
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

                            try
                            {
                                using (SqlRepository<Floutec> repo = new SqlRepository<Floutec>(sqlConnection))
                                {
                                    repo.Update(selectedFloutec);
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.Floutec, Timestamp = DateTime.Now });
                            }

                            UpdateData();

                            FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                        }
                    }
                    else if (treeEstimators.SelectedNode.Parent.Name.Equals("rocsGroup"))
                    {
                        AddROC809Popup popup = new AddROC809Popup();

                        popup.IsEdit = true;

                        popup.ROC809s = rocs;

                        popup.ROC809 = selectedROC;

                        DialogResult dialogResult = popup.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            selectedROC = popup.ROC809;
                            selectedROC.DateModified = DateTime.Now;

                            try
                            {
                                using (SqlRepository<ROC809> repo = new SqlRepository<ROC809>(sqlConnection))
                                {
                                    repo.Update(selectedROC);
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.ROC, Timestamp = DateTime.Now });
                            }

                            UpdateData();

                            FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                        }
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

                            try
                            {
                                using (SqlRepository<FloutecMeasureLine> repo = new SqlRepository<FloutecMeasureLine>(sqlConnection))
                                {
                                    repo.Update(selectedFloutecLine);
                                }
                            }
                            catch(Exception ex)
                            {
                                Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.Floutec, Timestamp = DateTime.Now });
                            }

                            UpdateData();

                            FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                        }
                    }
                    else if (treeEstimators.SelectedNode.Parent.Parent.Name.Equals("rocsGroup"))
                    {
                        AddROC809PointPopup popup = new AddROC809PointPopup();

                        popup.IsEdit = true;

                        popup.ROCPoint = selectedROCPoint;

                        popup.ROCPoints = rocPoints.Where(p => p.EstimatorId == selectedROC.Id).ToList();

                        DialogResult dialogResult = popup.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            selectedROCPoint = popup.ROCPoint;
                            selectedROCPoint.DateModified = DateTime.Now;

                            try
                            {
                                using (SqlRepository<ROC809MeasurePoint> repo = new SqlRepository<ROC809MeasurePoint>(sqlConnection))
                                {
                                    repo.Update(selectedROCPoint);
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.ROC, Timestamp = DateTime.Now });
                            }

                            UpdateData();

                            FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                        }
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

                        try
                        {
                            using (SqlRepository<Floutec> repo = new SqlRepository<Floutec>(sqlConnection))
                            {
                                Floutec existingFloutec = repo.Get(selectedFloutec.Id);
                                existingFloutec.MeasureLines.Add(line);
                                repo.Update(existingFloutec);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.Floutec, Timestamp = DateTime.Now });
                        }

                        UpdateData();

                        FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                    }
                }
                else if (treeEstimators.SelectedNode.Parent.Name.Equals("rocsGroup"))
                {
                    AddROC809PointPopup popup = new AddROC809PointPopup();

                    popup.IsEdit = false;

                    popup.ROCPoints = rocPoints.Where(p => p.EstimatorId == selectedROC.Id).ToList();

                    DialogResult dialogResult = popup.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        ROC809MeasurePoint point = popup.ROCPoint;
                        point.DateCreated = DateTime.Now;
                        point.DateModified = DateTime.Now;

                        try
                        {
                            using (SqlRepository<ROC809> repo = new SqlRepository<ROC809>(sqlConnection))
                            {
                                ROC809 existingROC = repo.Get(selectedROC.Id);
                                existingROC.MeasureLines.Add(point);
                                repo.Update(existingROC);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.ROC, Timestamp = DateTime.Now });
                        }

                        UpdateData();

                        FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                    }
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
                                try
                                {
                                    using (SqlRepository<FloutecHourlyData> repo1 = new SqlRepository<FloutecHourlyData>(sqlConnection))
                                    using (SqlRepository<FloutecInstantData> repo2 = new SqlRepository<FloutecInstantData>(sqlConnection))
                                    using (SqlRepository<FloutecIdentData> repo3 = new SqlRepository<FloutecIdentData>(sqlConnection))
                                    using (SqlRepository<FloutecAlarmData> repo4 = new SqlRepository<FloutecAlarmData>(sqlConnection))
                                    using (SqlRepository<FloutecInterData> repo5 = new SqlRepository<FloutecInterData>(sqlConnection))
                                    using (SqlRepository<FloutecMeasureLine> repo6 = new SqlRepository<FloutecMeasureLine>(sqlConnection))
                                    using (SqlRepository<Floutec> repo7 = new SqlRepository<Floutec>(sqlConnection))
                                    {
                                        repo1.Delete(repo1.GetAll().Where(d => d.MeasureLine.EstimatorId == selectedFloutec.Id));
                                        repo2.Delete(repo2.GetAll().Where(d => d.MeasureLine.EstimatorId == selectedFloutec.Id));
                                        repo3.Delete(repo3.GetAll().Where(d => d.MeasureLine.EstimatorId == selectedFloutec.Id));
                                        repo4.Delete(repo4.GetAll().Where(d => d.MeasureLine.EstimatorId == selectedFloutec.Id));
                                        repo5.Delete(repo5.GetAll().Where(d => d.MeasureLine.EstimatorId == selectedFloutec.Id));
                                        repo6.Delete(repo6.GetAll().Where(l => l.EstimatorId == selectedFloutec.Id));
                                        repo7.Delete(selectedFloutec.Id);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.Floutec, Timestamp = DateTime.Now });
                                }

                                UpdateData();

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

                                try
                                {
                                    using (SqlRepository<Floutec> repo = new SqlRepository<Floutec>(sqlConnection))
                                    {
                                        repo.Update(selectedFloutec);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.Floutec, Timestamp = DateTime.Now });
                                }

                                UpdateData();

                                FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                            }
                        }
                    }
                    else if (treeEstimators.SelectedNode.Parent.Name.Equals("rocsGroup"))
                    {
                        contextMenuEstimators.Close();

                        if (selectedROC.IsDeleted)
                        {
                            var confirmResult = MessageBox.Show(
                                "Вы действительно хотите удалить вычислитель ROC809 с адресом " +
                                selectedROC.Address + "? Вычислитель и его точки будут удалены без возможности восстановления",
                                "Удаление вычислителя ROC809",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);

                            if (confirmResult == DialogResult.Yes)
                            {
                                try
                                {
                                    using (SqlRepository<ROC809MinuteData> repo1 = new SqlRepository<ROC809MinuteData>(sqlConnection))
                                    using (SqlRepository<ROC809PeriodicData> repo2 = new SqlRepository<ROC809PeriodicData>(sqlConnection))
                                    using (SqlRepository<ROC809DailyData> repo3 = new SqlRepository<ROC809DailyData>(sqlConnection))
                                    using (SqlRepository<ROC809MeasurePoint> repo4 = new SqlRepository<ROC809MeasurePoint>(sqlConnection))
                                    using (SqlRepository<ROC809EventData> repo5 = new SqlRepository<ROC809EventData>(sqlConnection))
                                    using (SqlRepository<ROC809AlarmData> repo6 = new SqlRepository<ROC809AlarmData>(sqlConnection))
                                    using (SqlRepository<ROC809> repo7 = new SqlRepository<ROC809>(sqlConnection))
                                    {
                                        repo1.Delete(repo1.GetAll().Where(d => d.MeasurePoint.EstimatorId == selectedROC.Id));
                                        repo2.Delete(repo2.GetAll().Where(d => d.MeasurePoint.EstimatorId == selectedROC.Id));
                                        repo3.Delete(repo3.GetAll().Where(d => d.MeasurePoint.EstimatorId == selectedROC.Id));
                                        repo4.Delete(repo4.GetAll().Where(p => p.EstimatorId == selectedROC.Id));
                                        repo5.Delete(repo5.GetAll().Where(d => d.ROC809Id == selectedROC.Id));
                                        repo6.Delete(repo6.GetAll().Where(d => d.ROC809Id == selectedROC.Id));
                                        repo7.Delete(selectedROC.Id);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.ROC, Timestamp = DateTime.Now });
                                }

                                UpdateData();

                                FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                            }
                        }
                        else
                        {
                            var confirmResult = MessageBox.Show(
                                "Вы действительно хотите отметить вычислитель ROC809 с адресом " +
                                selectedROC.Address + " как удалённый? Вычислитель и его точки будут изъяты из очереди опроса с возможностью восстановления",
                                "Удаление вычислителя ROC809",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);

                            if (confirmResult == DialogResult.Yes)
                            {
                                selectedROC.IsDeleted = true;
                                selectedROC.DateDeleted = DateTime.Now;

                                try
                                {
                                    using (SqlRepository<ROC809> repo = new SqlRepository<ROC809>(sqlConnection))
                                    {
                                        repo.Update(selectedROC);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.ROC, Timestamp = DateTime.Now });
                                }

                                UpdateData();

                                FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                            }
                        }
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
                                try
                                {
                                    using (SqlRepository<FloutecHourlyData> repo1 = new SqlRepository<FloutecHourlyData>(sqlConnection))
                                    using (SqlRepository<FloutecInstantData> repo2 = new SqlRepository<FloutecInstantData>(sqlConnection))
                                    using (SqlRepository<FloutecIdentData> repo3 = new SqlRepository<FloutecIdentData>(sqlConnection))
                                    using (SqlRepository<FloutecAlarmData> repo4 = new SqlRepository<FloutecAlarmData>(sqlConnection))
                                    using (SqlRepository<FloutecInterData> repo5 = new SqlRepository<FloutecInterData>(sqlConnection))
                                    using (SqlRepository<FloutecMeasureLine> repo6 = new SqlRepository<FloutecMeasureLine>(sqlConnection))
                                    {
                                        repo1.Delete(repo1.GetAll().Where(d => d.FloutecMeasureLineId == selectedFloutecLine.Id));
                                        repo2.Delete(repo2.GetAll().Where(d => d.FloutecMeasureLineId == selectedFloutecLine.Id));
                                        repo3.Delete(repo3.GetAll().Where(d => d.FloutecMeasureLineId == selectedFloutecLine.Id));
                                        repo4.Delete(repo4.GetAll().Where(d => d.FloutecMeasureLineId == selectedFloutecLine.Id));
                                        repo5.Delete(repo5.GetAll().Where(d => d.FloutecMeasureLineId == selectedFloutecLine.Id));
                                        repo6.Delete(selectedFloutecLine.Id);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.Floutec, Timestamp = DateTime.Now });
                                }

                                UpdateData();

                                FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                            }
                        }
                        else
                        {
                            var confirmResult = MessageBox.Show(
                                "Вы действительно хотите отметить нитку измерения №" + selectedFloutecLine.Number + " вычислителя ФЛОУТЭК с адресом " +
                                selectedFloutec.Address + " как удалённую? Нитка будет изъята из очереди опроса с возможностью восстановления",
                                "Удаление нитки вычислителя ФЛОУТЭК",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);

                            if (confirmResult == DialogResult.Yes)
                            {
                                selectedFloutecLine.IsDeleted = true;
                                selectedFloutecLine.DateDeleted = DateTime.Now;

                                try
                                {
                                    using (SqlRepository<FloutecMeasureLine> repo = new SqlRepository<FloutecMeasureLine>(sqlConnection))
                                    {
                                        repo.Update(selectedFloutecLine);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.Floutec, Timestamp = DateTime.Now });
                                }

                                UpdateData();

                                FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                            }
                        }
                    }
                    else if (treeEstimators.SelectedNode.Parent.Parent.Name.Equals("rocsGroup"))
                    {
                        contextMenuEstimators.Close();

                        if (selectedROCPoint.IsDeleted)
                        {
                            var confirmResult = MessageBox.Show(
                                "Вы действительно хотите удалить точку измерения №" + selectedROCPoint.Number + " в историческом сегменте №" + selectedROCPoint.HistSegment + " вычислителя ROC809 с адресом " +
                                selectedROC.Address + "? Точка будет удалена без возможности восстановления",
                                "Удаление точки вычислителя ROC809",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);

                            if (confirmResult == DialogResult.Yes)
                            {
                                try
                                {
                                    using (SqlRepository<ROC809MinuteData> repo1 = new SqlRepository<ROC809MinuteData>(sqlConnection))
                                    using (SqlRepository<ROC809PeriodicData> repo2 = new SqlRepository<ROC809PeriodicData>(sqlConnection))
                                    using (SqlRepository<ROC809DailyData> repo3 = new SqlRepository<ROC809DailyData>(sqlConnection))
                                    using (SqlRepository<ROC809MeasurePoint> repo4 = new SqlRepository<ROC809MeasurePoint>(sqlConnection))
                                    {
                                        repo1.Delete(repo1.GetAll().Where(d => d.ROC809MeasurePointId == selectedROCPoint.Id));
                                        repo2.Delete(repo2.GetAll().Where(d => d.ROC809MeasurePointId == selectedROCPoint.Id));
                                        repo3.Delete(repo3.GetAll().Where(d => d.ROC809MeasurePointId == selectedROCPoint.Id));
                                        repo4.Delete(selectedROCPoint.Id);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.ROC, Timestamp = DateTime.Now });
                                }

                                UpdateData();

                                FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                            }
                        }
                        else
                        {
                            var confirmResult = MessageBox.Show(
                                "Вы действительно хотите отметить точку измерения №" + selectedROCPoint.Number + " в историческом сегменте №" + selectedROCPoint.HistSegment + " вычислителя ROC809 с адресом " +
                                selectedROC.Address + " как удалённую? Точка будет изъята из очереди опроса с возможностью восстановления",
                                "Удаление точки вычислителя ROC809",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);

                            if (confirmResult == DialogResult.Yes)
                            {
                                selectedROCPoint.IsDeleted = true;
                                selectedROCPoint.DateDeleted = DateTime.Now;

                                try
                                {
                                    using (SqlRepository<ROC809MeasurePoint> repo = new SqlRepository<ROC809MeasurePoint>(sqlConnection))
                                    {
                                        repo.Update(selectedROCPoint);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.ROC, Timestamp = DateTime.Now });
                                }

                                UpdateData();

                                FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                            }
                        }
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

                        try
                        {
                            using (SqlRepository<Floutec> repo = new SqlRepository<Floutec>(sqlConnection))
                            {
                                repo.Update(selectedFloutec);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.Floutec, Timestamp = DateTime.Now });
                        }

                        UpdateData();

                        FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                    }
                    else if (treeEstimators.SelectedNode.Parent.Name.Equals("rocsGroup"))
                    {
                        contextMenuEstimators.Close();

                        selectedROC.IsDeleted = false;

                        try
                        {
                            using (SqlRepository<ROC809> repo = new SqlRepository<ROC809>(sqlConnection))
                            {
                                repo.Update(selectedROC);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.ROC, Timestamp = DateTime.Now });
                        }

                        UpdateData();

                        FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                    }
                }
                else if (treeEstimators.SelectedNode.Level == 3)
                {
                    if (treeEstimators.SelectedNode.Parent.Parent.Name.Equals("floutecsGroup"))
                    {
                        contextMenuEstimators.Close();

                        selectedFloutecLine.IsDeleted = false;

                        try
                        {
                            using (SqlRepository<FloutecMeasureLine> repo = new SqlRepository<FloutecMeasureLine>(sqlConnection))
                            {
                                repo.Update(selectedFloutecLine);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.Floutec, Timestamp = DateTime.Now });
                        }

                        UpdateData();

                        FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                    }
                    else if (treeEstimators.SelectedNode.Parent.Parent.Name.Equals("rocsGroup"))
                    {
                        contextMenuEstimators.Close();

                        selectedROCPoint.IsDeleted = false;

                        try
                        {
                            using (SqlRepository<ROC809MeasurePoint> repo = new SqlRepository<ROC809MeasurePoint>(sqlConnection))
                            {
                                repo.Update(selectedROCPoint);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(listLogMessages, new LogEntry { Message = ex.Message, Status = LogStatus.Error, Type = LogType.ROC, Timestamp = DateTime.Now });
                        }

                        UpdateData();

                        FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
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
                Logger.Log(listLogMessages, new LogEntry { Message = "Были изменены настройки", Status = LogStatus.Info, Type = LogType.System, Timestamp = DateTime.Now });

                InitializeSqlConnection();
                UpdateData();
                FillFloutecsTree(field, floutecs, floutecLines, rocs, rocPoints);
                //scanner = new Scanner(sqlConnection);
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            AboutPopup popup = new AboutPopup();

            DialogResult dialogResult = popup.ShowDialog();
        }

        private void menuRun_Click(object sender, EventArgs e)
        {
            menuRun.Visible = false;
            menuStop.Visible = true;

            contextMenuEstimators.Enabled = false;
            menuSettings.Enabled = false;

            scanTimer.Start();

            Logger.Log(listLogMessages, new LogEntry { Message = "Опрос запущен", Status = LogStatus.Info, Type = LogType.System, Timestamp = DateTime.Now });
        }

        private void menuStop_Click(object sender, EventArgs e)
        {
            menuStop.Visible = false;
            menuRun.Visible = true;

            scanTimer.Stop();

            contextMenuEstimators.Enabled = true;
            menuSettings.Enabled = true;

            Logger.Log(listLogMessages, new LogEntry { Message = "Опрос остановлен", Status = LogStatus.Info, Type = LogType.System, Timestamp = DateTime.Now });
        } 

        #endregion

        #region Выполнение бизнес-логики

        private void scanner_Tick(object sender, EventArgs e)
        {
            if (field != null)
            {
                floutecScanner.Process(field.Id, sqlConnection, Settings.DbfTablesPath);
                rocScanner.Process(field.Id, sqlConnection);
            }
                //scanner.Process(listLogMessages, field);       
        }

        #endregion

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                                "Вы действительно хотите выйти из программы?",
                                "Выход",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowMe();
        }
    }
}
