using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Login
{
    public partial class AddUserForm : Form
    {
        public User NewUser { get; private set; }

        public AddUserForm(string programStudiu, string cicluInvatamant, string anStudiu, string semestru)
        {
            InitializeComponent(programStudiu, cicluInvatamant, anStudiu, semestru);
        }


    }
}
