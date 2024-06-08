namespace FormsNET6
{
    partial class SelectionForm
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
        private void InitializeComponent()
        {
            CicluriDeInvDropDown = new ComboBox();
            CicluriDeInvLabel = new Label();
            ProgrameStudiiDropDown = new ComboBox();
            ProgrameStudiiLabel = new Label();
            AniiDeStudiuDropDown = new ComboBox();
            AniiDeStudiuLabel = new Label();
            SemestruDropDown = new ComboBox();
            SemestruLabel = new Label();
            ButtonSubmit = new Button();
            minButton = new Button();
            ButtonBack = new Button();
            SuspendLayout();
            // 
            // CicluriDeInvDropDown
            // 
            CicluriDeInvDropDown.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CicluriDeInvDropDown.FormattingEnabled = true;
            CicluriDeInvDropDown.Location = new Point(60, 162);
            CicluriDeInvDropDown.Margin = new Padding(3, 4, 3, 4);
            CicluriDeInvDropDown.Name = "CicluriDeInvDropDown";
            CicluriDeInvDropDown.Size = new Size(141, 28);
            CicluriDeInvDropDown.TabIndex = 1;
            CicluriDeInvDropDown.SelectedIndexChanged += CicluriDeInvDropDown_SelectedIndexChanged;
            // 
            // CicluriDeInvLabel
            // 
            CicluriDeInvLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CicluriDeInvLabel.AutoSize = true;
            CicluriDeInvLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CicluriDeInvLabel.Location = new Point(60, 138);
            CicluriDeInvLabel.Name = "CicluriDeInvLabel";
            CicluriDeInvLabel.Size = new Size(144, 18);
            CicluriDeInvLabel.TabIndex = 2;
            CicluriDeInvLabel.Text = "Cicluri de Invatamant";
            // 
            // ProgrameStudiiDropDown
            // 
            ProgrameStudiiDropDown.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProgrameStudiiDropDown.FormattingEnabled = true;
            ProgrameStudiiDropDown.Location = new Point(240, 162);
            ProgrameStudiiDropDown.Margin = new Padding(3, 4, 3, 4);
            ProgrameStudiiDropDown.Name = "ProgrameStudiiDropDown";
            ProgrameStudiiDropDown.Size = new Size(141, 28);
            ProgrameStudiiDropDown.TabIndex = 1;
            ProgrameStudiiDropDown.SelectedIndexChanged += ProgrameStudiiDropDown_SelectedIndexChanged;
            // 
            // ProgrameStudiiLabel
            // 
            ProgrameStudiiLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProgrameStudiiLabel.AutoSize = true;
            ProgrameStudiiLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ProgrameStudiiLabel.Location = new Point(240, 138);
            ProgrameStudiiLabel.Name = "ProgrameStudiiLabel";
            ProgrameStudiiLabel.Size = new Size(132, 18);
            ProgrameStudiiLabel.TabIndex = 2;
            ProgrameStudiiLabel.Text = "Programe de studii";
            // 
            // AniiDeStudiuDropDown
            // 
            AniiDeStudiuDropDown.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AniiDeStudiuDropDown.FormattingEnabled = true;
            AniiDeStudiuDropDown.Location = new Point(420, 162);
            AniiDeStudiuDropDown.Margin = new Padding(3, 4, 3, 4);
            AniiDeStudiuDropDown.Name = "AniiDeStudiuDropDown";
            AniiDeStudiuDropDown.Size = new Size(141, 28);
            AniiDeStudiuDropDown.TabIndex = 1;
            AniiDeStudiuDropDown.SelectedIndexChanged += AniiDeStudiuDropDown_SelectedIndexChanged;
            // 
            // AniiDeStudiuLabel
            // 
            AniiDeStudiuLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AniiDeStudiuLabel.AutoSize = true;
            AniiDeStudiuLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AniiDeStudiuLabel.Location = new Point(420, 138);
            AniiDeStudiuLabel.Name = "AniiDeStudiuLabel";
            AniiDeStudiuLabel.Size = new Size(99, 18);
            AniiDeStudiuLabel.TabIndex = 2;
            AniiDeStudiuLabel.Text = "Anul de studiu";
            // 
            // SemestruDropDown
            // 
            SemestruDropDown.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SemestruDropDown.FormattingEnabled = true;
            SemestruDropDown.Location = new Point(600, 162);
            SemestruDropDown.Margin = new Padding(3, 4, 3, 4);
            SemestruDropDown.Name = "SemestruDropDown";
            SemestruDropDown.Size = new Size(141, 28);
            SemestruDropDown.TabIndex = 1;
            SemestruDropDown.SelectedIndexChanged += SemestruDropDown_SelectedIndexChanged;
            // 
            // SemestruLabel
            // 
            SemestruLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SemestruLabel.AutoSize = true;
            SemestruLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            SemestruLabel.Location = new Point(600, 138);
            SemestruLabel.Name = "SemestruLabel";
            SemestruLabel.Size = new Size(72, 18);
            SemestruLabel.TabIndex = 2;
            SemestruLabel.Text = "Semestru";
            // 
            // ButtonSubmit
            // 
            ButtonSubmit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonSubmit.BackColor = Color.WhiteSmoke;
            ButtonSubmit.BackgroundImageLayout = ImageLayout.Center;
            ButtonSubmit.FlatStyle = FlatStyle.Flat;
            ButtonSubmit.ForeColor = Color.Black;
            ButtonSubmit.Location = new Point(260, 375);
            ButtonSubmit.Margin = new Padding(3, 4, 3, 4);
            ButtonSubmit.Name = "ButtonSubmit";
            ButtonSubmit.Size = new Size(285, 71);
            ButtonSubmit.TabIndex = 3;
            ButtonSubmit.Text = "Submit";
            ButtonSubmit.UseVisualStyleBackColor = false;
            ButtonSubmit.Click += ButtonSubmit_Click;
            // 
            // minButton
            // 
            minButton.BackgroundImage = Properties.Resources.dash_computer_icons_clip_art_least_count_2242c6e02bb9214666ddb253acc75c6b;
            minButton.BackgroundImageLayout = ImageLayout.Stretch;
            minButton.FlatStyle = FlatStyle.Flat;
            minButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            minButton.ForeColor = Color.LightGray;
            minButton.Location = new Point(756, 15);
            minButton.Margin = new Padding(3, 4, 3, 4);
            minButton.Name = "minButton";
            minButton.Size = new Size(32, 31);
            minButton.TabIndex = 4;
            minButton.TextAlign = ContentAlignment.TopCenter;
            minButton.UseVisualStyleBackColor = true;
            minButton.Click += minButton_Click;
            // 
            // ButtonBack
            // 
            ButtonBack.BackColor = Color.LightGray;
            ButtonBack.BackgroundImage = Properties.Resources._3565454_200;
            ButtonBack.BackgroundImageLayout = ImageLayout.Stretch;
            ButtonBack.FlatStyle = FlatStyle.Flat;
            ButtonBack.ForeColor = Color.LightGray;
            ButtonBack.Location = new Point(12, 15);
            ButtonBack.Margin = new Padding(3, 4, 3, 4);
            ButtonBack.Name = "ButtonBack";
            ButtonBack.Size = new Size(40, 50);
            ButtonBack.TabIndex = 0;
            ButtonBack.UseVisualStyleBackColor = false;
            ButtonBack.Click += ButtonBack_Click;
            // 
            // SelectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(800, 562);
            Controls.Add(minButton);
            Controls.Add(ButtonSubmit);
            Controls.Add(SemestruLabel);
            Controls.Add(AniiDeStudiuLabel);
            Controls.Add(SemestruDropDown);
            Controls.Add(ProgrameStudiiLabel);
            Controls.Add(AniiDeStudiuDropDown);
            Controls.Add(CicluriDeInvLabel);
            Controls.Add(ProgrameStudiiDropDown);
            Controls.Add(CicluriDeInvDropDown);
            Controls.Add(ButtonBack);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "SelectionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SelectionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button ButtonBack;
        private System.Windows.Forms.ComboBox CicluriDeInvDropDown;
        private System.Windows.Forms.Label CicluriDeInvLabel;
        private System.Windows.Forms.ComboBox ProgrameStudiiDropDown;
        private System.Windows.Forms.Label ProgrameStudiiLabel;
        private System.Windows.Forms.ComboBox AniiDeStudiuDropDown;
        private System.Windows.Forms.Label AniiDeStudiuLabel;
        private System.Windows.Forms.ComboBox SemestruDropDown;
        private System.Windows.Forms.Label SemestruLabel;
        private System.Windows.Forms.Button ButtonSubmit;
        private System.Windows.Forms.Button minButton;
    }
}