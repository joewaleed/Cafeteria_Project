namespace Cafeteria_Managment_System {
    public partial class Welcome : Form {
        ConnectionFunction confunc;
        public Welcome() {
            InitializeComponent();
            confunc = new ConnectionFunction();
        }

        private void AddadmnBtn_Click(object sender, EventArgs e) {
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
                    string Query = $"Insert into Users values ('{NameTB.Text}','{GenderCB.SelectedItem.ToString().ToLower()}','{PasswordTB.Text}','{PhoneTB.Text}','{AddressTB.Text}', 1)";
                    confunc.SetData(Query);
                    CurrentUser.Name = NameTB.Text;
                    CurrentUser.Gender = GenderCB.SelectedItem.ToString().ToLower();
                    User user = User.GetInstance();
                    user.Switch();
                    this.Hide();
                } catch (Exception exception) {
                    MessageBox.Show($"Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
