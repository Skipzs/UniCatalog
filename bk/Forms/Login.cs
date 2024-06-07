using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Login
{
    public partial class LoginForm : Form
    {
        private bool isClosingConfirmed = false;
        private static readonly HttpClient client;

        static LoginForm()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            client = new HttpClient(handler);
        }

        public LoginForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(LoginForm_FormClosing);
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            var login = new { Username = UsernameLogin.Text, Password = PasswordLogin.Text };
            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7063/api/login/validate", content);

            if (response.IsSuccessStatusCode)
            {
                SelectionForm f = new SelectionForm(this); // Pass this instance to the SelectionForm
                this.Hide();
                f.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosingConfirmed)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to close the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
