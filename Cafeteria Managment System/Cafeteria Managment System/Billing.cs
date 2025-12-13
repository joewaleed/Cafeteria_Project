namespace Cafeteria_Managment_System {
    public partial class Billing : Form {
        ConnectionFunction confunc;
        int SelectedCategory;
        public Billing() {
            InitializeComponent();
            confunc = new ConnectionFunction();
            ShowBilling();
            wlcmmssg.Text = $"{CurrentUser.Gender}{CurrentUser.Name}";
        }

        private void ShowBilling() {
            try {
                ShowCategories();
                if (CategoriesDG.Rows.Count > 0 && CategoriesDG.Columns.Count > 0) {
                    SelectedCategory = int.Parse(CategoriesDG.Rows[0].Cells[0].Value.ToString());
                } else {
                    SelectedCategory = 0;
                    MessageBox.Show("Please Contact The Admin to add Items","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                ShowItems();
            } catch (Exception exception) {
                MessageBox.Show($"Couldn't retrive data \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Switch() {
            ShowBilling();
            wlcmmssg.Text = $"{CurrentUser.Gender}{CurrentUser.Name}";
            this.Show();
        }

        private static Billing _instance;
        public static Billing GetInstance() {
            if (_instance == null || _instance.IsDisposed) {
                _instance = new Billing();
            }
            return _instance;
        }

        private void ShowCategories() {
            try {
                string Query = "select CatCode,CatName from Cat";
                CategoriesDG.DataSource = confunc.GetData(Query);
                CategoriesDG.Columns["CatCode"].Visible = false;
            } catch (Exception exception) {
                MessageBox.Show($"Couldn't retrive data \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowItems() {
            try {
                string Query = $"select ItemCode,ItemName,cast(round(ItemPrice, 2) as decimal(10, 2)) as ItemPrice from Item where itemCat ={SelectedCategory}";
                ItemsDG.DataSource = confunc.GetData(Query);
                ItemsDG.Columns["ItemCode"].Visible = false;

                if (ItemsDG.RowCount > 0) {
                    PriceTB.Text = ItemsDG.Rows[0].Cells[2].Value.ToString();
                    ItemTB.Text = ItemsDG.Rows[0].Cells[1].Value.ToString();
                    QuantityNUD.Value = 1;
                    if (string.IsNullOrWhiteSpace(ItemTB.Text)) {
                        ItemCode = 0;
                    } else {
                        ItemCode = int.Parse(ItemsDG.Rows[0].Cells[0].Value.ToString());
                    }
                }
            } catch (Exception exception) {
                MessageBox.Show($"Couldn't retrive data \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategoriesDG_CellClick(object sender, DataGridViewCellEventArgs e) {
            SelectedCategory = int.Parse(CategoriesDG.SelectedRows[0].Cells[0].Value.ToString());
            ShowItems();
        }
        int ItemCode = 0;
        double total = 0.0;
        int n = 1;

        private void AdditmBtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(PriceTB.Text)) {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (!string.IsNullOrWhiteSpace(ItemTB.Text)) {
                double itmTotal = double.Parse(PriceTB.Text) * (int)QuantityNUD.Value;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(CartDG);
                row.Cells[0].Value = n++;
                row.Cells[1].Value = ItemCode;
                row.Cells[2].Value = ItemTB.Text;
                row.Cells[3].Value = double.Parse(PriceTB.Text);
                row.Cells[4].Value = (int)QuantityNUD.Value;
                row.Cells[5].Value = itmTotal;
                CartDG.Rows.Add(row);
                total += itmTotal;
                Totallbl.Text = $"Total = {total.ToString("F2")}";
            }
        }

        private void logoutpnl_Click(object sender, EventArgs e) {
            Login logout = Login.GetInstance();
            logout.Switch();
            this.Hide();
        }

        private void ItemsDG_CellClick(object sender, DataGridViewCellEventArgs e) {
            PriceTB.Text = ItemsDG.SelectedRows[0].Cells[2].Value.ToString();
            ItemTB.Text = ItemsDG.SelectedRows[0].Cells[1].Value.ToString();
            if (string.IsNullOrWhiteSpace(ItemTB.Text)) {
                ItemCode = 0;
            } else {
                ItemCode = int.Parse(ItemsDG.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void closeBtn_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void orderComBtn_Click(object sender, EventArgs e) {
            try {
                if (CartDG.RowCount < 1) {
                    MessageBox.Show("Nothing in the cart", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string Query = $"insert into Invoice(UserID,InvoiceAmount) values ({CurrentUser.Userid},{total})";
                confunc.SetData(Query);

                foreach (DataGridViewRow dvgr in CartDG.Rows) {
                    Query = $"insert into ItemPerInvoice(invoiceID,itemName,itemPrice,itemQunatity) values((select Max(InvoiceID) from Invoice),'{dvgr.Cells[2].Value.ToString()}',{double.Parse(dvgr.Cells[3].Value.ToString())},{int.Parse(dvgr.Cells[4].Value.ToString())})";
                    confunc.SetData(Query);
                }
                ClearCart();
                MessageBox.Show("OrderCompleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show($"Something Went Wrong \n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void ClearCart() {
            CartDG.Rows.Clear();
            total = 0;
            Totallbl.Text = $"Total = {total.ToString("F2")}";
        }
        private void clrbtn_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Are You Sure You Want To Clear The Cart?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK) {
                ClearCart();
            }
        }

        int Itemrowcode = 0;
        private void CartDG_CellClick(object sender, DataGridViewCellEventArgs e) {
            Itemrowcode = int.Parse(CartDG.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void rmvbtn_Click(object sender, EventArgs e) {
            if(Itemrowcode < 1) {
                MessageBox.Show("Plaese Select an Item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try {
                int rowIndex = CartDG.CurrentCell.RowIndex;
                total -= double.Parse(CartDG.Rows[rowIndex].Cells[5].Value.ToString());
                CartDG.Rows.RemoveAt(rowIndex);
                Totallbl.Text = $"Total = {total.ToString("F2")}";
            } catch (Exception ex) {
                MessageBox.Show($"Something went wrong \n {ex}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
