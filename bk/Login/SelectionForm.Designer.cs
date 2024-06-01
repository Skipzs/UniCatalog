namespace Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionForm));
            this.ButtonBack = new System.Windows.Forms.Button();
            this.CicluriDeInvDropDown = new System.Windows.Forms.ComboBox();
            this.CicluriDeInvLabel = new System.Windows.Forms.Label();
            this.ProgrameStudiiDropDown = new System.Windows.Forms.ComboBox();
            this.ProgrameStudiiLabel = new System.Windows.Forms.Label();
            this.AniiDeStudiuDropDown = new System.Windows.Forms.ComboBox();
            this.AniiDeStudiuLabel = new System.Windows.Forms.Label();
            this.SemestruDropDown = new System.Windows.Forms.ComboBox();
            this.SemestruLabel = new System.Windows.Forms.Label();
            this.ButtonSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonBack
            // 
            this.ButtonBack.BackColor = System.Drawing.Color.LightGray;
            this.ButtonBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonBack.BackgroundImage")));
            this.ButtonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonBack.ForeColor = System.Drawing.Color.LightGray;
            this.ButtonBack.Location = new System.Drawing.Point(12, 12);
            this.ButtonBack.Name = "ButtonBack";
            this.ButtonBack.Size = new System.Drawing.Size(40, 40);
            this.ButtonBack.TabIndex = 0;
            this.ButtonBack.UseVisualStyleBackColor = false;
            this.ButtonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // CicluriDeInvDropDown
            // 
            this.CicluriDeInvDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CicluriDeInvDropDown.FormattingEnabled = true;
            this.CicluriDeInvDropDown.Items.AddRange(new object[] {
            "Licentă",
            "Masterat"});
            this.CicluriDeInvDropDown.Location = new System.Drawing.Point(60, 130);
            this.CicluriDeInvDropDown.Name = "CicluriDeInvDropDown";
            this.CicluriDeInvDropDown.Size = new System.Drawing.Size(141, 24);
            this.CicluriDeInvDropDown.TabIndex = 1;
            // 
            // CicluriDeInvLabel
            // 
            this.CicluriDeInvLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CicluriDeInvLabel.AutoSize = true;
            this.CicluriDeInvLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CicluriDeInvLabel.Location = new System.Drawing.Point(60, 110);
            this.CicluriDeInvLabel.Name = "CicluriDeInvLabel";
            this.CicluriDeInvLabel.Size = new System.Drawing.Size(144, 18);
            this.CicluriDeInvLabel.TabIndex = 2;
            this.CicluriDeInvLabel.Text = "Cicluri de Invatamant";
            // 
            // ProgrameStudiiDropDown
            // 
            this.ProgrameStudiiDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgrameStudiiDropDown.FormattingEnabled = true;
            this.ProgrameStudiiDropDown.Items.AddRange(new object[] {
            "Licentă",
            "Masterat"});
            this.ProgrameStudiiDropDown.Location = new System.Drawing.Point(240, 130);
            this.ProgrameStudiiDropDown.Name = "ProgrameStudiiDropDown";
            this.ProgrameStudiiDropDown.Size = new System.Drawing.Size(141, 24);
            this.ProgrameStudiiDropDown.TabIndex = 1;
            // 
            // ProgrameStudiiLabel
            // 
            this.ProgrameStudiiLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgrameStudiiLabel.AutoSize = true;
            this.ProgrameStudiiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgrameStudiiLabel.Location = new System.Drawing.Point(240, 110);
            this.ProgrameStudiiLabel.Name = "ProgrameStudiiLabel";
            this.ProgrameStudiiLabel.Size = new System.Drawing.Size(132, 18);
            this.ProgrameStudiiLabel.TabIndex = 2;
            this.ProgrameStudiiLabel.Text = "Programe de studii";
            // 
            // AniiDeStudiuDropDown
            // 
            this.AniiDeStudiuDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AniiDeStudiuDropDown.FormattingEnabled = true;
            this.AniiDeStudiuDropDown.Items.AddRange(new object[] {
            "Licentă",
            "Masterat"});
            this.AniiDeStudiuDropDown.Location = new System.Drawing.Point(420, 130);
            this.AniiDeStudiuDropDown.Name = "AniiDeStudiuDropDown";
            this.AniiDeStudiuDropDown.Size = new System.Drawing.Size(141, 24);
            this.AniiDeStudiuDropDown.TabIndex = 1;
            // 
            // AniiDeStudiuLabel
            // 
            this.AniiDeStudiuLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AniiDeStudiuLabel.AutoSize = true;
            this.AniiDeStudiuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AniiDeStudiuLabel.Location = new System.Drawing.Point(420, 110);
            this.AniiDeStudiuLabel.Name = "AniiDeStudiuLabel";
            this.AniiDeStudiuLabel.Size = new System.Drawing.Size(99, 18);
            this.AniiDeStudiuLabel.TabIndex = 2;
            this.AniiDeStudiuLabel.Text = "Anul de studiu";
            // 
            // SemestruDropDown
            // 
            this.SemestruDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SemestruDropDown.FormattingEnabled = true;
            this.SemestruDropDown.Items.AddRange(new object[] {
            "Licentă",
            "Masterat"});
            this.SemestruDropDown.Location = new System.Drawing.Point(600, 130);
            this.SemestruDropDown.Name = "SemestruDropDown";
            this.SemestruDropDown.Size = new System.Drawing.Size(141, 24);
            this.SemestruDropDown.TabIndex = 1;
            // 
            // SemestruLabel
            // 
            this.SemestruLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SemestruLabel.AutoSize = true;
            this.SemestruLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SemestruLabel.Location = new System.Drawing.Point(600, 110);
            this.SemestruLabel.Name = "SemestruLabel";
            this.SemestruLabel.Size = new System.Drawing.Size(72, 18);
            this.SemestruLabel.TabIndex = 2;
            this.SemestruLabel.Text = "Semestru";
            // 
            // ButtonSubmit
            // 
            this.ButtonSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSubmit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSubmit.ForeColor = System.Drawing.Color.Black;
            this.ButtonSubmit.Location = new System.Drawing.Point(260, 300);
            this.ButtonSubmit.Name = "ButtonSubmit";
            this.ButtonSubmit.Size = new System.Drawing.Size(285, 57);
            this.ButtonSubmit.TabIndex = 3;
            this.ButtonSubmit.Text = "Submit";
            this.ButtonSubmit.UseVisualStyleBackColor = false;
            this.ButtonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // SelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonSubmit);
            this.Controls.Add(this.SemestruLabel);
            this.Controls.Add(this.AniiDeStudiuLabel);
            this.Controls.Add(this.SemestruDropDown);
            this.Controls.Add(this.ProgrameStudiiLabel);
            this.Controls.Add(this.AniiDeStudiuDropDown);
            this.Controls.Add(this.CicluriDeInvLabel);
            this.Controls.Add(this.ProgrameStudiiDropDown);
            this.Controls.Add(this.CicluriDeInvDropDown);
            this.Controls.Add(this.ButtonBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "SelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}