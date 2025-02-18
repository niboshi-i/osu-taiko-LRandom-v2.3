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
            this.ComboBoxFirstLanguege = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.ButtonSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComboBoxFirstLanguege
            // 
            this.ComboBoxFirstLanguege.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFirstLanguege.FormattingEnabled = true;
            this.ComboBoxFirstLanguege.Location = new System.Drawing.Point(18, 37);
            this.ComboBoxFirstLanguege.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ComboBoxFirstLanguege.Name = "ComboBoxFirstLanguege";
            this.ComboBoxFirstLanguege.Size = new System.Drawing.Size(133, 28);
            this.ComboBoxFirstLanguege.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label1.Location = new System.Drawing.Point(14, 9);
            this.Label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(137, 24);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Select Language";
            // 
            // ButtonSelect
            // 
            this.ButtonSelect.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonSelect.Location = new System.Drawing.Point(166, 9);
            this.ButtonSelect.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ButtonSelect.Name = "ButtonSelect";
            this.ButtonSelect.Size = new System.Drawing.Size(95, 63);
            this.ButtonSelect.TabIndex = 2;
            this.ButtonSelect.Text = "OK";
            this.ButtonSelect.UseVisualStyleBackColor = true;
            // 
            // CustomDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 81);
            this.Controls.Add(this.ButtonSelect);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ComboBoxFirstLanguege);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximumSize = new System.Drawing.Size(291, 120);
            this.MinimumSize = new System.Drawing.Size(291, 120);
            this.Name = "CustomDialog";
            this.Text = "osu!taiko LRandom";
            this.Load += new System.EventHandler(this.CustomDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxFirstLanguege;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button ButtonSelect;
    }
}