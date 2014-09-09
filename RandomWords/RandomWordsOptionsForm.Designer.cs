namespace RandomWords
{
	partial class RandomWordsOptionsForm
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
			this.SaveButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.CapitalizationComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.NumberOfWordsNUD = new System.Windows.Forms.NumericUpDown();
			this.WordDelimiterTextBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.NumberOfWordsNUD)).BeginInit();
			this.SuspendLayout();
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(232, 142);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 0;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(151, 142);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 23);
			this.CancelButton.TabIndex = 0;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// CapitalizationComboBox
			// 
			this.CapitalizationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CapitalizationComboBox.FormattingEnabled = true;
			this.CapitalizationComboBox.Location = new System.Drawing.Point(186, 83);
			this.CapitalizationComboBox.Name = "CapitalizationComboBox";
			this.CapitalizationComboBox.Size = new System.Drawing.Size(121, 21);
			this.CapitalizationComboBox.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(102, 86);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Capitalization";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(68, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Separate words with";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(147, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Number of words in Password";
			// 
			// NumberOfWordsNUD
			// 
			this.NumberOfWordsNUD.Location = new System.Drawing.Point(186, 17);
			this.NumberOfWordsNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumberOfWordsNUD.Name = "NumberOfWordsNUD";
			this.NumberOfWordsNUD.Size = new System.Drawing.Size(121, 20);
			this.NumberOfWordsNUD.TabIndex = 1;
			this.NumberOfWordsNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumberOfWordsNUD.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// WordDelimiterTextBox
			// 
			this.WordDelimiterTextBox.Location = new System.Drawing.Point(186, 51);
			this.WordDelimiterTextBox.Name = "WordDelimiterTextBox";
			this.WordDelimiterTextBox.Size = new System.Drawing.Size(121, 20);
			this.WordDelimiterTextBox.TabIndex = 2;
			// 
			// RandomWordsOptionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 177);
			this.Controls.Add(this.WordDelimiterTextBox);
			this.Controls.Add(this.NumberOfWordsNUD);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.CapitalizationComboBox);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.SaveButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RandomWordsOptionsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Random Words Options";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.NumberOfWordsNUD)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.ComboBox CapitalizationComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown NumberOfWordsNUD;
		private System.Windows.Forms.TextBox WordDelimiterTextBox;
	}
}