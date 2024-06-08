namespace FormsNET6
{
    partial class AddUserForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelProgramStudiu;
        private System.Windows.Forms.Label labelCicluInvatamant;
        private System.Windows.Forms.Label labelAnStudiu;
        private System.Windows.Forms.Label labelSemestru;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Label labelCnp;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.TextBox textBoxProgramStudiu;
        private System.Windows.Forms.TextBox textBoxCicluInvatamant;
        private System.Windows.Forms.TextBox textBoxAnStudiu;
        private System.Windows.Forms.TextBox textBoxSemestru;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.TextBox textBoxCnp;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.Button addButton;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelProgramStudiu = new System.Windows.Forms.Label();
            this.labelCicluInvatamant = new System.Windows.Forms.Label();
            this.labelAnStudiu = new System.Windows.Forms.Label();
            this.labelSemestru = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.labelCnp = new System.Windows.Forms.Label();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.textBoxProgramStudiu = new System.Windows.Forms.TextBox();
            this.textBoxCicluInvatamant = new System.Windows.Forms.TextBox();
            this.textBoxAnStudiu = new System.Windows.Forms.TextBox();
            this.textBoxSemestru = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.textBoxCnp = new System.Windows.Forms.TextBox();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddUserForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Name = "AddUserForm";
            this.Text = "Add New User";

            // Initialize and add labels
            InitializeLabel(this.labelProgramStudiu, "Program Studii", 10, 20);
            InitializeLabel(this.labelCicluInvatamant, "Ciclu Invatamant", 10, 50);
            InitializeLabel(this.labelAnStudiu, "An Studii", 10, 80);
            InitializeLabel(this.labelSemestru, "Semestru", 10, 110);
            InitializeLabel(this.labelEmail, "Email", 10, 140);
            InitializeLabel(this.labelFirstName, "First Name", 10, 170);
            InitializeLabel(this.labelLastName, "Last Name", 10, 200);
            InitializeLabel(this.labelAge, "Age", 10, 230);
            InitializeLabel(this.labelCnp, "CNP", 10, 260);
            InitializeLabel(this.labelPhoneNumber, "Phone Number", 10, 290);

            // Initialize and add text boxes
            InitializeTextBox(this.textBoxProgramStudiu, 150, 20, true);
            InitializeTextBox(this.textBoxCicluInvatamant, 150, 50, true);
            InitializeTextBox(this.textBoxAnStudiu, 150, 80, true);
            InitializeTextBox(this.textBoxSemestru, 150, 110, true);
            InitializeTextBox(this.textBoxEmail, 150, 140, false);
            InitializeTextBox(this.textBoxFirstName, 150, 170, false);
            InitializeTextBox(this.textBoxLastName, 150, 200, false);
            InitializeTextBox(this.textBoxAge, 150, 230, false);
            InitializeTextBox(this.textBoxCnp, 150, 260, false);
            InitializeTextBox(this.textBoxPhoneNumber, 150, 290, false);

            // Initialize and add button
            this.addButton.Text = "Add";
            this.addButton.Location = new System.Drawing.Point(150, 320);
            this.addButton.Size = new System.Drawing.Size(100, 30);
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            this.Controls.Add(this.addButton);

            this.ResumeLayout(false);
        }

        private void InitializeLabel(System.Windows.Forms.Label label, string text, int x, int y)
        {
            label.Text = text;
            label.Location = new System.Drawing.Point(x, y);
            label.Size = new System.Drawing.Size(120, 20);
            this.Controls.Add(label);
        }

        private void InitializeTextBox(System.Windows.Forms.TextBox textBox, int x, int y, bool readOnly)
        {
            textBox.Location = new System.Drawing.Point(x, y);
            textBox.Size = new System.Drawing.Size(200, 20);
            textBox.ReadOnly = readOnly;
            this.Controls.Add(textBox);
        }

        #endregion
    }
}