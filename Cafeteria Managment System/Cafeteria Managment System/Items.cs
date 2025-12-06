using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cafeteria_Managment_System {
    public partial class Items : Form {
        ConnectionFunction confunc;
        public Items() {
            InitializeComponent();
            confunc = new ConnectionFunction();
            ShowItems();
            GetCategories();
        }
        private void ShowItems() {
            try {
                string Query = "select itemCode, ItemName,cast(round(ItemPrice, 2) as decimal(10, 2)) as ItemPrice,ItemCat ,CatName from Item join cat on Item.ItemCat = Cat.CatCode";
                ItemsDG.DataSource = confunc.GetData(Query);
            } catch (Exception exception) {
                MessageBox.Show($"Couldn't retrive data \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetCategories() {
            string Query = "select * from Cat";
            CategoriesCB.ValueMember = confunc.GetData(Query).Columns["CatCode"].ToString();
            CategoriesCB.DisplayMember = confunc.GetData(Query).Columns["CatName"].ToString();
            CategoriesCB.DataSource = confunc.GetData(Query);
            ItemsDG.Columns["ItemCat"].Visible = false;
        }

        private void AdditmBtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(NameTB.Text)) {
                MessageBox.Show("Name field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(PriceTB.Text)) {
                MessageBox.Show("Price field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (CategoriesCB.SelectedIndex == -1) {
                MessageBox.Show("There is no category found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                try {
                    string Query = $"Insert into Item values ('{NameTB.Text}',{double.Parse(PriceTB.Text)},{int.Parse(CategoriesCB.SelectedValue.ToString())})";
                    confunc.SetData(Query);
                    ShowItems();
                } catch (Exception exception) {
                    MessageBox.Show($"Something went wrong \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        int key = 0;
        private void ResetKey() {
            key = 0;
            NameTB.Text = "";
            PriceTB.Text = "";
        }

        private void ItemsDG_CellClick(object sender, DataGridViewCellEventArgs e) {
            NameTB.Text = ItemsDG.SelectedRows[0].Cells[1].Value.ToString();
            PriceTB.Text = ItemsDG.SelectedRows[0].Cells[2].Value.ToString();
            CategoriesCB.SelectedValue = ItemsDG.SelectedRows[0].Cells[3].Value.ToString();

            if (!string.IsNullOrWhiteSpace(NameTB.Text)) {
                key = int.Parse(ItemsDG.SelectedRows[0].Cells[0].Value.ToString());
            } else ResetKey();
        }

        private void Edititmbtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(NameTB.Text)) {
                MessageBox.Show("Name field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(PriceTB.Text)) {
                MessageBox.Show("Price field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (CategoriesCB.SelectedIndex == -1) {
                MessageBox.Show("There is no category found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                try {
                    string Query = $"Update Item set ItemName = '{NameTB.Text}',ItemPrice = {double.Parse(PriceTB.Text)},ItemCat = {int.Parse(CategoriesCB.SelectedValue.ToString())} where ItemCode = {key}";
                    confunc.SetData(Query);
                    ShowItems();
                } catch (Exception exception) {
                    MessageBox.Show($"Something went wrong \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Delitmbtn_Click(object sender, EventArgs e) {
            if(key == 0){
                MessageBox.Show("Key not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else {
                try {
                    string Query = $"Delete from Item where ItemCode = {key}";
                    confunc.SetData(Query);
                    ShowItems();
                    ResetKey();
                } catch (Exception exception) {
                    MessageBox.Show($"Something went wrong \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
