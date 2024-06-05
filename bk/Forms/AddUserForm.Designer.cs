using System.Collections.Generic;
using System.Drawing;

namespace Login
{
    partial class AddUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(string programStudiu, string cicluInvatamant, string anStudiu, string semestru)
        {
            // Initialize form components
            this.Text = "Add New User";
            this.Size = new Size(400, 400);

            var labels = new[]
            {
                "Program Studii", "Ciclu Invatamant", "An Studii", "Semestru", "Email",
                "First Name", "Last Name", "Age", "CNP", "Phone Number"
            };

            var textBoxes = new List<System.Windows.Forms.TextBox>();

            for (int i = 0; i < labels.Length; i++)
            {
                var label = new System.Windows.Forms.Label
                {
                    Text = labels[i],
                    Location = new Point(10, 20 + (i * 30)),
                    Size = new Size(120, 20)
                };

                var textBox = new System.Windows.Forms.TextBox
                {
                    Location = new Point(150, 20 + (i * 30)),
                    Size = new Size(200, 20),
                    ReadOnly = i < 4 // Make the first four textboxes read-only
                };

                // Prepopulate the first four fields
                if (i == 0) textBox.Text = programStudiu;
                if (i == 1) textBox.Text = cicluInvatamant;
                if (i == 2) textBox.Text = anStudiu;
                if (i == 3) textBox.Text = semestru;

                textBoxes.Add(textBox);
                this.Controls.Add(label);
                this.Controls.Add(textBox);
            }

            var addButton = new System.Windows.Forms.Button
            {
                Text = "Add",
                Location = new Point(150, 20 + (labels.Length * 30)),
                Size = new Size(100, 30)
            };
            addButton.Click += (sender, e) =>
            {
                NewUser = new User
                {
                    ProgramStudiu = textBoxes[0].Text,
                    CicluInvatamant = textBoxes[1].Text,
                    AnStudiu = textBoxes[2].Text,
                    Semestru = textBoxes[3].Text,
                    Email = textBoxes[4].Text,
                    FirstName = textBoxes[5].Text,
                    LastName = textBoxes[6].Text,
                    Age = int.Parse(textBoxes[7].Text),
                    Cnp = textBoxes[8].Text,
                    PhoneNumber = textBoxes[9].Text
                };
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            };

            this.Controls.Add(addButton);
        }

        #endregion
    }
}