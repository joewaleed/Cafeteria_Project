namespace Cafeteria_Managment_System {
    public partial class Invoices : Form {
        ConnectionFunction confunc;
        public Invoices() {
            InitializeComponent();
            confunc = new ConnectionFunction();
        }

        private static Invoices _instance;
        public static Invoices GetInstance() {
            if (_instance == null || _instance.IsDisposed) {
                _instance = new Invoices();
            }
            return _instance;
        }

        public void Switch() {
            ShowInvoices();
            wlcmmssg.Text = $"{CurrentUser.Gender}{CurrentUser.Name}";
            this.Show();
        }

        void ShowInvoices() {
            try {
                string Query = "select I.InvoiceId, U.UserName, I.InvoiceDate,I.InvoiceAmount from Invoice I Left join Users U on U.UserID = I.UserID";
                InvoicesDGV.DataSource = confunc.GetData(Query);
                ShowItems();
            } catch (Exception exception) {
                MessageBox.Show($"Couldn't retrive data \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ShowItems() {
            string Query = $"Select ItemName,ItemPrice,itemQunatity,(ItemPrice*itemQunatity) as Total from ItemPerInvoice where InvoiceID = {InvoicesDGV.Rows[0].Cells[0].Value}";
            InvoiceItemDG.DataSource = confunc.GetData(Query);
        }

        private void closebtn_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        private void UserPanel_Click(object sender, EventArgs e) {
            User user = User.GetInstance();
            user.Switch();
            this.Hide();
        }

        private void ItemPanel_Click(object sender, EventArgs e) {
            Items items = Items.GetInstance();
            items.Switch();
            this.Hide();
        }

        private void logoutpnl_Click(object sender, EventArgs e) {
            Login logout = Login.GetInstance();
            logout.Switch();
            this.Hide();
        }

        private void catpnl_Click(object sender, EventArgs e) {
            Category category = Category.GetInstance();
            category.Switch();
            this.Hide();
        }

        private void IDRB_CheckedChanged(object sender, EventArgs e) {
            OrderNumberTB.Text = "";
            OrderNumberTB.Visible = IDRB.Checked;
        }

        private void DateRB_CheckedChanged(object sender, EventArgs e) {
            TimePicker.Visible = DateRB.Checked;
        }

        private void PriceRangeRB_CheckedChanged(object sender, EventArgs e) {
            MinNUD.Visible = PriceRangeRB.Checked;
            MaxNUD.Visible = PriceRangeRB.Checked;
        }

        private void searchBtn_Click(object sender, EventArgs e) {
            try {
                if (IDRB.Checked) {
                    string Query = $"select I.InvoiceId, U.UserName, I.InvoiceDate,I.InvoiceAmount from Invoice I Left join Users U on U.UserID = I.UserID where InvoiceID = {OrderNumberTB.Text}";
                    InvoicesDGV.DataSource = confunc.GetData(Query);
                } else if (DateRB.Checked) {
                    string Query = $"select I.InvoiceId, U.UserName, I.InvoiceDate,I.InvoiceAmount from Invoice I Left join Users U on U.UserID = I.UserID where InvoiceDate = {TimePicker.Text}";
                    InvoicesDGV.DataSource = confunc.GetData(Query);
                } else if (PriceRangeRB.Checked) {
                    string Query = $"select I.InvoiceId, U.UserName, I.InvoiceDate,I.InvoiceAmount from Invoice I Left join Users U on U.UserID = I.UserID where InvoiceAmount between {MinNUD.Value} and {MaxNUD.Value}";
                    InvoicesDGV.DataSource = confunc.GetData(Query);
                } else {
                    throw new Exception("Something went wrong");
                }
                ShowItems();
            } catch (Exception exception) {
                MessageBox.Show($"Couldn't retrive data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetbtn_Click(object sender, EventArgs e) {
            ShowInvoices();
        }

        private void InvoicesDGV_CellClick(object sender, DataGridViewCellEventArgs e) {
            try {
                string Query = $"Select ItemName,ItemPrice,itemQunatity,(ItemPrice*itemQunatity) as Total from ItemPerInvoice where InvoiceID = {InvoicesDGV.SelectedRows[0].Cells[0].Value}";
                InvoiceItemDG.DataSource = confunc.GetData(Query);
            } catch (Exception ex){
                MessageBox.Show($"Couldn't retrive data \n {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
