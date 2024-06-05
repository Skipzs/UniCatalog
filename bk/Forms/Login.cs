using System;
using System.Windows.Forms;


namespace Login
{
    public partial class LoginForm : Form
    {
        private bool isClosingConfirmed = false;

        public LoginForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(LoginForm_FormClosing);
            
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UsernameLogin.Text == "Admin" && PasswordLogin.Text == "admin1")
            {
                SelectionForm f = new SelectionForm(this); // Pass this instance to the SelectionForm
                this.Hide();
                f.Show();
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosingConfirmed)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to close the application????", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    isClosingConfirmed = true;
                    Application.Exit();
                    
                }
                else
                {
                    e.Cancel = true; // Cancel the form closing event
                }
            }
        }
    }
}
