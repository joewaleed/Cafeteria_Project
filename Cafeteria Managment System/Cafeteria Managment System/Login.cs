namespace Cafeteria_Managment_System {
    public partial class Login : Form {
        ConnectionFunction confunc;
        public Login() {
            InitializeComponent();
            confunc = new ConnectionFunction();
        }

        private static Login _instance;
        public static Login GetInstance() {
            if (_instance == null || _instance.IsDisposed) {
                _instance = new Login();
            }
            return _instance;
        }

        public void Switch() {
            UsernameTB.Text = "";
            PasswordTB.Text = "";
            this.Show();
        }

        private void AdditmBtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(UsernameTB.Text)) {
                MessageBox.Show("Name field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(PasswordTB.Text)) {
                MessageBox.Show("Password field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                try {
                    string query = $"select count(*) from Users where Lower(UserName) = Lower('{UsernameTB.Text}') AND UserPass = '{PasswordTB.Text}'";
                    int count = int.Parse(confunc.GetData(query).Rows[0][0].ToString());
                    if (count > 1) {
                        throw new Exception("Login output contains more than one result");
                    } else if (count == 1) {
                        query = $"select isAdmin,UserName,UserGender,UserID from Users where UserName = '{UsernameTB.Text}' AND UserPass = '{PasswordTB.Text}'";
                        CurrentUser.Name = confunc.GetData(query).Rows[0][1].ToString();
                        CurrentUser.Gender = confunc.GetData(query).Rows[0][2].ToString();
                        CurrentUser.Userid = int.Parse(confunc.GetData(query).Rows[0][3].ToString());
                        if (bool.Parse(confunc.GetData(query).Rows[0][0].ToString())) {
                            User user = User.GetInstance();
                            user.Switch();
                            this.Hide();
                        } else {
                            Billing billing = Billing.GetInstance();
                            billing.Switch();
                            this.Hide();
                        }
                    } else {
                        MessageBox.Show("Username or password is not correct please try again", "Incorrect inputs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } catch (Exception exception) {
                    MessageBox.Show($"Something Went Wrong \n {exception}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LeaveTxtbtn_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void UsernameTB_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                PasswordTB.Select();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void PasswordTB_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                AdditmBtn_Click(sender,e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
