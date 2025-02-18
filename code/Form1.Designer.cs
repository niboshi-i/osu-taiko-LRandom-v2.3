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
            this.TextBoxBeforMapDate = new System.Windows.Forms.TextBox();
            this.RadioButtonR = new System.Windows.Forms.RadioButton();
            this.RadioButtonLR = new System.Windows.Forms.RadioButton();
            this.TextBoxAfterMapDate = new System.Windows.Forms.TextBox();
            this.TextBoxRule = new System.Windows.Forms.TextBox();
            this.TextBoxDiffBack = new System.Windows.Forms.TextBox();
            this.TextBoxSelectMap = new System.Windows.Forms.TextBox();
            this.LabelSelectMap = new System.Windows.Forms.Label();
            this.CheckBoxOriginalDiff = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CheckBoxOverwrite = new System.Windows.Forms.CheckBox();
            this.LabelDiffNumber = new System.Windows.Forms.Label();
            this.LabelCount = new System.Windows.Forms.Label();
            this.ComboBoxSelectHistory = new System.Windows.Forms.ComboBox();
            this.LabelSelectHistory = new System.Windows.Forms.Label();
            this.ButtonAllSelect = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.NumericUpDownNum = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDowncount = new System.Windows.Forms.NumericUpDown();
            this.CheckBoxNoChange = new System.Windows.Forms.CheckBox();
            this.NumericUpDownOffset = new System.Windows.Forms.NumericUpDown();
            this.CheckBoxSV = new System.Windows.Forms.CheckBox();
            this.LabelOffset = new System.Windows.Forms.Label();
            this.TextBoxHP = new System.Windows.Forms.TextBox();
            this.LabelHP = new System.Windows.Forms.Label();
            this.TextBoxOD = new System.Windows.Forms.TextBox();
            this.LabelOD = new System.Windows.Forms.Label();
            this.Buttonread = new System.Windows.Forms.Button();
            this.LabelReport = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.ButtonAllCancel = new System.Windows.Forms.Button();
            this.LabelDelinfo = new System.Windows.Forms.Label();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.ButtonSongs = new System.Windows.Forms.Button();
            this.LabelSongs = new System.Windows.Forms.Label();
            this.TextBoxSongs = new System.Windows.Forms.TextBox();
            this.LabelBG = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.RadioButtonPicOn = new System.Windows.Forms.RadioButton();
            this.RadioButtonPicOff = new System.Windows.Forms.RadioButton();
            this.LabelHistory = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RadioButtonHistoryOn = new System.Windows.Forms.RadioButton();
            this.RadioButtonHistoryOff = new System.Windows.Forms.RadioButton();
            this.LabelLanguage = new System.Windows.Forms.Label();
            this.ComboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDowncount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownOffset)).BeginInit();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.TabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonMake
            // 
            this.ButtonMake.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonMake.Location = new System.Drawing.Point(391, 101);
            this.ButtonMake.Name = "ButtonMake";
            this.ButtonMake.Size = new System.Drawing.Size(114, 70);
            this.ButtonMake.TabIndex = 0;
            this.ButtonMake.Text = "実行";
            this.ButtonMake.UseVisualStyleBackColor = true;
            this.ButtonMake.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TextBoxBeforMapDate
            // 
            this.TextBoxBeforMapDate.Location = new System.Drawing.Point(38, 92);
            this.TextBoxBeforMapDate.Multiline = true;
            this.TextBoxBeforMapDate.Name = "TextBoxBeforMapDate";
            this.TextBoxBeforMapDate.ReadOnly = true;
            this.TextBoxBeforMapDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxBeforMapDate.Size = new System.Drawing.Size(101, 131);
            this.TextBoxBeforMapDate.TabIndex = 2;
            // 
            // RadioButtonR
            // 
            this.RadioButtonR.AutoSize = true;
            this.RadioButtonR.Checked = true;
            this.RadioButtonR.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RadioButtonR.Location = new System.Drawing.Point(271, 191);
            this.RadioButtonR.Name = "RadioButtonR";
            this.RadioButtonR.Size = new System.Drawing.Size(116, 35);
            this.RadioButtonR.TabIndex = 3;
            this.RadioButtonR.TabStop = true;
            this.RadioButtonR.Text = "でたらめ";
            this.RadioButtonR.UseVisualStyleBackColor = true;
            this.RadioButtonR.Click += new System.EventHandler(this.RadioButtonR_Click);
            // 
            // RadioButtonLR
            // 
            this.RadioButtonLR.AutoSize = true;
            this.RadioButtonLR.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RadioButtonLR.Location = new System.Drawing.Point(271, 232);
            this.RadioButtonLR.Name = "RadioButtonLR";
            this.RadioButtonLR.Size = new System.Drawing.Size(200, 35);
            this.RadioButtonLR.TabIndex = 4;
            this.RadioButtonLR.Text = "制限付きでたらめ";
            this.RadioButtonLR.UseVisualStyleBackColor = true;
            this.RadioButtonLR.Click += new System.EventHandler(this.RadioButton2_Click);
            // 
            // TextBoxAfterMapDate
            // 
            this.TextBoxAfterMapDate.Location = new System.Drawing.Point(38, 236);
            this.TextBoxAfterMapDate.Multiline = true;
            this.TextBoxAfterMapDate.Name = "TextBoxAfterMapDate";
            this.TextBoxAfterMapDate.ReadOnly = true;
            this.TextBoxAfterMapDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxAfterMapDate.Size = new System.Drawing.Size(101, 131);
            this.TextBoxAfterMapDate.TabIndex = 7;
            // 
            // TextBoxRule
            // 
            this.TextBoxRule.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxRule.Location = new System.Drawing.Point(477, 232);
            this.TextBoxRule.Name = "TextBoxRule";
            this.TextBoxRule.Size = new System.Drawing.Size(150, 31);
            this.TextBoxRule.TabIndex = 8;
            this.TextBoxRule.TextChanged += new System.EventHandler(this.TextBoxRule_TextChanged);
            // 
            // TextBoxDiffBack
            // 
            this.TextBoxDiffBack.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxDiffBack.Location = new System.Drawing.Point(22, 70);
            this.TextBoxDiffBack.Name = "TextBoxDiffBack";
            this.TextBoxDiffBack.ReadOnly = true;
            this.TextBoxDiffBack.Size = new System.Drawing.Size(308, 31);
            this.TextBoxDiffBack.TabIndex = 9;
            // 
            // TextBoxSelectMap
            // 
            this.TextBoxSelectMap.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxSelectMap.Location = new System.Drawing.Point(26, 15);
            this.TextBoxSelectMap.Name = "TextBoxSelectMap";
            this.TextBoxSelectMap.ReadOnly = true;
            this.TextBoxSelectMap.Size = new System.Drawing.Size(495, 27);
            this.TextBoxSelectMap.TabIndex = 12;
            // 
            // LabelSelectMap
            // 
            this.LabelSelectMap.AutoSize = true;
            this.LabelSelectMap.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelSelectMap.Location = new System.Drawing.Point(527, 18);
            this.LabelSelectMap.Name = "LabelSelectMap";
            this.LabelSelectMap.Size = new System.Drawing.Size(122, 24);
            this.LabelSelectMap.TabIndex = 15;
            this.LabelSelectMap.Text = "生成したい譜面";
            // 
            // CheckBoxOriginalDiff
            // 
            this.CheckBoxOriginalDiff.AutoSize = true;
            this.CheckBoxOriginalDiff.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBoxOriginalDiff.Location = new System.Drawing.Point(3, 0);
            this.CheckBoxOriginalDiff.Name = "CheckBoxOriginalDiff";
            this.CheckBoxOriginalDiff.Size = new System.Drawing.Size(317, 28);
            this.CheckBoxOriginalDiff.TabIndex = 19;
            this.CheckBoxOriginalDiff.Text = "生成する譜面に元の難易度名を残さない";
            this.CheckBoxOriginalDiff.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CheckBoxOverwrite);
            this.panel1.Controls.Add(this.TextBoxDiffBack);
            this.panel1.Controls.Add(this.CheckBoxOriginalDiff);
            this.panel1.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel1.Location = new System.Drawing.Point(271, 281);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 112);
            this.panel1.TabIndex = 20;
            // 
            // CheckBoxOverwrite
            // 
            this.CheckBoxOverwrite.AutoSize = true;
            this.CheckBoxOverwrite.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBoxOverwrite.Location = new System.Drawing.Point(3, 33);
            this.CheckBoxOverwrite.Name = "CheckBoxOverwrite";
            this.CheckBoxOverwrite.Size = new System.Drawing.Size(349, 28);
            this.CheckBoxOverwrite.TabIndex = 22;
            this.CheckBoxOverwrite.Text = "同名のファイルがすでにある場合上書きする";
            this.CheckBoxOverwrite.UseVisualStyleBackColor = true;
            // 
            // LabelDiffNumber
            // 
            this.LabelDiffNumber.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelDiffNumber.Location = new System.Drawing.Point(414, 200);
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
            this.LabelCount.Location = new System.Drawing.Point(514, 119);
            this.LabelCount.Name = "LabelCount";
            this.LabelCount.Size = new System.Drawing.Size(69, 28);
            this.LabelCount.TabIndex = 21;
            this.LabelCount.Text = "作る数";
            this.LabelCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ComboBoxSelectHistory
            // 
            this.ComboBoxSelectHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSelectHistory.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ComboBoxSelectHistory.FormattingEnabled = true;
            this.ComboBoxSelectHistory.ItemHeight = 20;
            this.ComboBoxSelectHistory.Location = new System.Drawing.Point(26, 48);
            this.ComboBoxSelectHistory.Name = "ComboBoxSelectHistory";
            this.ComboBoxSelectHistory.Size = new System.Drawing.Size(495, 28);
            this.ComboBoxSelectHistory.TabIndex = 22;
            this.ComboBoxSelectHistory.SelectionChangeCommitted += new System.EventHandler(this.ComboBox1_SelectionChangeCommitted);
            // 
            // LabelSelectHistory
            // 
            this.LabelSelectHistory.AutoSize = true;
            this.LabelSelectHistory.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelSelectHistory.Location = new System.Drawing.Point(527, 52);
            this.LabelSelectHistory.Name = "LabelSelectHistory";
            this.LabelSelectHistory.Size = new System.Drawing.Size(138, 24);
            this.LabelSelectHistory.TabIndex = 23;
            this.LabelSelectHistory.Text = "履歴から選択する";
            // 
            // ButtonAllSelect
            // 
            this.ButtonAllSelect.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonAllSelect.Location = new System.Drawing.Point(49, 330);
            this.ButtonAllSelect.Name = "ButtonAllSelect";
            this.ButtonAllSelect.Size = new System.Drawing.Size(123, 47);
            this.ButtonAllSelect.TabIndex = 24;
            this.ButtonAllSelect.Text = "全て選択";
            this.ButtonAllSelect.UseVisualStyleBackColor = true;
            this.ButtonAllSelect.Click += new System.EventHandler(this.Button2_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonDelete.Location = new System.Drawing.Point(467, 330);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(162, 47);
            this.ButtonDelete.TabIndex = 25;
            this.ButtonDelete.Text = "選択中の項目を削除";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.Button3_Click_1);
            // 
            // TabControl1
            // 
            this.TabControl1.AllowDrop = true;
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(686, 433);
            this.TabControl1.TabIndex = 28;
            this.TabControl1.Click += new System.EventHandler(this.TabControl1_Click);
            this.TabControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.TabControl1_DragDrop);
            this.TabControl1.DragEnter += new System.Windows.Forms.DragEventHandler(this.TabControl1_DragEnter);
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage1.Controls.Add(this.PictureBox);
            this.TabPage1.Controls.Add(this.NumericUpDownNum);
            this.TabPage1.Controls.Add(this.NumericUpDowncount);
            this.TabPage1.Controls.Add(this.CheckBoxNoChange);
            this.TabPage1.Controls.Add(this.NumericUpDownOffset);
            this.TabPage1.Controls.Add(this.CheckBoxSV);
            this.TabPage1.Controls.Add(this.LabelOffset);
            this.TabPage1.Controls.Add(this.TextBoxHP);
            this.TabPage1.Controls.Add(this.LabelHP);
            this.TabPage1.Controls.Add(this.TextBoxOD);
            this.TabPage1.Controls.Add(this.LabelOD);
            this.TabPage1.Controls.Add(this.Buttonread);
            this.TabPage1.Controls.Add(this.LabelDiffNumber);
            this.TabPage1.Controls.Add(this.LabelReport);
            this.TabPage1.Controls.Add(this.TextBoxBeforMapDate);
            this.TabPage1.Controls.Add(this.LabelCount);
            this.TabPage1.Controls.Add(this.LabelSelectHistory);
            this.TabPage1.Controls.Add(this.panel1);
            this.TabPage1.Controls.Add(this.ComboBoxSelectHistory);
            this.TabPage1.Controls.Add(this.TextBoxAfterMapDate);
            this.TabPage1.Controls.Add(this.TextBoxRule);
            this.TabPage1.Controls.Add(this.RadioButtonLR);
            this.TabPage1.Controls.Add(this.RadioButtonR);
            this.TabPage1.Controls.Add(this.ButtonMake);
            this.TabPage1.Controls.Add(this.LabelSelectMap);
            this.TabPage1.Controls.Add(this.TextBoxSelectMap);
            this.TabPage1.Location = new System.Drawing.Point(4, 27);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(678, 402);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "メインメニュー";
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(150, 101);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(110, 80);
            this.PictureBox.TabIndex = 29;
            this.PictureBox.TabStop = false;
            // 
            // NumericUpDownNum
            // 
            this.NumericUpDownNum.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NumericUpDownNum.Location = new System.Drawing.Point(586, 197);
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
            this.NumericUpDownNum.ValueChanged += new System.EventHandler(this.NumericUpDownNum_ValueChanged);
            // 
            // NumericUpDowncount
            // 
            this.NumericUpDowncount.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NumericUpDowncount.Location = new System.Drawing.Point(586, 117);
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
            this.CheckBoxNoChange.Location = new System.Drawing.Point(164, 351);
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
            this.NumericUpDownOffset.Location = new System.Drawing.Point(164, 288);
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
            this.NumericUpDownOffset.Size = new System.Drawing.Size(77, 27);
            this.NumericUpDownOffset.TabIndex = 33;
            // 
            // CheckBoxSV
            // 
            this.CheckBoxSV.AutoSize = true;
            this.CheckBoxSV.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBoxSV.Location = new System.Drawing.Point(164, 323);
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
            this.LabelOffset.Location = new System.Drawing.Point(165, 265);
            this.LabelOffset.Name = "LabelOffset";
            this.LabelOffset.Size = new System.Drawing.Size(56, 24);
            this.LabelOffset.TabIndex = 30;
            this.LabelOffset.Text = "Offset";
            // 
            // TextBoxHP
            // 
            this.TextBoxHP.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxHP.Location = new System.Drawing.Point(211, 223);
            this.TextBoxHP.Name = "TextBoxHP";
            this.TextBoxHP.Size = new System.Drawing.Size(30, 27);
            this.TextBoxHP.TabIndex = 29;
            // 
            // LabelHP
            // 
            this.LabelHP.AutoSize = true;
            this.LabelHP.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelHP.Location = new System.Drawing.Point(211, 200);
            this.LabelHP.Name = "LabelHP";
            this.LabelHP.Size = new System.Drawing.Size(32, 24);
            this.LabelHP.TabIndex = 28;
            this.LabelHP.Text = "HP";
            // 
            // TextBoxOD
            // 
            this.TextBoxOD.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxOD.Location = new System.Drawing.Point(164, 223);
            this.TextBoxOD.Name = "TextBoxOD";
            this.TextBoxOD.Size = new System.Drawing.Size(30, 27);
            this.TextBoxOD.TabIndex = 27;
            // 
            // LabelOD
            // 
            this.LabelOD.AutoSize = true;
            this.LabelOD.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelOD.Location = new System.Drawing.Point(163, 200);
            this.LabelOD.Name = "LabelOD";
            this.LabelOD.Size = new System.Drawing.Size(34, 24);
            this.LabelOD.TabIndex = 26;
            this.LabelOD.Text = "OD";
            // 
            // Buttonread
            // 
            this.Buttonread.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Buttonread.Location = new System.Drawing.Point(271, 101);
            this.Buttonread.Name = "Buttonread";
            this.Buttonread.Size = new System.Drawing.Size(114, 70);
            this.Buttonread.TabIndex = 25;
            this.Buttonread.Text = "読み込む";
            this.Buttonread.UseVisualStyleBackColor = true;
            this.Buttonread.Click += new System.EventHandler(this.Buttonread_Click);
            // 
            // LabelReport
            // 
            this.LabelReport.AutoSize = true;
            this.LabelReport.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelReport.Location = new System.Drawing.Point(43, 371);
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
            this.TabPage2.Size = new System.Drawing.Size(678, 402);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "履歴";
            // 
            // ButtonAllCancel
            // 
            this.ButtonAllCancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonAllCancel.Location = new System.Drawing.Point(178, 330);
            this.ButtonAllCancel.Name = "ButtonAllCancel";
            this.ButtonAllCancel.Size = new System.Drawing.Size(123, 47);
            this.ButtonAllCancel.TabIndex = 30;
            this.ButtonAllCancel.Text = "全て解除";
            this.ButtonAllCancel.UseVisualStyleBackColor = true;
            this.ButtonAllCancel.Click += new System.EventHandler(this.Button4_Click);
            // 
            // LabelDelinfo
            // 
            this.LabelDelinfo.AutoSize = true;
            this.LabelDelinfo.Location = new System.Drawing.Point(427, 379);
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
            this.DataGridView.Location = new System.Drawing.Point(26, 21);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowTemplate.Height = 21;
            this.DataGridView.Size = new System.Drawing.Size(625, 290);
            this.DataGridView.TabIndex = 28;
            this.DataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // TabPage3
            // 
            this.TabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage3.Controls.Add(this.ButtonSongs);
            this.TabPage3.Controls.Add(this.LabelSongs);
            this.TabPage3.Controls.Add(this.TextBoxSongs);
            this.TabPage3.Controls.Add(this.LabelBG);
            this.TabPage3.Controls.Add(this.panel3);
            this.TabPage3.Controls.Add(this.LabelHistory);
            this.TabPage3.Controls.Add(this.panel2);
            this.TabPage3.Controls.Add(this.LabelLanguage);
            this.TabPage3.Controls.Add(this.ComboBoxLanguage);
            this.TabPage3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TabPage3.Location = new System.Drawing.Point(4, 27);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(678, 402);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "詳細設定";
            // 
            // ButtonSongs
            // 
            this.ButtonSongs.Location = new System.Drawing.Point(431, 184);
            this.ButtonSongs.Name = "ButtonSongs";
            this.ButtonSongs.Size = new System.Drawing.Size(86, 31);
            this.ButtonSongs.TabIndex = 11;
            this.ButtonSongs.Text = "参照";
            this.ButtonSongs.UseVisualStyleBackColor = true;
            this.ButtonSongs.Visible = false;
            this.ButtonSongs.Click += new System.EventHandler(this.ButtonSongs_Click);
            // 
            // LabelSongs
            // 
            this.LabelSongs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelSongs.Location = new System.Drawing.Point(4, 187);
            this.LabelSongs.Name = "LabelSongs";
            this.LabelSongs.Size = new System.Drawing.Size(147, 24);
            this.LabelSongs.TabIndex = 10;
            this.LabelSongs.Text = "Songsフォルダー";
            this.LabelSongs.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LabelSongs.Visible = false;
            // 
            // TextBoxSongs
            // 
            this.TextBoxSongs.Location = new System.Drawing.Point(181, 184);
            this.TextBoxSongs.Name = "TextBoxSongs";
            this.TextBoxSongs.ReadOnly = true;
            this.TextBoxSongs.Size = new System.Drawing.Size(244, 31);
            this.TextBoxSongs.TabIndex = 9;
            this.TextBoxSongs.Visible = false;
            this.TextBoxSongs.TextChanged += new System.EventHandler(this.TextBoxSongs_TextChanged);
            // 
            // LabelBG
            // 
            this.LabelBG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelBG.Location = new System.Drawing.Point(8, 134);
            this.LabelBG.Name = "LabelBG";
            this.LabelBG.Size = new System.Drawing.Size(147, 24);
            this.LabelBG.TabIndex = 7;
            this.LabelBG.Text = "背景の画像";
            this.LabelBG.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.RadioButtonPicOn);
            this.panel3.Controls.Add(this.RadioButtonPicOff);
            this.panel3.Location = new System.Drawing.Point(181, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 47);
            this.panel3.TabIndex = 6;
            // 
            // RadioButtonPicOn
            // 
            this.RadioButtonPicOn.AutoSize = true;
            this.RadioButtonPicOn.Location = new System.Drawing.Point(15, 12);
            this.RadioButtonPicOn.Name = "RadioButtonPicOn";
            this.RadioButtonPicOn.Size = new System.Drawing.Size(92, 28);
            this.RadioButtonPicOn.TabIndex = 2;
            this.RadioButtonPicOn.TabStop = true;
            this.RadioButtonPicOn.Text = "読み込む";
            this.RadioButtonPicOn.UseVisualStyleBackColor = true;
            // 
            // RadioButtonPicOff
            // 
            this.RadioButtonPicOff.AutoSize = true;
            this.RadioButtonPicOff.Location = new System.Drawing.Point(113, 12);
            this.RadioButtonPicOff.Name = "RadioButtonPicOff";
            this.RadioButtonPicOff.Size = new System.Drawing.Size(124, 28);
            this.RadioButtonPicOff.TabIndex = 3;
            this.RadioButtonPicOff.TabStop = true;
            this.RadioButtonPicOff.Text = "読み込まない";
            this.RadioButtonPicOff.UseVisualStyleBackColor = true;
            this.RadioButtonPicOff.Click += new System.EventHandler(this.RadioButtonPicOff_Click);
            // 
            // LabelHistory
            // 
            this.LabelHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelHistory.Location = new System.Drawing.Point(17, 81);
            this.LabelHistory.Name = "LabelHistory";
            this.LabelHistory.Size = new System.Drawing.Size(134, 24);
            this.LabelHistory.TabIndex = 5;
            this.LabelHistory.Text = "履歴";
            this.LabelHistory.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RadioButtonHistoryOn);
            this.panel2.Controls.Add(this.RadioButtonHistoryOff);
            this.panel2.Location = new System.Drawing.Point(181, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 47);
            this.panel2.TabIndex = 4;
            // 
            // RadioButtonHistoryOn
            // 
            this.RadioButtonHistoryOn.AutoSize = true;
            this.RadioButtonHistoryOn.Location = new System.Drawing.Point(15, 12);
            this.RadioButtonHistoryOn.Name = "RadioButtonHistoryOn";
            this.RadioButtonHistoryOn.Size = new System.Drawing.Size(60, 28);
            this.RadioButtonHistoryOn.TabIndex = 2;
            this.RadioButtonHistoryOn.TabStop = true;
            this.RadioButtonHistoryOn.Text = "残す";
            this.RadioButtonHistoryOn.UseVisualStyleBackColor = true;
            // 
            // RadioButtonHistoryOff
            // 
            this.RadioButtonHistoryOff.AutoSize = true;
            this.RadioButtonHistoryOff.Location = new System.Drawing.Point(113, 12);
            this.RadioButtonHistoryOff.Name = "RadioButtonHistoryOff";
            this.RadioButtonHistoryOff.Size = new System.Drawing.Size(92, 28);
            this.RadioButtonHistoryOff.TabIndex = 3;
            this.RadioButtonHistoryOff.TabStop = true;
            this.RadioButtonHistoryOff.Text = "残さない";
            this.RadioButtonHistoryOff.UseVisualStyleBackColor = true;
            // 
            // LabelLanguage
            // 
            this.LabelLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelLanguage.Location = new System.Drawing.Point(21, 32);
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
            this.ComboBoxLanguage.Location = new System.Drawing.Point(181, 29);
            this.ComboBoxLanguage.Name = "ComboBoxLanguage";
            this.ComboBoxLanguage.Size = new System.Drawing.Size(178, 32);
            this.ComboBoxLanguage.TabIndex = 0;
            this.ComboBoxLanguage.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxLanguage_SelectionChangeCommitted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 433);
            this.Controls.Add(this.TabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(760, 499);
            this.MinimumSize = new System.Drawing.Size(702, 472);
            this.Name = "Form1";
            this.Text = "osu!taiko LRandom v2.7";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDowncount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownOffset)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.TabPage3.ResumeLayout(false);
            this.TabPage3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonMake;
        private System.Windows.Forms.TextBox TextBoxBeforMapDate;
        private System.Windows.Forms.RadioButton RadioButtonR;
        private System.Windows.Forms.RadioButton RadioButtonLR;
        private System.Windows.Forms.TextBox TextBoxAfterMapDate;
        private System.Windows.Forms.TextBox TextBoxRule;
        private System.Windows.Forms.TextBox TextBoxDiffBack;
        private System.Windows.Forms.TextBox TextBoxSelectMap;
        private System.Windows.Forms.Label LabelSelectMap;
        private System.Windows.Forms.CheckBox CheckBoxOriginalDiff;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelDiffNumber;
        private System.Windows.Forms.Label LabelCount;
        private System.Windows.Forms.CheckBox CheckBoxOverwrite;
        private System.Windows.Forms.ComboBox ComboBoxSelectHistory;
        private System.Windows.Forms.Label LabelSelectHistory;
        private System.Windows.Forms.Button ButtonAllSelect;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Label LabelDelinfo;
        private System.Windows.Forms.Button ButtonAllCancel;
        private System.Windows.Forms.Label LabelReport;
        private System.Windows.Forms.TabPage TabPage3;
        private System.Windows.Forms.Label LabelLanguage;
        private System.Windows.Forms.ComboBox ComboBoxLanguage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton RadioButtonHistoryOn;
        private System.Windows.Forms.RadioButton RadioButtonHistoryOff;
        private System.Windows.Forms.Label LabelHistory;
        private System.Windows.Forms.Button Buttonread;
        private System.Windows.Forms.Label LabelOD;
        private System.Windows.Forms.TextBox TextBoxOD;
        private System.Windows.Forms.Label LabelOffset;
        private System.Windows.Forms.TextBox TextBoxHP;
        private System.Windows.Forms.Label LabelHP;
        private System.Windows.Forms.CheckBox CheckBoxSV;
        private System.Windows.Forms.NumericUpDown NumericUpDownOffset;
        private System.Windows.Forms.CheckBox CheckBoxNoChange;
        private System.Windows.Forms.NumericUpDown NumericUpDowncount;
        private System.Windows.Forms.NumericUpDown NumericUpDownNum;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Label LabelBG;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton RadioButtonPicOn;
        private System.Windows.Forms.RadioButton RadioButtonPicOff;
        private System.Windows.Forms.Label LabelSongs;
        private System.Windows.Forms.TextBox TextBoxSongs;
        private System.Windows.Forms.Button ButtonSongs;
    }
}

