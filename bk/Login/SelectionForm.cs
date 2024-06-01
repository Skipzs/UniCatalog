using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class SelectionForm : Form
    {
        public SelectionForm()
        {
            InitializeComponent();
        }

        private LoginForm loginForm;

        public SelectionForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show(); // Show the original LoginForm
        }


        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            String querry = CicluriDeInvDropDown.Text + ProgrameStudiiDropDown.Text
                            + AniiDeStudiuDropDown.Text + SemestruDropDown.Text;
            Tabele t = new Tabele();
            t.Show();
        }

    }
}
