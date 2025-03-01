namespace taiko
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonMake = new System.Windows.Forms.Button();
            this.RadioButtonR = new System.Windows.Forms.RadioButton();
            this.RadioButtonLR = new System.Windows.Forms.RadioButton();
            this.TextBoxRule = new System.Windows.Forms.TextBox();
            this.TextBoxSelectedMap = new System.Windows.Forms.TextBox();
            this.LabelSelectMap = new System.Windows.Forms.Label();
            this.CheckBoxOverwrite = new System.Windows.Forms.CheckBox();
            this.LabelDiffNumber = new System.Windows.Forms.Label();
            this.LabelCount = new System.Windows.Forms.Label();
            this.ComboBoxFromHistory = new System.Windows.Forms.ComboBox();
            this.LabelSelectHistory = new System.Windows.Forms.Label();
            this.ButtonAllSelect = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.NumericUpDownHP = new System.Windows.Forms.NumericUpDown();
            this.CheckBoxHP = new System.Windows.Forms.CheckBox();
            this.NumericUpDownOD = new System.Windows.Forms.NumericUpDown();
            this.CheckBoxOD = new System.Windows.Forms.CheckBox();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.CheckBoxOriginalDiff = new System.Windows.Forms.CheckBox();
            this.NumericUpDownNum = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDowncount = new System.Windows.Forms.NumericUpDown();
            this.CheckBoxNoChange = new System.Windows.Forms.CheckBox();
            this.NumericUpDownOffset = new System.Windows.Forms.NumericUpDown();
            this.CheckBoxSV = new System.Windows.Forms.CheckBox();
            this.LabelOffset = new System.Windows.Forms.Label();
            this.ButtonRead = new System.Windows.Forms.Button();
            this.LabelReport = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.ButtonAllCancel = new System.Windows.Forms.Button();
            this.LabelDelinfo = new System.Windows.Forms.Label();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RadioButtonPicOff = new System.Windows.Forms.RadioButton();
            this.RadioButtonPicOn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RadioButtonHistoryOff = new System.Windows.Forms.RadioButton();
            this.RadioButtonHistoryOn = new System.Windows.Forms.RadioButton();
            this.LabelBG = new System.Windows.Forms.Label();
            this.LabelHistory = new System.Windows.Forms.Label();
            this.LabelLanguage = new System.Windows.Forms.Label();
            this.ComboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.TabControl.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDowncount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownOffset)).BeginInit();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.TabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonMake
            // 
            this.ButtonMake.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonMake.Location = new System.Drawing.Point(344, 97);
            this.ButtonMake.Name = "ButtonMake";
            this.ButtonMake.Size = new System.Drawing.Size(114, 70);
            this.ButtonMake.TabIndex = 0;
            this.ButtonMake.Text = "実行";
            this.ButtonMake.UseVisualStyleBackColor = true;
            this.ButtonMake.Click += new System.EventHandler(this.ButtonMake_Click);
            // 
            // RadioButtonR
            // 
            this.RadioButtonR.AutoSize = true;
            this.RadioButtonR.Checked = true;
            this.RadioButtonR.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RadioButtonR.Location = new System.Drawing.Point(210, 187);
            this.RadioButtonR.Name = "RadioButtonR";
            this.RadioButtonR.Size = new System.Drawing.Size(116, 35);
            this.RadioButtonR.TabIndex = 3;
            this.RadioButtonR.TabStop = true;
            this.RadioButtonR.Text = "でたらめ";
            this.RadioButtonR.UseVisualStyleBackColor = true;
            // 
            // RadioButtonLR
            // 
            this.RadioButtonLR.AutoSize = true;
            this.RadioButtonLR.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RadioButtonLR.Location = new System.Drawing.Point(210, 228);
            this.RadioButtonLR.Name = "RadioButtonLR";
            this.RadioButtonLR.Size = new System.Drawing.Size(200, 35);
            this.RadioButtonLR.TabIndex = 4;
            this.RadioButtonLR.Text = "制限付きでたらめ";
            this.RadioButtonLR.UseVisualStyleBackColor = true;
            // 
            // TextBoxRule
            // 
            this.TextBoxRule.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxRule.Location = new System.Drawing.Point(416, 228);
            this.TextBoxRule.Name = "TextBoxRule";
            this.TextBoxRule.Size = new System.Drawing.Size(150, 31);
            this.TextBoxRule.TabIndex = 8;
            // 
            // TextBoxSelectedMap
            // 
            this.TextBoxSelectedMap.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxSelectedMap.Location = new System.Drawing.Point(26, 15);
            this.TextBoxSelectedMap.Name = "TextBoxSelectedMap";
            this.TextBoxSelectedMap.ReadOnly = true;
            this.TextBoxSelectedMap.Size = new System.Drawing.Size(482, 27);
            this.TextBoxSelectedMap.TabIndex = 12;
            // 
            // LabelSelectMap
            // 
            this.LabelSelectMap.AutoSize = true;
            this.LabelSelectMap.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelSelectMap.Location = new System.Drawing.Point(514, 18);
            this.LabelSelectMap.Name = "LabelSelectMap";
            this.LabelSelectMap.Size = new System.Drawing.Size(106, 24);
            this.LabelSelectMap.TabIndex = 15;
            this.LabelSelectMap.Text = "元になる譜面";
            // 
            // CheckBoxOverwrite
            // 
            this.CheckBoxOverwrite.AutoSize = true;
            this.CheckBoxOverwrite.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBoxOverwrite.Location = new System.Drawing.Point(210, 314);
            this.CheckBoxOverwrite.Name = "CheckBoxOverwrite";
            this.CheckBoxOverwrite.Size = new System.Drawing.Size(349, 28);
            this.CheckBoxOverwrite.TabIndex = 22;
            this.CheckBoxOverwrite.Text = "同名のファイルがすでにある場合上書きする";
            this.CheckBoxOverwrite.UseVisualStyleBackColor = true;
            // 
            // LabelDiffNumber
            // 
            this.LabelDiffNumber.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelDiffNumber.Location = new System.Drawing.Point(374, 189);
            this.LabelDiffNumber.Name = "LabelDiffNumber";
            this.LabelDiffNumber.Size = new System.Drawing.Size(166, 20);
            this.LabelDiffNumber.TabIndex = 21;
            this.LabelDiffNumber.Text = "後ろに付く数字の始点";
            this.LabelDiffNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelCount
            // 
            this.LabelCount.AutoSize = true;
            this.LabelCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelCount.Location = new System.Drawing.Point(474, 119);
            this.LabelCount.Name = "LabelCount";
            this.LabelCount.Size = new System.Drawing.Size(69, 28);
            this.LabelCount.TabIndex = 21;
            this.LabelCount.Text = "作る数";
            this.LabelCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ComboBoxFromHistory
            // 
            this.ComboBoxFromHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFromHistory.DropDownWidth = 482;
            this.ComboBoxFromHistory.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ComboBoxFromHistory.FormattingEnabled = true;
            this.ComboBoxFromHistory.ItemHeight = 20;
            this.ComboBoxFromHistory.Location = new System.Drawing.Point(26, 48);
            this.ComboBoxFromHistory.Name = "ComboBoxFromHistory";
            this.ComboBoxFromHistory.Size = new System.Drawing.Size(482, 28);
            this.ComboBoxFromHistory.TabIndex = 22;
            this.ComboBoxFromHistory.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxFromHistory_SelectionChangeCommitted);
            // 
            // LabelSelectHistory
            // 
            this.LabelSelectHistory.AutoSize = true;
            this.LabelSelectHistory.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelSelectHistory.Location = new System.Drawing.Point(514, 52);
            this.LabelSelectHistory.Name = "LabelSelectHistory";
            this.LabelSelectHistory.Size = new System.Drawing.Size(106, 24);
            this.LabelSelectHistory.TabIndex = 23;
            this.LabelSelectHistory.Text = "履歴から選ぶ";
            // 
            // ButtonAllSelect
            // 
            this.ButtonAllSelect.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonAllSelect.Location = new System.Drawing.Point(49, 295);
            this.ButtonAllSelect.Name = "ButtonAllSelect";
            this.ButtonAllSelect.Size = new System.Drawing.Size(123, 47);
            this.ButtonAllSelect.TabIndex = 24;
            this.ButtonAllSelect.Text = "全て選択";
            this.ButtonAllSelect.UseVisualStyleBackColor = true;
            this.ButtonAllSelect.Click += new System.EventHandler(this.ButtonAllSelect_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonDelete.Location = new System.Drawing.Point(418, 295);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(162, 47);
            this.ButtonDelete.TabIndex = 25;
            this.ButtonDelete.Text = "選択中の項目を削除";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // TabControl
            // 
            this.TabControl.AllowDrop = true;
            this.TabControl.Controls.Add(this.TabPage1);
            this.TabControl.Controls.Add(this.TabPage2);
            this.TabControl.Controls.Add(this.TabPage3);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(634, 392);
            this.TabControl.TabIndex = 28;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            this.TabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl_Selecting);
            this.TabControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.TabControl_DragDrop);
            this.TabControl.DragEnter += new System.Windows.Forms.DragEventHandler(this.TabControl_DragEnter);
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage1.Controls.Add(this.NumericUpDownHP);
            this.TabPage1.Controls.Add(this.CheckBoxHP);
            this.TabPage1.Controls.Add(this.NumericUpDownOD);
            this.TabPage1.Controls.Add(this.CheckBoxOD);
            this.TabPage1.Controls.Add(this.CheckBoxOverwrite);
            this.TabPage1.Controls.Add(this.PictureBox);
            this.TabPage1.Controls.Add(this.CheckBoxOriginalDiff);
            this.TabPage1.Controls.Add(this.NumericUpDownNum);
            this.TabPage1.Controls.Add(this.NumericUpDowncount);
            this.TabPage1.Controls.Add(this.CheckBoxNoChange);
            this.TabPage1.Controls.Add(this.NumericUpDownOffset);
            this.TabPage1.Controls.Add(this.CheckBoxSV);
            this.TabPage1.Controls.Add(this.LabelOffset);
            this.TabPage1.Controls.Add(this.ButtonRead);
            this.TabPage1.Controls.Add(this.LabelDiffNumber);
            this.TabPage1.Controls.Add(this.LabelReport);
            this.TabPage1.Controls.Add(this.LabelCount);
            this.TabPage1.Controls.Add(this.LabelSelectHistory);
            this.TabPage1.Controls.Add(this.ComboBoxFromHistory);
            this.TabPage1.Controls.Add(this.TextBoxRule);
            this.TabPage1.Controls.Add(this.RadioButtonLR);
            this.TabPage1.Controls.Add(this.RadioButtonR);
            this.TabPage1.Controls.Add(this.ButtonMake);
            this.TabPage1.Controls.Add(this.LabelSelectMap);
            this.TabPage1.Controls.Add(this.TextBoxSelectedMap);
            this.TabPage1.Location = new System.Drawing.Point(4, 27);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(626, 361);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "メインメニュー";
            // 
            // NumericUpDownHP
            // 
            this.NumericUpDownHP.DecimalPlaces = 1;
            this.NumericUpDownHP.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NumericUpDownHP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericUpDownHP.Location = new System.Drawing.Point(72, 220);
            this.NumericUpDownHP.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericUpDownHP.Name = "NumericUpDownHP";
            this.NumericUpDownHP.Size = new System.Drawing.Size(50, 27);
            this.NumericUpDownHP.TabIndex = 39;
            this.NumericUpDownHP.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // CheckBoxHP
            // 
            this.CheckBoxHP.AutoSize = true;
            this.CheckBoxHP.BackColor = System.Drawing.SystemColors.Control;
            this.CheckBoxHP.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBoxHP.Location = new System.Drawing.Point(20, 220);
            this.CheckBoxHP.Name = "CheckBoxHP";
            this.CheckBoxHP.Size = new System.Drawing.Size(51, 28);
            this.CheckBoxHP.TabIndex = 40;
            this.CheckBoxHP.Text = "HP";
            this.CheckBoxHP.UseVisualStyleBackColor = false;
            // 
            // NumericUpDownOD
            // 
            this.NumericUpDownOD.DecimalPlaces = 1;
            this.NumericUpDownOD.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NumericUpDownOD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericUpDownOD.Location = new System.Drawing.Point(72, 192);
            this.NumericUpDownOD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericUpDownOD.Name = "NumericUpDownOD";
            this.NumericUpDownOD.Size = new System.Drawing.Size(50, 27);
            this.NumericUpDownOD.TabIndex = 37;
            this.NumericUpDownOD.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // CheckBoxOD
            // 
            this.CheckBoxOD.AutoSize = true;
            this.CheckBoxOD.BackColor = System.Drawing.SystemColors.Control;
            this.CheckBoxOD.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBoxOD.Location = new System.Drawing.Point(20, 192);
            this.CheckBoxOD.Name = "CheckBoxOD";
            this.CheckBoxOD.Size = new System.Drawing.Size(53, 28);
            this.CheckBoxOD.TabIndex = 38;
            this.CheckBoxOD.Text = "OD";
            this.CheckBoxOD.UseVisualStyleBackColor = false;
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(47, 94);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(110, 80);
            this.PictureBox.TabIndex = 29;
            this.PictureBox.TabStop = false;
            // 
            // CheckBoxOriginalDiff
            // 
            this.CheckBoxOriginalDiff.AutoSize = true;
            this.CheckBoxOriginalDiff.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBoxOriginalDiff.Location = new System.Drawing.Point(210, 280);
            this.CheckBoxOriginalDiff.Name = "CheckBoxOriginalDiff";
            this.CheckBoxOriginalDiff.Size = new System.Drawing.Size(317, 28);
            this.CheckBoxOriginalDiff.TabIndex = 19;
            this.CheckBoxOriginalDiff.Text = "生成する譜面に元の難易度名を残さない";
            this.CheckBoxOriginalDiff.UseVisualStyleBackColor = true;
            // 
            // NumericUpDownNum
            // 
            this.NumericUpDownNum.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NumericUpDownNum.Location = new System.Drawing.Point(546, 187);
            this.NumericUpDownNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericUpDownNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownNum.Name = "NumericUpDownNum";
            this.NumericUpDownNum.Size = new System.Drawing.Size(54, 27);
            this.NumericUpDownNum.TabIndex = 36;
            this.NumericUpDownNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUpDownNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NumericUpDowncount
            // 
            this.NumericUpDowncount.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NumericUpDowncount.Location = new System.Drawing.Point(546, 117);
            this.NumericUpDowncount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericUpDowncount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDowncount.Name = "NumericUpDowncount";
            this.NumericUpDowncount.Size = new System.Drawing.Size(55, 31);
            this.NumericUpDowncount.TabIndex = 35;
            this.NumericUpDowncount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUpDowncount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CheckBoxNoChange
            // 
            this.CheckBoxNoChange.AutoSize = true;
            this.CheckBoxNoChange.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBoxNoChange.Location = new System.Drawing.Point(47, 291);
            this.CheckBoxNoChange.Name = "CheckBoxNoChange";
            this.CheckBoxNoChange.Size = new System.Drawing.Size(123, 22);
            this.CheckBoxNoChange.TabIndex = 34;
            this.CheckBoxNoChange.Text = "ノーツを変えない";
            this.CheckBoxNoChange.UseVisualStyleBackColor = true;
            this.CheckBoxNoChange.CheckedChanged += new System.EventHandler(this.CheckBoxNoChange_CheckedChanged);
            // 
            // NumericUpDownOffset
            // 
            this.NumericUpDownOffset.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NumericUpDownOffset.Location = new System.Drawing.Point(131, 218);
            this.NumericUpDownOffset.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NumericUpDownOffset.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.NumericUpDownOffset.Name = "NumericUpDownOffset";
            this.NumericUpDownOffset.Size = new System.Drawing.Size(57, 27);
            this.NumericUpDownOffset.TabIndex = 33;
            // 
            // CheckBoxSV
            // 
            this.CheckBoxSV.AutoSize = true;
            this.CheckBoxSV.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBoxSV.Location = new System.Drawing.Point(47, 257);
            this.CheckBoxSV.Name = "CheckBoxSV";
            this.CheckBoxSV.Size = new System.Drawing.Size(75, 28);
            this.CheckBoxSV.TabIndex = 32;
            this.CheckBoxSV.Text = "no SV";
            this.CheckBoxSV.UseVisualStyleBackColor = true;
            // 
            // LabelOffset
            // 
            this.LabelOffset.AutoSize = true;
            this.LabelOffset.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelOffset.Location = new System.Drawing.Point(131, 195);
            this.LabelOffset.Name = "LabelOffset";
            this.LabelOffset.Size = new System.Drawing.Size(56, 24);
            this.LabelOffset.TabIndex = 30;
            this.LabelOffset.Text = "Offset";
            // 
            // ButtonRead
            // 
            this.ButtonRead.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonRead.Location = new System.Drawing.Point(212, 97);
            this.ButtonRead.Name = "ButtonRead";
            this.ButtonRead.Size = new System.Drawing.Size(114, 70);
            this.ButtonRead.TabIndex = 25;
            this.ButtonRead.Text = "読み込む";
            this.ButtonRead.UseVisualStyleBackColor = true;
            this.ButtonRead.Click += new System.EventHandler(this.ButtonRead_Click);
            // 
            // LabelReport
            // 
            this.LabelReport.AutoSize = true;
            this.LabelReport.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelReport.Location = new System.Drawing.Point(28, 323);
            this.LabelReport.Name = "LabelReport";
            this.LabelReport.Size = new System.Drawing.Size(0, 24);
            this.LabelReport.TabIndex = 24;
            // 
            // TabPage2
            // 
            this.TabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage2.Controls.Add(this.ButtonAllCancel);
            this.TabPage2.Controls.Add(this.LabelDelinfo);
            this.TabPage2.Controls.Add(this.DataGridView);
            this.TabPage2.Controls.Add(this.ButtonAllSelect);
            this.TabPage2.Controls.Add(this.ButtonDelete);
            this.TabPage2.Location = new System.Drawing.Point(4, 27);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TabPage2.Size = new System.Drawing.Size(626, 361);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "履歴";
            // 
            // ButtonAllCancel
            // 
            this.ButtonAllCancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonAllCancel.Location = new System.Drawing.Point(178, 295);
            this.ButtonAllCancel.Name = "ButtonAllCancel";
            this.ButtonAllCancel.Size = new System.Drawing.Size(123, 47);
            this.ButtonAllCancel.TabIndex = 30;
            this.ButtonAllCancel.Text = "全て解除";
            this.ButtonAllCancel.UseVisualStyleBackColor = true;
            this.ButtonAllCancel.Click += new System.EventHandler(this.ButtonAllCancel_Click);
            // 
            // LabelDelinfo
            // 
            this.LabelDelinfo.AutoSize = true;
            this.LabelDelinfo.Location = new System.Drawing.Point(378, 343);
            this.LabelDelinfo.Name = "LabelDelinfo";
            this.LabelDelinfo.Size = new System.Drawing.Size(224, 18);
            this.LabelDelinfo.TabIndex = 29;
            this.LabelDelinfo.Text = "履歴から消えるだけで譜面は消えません";
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToOrderColumns = true;
            this.DataGridView.AllowUserToResizeColumns = false;
            this.DataGridView.AllowUserToResizeRows = false;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(24, 19);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowTemplate.Height = 21;
            this.DataGridView.Size = new System.Drawing.Size(578, 270);
            this.DataGridView.TabIndex = 28;
            this.DataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellClick);
            // 
            // TabPage3
            // 
            this.TabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage3.Controls.Add(this.panel2);
            this.TabPage3.Controls.Add(this.panel1);
            this.TabPage3.Controls.Add(this.LabelBG);
            this.TabPage3.Controls.Add(this.LabelHistory);
            this.TabPage3.Controls.Add(this.LabelLanguage);
            this.TabPage3.Controls.Add(this.ComboBoxLanguage);
            this.TabPage3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TabPage3.Location = new System.Drawing.Point(4, 27);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(626, 361);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "詳細設定";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RadioButtonPicOff);
            this.panel2.Controls.Add(this.RadioButtonPicOn);
            this.panel2.Location = new System.Drawing.Point(188, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(233, 46);
            this.panel2.TabIndex = 13;
            // 
            // RadioButtonPicOff
            // 
            this.RadioButtonPicOff.AutoSize = true;
            this.RadioButtonPicOff.Location = new System.Drawing.Point(106, 10);
            this.RadioButtonPicOff.Name = "RadioButtonPicOff";
            this.RadioButtonPicOff.Size = new System.Drawing.Size(124, 28);
            this.RadioButtonPicOff.TabIndex = 3;
            this.RadioButtonPicOff.Text = "読み込まない";
            this.RadioButtonPicOff.UseVisualStyleBackColor = true;
            this.RadioButtonPicOff.Click += new System.EventHandler(this.RadioButtonPicOff_Click);
            // 
            // RadioButtonPicOn
            // 
            this.RadioButtonPicOn.AutoSize = true;
            this.RadioButtonPicOn.Checked = true;
            this.RadioButtonPicOn.Location = new System.Drawing.Point(8, 10);
            this.RadioButtonPicOn.Name = "RadioButtonPicOn";
            this.RadioButtonPicOn.Size = new System.Drawing.Size(92, 28);
            this.RadioButtonPicOn.TabIndex = 2;
            this.RadioButtonPicOn.TabStop = true;
            this.RadioButtonPicOn.Text = "読み込む";
            this.RadioButtonPicOn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RadioButtonHistoryOff);
            this.panel1.Controls.Add(this.RadioButtonHistoryOn);
            this.panel1.Location = new System.Drawing.Point(188, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 46);
            this.panel1.TabIndex = 12;
            // 
            // RadioButtonHistoryOff
            // 
            this.RadioButtonHistoryOff.AutoSize = true;
            this.RadioButtonHistoryOff.Location = new System.Drawing.Point(106, 9);
            this.RadioButtonHistoryOff.Name = "RadioButtonHistoryOff";
            this.RadioButtonHistoryOff.Size = new System.Drawing.Size(92, 28);
            this.RadioButtonHistoryOff.TabIndex = 3;
            this.RadioButtonHistoryOff.Text = "残さない";
            this.RadioButtonHistoryOff.UseVisualStyleBackColor = true;
            // 
            // RadioButtonHistoryOn
            // 
            this.RadioButtonHistoryOn.AutoSize = true;
            this.RadioButtonHistoryOn.Checked = true;
            this.RadioButtonHistoryOn.Location = new System.Drawing.Point(8, 9);
            this.RadioButtonHistoryOn.Name = "RadioButtonHistoryOn";
            this.RadioButtonHistoryOn.Size = new System.Drawing.Size(60, 28);
            this.RadioButtonHistoryOn.TabIndex = 2;
            this.RadioButtonHistoryOn.TabStop = true;
            this.RadioButtonHistoryOn.Text = "残す";
            this.RadioButtonHistoryOn.UseVisualStyleBackColor = true;
            // 
            // LabelBG
            // 
            this.LabelBG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelBG.Location = new System.Drawing.Point(32, 134);
            this.LabelBG.Name = "LabelBG";
            this.LabelBG.Size = new System.Drawing.Size(147, 24);
            this.LabelBG.TabIndex = 7;
            this.LabelBG.Text = "背景の画像";
            this.LabelBG.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelHistory
            // 
            this.LabelHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelHistory.Location = new System.Drawing.Point(41, 81);
            this.LabelHistory.Name = "LabelHistory";
            this.LabelHistory.Size = new System.Drawing.Size(134, 24);
            this.LabelHistory.TabIndex = 5;
            this.LabelHistory.Text = "履歴";
            this.LabelHistory.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelLanguage
            // 
            this.LabelLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelLanguage.Location = new System.Drawing.Point(45, 32);
            this.LabelLanguage.Name = "LabelLanguage";
            this.LabelLanguage.Size = new System.Drawing.Size(130, 24);
            this.LabelLanguage.TabIndex = 1;
            this.LabelLanguage.Text = "言語設定";
            this.LabelLanguage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ComboBoxLanguage
            // 
            this.ComboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxLanguage.FormattingEnabled = true;
            this.ComboBoxLanguage.Location = new System.Drawing.Point(191, 29);
            this.ComboBoxLanguage.Name = "ComboBoxLanguage";
            this.ComboBoxLanguage.Size = new System.Drawing.Size(178, 32);
            this.ComboBoxLanguage.TabIndex = 0;
            this.ComboBoxLanguage.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxLanguage_SelectionChangeCommitted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 392);
            this.Controls.Add(this.TabControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 431);
            this.MinimumSize = new System.Drawing.Size(650, 431);
            this.Name = "Form1";
            this.Text = "osu!taiko LRandom v2.8.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TabControl.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDowncount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownOffset)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.TabPage3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonMake;
        private System.Windows.Forms.RadioButton RadioButtonR;
        private System.Windows.Forms.RadioButton RadioButtonLR;
        private System.Windows.Forms.TextBox TextBoxRule;
        private System.Windows.Forms.TextBox TextBoxSelectedMap;
        private System.Windows.Forms.Label LabelSelectMap;
        private System.Windows.Forms.Label LabelDiffNumber;
        private System.Windows.Forms.Label LabelCount;
        private System.Windows.Forms.CheckBox CheckBoxOverwrite;
        private System.Windows.Forms.ComboBox ComboBoxFromHistory;
        private System.Windows.Forms.Label LabelSelectHistory;
        private System.Windows.Forms.Button ButtonAllSelect;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Label LabelDelinfo;
        private System.Windows.Forms.Button ButtonAllCancel;
        private System.Windows.Forms.Label LabelReport;
        private System.Windows.Forms.TabPage TabPage3;
        private System.Windows.Forms.Label LabelLanguage;
        private System.Windows.Forms.ComboBox ComboBoxLanguage;
        private System.Windows.Forms.RadioButton RadioButtonHistoryOn;
        private System.Windows.Forms.RadioButton RadioButtonHistoryOff;
        private System.Windows.Forms.Label LabelHistory;
        private System.Windows.Forms.Button ButtonRead;
        private System.Windows.Forms.Label LabelOffset;
        private System.Windows.Forms.CheckBox CheckBoxSV;
        private System.Windows.Forms.NumericUpDown NumericUpDownOffset;
        private System.Windows.Forms.CheckBox CheckBoxNoChange;
        private System.Windows.Forms.NumericUpDown NumericUpDowncount;
        private System.Windows.Forms.NumericUpDown NumericUpDownNum;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Label LabelBG;
        private System.Windows.Forms.RadioButton RadioButtonPicOn;
        private System.Windows.Forms.RadioButton RadioButtonPicOff;
        private System.Windows.Forms.CheckBox CheckBoxOriginalDiff;
        private System.Windows.Forms.NumericUpDown NumericUpDownOD;
        private System.Windows.Forms.CheckBox CheckBoxOD;
        private System.Windows.Forms.NumericUpDown NumericUpDownHP;
        private System.Windows.Forms.CheckBox CheckBoxHP;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}

