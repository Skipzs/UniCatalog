namespace FormsNET6
{
    public partial class AddUserForm : Form
    {
        public User NewUser { get; private set; }

        public AddUserForm(string programStudiu, string cicluInvatamant, string anStudiu, string semestru)
        {
            InitializeComponent();
            InitializeFormFields(programStudiu, cicluInvatamant, anStudiu, semestru);
        }

        private void InitializeFormFields(string programStudiu, string cicluInvatamant, string anStudiu, string semestru)
        {
            textBoxProgramStudiu.Text = programStudiu;
            textBoxCicluInvatamant.Text = cicluInvatamant;
            textBoxAnStudiu.Text = anStudiu;
            textBoxSemestru.Text = semestru;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                NewUser = new User
                {
                    ProgramStudiu = textBoxProgramStudiu.Text,
                    CicluInvatamant = textBoxCicluInvatamant.Text,
                    AnStudiu = textBoxAnStudiu.Text,
                    Semestru = textBoxSemestru.Text,
                    Email = textBoxEmail.Text,
                    FirstName = textBoxFirstName.Text,
                    LastName = textBoxLastName.Text,
                    Age = int.Parse(textBoxAge.Text),
                    Cnp = textBoxCnp.Text,
                    PhoneNumber = textBoxPhoneNumber.Text
                };
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}