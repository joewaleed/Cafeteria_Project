using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cafeteria_Managment_System {
    public partial class Category : Form {
        ConnectionFunction confunc;
        public Category() {
            InitializeComponent();
            confunc = new ConnectionFunction();
            ShowCategories();
        }

        private void ShowCategories() {
            try {
                string Query = "select * from Cat";
                CategoriesDG.DataSource = confunc.GetData(Query);
            } catch (Exception exception) {
                MessageBox.Show($"Couldn't retrive data \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddcatBtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(NameTB.Text)) {
                MessageBox.Show("Name field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(DescriptionTB.Text)) {
                MessageBox.Show("Description field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                try {
                    string Query = $"Insert into Cat values ('{NameTB.Text}','{DescriptionTB.Text}')";
                    confunc.SetData(Query);
                    ShowCategories();
                } catch (Exception exception) {
                    MessageBox.Show($"Something went wrong \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        int key = 0;
        private void ResetKey() {
            key = 0;
            NameTB.Text = "";
            DescriptionTB.Text = "";
        }

        private void CategoriesDG_CellClick(object sender, DataGridViewCellEventArgs e) {
            NameTB.Text = CategoriesDG.SelectedRows[0].Cells[1].Value.ToString();
            DescriptionTB.Text = CategoriesDG.SelectedRows[0].Cells[2].Value.ToString();

            if (!string.IsNullOrWhiteSpace(NameTB.Text)) {
                key = int.Parse(CategoriesDG.SelectedRows[0].Cells[0].Value.ToString());
            } else ResetKey();
        }

        private void Editcatbtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(NameTB.Text)) {
                MessageBox.Show("Name field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(DescriptionTB.Text)) {
                MessageBox.Show("Description field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                try {
                    string Query = $"Update Cat set CatName = '{NameTB.Text}' , CatDesc = '{DescriptionTB.Text}' where CatCode = {key}";
                    confunc.SetData(Query);
                    ShowCategories();
                } catch (Exception exception) {
                    MessageBox.Show($"Something went wrong \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Delcatbtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(NameTB.Text)) {
                MessageBox.Show("Name field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(DescriptionTB.Text)) {
                MessageBox.Show("Description field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                try {
                    string Query = $"Delete from Cat where CatCode = {key}";
                    confunc.SetData(Query);
                    ShowCategories();
                } catch (Exception exception) {
                    MessageBox.Show($"Something went wrong \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void NameTB_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                DescriptionTB.Select();
            }
        }

        private void DescriptionTB_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                AddcatBtn_Click(sender, e);
            }
        }
    }
}
