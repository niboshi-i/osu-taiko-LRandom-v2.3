namespace taiko
{
    partial class CustomDialog
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
            this.comboBoxFirstLanguege = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxFirstLanguege
            // 
            this.comboBoxFirstLanguege.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFirstLanguege.FormattingEnabled = true;
            this.comboBoxFirstLanguege.Location = new System.Drawing.Point(18, 37);
            this.comboBoxFirstLanguege.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBoxFirstLanguege.Name = "comboBoxFirstLanguege";
            this.comboBoxFirstLanguege.Size = new System.Drawing.Size(133, 28);
            this.comboBoxFirstLanguege.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Language";
            // 
            // buttonSelect
            // 
            this.buttonSelect.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSelect.Location = new System.Drawing.Point(166, 9);
            this.buttonSelect.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(95, 63);
            this.buttonSelect.TabIndex = 2;
            this.buttonSelect.Text = "OK";
            this.buttonSelect.UseVisualStyleBackColor = true;
            // 
            // CustomDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 81);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxFirstLanguege);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximumSize = new System.Drawing.Size(291, 120);
            this.MinimumSize = new System.Drawing.Size(291, 120);
            this.Name = "CustomDialog";
            this.Text = "osu!taiko LRandom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFirstLanguege;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelect;
    }
}