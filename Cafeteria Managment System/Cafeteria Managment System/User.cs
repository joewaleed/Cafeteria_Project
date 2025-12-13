namespace Cafeteria_Managment_System
{
    public partial class User : Form {
        ConnectionFunction confunc;
        public User() {
            InitializeComponent();
            confunc = new ConnectionFunction();
            ShowUsers();
            wlcmmssg.Text = $"{CurrentUser.Gender}{CurrentUser.Name}";
        }
        private static User _instance;
        public static User GetInstance() {
            if (_instance == null || _instance.IsDisposed) {
                _instance = new User();
            }
            return _instance;
        }

        private void ShowUsers() {
            try {
                string Query = "select * from Users";
                UsersDG.DataSource = confunc.GetData(Query);
                GenderCB.SelectedIndex = 0;
                UsersDG.Columns["isAdmin"].Visible = false;
            } catch (Exception exception) {
                MessageBox.Show($"Couldn't retrive data \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Switch() {
            ShowUsers();
            wlcmmssg.Text = $"{CurrentUser.Gender}{CurrentUser.Name}";
            this.Show();
        }

        private void AddusrBtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(NameTB.Text)) {
                MessageBox.Show("Name field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(PasswordTB.Text)) {
                MessageBox.Show("Password field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (GenderCB.SelectedIndex == -1) {
                MessageBox.Show("Gender not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(PhoneTB.Text)) {
                MessageBox.Show("Phone number field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(AddressTB.Text)) {
                MessageBox.Show("Address field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                try {
                    string isAdmin = AdminCheck.Checked ? "1" : "0";
                    string Query = $"Insert into Users values ('{NameTB.Text}','{GenderCB.SelectedItem.ToString().ToLower()}','{PasswordTB.Text}','{PhoneTB.Text}','{AddressTB.Text}',{isAdmin})";
                    confunc.SetData(Query);
                    ShowUsers();
                } catch (Exception exception) {
                    MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        int key = 0;

        private void ResetKey() {
            key = 0;
            NameTB.Text = "";
            PasswordTB.Text = "";
            GenderCB.SelectedIndex = 0;
            PhoneTB.Text = "";
            AddressTB.Text = "";
        }

        private void UsersDG_CellClick(object sender, DataGridViewCellEventArgs e) {
            NameTB.Text = UsersDG.SelectedRows[0].Cells[1].Value.ToString();
            GenderCB.SelectedIndex = (UsersDG.SelectedRows[0].Cells[2].Value.ToString() == "male") ? 0 : 1;
            PasswordTB.Text = UsersDG.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTB.Text = UsersDG.SelectedRows[0].Cells[4].Value.ToString();
            AddressTB.Text = UsersDG.SelectedRows[0].Cells[5].Value.ToString();
            AdminCheck.Checked = bool.Parse(UsersDG.SelectedRows[0].Cells[6].Value.ToString());

            if (!string.IsNullOrWhiteSpace(NameTB.Text)) {
                key = int.Parse(UsersDG.SelectedRows[0].Cells[0].Value.ToString());
            } else ResetKey();
        }

        private void Editusrbtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(NameTB.Text)) {
                MessageBox.Show("Name field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(PasswordTB.Text)) {
                MessageBox.Show("Password field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (GenderCB.SelectedIndex == -1) {
                MessageBox.Show("Gender not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(PhoneTB.Text)) {
                MessageBox.Show("Phone number field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(AddressTB.Text)) {
                MessageBox.Show("Address field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                try {
                    string Query = "select Count(isAdmin) from users where isAdmin = 1";
                    int adminCount = int.Parse(confunc.GetData(Query).Rows[0][0].ToString());
                    Query = $"select isAdmin from users where UserID ={key}";
                    bool isUserAdmin = bool.Parse(confunc.GetData(Query).Rows[0][0].ToString());
                    if ((isUserAdmin && adminCount > 1) || !isUserAdmin) {
                        string isAdmin = AdminCheck.Checked ? "1" : "0";
                        Query = $"Update Users set UserName = '{NameTB.Text}',UserGender = '{GenderCB.SelectedItem.ToString().ToLower()}', UserPass = '{PasswordTB.Text}',UserPhone = '{PhoneTB.Text}',UserAddress = '{AddressTB.Text}',isAdmin={isAdmin} where UserID = {key}";
                        confunc.SetData(Query);
                        ShowUsers();
                    } else {
                        MessageBox.Show("You can't Edit the last admin in the system to non-admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch (Exception exception) {
                    MessageBox.Show($"Something went wrong \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Delusrbtn_Click(object sender, EventArgs e) {
            if (key == 0 || string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(PasswordTB.Text)) {
                MessageBox.Show("Key not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                try {
                    string Query = "select Count(isAdmin) from users where isAdmin = 1";
                    int adminCount = int.Parse(confunc.GetData(Query).Rows[0][0].ToString());
                    Query = $"select isAdmin from users where UserID ={key}";
                    bool isUserAdmin = bool.Parse(confunc.GetData(Query).Rows[0][0].ToString());
                    if ((isUserAdmin && adminCount > 1) || !isUserAdmin) {
                        Query = $"Delete from Users where UserID = {key}";
                        confunc.SetData(Query);
                        ShowUsers();
                        ResetKey();
                    } else {
                        MessageBox.Show("You can't delete the last admin in the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                } catch (Exception exception) {
                    MessageBox.Show($"Something went wrong \n {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void NameTB_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.Handled = true;
                e.SuppressKeyPress = true;
                PasswordTB.Select();
            }
        }

        private void PasswordTB_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.Handled = true;
                e.SuppressKeyPress = true;
                PhoneTB.Select();
            }
        }

        private void PhoneTB_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.Handled = true;
                e.SuppressKeyPress = true;
                AddressTB.Select();
            }
        }

        private void AddressTB_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.Handled = true;
                e.SuppressKeyPress = true;
                AddusrBtn_Click(sender, e);
            }
        }

        private void CategoriesPanel_Click(object sender, EventArgs e) {
            Category category = Category.GetInstance();
            category.Switch();
            this.Hide();
        }

        private void ItemsPanel_Click(object sender, EventArgs e) {
            Items items = Items.GetInstance();
            items.Switch();
            this.Hide();
        }

        private void Logoutpnl_Click(object sender, EventArgs e) {
            Login logout = Login.GetInstance();
            logout.Switch();
            this.Hide();
        }

        private void closebtn_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void invpnl_Click(object sender, EventArgs e) {
            Invoices invoices = Invoices.GetInstance();
            invoices.Switch();
            this.Hide();
        }
    }
}
