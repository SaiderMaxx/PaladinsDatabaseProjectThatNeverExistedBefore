using PaladinsDatabaseProject.Controller;
using PaladinsDatabaseProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaladinsDatabaseProject.View
{
    public partial class FrontPageView : Form
    {
        PaladinsController paladinsController = new PaladinsController();
        public FrontPageView()
        {
            InitializeComponent();
        }

        private void RefreshTable()
        {
            dgvChampions.DataSource = paladinsController.GetAllChampions();
        }
        private void FrontPage_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Champion champion = new Champion();
            champion.Name = txtName.Text;
            champion.Level = int.Parse(txtLevel.Text);
            paladinsController.AddChampion(champion);
            RefreshTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvChampions.CurrentRow;
            int id = int.Parse(row.Cells[0].Value.ToString());
            Champion champion = new Champion();
            champion.Name = txtName.Text;
            champion.Level = int.Parse(txtLevel.Text);
            paladinsController.UpdateChampion(id, champion);
            RefreshTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvChampions.CurrentRow;
            int id = int.Parse(row.Cells[0].Value.ToString());
            paladinsController.DeleteChampion(id);
            RefreshTable();
        }
    }
}
