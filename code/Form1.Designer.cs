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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButtonR = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBoxRule = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBoxRef2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxHistory = new System.Windows.Forms.TextBox();
            this.numericUpDownNum = new System.Windows.Forms.NumericUpDown();
            this.numericUpDowncount = new System.Windows.Forms.NumericUpDown();
            this.checkBoxnochange = new System.Windows.Forms.CheckBox();
            this.numericUpDownOffset = new System.Windows.Forms.NumericUpDown();
            this.checkBoxSV = new System.Windows.Forms.CheckBox();
            this.labelOffset = new System.Windows.Forms.Label();
            this.textBoxHP = new System.Windows.Forms.TextBox();
            this.labelHP = new System.Windows.Forms.Label();
            this.textBoxOD = new System.Windows.Forms.TextBox();
            this.labelOD = new System.Windows.Forms.Label();
            this.buttonread = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButtonpicon = new System.Windows.Forms.RadioButton();
            this.radioButtonpicoff = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonhistoryon = new System.Windows.Forms.RadioButton();
            this.radioButtonhistoryoff = new System.Windows.Forms.RadioButton();
            this.labellanguage = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.textBoxSongs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSongs = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowncount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffset)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(391, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "実行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 92);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(101, 131);
            this.textBox1.TabIndex = 2;
            // 
            // radioButtonR
            // 
            this.radioButtonR.AutoSize = true;
            this.radioButtonR.Checked = true;
            this.radioButtonR.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButtonR.Location = new System.Drawing.Point(271, 191);
            this.radioButtonR.Name = "radioButtonR";
            this.radioButtonR.Size = new System.Drawing.Size(116, 35);
            this.radioButtonR.TabIndex = 3;
            this.radioButtonR.TabStop = true;
            this.radioButtonR.Text = "でたらめ";
            this.radioButtonR.UseVisualStyleBackColor = true;
            this.radioButtonR.Click += new System.EventHandler(this.radioButtonR_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButton2.Location = new System.Drawing.Point(271, 232);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(200, 35);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "制限付きでたらめ";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(38, 236);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(101, 131);
            this.textBox3.TabIndex = 7;
            // 
            // textBoxRule
            // 
            this.textBoxRule.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxRule.Location = new System.Drawing.Point(477, 232);
            this.textBoxRule.Name = "textBoxRule";
            this.textBoxRule.Size = new System.Drawing.Size(150, 31);
            this.textBoxRule.TabIndex = 8;
            this.textBoxRule.TextChanged += new System.EventHandler(this.textBoxRule_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox4.Location = new System.Drawing.Point(22, 70);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(308, 31);
            this.textBox4.TabIndex = 9;
            // 
            // textBoxRef2
            // 
            this.textBoxRef2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxRef2.Location = new System.Drawing.Point(26, 15);
            this.textBoxRef2.Name = "textBoxRef2";
            this.textBoxRef2.ReadOnly = true;
            this.textBoxRef2.Size = new System.Drawing.Size(495, 27);
            this.textBoxRef2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(527, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "生成したい譜面";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox2.Location = new System.Drawing.Point(3, 0);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(317, 28);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Text = "生成する譜面に元の難易度名を残さない";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel1.Location = new System.Drawing.Point(271, 281);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 112);
            this.panel1.TabIndex = 20;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox1.Location = new System.Drawing.Point(3, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(349, 28);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "同名のファイルがすでにある場合上書きする";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(414, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "後ろに付く数字の始点";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(511, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 28);
            this.label5.TabIndex = 21;
            this.label5.Text = "作る数";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 20;
            this.comboBox1.Location = new System.Drawing.Point(26, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(495, 28);
            this.comboBox1.TabIndex = 22;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(527, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 24);
            this.label7.TabIndex = 23;
            this.label7.Text = "履歴から選択する";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(49, 330);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 47);
            this.button2.TabIndex = 24;
            this.button2.Text = "全て選択";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button3.Location = new System.Drawing.Point(467, 330);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 47);
            this.button3.TabIndex = 25;
            this.button3.Text = "選択中の項目を削除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(686, 433);
            this.tabControl1.TabIndex = 28;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            this.tabControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabControl1_DragDrop);
            this.tabControl1.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabControl1_DragEnter);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.textBoxHistory);
            this.tabPage1.Controls.Add(this.numericUpDownNum);
            this.tabPage1.Controls.Add(this.numericUpDowncount);
            this.tabPage1.Controls.Add(this.checkBoxnochange);
            this.tabPage1.Controls.Add(this.numericUpDownOffset);
            this.tabPage1.Controls.Add(this.checkBoxSV);
            this.tabPage1.Controls.Add(this.labelOffset);
            this.tabPage1.Controls.Add(this.textBoxHP);
            this.tabPage1.Controls.Add(this.labelHP);
            this.tabPage1.Controls.Add(this.textBoxOD);
            this.tabPage1.Controls.Add(this.labelOD);
            this.tabPage1.Controls.Add(this.buttonread);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.textBoxRule);
            this.tabPage1.Controls.Add(this.radioButton2);
            this.tabPage1.Controls.Add(this.radioButtonR);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBoxRef2);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(678, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "メインメニュー";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(150, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 80);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxHistory
            // 
            this.textBoxHistory.Location = new System.Drawing.Point(165, 374);
            this.textBoxHistory.Name = "textBoxHistory";
            this.textBoxHistory.Size = new System.Drawing.Size(100, 25);
            this.textBoxHistory.TabIndex = 38;
            this.textBoxHistory.Visible = false;
            // 
            // numericUpDownNum
            // 
            this.numericUpDownNum.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numericUpDownNum.Location = new System.Drawing.Point(586, 197);
            this.numericUpDownNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNum.Name = "numericUpDownNum";
            this.numericUpDownNum.Size = new System.Drawing.Size(54, 27);
            this.numericUpDownNum.TabIndex = 36;
            this.numericUpDownNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNum.ValueChanged += new System.EventHandler(this.numericUpDownNum_ValueChanged);
            // 
            // numericUpDowncount
            // 
            this.numericUpDowncount.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numericUpDowncount.Location = new System.Drawing.Point(586, 117);
            this.numericUpDowncount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDowncount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDowncount.Name = "numericUpDowncount";
            this.numericUpDowncount.Size = new System.Drawing.Size(55, 31);
            this.numericUpDowncount.TabIndex = 35;
            this.numericUpDowncount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDowncount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBoxnochange
            // 
            this.checkBoxnochange.AutoSize = true;
            this.checkBoxnochange.Location = new System.Drawing.Point(164, 351);
            this.checkBoxnochange.Name = "checkBoxnochange";
            this.checkBoxnochange.Size = new System.Drawing.Size(123, 22);
            this.checkBoxnochange.TabIndex = 34;
            this.checkBoxnochange.Text = "ノーツを変えない";
            this.checkBoxnochange.UseVisualStyleBackColor = true;
            this.checkBoxnochange.CheckedChanged += new System.EventHandler(this.checkBoxnochange_CheckedChanged);
            // 
            // numericUpDownOffset
            // 
            this.numericUpDownOffset.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numericUpDownOffset.Location = new System.Drawing.Point(164, 288);
            this.numericUpDownOffset.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownOffset.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDownOffset.Name = "numericUpDownOffset";
            this.numericUpDownOffset.Size = new System.Drawing.Size(77, 27);
            this.numericUpDownOffset.TabIndex = 33;
            // 
            // checkBoxSV
            // 
            this.checkBoxSV.AutoSize = true;
            this.checkBoxSV.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxSV.Location = new System.Drawing.Point(164, 323);
            this.checkBoxSV.Name = "checkBoxSV";
            this.checkBoxSV.Size = new System.Drawing.Size(102, 28);
            this.checkBoxSV.TabIndex = 32;
            this.checkBoxSV.Text = "no SVwip";
            this.checkBoxSV.UseVisualStyleBackColor = true;
            // 
            // labelOffset
            // 
            this.labelOffset.AutoSize = true;
            this.labelOffset.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelOffset.Location = new System.Drawing.Point(165, 265);
            this.labelOffset.Name = "labelOffset";
            this.labelOffset.Size = new System.Drawing.Size(83, 24);
            this.labelOffset.TabIndex = 30;
            this.labelOffset.Text = "Offsetwip";
            // 
            // textBoxHP
            // 
            this.textBoxHP.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxHP.Location = new System.Drawing.Point(211, 223);
            this.textBoxHP.Name = "textBoxHP";
            this.textBoxHP.Size = new System.Drawing.Size(30, 27);
            this.textBoxHP.TabIndex = 29;
            // 
            // labelHP
            // 
            this.labelHP.AutoSize = true;
            this.labelHP.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelHP.Location = new System.Drawing.Point(211, 200);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(32, 24);
            this.labelHP.TabIndex = 28;
            this.labelHP.Text = "HP";
            // 
            // textBoxOD
            // 
            this.textBoxOD.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxOD.Location = new System.Drawing.Point(164, 223);
            this.textBoxOD.Name = "textBoxOD";
            this.textBoxOD.Size = new System.Drawing.Size(30, 27);
            this.textBoxOD.TabIndex = 27;
            // 
            // labelOD
            // 
            this.labelOD.AutoSize = true;
            this.labelOD.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelOD.Location = new System.Drawing.Point(163, 200);
            this.labelOD.Name = "labelOD";
            this.labelOD.Size = new System.Drawing.Size(34, 24);
            this.labelOD.TabIndex = 26;
            this.labelOD.Text = "OD";
            // 
            // buttonread
            // 
            this.buttonread.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonread.Location = new System.Drawing.Point(271, 101);
            this.buttonread.Name = "buttonread";
            this.buttonread.Size = new System.Drawing.Size(114, 70);
            this.buttonread.TabIndex = 25;
            this.buttonread.Text = "読み込む";
            this.buttonread.UseVisualStyleBackColor = true;
            this.buttonread.Click += new System.EventHandler(this.buttonread_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(48, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 24);
            this.label8.TabIndex = 24;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage2.Size = new System.Drawing.Size(678, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "履歴";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button4.Location = new System.Drawing.Point(178, 330);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 47);
            this.button4.TabIndex = 30;
            this.button4.Text = "全て解除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(427, 379);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(224, 18);
            this.label10.TabIndex = 29;
            this.label10.Text = "履歴から消えるだけで譜面は消えません";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(625, 290);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.buttonSongs);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.textBoxSongs);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Controls.Add(this.labellanguage);
            this.tabPage3.Controls.Add(this.comboBoxLanguage);
            this.tabPage3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(678, 402);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "詳細設定";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(8, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "背景の画像";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButtonpicon);
            this.panel3.Controls.Add(this.radioButtonpicoff);
            this.panel3.Location = new System.Drawing.Point(181, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 47);
            this.panel3.TabIndex = 6;
            // 
            // radioButtonpicon
            // 
            this.radioButtonpicon.AutoSize = true;
            this.radioButtonpicon.Location = new System.Drawing.Point(15, 12);
            this.radioButtonpicon.Name = "radioButtonpicon";
            this.radioButtonpicon.Size = new System.Drawing.Size(92, 28);
            this.radioButtonpicon.TabIndex = 2;
            this.radioButtonpicon.TabStop = true;
            this.radioButtonpicon.Text = "読み込む";
            this.radioButtonpicon.UseVisualStyleBackColor = true;
            // 
            // radioButtonpicoff
            // 
            this.radioButtonpicoff.AutoSize = true;
            this.radioButtonpicoff.Location = new System.Drawing.Point(113, 12);
            this.radioButtonpicoff.Name = "radioButtonpicoff";
            this.radioButtonpicoff.Size = new System.Drawing.Size(124, 28);
            this.radioButtonpicoff.TabIndex = 3;
            this.radioButtonpicoff.TabStop = true;
            this.radioButtonpicoff.Text = "読み込まない";
            this.radioButtonpicoff.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(17, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "履歴";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButtonhistoryon);
            this.panel2.Controls.Add(this.radioButtonhistoryoff);
            this.panel2.Location = new System.Drawing.Point(181, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 47);
            this.panel2.TabIndex = 4;
            // 
            // radioButtonhistoryon
            // 
            this.radioButtonhistoryon.AutoSize = true;
            this.radioButtonhistoryon.Location = new System.Drawing.Point(15, 12);
            this.radioButtonhistoryon.Name = "radioButtonhistoryon";
            this.radioButtonhistoryon.Size = new System.Drawing.Size(60, 28);
            this.radioButtonhistoryon.TabIndex = 2;
            this.radioButtonhistoryon.TabStop = true;
            this.radioButtonhistoryon.Text = "残す";
            this.radioButtonhistoryon.UseVisualStyleBackColor = true;
            // 
            // radioButtonhistoryoff
            // 
            this.radioButtonhistoryoff.AutoSize = true;
            this.radioButtonhistoryoff.Location = new System.Drawing.Point(113, 12);
            this.radioButtonhistoryoff.Name = "radioButtonhistoryoff";
            this.radioButtonhistoryoff.Size = new System.Drawing.Size(92, 28);
            this.radioButtonhistoryoff.TabIndex = 3;
            this.radioButtonhistoryoff.TabStop = true;
            this.radioButtonhistoryoff.Text = "残さない";
            this.radioButtonhistoryoff.UseVisualStyleBackColor = true;
            // 
            // labellanguage
            // 
            this.labellanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labellanguage.Location = new System.Drawing.Point(21, 32);
            this.labellanguage.Name = "labellanguage";
            this.labellanguage.Size = new System.Drawing.Size(130, 24);
            this.labellanguage.TabIndex = 1;
            this.labellanguage.Text = "言語設定";
            this.labellanguage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(181, 29);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(178, 32);
            this.comboBoxLanguage.TabIndex = 0;
            this.comboBoxLanguage.SelectionChangeCommitted += new System.EventHandler(this.comboBoxLanguage_SelectionChangeCommitted);
            // 
            // textBoxSongs
            // 
            this.textBoxSongs.Location = new System.Drawing.Point(181, 187);
            this.textBoxSongs.Name = "textBoxSongs";
            this.textBoxSongs.Size = new System.Drawing.Size(244, 31);
            this.textBoxSongs.TabIndex = 9;
            this.textBoxSongs.TextChanged += new System.EventHandler(this.textBoxSongs_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(8, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Songsフォルダー";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonSongs
            // 
            this.buttonSongs.Location = new System.Drawing.Point(431, 187);
            this.buttonSongs.Name = "buttonSongs";
            this.buttonSongs.Size = new System.Drawing.Size(86, 31);
            this.buttonSongs.TabIndex = 11;
            this.buttonSongs.Text = "参照";
            this.buttonSongs.UseVisualStyleBackColor = true;
            this.buttonSongs.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 433);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(760, 499);
            this.MinimumSize = new System.Drawing.Size(702, 472);
            this.Name = "Form1";
            this.Text = "osu!taiko LRandom v2.5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowncount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffset)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButtonR;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBoxRule;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBoxRef2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label labellanguage;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonhistoryon;
        private System.Windows.Forms.RadioButton radioButtonhistoryoff;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonread;
        private System.Windows.Forms.Label labelOD;
        private System.Windows.Forms.TextBox textBoxOD;
        private System.Windows.Forms.Label labelOffset;
        private System.Windows.Forms.TextBox textBoxHP;
        private System.Windows.Forms.Label labelHP;
        private System.Windows.Forms.CheckBox checkBoxSV;
        private System.Windows.Forms.NumericUpDown numericUpDownOffset;
        private System.Windows.Forms.CheckBox checkBoxnochange;
        private System.Windows.Forms.NumericUpDown numericUpDowncount;
        private System.Windows.Forms.NumericUpDown numericUpDownNum;
        private System.Windows.Forms.TextBox textBoxHistory;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButtonpicon;
        private System.Windows.Forms.RadioButton radioButtonpicoff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSongs;
        private System.Windows.Forms.Button buttonSongs;
    }
}

