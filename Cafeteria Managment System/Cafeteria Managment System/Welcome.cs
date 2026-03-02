using System.Security.Cryptography;
using System.Text;

namespace Cafeteria_Managment_System {
    public partial class Welcome : Form {
        ConnectionFunction confunc;
        public Welcome() {
            InitializeComponent();
            confunc = new ConnectionFunction();
            GenderCB.SelectedIndex = 0;
        }

        private void AddadmnBtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(NameTB.Text)) {
                MessageBox.Show("Name field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(PasswordTB.Text) || PasswordTB.Text.Length < 8) {
                MessageBox.Show("Password field is empty or less than 8 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (GenderCB.SelectedIndex == -1) {
                MessageBox.Show("Gender not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(PhoneTB.Text)) {
                MessageBox.Show("Phone number field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrWhiteSpace(AddressTB.Text)) {
                MessageBox.Show("Address field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                try {
                    HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes("secretkey"));
                    string Query = $"Insert into Users values ('{NameTB.Text}','{GenderCB.SelectedItem.ToString().ToLower()}','{Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(PasswordTB.Text)))}','{PhoneTB.Text}','{AddressTB.Text}', 1)";
                    confunc.SetData(Query);
                    CurrentUser.Name = NameTB.Text;
                    CurrentUser.Gender = GenderCB.SelectedItem.ToString().ToLower();
                    User user = User.GetInstance();
                    user.Switch();
                    this.Hide();
                } catch (Exception) {
                    MessageBox.Show($"Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LeaveTxtbtn_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
