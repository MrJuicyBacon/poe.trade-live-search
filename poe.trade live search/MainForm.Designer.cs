namespace poe.trade_live_search
{
    partial class MainForm
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
            this.addButton = new System.Windows.Forms.Button();
            this.poetradeStopButton = new System.Windows.Forms.Button();
            this.itemsListBox = new System.Windows.Forms.ListBox();
            this.poetradeExDealLabel = new System.Windows.Forms.Label();
            this.poetradeCDealLabel = new System.Windows.Forms.Label();
            this.poetradeCDealTextBox = new System.Windows.Forms.TextBox();
            this.poetradeExDealTextBox = new System.Windows.Forms.TextBox();
            this.poetradeApplyDealButton = new System.Windows.Forms.Button();
            this.siteComboBox = new System.Windows.Forms.ComboBox();
            this.linkTextBox = new System.Windows.Forms.TextBox();
            this.linkLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.siteLabel = new System.Windows.Forms.Label();
            this.linksListBox = new System.Windows.Forms.CheckedListBox();
            this.logText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(350, 65);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(40, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.poetradeStartButton_Click);
            // 
            // poetradeStopButton
            // 
            this.poetradeStopButton.Location = new System.Drawing.Point(396, 293);
            this.poetradeStopButton.Name = "poetradeStopButton";
            this.poetradeStopButton.Size = new System.Drawing.Size(69, 23);
            this.poetradeStopButton.TabIndex = 3;
            this.poetradeStopButton.Text = "stop";
            this.poetradeStopButton.UseVisualStyleBackColor = true;
            this.poetradeStopButton.Click += new System.EventHandler(this.poetradeStopButton_Click);
            // 
            // itemsListBox
            // 
            this.itemsListBox.FormattingEnabled = true;
            this.itemsListBox.Location = new System.Drawing.Point(15, 104);
            this.itemsListBox.Name = "itemsListBox";
            this.itemsListBox.Size = new System.Drawing.Size(375, 212);
            this.itemsListBox.TabIndex = 4;
            this.itemsListBox.SelectedIndexChanged += new System.EventHandler(this.itemsListBox_SelectedIndexChanged);
            // 
            // poetradeExDealLabel
            // 
            this.poetradeExDealLabel.AutoSize = true;
            this.poetradeExDealLabel.Location = new System.Drawing.Point(12, 9);
            this.poetradeExDealLabel.Name = "poetradeExDealLabel";
            this.poetradeExDealLabel.Size = new System.Drawing.Size(70, 13);
            this.poetradeExDealLabel.TabIndex = 5;
            this.poetradeExDealLabel.Text = "Good deal ex";
            // 
            // poetradeCDealLabel
            // 
            this.poetradeCDealLabel.AutoSize = true;
            this.poetradeCDealLabel.Location = new System.Drawing.Point(88, 9);
            this.poetradeCDealLabel.Name = "poetradeCDealLabel";
            this.poetradeCDealLabel.Size = new System.Drawing.Size(65, 13);
            this.poetradeCDealLabel.TabIndex = 6;
            this.poetradeCDealLabel.Text = "Good deal c";
            // 
            // poetradeCDealTextBox
            // 
            this.poetradeCDealTextBox.Location = new System.Drawing.Point(87, 25);
            this.poetradeCDealTextBox.Name = "poetradeCDealTextBox";
            this.poetradeCDealTextBox.Size = new System.Drawing.Size(69, 20);
            this.poetradeCDealTextBox.TabIndex = 7;
            // 
            // poetradeExDealTextBox
            // 
            this.poetradeExDealTextBox.Location = new System.Drawing.Point(12, 25);
            this.poetradeExDealTextBox.Name = "poetradeExDealTextBox";
            this.poetradeExDealTextBox.Size = new System.Drawing.Size(69, 20);
            this.poetradeExDealTextBox.TabIndex = 8;
            // 
            // poetradeApplyDealButton
            // 
            this.poetradeApplyDealButton.Location = new System.Drawing.Point(162, 22);
            this.poetradeApplyDealButton.Name = "poetradeApplyDealButton";
            this.poetradeApplyDealButton.Size = new System.Drawing.Size(69, 23);
            this.poetradeApplyDealButton.TabIndex = 9;
            this.poetradeApplyDealButton.Text = "apply";
            this.poetradeApplyDealButton.UseVisualStyleBackColor = true;
            this.poetradeApplyDealButton.Click += new System.EventHandler(this.poetradeApplyDealButton_Click);
            // 
            // siteComboBox
            // 
            this.siteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.siteComboBox.FormattingEnabled = true;
            this.siteComboBox.Items.AddRange(new object[] {
            "poe.trade",
            "pathofexile.com"});
            this.siteComboBox.Location = new System.Drawing.Point(244, 66);
            this.siteComboBox.Name = "siteComboBox";
            this.siteComboBox.Size = new System.Drawing.Size(100, 21);
            this.siteComboBox.TabIndex = 14;
            // 
            // linkTextBox
            // 
            this.linkTextBox.Location = new System.Drawing.Point(128, 67);
            this.linkTextBox.Name = "linkTextBox";
            this.linkTextBox.Size = new System.Drawing.Size(110, 20);
            this.linkTextBox.TabIndex = 10;
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(129, 51);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(30, 13);
            this.linkLabel.TabIndex = 15;
            this.linkLabel.Text = "Link:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 51);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 16;
            this.nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 67);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(110, 20);
            this.nameTextBox.TabIndex = 17;
            // 
            // siteLabel
            // 
            this.siteLabel.AutoSize = true;
            this.siteLabel.Location = new System.Drawing.Point(245, 51);
            this.siteLabel.Name = "siteLabel";
            this.siteLabel.Size = new System.Drawing.Size(28, 13);
            this.siteLabel.TabIndex = 18;
            this.siteLabel.Text = "Site:";
            // 
            // linksListBox
            // 
            this.linksListBox.CheckOnClick = true;
            this.linksListBox.FormattingEnabled = true;
            this.linksListBox.Location = new System.Drawing.Point(396, 104);
            this.linksListBox.Name = "linksListBox";
            this.linksListBox.Size = new System.Drawing.Size(281, 94);
            this.linksListBox.TabIndex = 19;
            // 
            // logText
            // 
            this.logText.Location = new System.Drawing.Point(396, 204);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logText.Size = new System.Drawing.Size(281, 83);
            this.logText.TabIndex = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 380);
            this.Controls.Add(this.logText);
            this.Controls.Add(this.linksListBox);
            this.Controls.Add(this.siteLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.poetradeStopButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.poetradeExDealLabel);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.poetradeCDealTextBox);
            this.Controls.Add(this.siteComboBox);
            this.Controls.Add(this.poetradeCDealLabel);
            this.Controls.Add(this.poetradeExDealTextBox);
            this.Controls.Add(this.linkTextBox);
            this.Controls.Add(this.poetradeApplyDealButton);
            this.Controls.Add(this.itemsListBox);
            this.Controls.Add(this.addButton);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button poetradeStopButton;
        private System.Windows.Forms.ListBox itemsListBox;
        private System.Windows.Forms.Label poetradeExDealLabel;
        private System.Windows.Forms.Label poetradeCDealLabel;
        private System.Windows.Forms.TextBox poetradeCDealTextBox;
        private System.Windows.Forms.TextBox poetradeExDealTextBox;
        private System.Windows.Forms.Button poetradeApplyDealButton;
        private System.Windows.Forms.TextBox linkTextBox;
        private System.Windows.Forms.ComboBox siteComboBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label linkLabel;
        private System.Windows.Forms.Label siteLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.CheckedListBox linksListBox;
        private System.Windows.Forms.TextBox logText;
    }
}

