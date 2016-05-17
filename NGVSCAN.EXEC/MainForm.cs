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
    public partial class MainForm : Form
    {
        private UnitOfWork unitOfWork;

        public MainForm()
        {
            InitializeComponent();

            unitOfWork = new UnitOfWork();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FillFloutecsTree();
        }

        private void FillFloutecsTree()
        {
            treeFloutecs.Nodes.Clear();

            var field = unitOfWork.Repository<Field>().GetAll().Where(f => f.Name.Equals("SEM-SRV")).SingleOrDefault();

            TreeNode root;

            if (field != null)
            {
                root = treeFloutecs.Nodes.Add(field.Name);

                var floutecs = unitOfWork.Repository<Floutec>().GetAll().Where(f => f.FieldId == field.Id).ToList();

                TreeNode child1;

                foreach (var floutec in floutecs)
                {
                    child1 = root.Nodes.Add(floutec.Address + " " + floutec.Name);

                    TreeNode child2;

                    var lines = unitOfWork.Repository<FloutecMeasureLine>().GetAll().Where(l => l.EstimatorId == floutec.Id);

                    foreach (var line in lines)
                    {
                        child2 = child1.Nodes.Add(line.Number + " " + line.Name);
                    }
                }
            }
        }

        private void treeFloutecs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tree = (TreeView)sender;

            if (tree.SelectedNode.Level == 0)
            {
                treeFloutecs.ContextMenuStrip.Items.Find("menuAddFloutecLine", false).SingleOrDefault().Enabled = false;
                treeFloutecs.ContextMenuStrip.Items.Find("menuAddFloutec", false).SingleOrDefault().Enabled = true;
                treeFloutecs.ContextMenuStrip.Items.Find("menuDeleteFloutec", false).SingleOrDefault().Enabled = false;

                groupFloutecsProperties.Controls.Clear();
            }
            else if (tree.SelectedNode.Level == 1)
            {
                treeFloutecs.ContextMenuStrip.Items.Find("menuAddFloutec", false).SingleOrDefault().Enabled = false;
                treeFloutecs.ContextMenuStrip.Items.Find("menuAddFloutecLine", false).SingleOrDefault().Enabled = true;
                treeFloutecs.ContextMenuStrip.Items.Find("menuDeleteFloutec", false).SingleOrDefault().Enabled = true;

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
                treeFloutecs.ContextMenuStrip.Items.Find("menuAddFloutec", false).SingleOrDefault().Enabled = false;
                treeFloutecs.ContextMenuStrip.Items.Find("menuAddFloutecLine", false).SingleOrDefault().Enabled = false;
                treeFloutecs.ContextMenuStrip.Items.Find("menuDeleteFloutec", false).SingleOrDefault().Enabled = true;

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

                    FillFloutecsTree();
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

                        FillFloutecsTree();
                    }

                    
                }
            }
        }
    }
}
