using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace taiko
{
    public partial class Form1 : Form
    {

        private string box1;
        private string box2;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRef_Click(object sender, EventArgs e) // Songsフォルダーの参照
        {
            FolderBrowserDialog dig = new FolderBrowserDialog
            {
                Description = "Songsフォルダーを選択してください"
            };

            if (dig.ShowDialog() == DialogResult.OK)
            {
                // ファイルが選択された場合の処理
                string folderPath = dig.SelectedPath;

                // app.config ファイルを読み込む
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // key1 の値を設定
                config.AppSettings.Settings["key1"].Value = folderPath;

                // 変更を保存
                config.Save(ConfigurationSaveMode.Modified);

                // 設定を反映させるために、ConfigurationManager をリフレッシュ
                ConfigurationManager.RefreshSection("appSettings");

                textBoxRef.Text = folderPath;

            }
        }

        private void button3_Click(object sender, EventArgs e) // .osuファイルの参照
        {
            string folderPath = ConfigurationManager.AppSettings["key1"];
            OpenFileDialog dig = new OpenFileDialog
            {
                Title = "ファイルを開く",
                Filter = ".osuファイル (*.osu)|*.osu",
                InitialDirectory = folderPath
            };

            if (dig.ShowDialog() == DialogResult.OK)
            {

                string filePath = dig.FileName;

                // テキストボックスにファイル名を表示
                string fileName = Path.GetFileName(filePath);
                textBoxRef2.Text = fileName;

                string data = File.ReadAllText(filePath);

                textBox1.Text = data;
                box1 = filePath;

                string beforfilePath = filePath.Substring(0, filePath.LastIndexOf('\\'));
                box2 = beforfilePath;


                string log = ConfigurationManager.AppSettings["key2"];
                // データが初期状態なら新しくデータテーブルを作る
                if (log == "[]")
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.AddRange(new DataColumn[] { new DataColumn("path"), new DataColumn("name") });

                    dataTable.Rows.Add(new object[] { filePath, fileName });


                    string json = JsonConvert.SerializeObject(dataTable); // Newtonsoft.Jsonを使用

                    // app.configファイルに保存
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["key2"].Value = json;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");


                    comboBox1.DataSource = dataTable;
                    comboBox1.DisplayMember = "name";
                    comboBox1.ValueMember = "path";

                }
                else // 履歴がすでにある場合はデータテーブルに変換してコンボボックスに表示
                {
                    JArray jsonArray = JArray.Parse(log);
                    DataTable dataTable = new DataTable();

                    if (jsonArray.Count > 0)
                    {
                        foreach (var property in jsonArray[0].ToObject<Dictionary<string, object>>())
                        {
                            dataTable.Columns.Add(property.Key);
                        }
                    }

                    foreach (JObject jsonObject in jsonArray)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            dataRow[column.ColumnName] = jsonObject[column.ColumnName];
                        }
                        dataTable.Rows.Add(dataRow);
                    }

                    dataTable.Rows.Add(dataTable.NewRow()["path"] = filePath, dataTable.NewRow()["name"] = fileName); // 1行で追加

                    string json = JsonConvert.SerializeObject(dataTable);

                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["key2"].Value = json;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");

                    comboBox1.DataSource = dataTable;
                    comboBox1.DisplayMember = "name";
                    comboBox1.ValueMember = "path";
                }

            }

        }


        private void button1_Click(object sender, EventArgs e) // 実行ボタン
        {
            // Stopwatch オブジェクトを作成
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            label8.Text = "動作中、、、";


            // 入力されたデータの文字列の後ろ部分が空白や改行だった場合それを削除して、string型の配列にする
            List<string> lines = new List<string>(textBox1.Lines);

            for (int i = lines.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    lines.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }

            string[] result = lines.ToArray();


            // テキストボックスにデータが入っていなければメッセージボックスを出してプログラムを終了
            if (result.Length == 0)
            {
                DialogResult dialogResult = MessageBox.Show("譜面が選択されていません><", "",
                  MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                label8.Text = "";

                return;
            }



            // テキストボックスにある難易度の文字列と最初の()の数字
            string diff1 = textBox4.Text;
            string[] parts = diff1.Split('(', ')');

            string part1befor = parts[0]; // "文字列(random等)"
            string part1 = part1befor.Substring(1, part1befor.Length - 2);

            // 括弧の中の数字部分、数字が入ってなかったら1として扱う
            int part2 = 1;
            if (!string.IsNullOrEmpty(parts[1]))
            {
                try
                {
                    int num = int.Parse(parts[1]); // 変数名を num に変更
                    part2 = num; // 外側の part2 に値を代入
                }
                catch
                {
                    DialogResult dialogResult = MessageBox.Show("後ろの付く数字は半角数字で入力してください><", "",
                      MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    label8.Text = "";
                    return;
                }
            }



            // 各情報と行番号を取得
            int hitnum = -1;

            string Titlename0 = null;
            int titlenum = -1;

            string Artistname0 = null;
            int artnum = -1;

            string Creatorname = null;
            int crenum = -1;

            string diffname0 = null;
            int vernum = -1;


            for (int i = 0; i < result.Length; i++)
            {
                string line = result[i];

                if (line.Contains("[HitObjects]"))
                {
                    hitnum = i + 1;
                }
                else if (line.StartsWith("Title:"))
                {
                    Titlename0 = line.Substring("Title:".Length).Trim();
                    titlenum = i;
                }
                else if (line.StartsWith("Artist:"))
                {
                    Artistname0 = line.Substring("Artist:".Length).Trim();
                    artnum = i;
                }
                else if (line.StartsWith("Creator:"))
                {
                    Creatorname = line.Substring("Creator:".Length).Trim();
                    crenum = i;
                }
                else if (line.StartsWith("Version:"))
                {
                    diffname0 = line.Substring("Version:".Length).Trim();
                    vernum = i;
                }
            }

            if (hitnum == -1 || Titlename0 == null || titlenum == -1 || Artistname0 == null || artnum == -1 ||
                Creatorname == null || crenum == -1 || diffname0 == null || vernum == -1)
            {
                DialogResult dialogResult = MessageBox.Show("譜面のデータに不備があるかもしれません><", "",
                  MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                label8.Text = "";
                return;
            }


            // 難易度名にすでに[Random]か[LRandom]があれば削除する
            string diffreg = @"(.*)\[?Random\]?\(\d+\)";
            string diffreg2 = @"(.*)\[?LRandom\[[^\]]*\]\]?\(\d+\)";
            diffname0 = Regex.Replace(diffname0, diffreg, "$1");
            diffname0 = Regex.Replace(diffname0, diffreg2, "$1");

            bool nodiffname = false;
            if (diffname0 == "")
            {
               nodiffname = true;
            }
            if (checkBox2.Checked)
            {
                nodiffname = true;
            }



            // 難易度、タイトル、アーティスト名に含まれるパスに使えない文字を削除する
            string Artistname = Regex.Replace(Artistname0, @"[\\\/><?:*|""]+", "");
            string Titlename = Regex.Replace(Titlename0, @"[\\\/><?:*|""]+", "");
            string diffname = Regex.Replace(diffname0, @"[\\\/><?:*|""]+", "");



            // 同じ譜面ですでに生成された譜面があれば、後ろの番号を取得する
            string escArtistname = Regex.Escape(Artistname);
            string escTitlename = Regex.Escape(Titlename);
            string escCreatorname = Regex.Escape(Creatorname);
            string escdiffname = Regex.Escape(diffname);
            string escpart1 = Regex.Escape(part1);

            string pattern = nodiffname ? $@"{escArtistname} - {escTitlename} \({escCreatorname}\) \[{escpart1}\((\d+)\)\]\.osu$"
                                               : $@"{escArtistname} - {escTitlename} \({escCreatorname}\) \[{escdiffname}\[{escpart1}\]\((\d+)\)\]\.osu$";

            List<string> numbers = new List<string>(); // 数字を格納するリスト

            Directory.GetFiles(box2)
                .ToList() // GetFilesの結果をToList()で評価
                .ForEach(fileName =>
                { // ForEachで各ファイル名を処理
                    Match match = Regex.Match(Path.GetFileName(fileName), pattern, RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        string number = match.Groups[1].Value; // 1番目のグループ (数字部分) を取得
                        numbers.Add(number); // 数字をリストに追加
                    }
                });



            // 繰り返し回数、空欄なら１回
            int time = 1;
            try
            {
                if (!string.IsNullOrEmpty(textBoxTimes.Text))
                {
                    int parsedTime = int.Parse(textBoxTimes.Text); // 変数名を parsedTime に変更
                    time = parsedTime; // 外側の time に値を代入
                }
            }
            catch (FormatException) // 入力が正しくない場合
            {
                DialogResult dialogResult = MessageBox.Show("回数は半角数字で入力してください><","",
                  MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                label8.Text = "";
                return;
            }

            if (time >99) // 作る数が100以上ならメッセージを出す
            {
                DialogResult dialogResult = MessageBox.Show("譜面を100個以上生成しようとしています :O\n本当に実行しますか？","",
                  MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                if(dialogResult == DialogResult.Cancel)
                {
                    label8.Text = "";
                    return;
                }
            }


            // 生成する譜面の後ろにつける番号をあらかじめ作る
            List<int> intList = numbers.Select(int.Parse).ToList();

            List<int> newnum = new List<int>();

            int current = part2;

            while (newnum.Count < time)
            {
                if (!intList.Contains(current))
                {
                    newnum.Add(current);
                }
                current++;
            }


          
            //Console.WriteLine($"繰り返し処理に入る前までの経過時間: {stopwatch.ElapsedMilliseconds} ミリ秒");



            // 個数分作るのを繰り返す
            for (int k = 0; k < time; k++)
            {
                // 難易度部分を作成

                string word;
                string word2;


                if (checkBox1.Checked) // 同名の難易度がある場合上書きする場合
                {
                    // 元の難易度を残さない場合、残す場合
                    word = nodiffname ? $"{part1}({k + part2})" : $"{diffname0}[{part1}]({k + part2})";
                    word2 = nodiffname ? $"{part1}({k + part2})" : $"{diffname}[{part1}]({k + part2})";
                }
                else // 上書きしない場合
                {
                    // 元の難易度を残さない場合、残す場合
                    word = nodiffname ? $"{part1}({newnum[k]})" : $"{diffname0}[{part1}]({newnum[k]})";
                    word2 = nodiffname ? $"{part1}({newnum[k]})" : $"{diffname}[{part1}]({newnum[k]})";
                }

                // 全体の配列の難易度部分を書き換える
                result[vernum] = $"Version:{word}";


                // ノーツだけの1次元配列
                string[] noteonly = result.Skip(hitnum).ToArray();


                // bigノーツの行番号取得
                List<int> big = new List<int>();

                for (int i = 0; i < noteonly.Length; i++)
                {
                    string[] big2 = noteonly[i].Split(',');

                    try
                    {
                        if (big2[4] == "4" || big2[4] == "6")
                        {
                            big.Add(i);
                        }
                    }
                    catch
                    {
                        DialogResult dialogResult = MessageBox.Show($"[HitObject]の\"{i + 1}\"行目に不備があるかもしれません\nもしくは osu file format のバージョンが対応していないです><", "",
                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        label8.Text = "";
                        return;
                    }
                }


                //Console.WriteLine($"ノーツを生成する処理に入る前までの経過時間: {stopwatch.ElapsedMilliseconds} ミリ秒");


                List<string> randomafter = new List<string>();


                if (radioButtonR.Checked) // でたらめの場合
                {
                    using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                    {
                        randomafter.AddRange(noteonly.Select(line =>
                        {
                            string[] parts2 = line.Split(',');

                            byte[] randomNumber = new byte[1];
                            rng.GetBytes(randomNumber);
                            parts2[4] = ((randomNumber[0] % 2) * 2).ToString(); // 0 か 2 を生成

                            return string.Join(",", parts2);
                        }));
                    }
                }
                else // 制限付きでたらめの場合
                {
                    // 制限のルールを取得
                    List<string> randomrule = new List<string>(textBoxRule.Lines);

                    if (randomrule.Count == 0) // ルールが入力されていなければエラーで終わり
                    {
                        DialogResult dialogResult = MessageBox.Show("ルールを入力してください><", "",
                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        label8.Text = "";
                        return;
                    }

                    string[] splrule = randomrule[0].Split(',');


                    try
                    {
                        // ルールの数字でランダムにノーツの数分の長さの１次元配列を作る  
                        List<string> box = new List<string>();
                        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                        {
                            byte[] bytes = new byte[4]; // int は 4 バイト

                            for (int i = 0; i < noteonly.Length; i++)
                            {
                                rng.GetBytes(bytes);
                                int index = Math.Abs(BitConverter.ToInt32(bytes, 0)) % splrule.Length;
                                box.Add(splrule[index]);
                            }
                        }


                        // 奇数かたまり目の色と偶数かたまり目の色を決める
                        string color1;
                        string color2;

                        using (RandomNumberGenerator rngColor = RandomNumberGenerator.Create())
                        {
                            byte[] randomNumberColor = new byte[1];
                            rngColor.GetBytes(randomNumberColor);
                            color1 = ((randomNumberColor[0] % 2) * 2).ToString();
                            color2 = (color1 == "0" ? "2" : "0");
                        }

                        int start = 0;
                        for (int j = 0; j < box.Count; j++)
                        {
                            if (start >= noteonly.Length) break;

                            string color = j % 2 == 0 ? color1 : color2;

                            for (int i = 0; i < int.Parse(box[j]); i++)
                            {
                                if (start >= noteonly.Length) break;

                                List<string> val03 = new List<string>(noteonly[start].Split(','));

                                val03[4] = color;
                                randomafter.Add(string.Join(",", val03));

                                start++;
                            }
                        }
                    }
                    catch
                    {
                        DialogResult dialogResult = MessageBox.Show("ルールを正しく入力してください><\n例)1,2,3", "",
                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        label8.Text = "";
                        return;
                    }

                }

                //Console.WriteLine($"bigノーツにする処理に入る前までの経過時間: {stopwatch.ElapsedMilliseconds} ミリ秒");

                // bigノーツに変換
                for (int x = 0; x < big.Count; x++)
                {
                    List<string> big3 = new List<string>(randomafter[big[x]].Split(','));
                    big3[4] = big3[4] == "0" ? "4" : (big3[4] == "2" ? "6" : big3[4]); // 三項演算子で判定
                    randomafter[big[x]] = string.Join(",", big3);
                }


                // ノーツより前の部分と完成したノーツ部分を結合して文字列にする
                string complete = string.Join(Environment.NewLine, result.Take(hitnum).Concat(randomafter));


                //最後の場合、中身を表示
                if (k == time - 1)
                {
                    textBox3.Text = complete;
                }


                // 譜面のパスを取得
                string Path = box1;

                string Pathcut = Regex.Replace(Path, @"\\(?!.*\\).*", ""); // 最後の'\'までを削除
                string Pathend = string.Format("\\{0} - {1} ({2}) [{3}].osu", Artistname, Titlename, Creatorname, word2);
                string newPath = Pathcut + Pathend;


                // ファイルを作る
                try
                {
                    using (StreamWriter writer = File.CreateText(newPath))
                    {
                        // ファイルにテキストを書き込む
                        writer.WriteLine(complete);
                    }

                }
                catch (Exception)
                {
                    if (newPath.Length > 260)
                    {
                        DialogResult dialogResult = MessageBox.Show("エラー\nパスの長さが260文字より多くなってしまうのが原因かもしれません><", "",
                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        label8.Text = "";
                        return;
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("エラー", "",
                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        label8.Text = "";
                        return;
                    }
                }
                //Console.WriteLine($"１週終わった時の経過時間: {stopwatch.ElapsedMilliseconds} ミリ秒");
            }

            label8.Text = "完了しました！";
            stopwatch.Stop();
            Console.WriteLine($"終了時の経過時間: {stopwatch.ElapsedMilliseconds} ミリ秒");
        }



        private void radioButtonR_Click(object sender, EventArgs e) // でたらめ
        {
            if (int.TryParse(textBox2.Text, out _)){
                textBox4.Text = $"[Random]({textBox2.Text})";
            }
            textBox4.Text = $"[Random](1)";
        }


        private void radioButton2_Click(object sender, EventArgs e) // 制限付きでたらめ
        {
            if (int.TryParse(textBox2.Text, out _)){
                textBox4.Text = $"[LRandom[{textBoxRule.Text}]]({textBox2.Text})";
            }
            textBox4.Text = $"[LRandom[{textBoxRule.Text}]](1)";
        }


        private void Form1_Load(object sender, EventArgs e) // ロード時の処理
        {
            textBox2.Text = "1";
            textBox4.Text = $"[Random]({textBox2.Text})";

            string folderPath = ConfigurationManager.AppSettings["key1"];
            textBoxRef.Text = folderPath;

            // 履歴があるか
            string log = ConfigurationManager.AppSettings["key2"];


            // ある場合は、コンボボックスに表示
            if (log != "[]")
            {
                JArray jsonArray = JArray.Parse(log);
                DataTable dataTable = new DataTable();

                if (jsonArray.Count > 0)
                {
                    foreach (var property in jsonArray[0].ToObject<Dictionary<string, object>>())
                    {
                        dataTable.Columns.Add(property.Key);
                    }
                    foreach (JObject jsonObject in jsonArray)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            dataRow[column.ColumnName] = jsonObject[column.ColumnName];
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }

                comboBox1.DataSource = dataTable;
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "path";

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns["name"].Width = 517;
                dataGridView1.Columns["name"].HeaderText = "ファイル名";
                dataGridView1.Columns["path"].Width = 75;
                dataGridView1.Columns["path"].HeaderText = "パス";

                dataGridView1.Columns["path"].DisplayIndex = 1; // 列順入れ替え
                dataGridView1.Columns["name"].DisplayIndex = 0;

                dataGridView1.Columns.Insert(0, new DataGridViewCheckBoxColumn { HeaderText = "削除", Name = "chkDelete", Width = 30 });

                dataGridView1.Columns[1].ReadOnly = true; // ReadOnly設定
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.RowHeadersVisible = false;
            }
        }


        private void textBoxRule_TextChanged(object sender, EventArgs e) // 自動で変更後の名前が変わる
        {
            if (radioButton2.Checked)
            {
                if (radioButtonR.Checked)
                {
                    textBox4.Text = $"[Random]({textBox2.Text})";
                }
                if (radioButton2.Checked)
                {
                    textBox4.Text = $"[LRandom[{textBoxRule.Text}]]({textBox2.Text})";
                }
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e) // 自動で変更後の名前が変わる
        {
            if (int.TryParse(textBox2.Text, out _))
            {
                if (radioButtonR.Checked)
                {
                    textBox4.Text = $"[Random]({textBox2.Text})";
                }
                if (radioButton2.Checked)
                {
                    textBox4.Text = $"[LRandom[{textBoxRule.Text}]]({textBox2.Text})";
                }
            }

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is DataRowView selectedRow) // DataRowView型であることを確認
            {
                int index = comboBox1.SelectedIndex;
                string name = selectedRow["name"].ToString();
                string filePath = selectedRow["path"].ToString();

                try
                {
                    string data = File.ReadAllText(filePath);
                    textBox1.Text = data;
                }
                catch
                {
                    DialogResult dialogResult = MessageBox.Show("ファイルが無くなっている、もしくは名前が変わっているかもしれません><", "",
                      MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    label8.Text = "";
                    return;
                }

                textBoxRef2.Text = name;

                // box1と2にもセット
                box1 = filePath;

                string beforfilePath = filePath.Substring(0, filePath.LastIndexOf('\\'));
                box2 = beforfilePath;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // チェックボックス列の列名
            string checkColumnName = "chkDelete";

            // 全ての行のチェックボックスにチェックを入れる
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[checkColumnName].Value = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // チェックボックス列の列名
            string checkColumnName = "chkDelete";

            // 全ての行のチェックボックスのチェックを外す
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[checkColumnName].Value = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // チェックボックス列の列名
            string checkColumnName = "chkDelete";

            // データテーブルを取得
            DataTable dt = (DataTable)dataGridView1.DataSource;

            // DataGridViewの行を逆順にループ (削除によるインデックスのずれを防ぐため)
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                // チェックボックスがチェックされているか確認
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[checkColumnName].Value) == true)
                {
                    // データテーブルから対応する行を削除
                    dt.Rows.RemoveAt(i);
                }
            }

            // DataGridViewを更新
            dataGridView1.DataSource = dt;

            string json = JsonConvert.SerializeObject(dt); // Newtonsoft.Jsonを使用

            // app.configファイルに保存 (例: appSettings要素)
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["key2"].Value = json;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            // 履歴を取得
            string log = ConfigurationManager.AppSettings["key2"];

            // ある場合は、コンボボックスに表示
            if (log != "[]")
            {
                JArray jsonArray = JArray.Parse(log);
                DataTable dataTable = new DataTable();

                if (jsonArray.Count > 0)
                {
                    foreach (var property in jsonArray[0].ToObject<Dictionary<string, object>>())
                    {
                        dataTable.Columns.Add(property.Key);
                    }
                    foreach (JObject jsonObject in jsonArray)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            dataRow[column.ColumnName] = jsonObject[column.ColumnName];
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }

                dataGridView1.DataSource = dataTable;
                comboBox1.DataSource = dataTable;

                if (dataGridView1.Columns["path"]?.Width != 75) // null許容演算子
                {
                    var nameColumn = dataGridView1.Columns["name"];
                    var pathColumn = dataGridView1.Columns["path"];

                    nameColumn.Width = 517;
                    nameColumn.HeaderText = "ファイル名";
                    pathColumn.Width = 75;
                    pathColumn.HeaderText = "パス";

                    pathColumn.DisplayIndex = 0;
                    nameColumn.DisplayIndex = 1;

                    dataGridView1.Columns.Insert(0, new DataGridViewCheckBoxColumn { HeaderText = "削除", Name = "chkDelete", Width = 30 });

                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.RowHeadersVisible = false;
                }
            }
        }


        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string filePath = files[0];

                // テキストボックスにファイル名を表示
                string fileName = Path.GetFileName(filePath);
                textBoxRef2.Text = fileName;

                string data = File.ReadAllText(filePath);
                textBox1.Text = data;

                //box1,2を変える
                box1 = filePath;

                string beforfilePath = filePath.Substring(0, filePath.LastIndexOf('\\'));
                box2 = beforfilePath;

                // 履歴を取得
                string log = ConfigurationManager.AppSettings["key2"];

                // 履歴が無ければ新しくデータテーブルを作る
                if (log == "[]")
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.AddRange(new DataColumn[] { new DataColumn("path"), new DataColumn("name") });

                    dataTable.Rows.Add(new object[] { filePath, fileName });

                    string json = JsonConvert.SerializeObject(dataTable);

                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["key2"].Value = json;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");

                    comboBox1.DataSource = dataTable;
                    comboBox1.DisplayMember = "name";
                    comboBox1.ValueMember = "path";

                }
                else // 履歴がすでにある場合はデータテーブルに変換してコンボボックスに表示
                {
                    JArray jsonArray = JArray.Parse(log);
                    DataTable dataTable = new DataTable();

                    if (jsonArray.Count > 0)
                    {
                        foreach (var property in jsonArray[0].ToObject<Dictionary<string, object>>())
                        {
                            dataTable.Columns.Add(property.Key);
                        }
                    }

                    foreach (JObject jsonObject in jsonArray)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            dataRow[column.ColumnName] = jsonObject[column.ColumnName];
                        }
                        dataTable.Rows.Add(dataRow);
                    }

                    dataTable.Rows.Add(dataTable.NewRow()["path"] = filePath, dataTable.NewRow()["name"] = fileName); // 1行で追加

                    string json = JsonConvert.SerializeObject(dataTable);

                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["key2"].Value = json;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");

                    comboBox1.DataSource = dataTable;
                    comboBox1.DisplayMember = "name";
                    comboBox1.ValueMember = "path";
                }

            }

        }

        private void tabPage2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // ドロップされたファイルが .osu ファイルかどうかを確認
                if (files.Any(file => Path.GetExtension(file).ToLower() == ".osu"))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tabPage2_DragDrop(object sender, DragEventArgs e)
        {
            // イベントを Form に転送
            Form1_DragDrop(sender, e);
            tabControl1_Click(sender, e);
        }


        private void tabPage1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // ドロップされたファイルが .osu ファイルかどうかを確認
                if (files.Any(file => Path.GetExtension(file).ToLower() == ".osu"))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tabPage1_DragDrop(object sender, DragEventArgs e)
        {
            // イベントを Form に転送
            Form1_DragDrop(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name != "chkDelete" && e.RowIndex >= 0)
            {
                // チェックボックス列以外のセルがクリックされた場合
                DataGridViewCheckBoxCell chkCell = dataGridView1.Rows[e.RowIndex].Cells["chkDelete"] as DataGridViewCheckBoxCell;
                chkCell.Value = !Convert.ToBoolean(chkCell.Value);
                
            }
        }

    }

}
