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
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OsuMemoryDataProvider;
using OsuMemoryDataProvider.OsuMemoryModels;

namespace taiko
{
    public partial class Form1 : Form
    {
        private readonly StructuredOsuMemoryReader _sreader = new StructuredOsuMemoryReader();
        private readonly OsuBaseAddresses _baseAddresses = new OsuBaseAddresses();
        private string box1; // .osuファイルのパス
        private string box2; // .osuファイルがあるフォルダのパス
        private string[,] Language;

        public Form1()
        {
            InitializeComponent();
        }


        private void buttonread_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("osu!");

            // osu! が起動しているか確認
            if (processes.Length == 0)
            {
                textBox1.Text = "osu! が起動していません。";
                return; // osu! が起動していなければ、処理を中断
            }

            // osu.exeのパス
            string osuPath = Path.GetDirectoryName(processes[0].MainModule.FileName);

            // Songsフォルダーのパスーーーーーーーosu.(ユーザー名).cfgから取得するようにする
            string songsPath = osuPath + "/Songs";


            // _songsPath が存在するか確認
            if (!Directory.Exists(songsPath))
            {
                textBox1.Text = "SongsPathフォルダーが見つかりません。";
                return;
            }

            _sreader.TryRead(_baseAddresses.Beatmap);

            string filePath = Path.Combine(songsPath ?? "", _baseAddresses.Beatmap.FolderName ?? "",
                        _baseAddresses.Beatmap.OsuFileName ?? "");
            

            // テキストボックスにファイル名を表示
            string fileName = Path.GetFileName(filePath);
            textBoxRef2.Text = fileName;

            string data = File.ReadAllText(filePath);

            textBox1.Text = data;
            box1 = filePath;

            string beforfilePath = filePath.Substring(0, filePath.LastIndexOf('\\'));
            box2 = beforfilePath;




            // 履歴がオフになっている場合はコンボボックスやデータテーブルに関与しない
            if (radioButtonhistoryoff.Checked)
            {
                return;
            }

            // 履歴を取得
            string log = ConfigurationManager.AppSettings["key2"];

            // 履歴がなければ新しくデータテーブルを作る
            if (log == "[]")
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.AddRange(new DataColumn[] { new DataColumn("path"), new DataColumn("name") });

                dataTable.Rows.Add(new object[] { filePath, fileName });

                string json = JsonConvert.SerializeObject(dataTable);

                ConfigSave("key2", json);

                comboBox1.DataSource = dataTable;
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "path";

            }
            else // 履歴がすでにある場合はデータテーブルに変換してコンボボックスに表示
            {
                DataTable dataTable = MakeDataTable(log);

                dataTable.Rows.Add(dataTable.NewRow()["path"] = filePath, dataTable.NewRow()["name"] = fileName); // 1行で追加

                string json = JsonConvert.SerializeObject(dataTable);

                ConfigSave("key2", json);

                comboBox1.DataSource = dataTable;
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "path";
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

                if (line.Contains("[HitObjects]")) hitnum = i + 1;
                else if (line.StartsWith("Title:")) { Titlename0 = line.Substring(6).Trim(); titlenum = i; }
                else if (line.StartsWith("Artist:")) { Artistname0 = line.Substring(7).Trim(); artnum = i; }
                else if (line.StartsWith("Creator:")) { Creatorname = line.Substring(8).Trim(); crenum = i; }
                else if (line.StartsWith("Version:")) { diffname0 = line.Substring(8).Trim(); vernum = i; }
            }

            if (hitnum == -1 || Titlename0 == null || titlenum == -1 || Artistname0 == null || artnum == -1 ||
                Creatorname == null || crenum == -1 || diffname0 == null || vernum == -1)
            {
                DialogResult dialogResult = MessageBox.Show("譜面のデータに不備があるかもしれません><", "",
                  MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                label8.Text = "";
                return;
            }


            // [の扱い修正する必要あるかもーーーーーーー
            // 難易度名にすでに[Random]か[LRandom]があれば削除する
            string diffreg = @"(.*)Random\]?\(\d+\)";
            string diffreg2 = @"(.*)LRandom\[[^\]]*\]\]?\(\d+\)";
            string diffreg3 = @"(.*)\[$";
            diffname0 = Regex.Replace(diffname0, diffreg, "$1");
            diffname0 = Regex.Replace(diffname0, diffreg2, "$1");
            diffname0 = Regex.Replace(diffname0, diffreg3 , "$1");


            // 別の方法探すーーーーーーー
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

            string pattern = nodiffname 
                ? $@"{escArtistname} - {escTitlename} \({escCreatorname}\) \[{escpart1}\((\d+)\)\]\.osu$"
                : $@"{escArtistname} - {escTitlename} \({escCreatorname}\) \[{escdiffname}\[{escpart1}\]\((\d+)\)\]\.osu$";

            List<string> numbers = new List<string>(); // 元からある数字を格納するリスト

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


          
            // Console.WriteLine($"繰り返し処理に入る前までの経過時間: {stopwatch.ElapsedMilliseconds} ミリ秒");



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
                        DialogResult dialogResult = MessageBox.Show(
                            $".osuファイルの\"{hitnum + i}\"行目に不備があるかもしれません" +
                            $"\nもしくは osu file format のバージョンが対応していないです><", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        label8.Text = "";
                        return;
                    }
                }



                // Console.WriteLine($"ノーツを生成する処理に入る前までの経過時間: {stopwatch.ElapsedMilliseconds} ミリ秒");



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
                                int index = System.Math.Abs(BitConverter.ToInt32(bytes, 0)) % splrule.Length;
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



                // Console.WriteLine($"bigノーツにする処理に入る前までの経過時間: {stopwatch.ElapsedMilliseconds} ミリ秒");



                // bigノーツに変換
                for (int x = 0; x < big.Count; x++)
                {
                    List<string> big3 = new List<string>(randomafter[big[x]].Split(','));
                    big3[4] = big3[4] == "0" ? "4" : (big3[4] == "2" ? "6" : big3[4]); // 三項演算子で判定
                    randomafter[big[x]] = string.Join(",", big3);
                }


                // ノーツより前の部分と完成したノーツ部分を結合して文字列にする
                string complete = string.Join(Environment.NewLine, result.Take(hitnum).Concat(randomafter));


                // 最後の場合、中身を表示
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
                    if (newPath.Length >= 260)
                    {            
                        DialogResult dialogResult = MessageBox.Show(
                            $"エラー\n生成される譜面のファイル名まで含んだパスの長さが'{newPath.Length}'文字でした" +
                            $"\nwindowsでは260文字未満にしかできないらしいです><" +
                            $"\n\"難易度名を残さない\"をオンにしたら'{newPath.Length - diffname.Length}'文字になります", "",
                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        label8.Text = "";
                        return;
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("エラー\n生成中に曲のフォルダーが消えた可能性があります><", "",
                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        label8.Text = "";
                        return;
                    }
                }


                // Console.WriteLine($"１週終わった時の経過時間: {stopwatch.ElapsedMilliseconds} ミリ秒");
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
            // 言語設定の適応
            string selectlang = ConfigurationManager.AppSettings["key3"];
       
            // 設定する言語のデータを読み取る
            string relativePath = $@"Language\{selectlang}.txt"; // 読み取るファイルの相対パス
            string lang = File.ReadAllText(relativePath, Encoding.UTF8);

            // 空行を削除して１次元配列にする
            List<string> lines = new List<string>(lang.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            string[] langarray = lines.ToArray();

            //２次元配列に加工
            string[,] newlangarray = new string[langarray.Length, 2];

            for (int i = 0; i < langarray.Length; i++)
            {
                string[] parts = langarray[i].Split(',');

                for (int j = 0; j < 2; j++)
                {
                    newlangarray[i, j] = parts[j].Trim(); // 前後の空白を削除
                }
            }

            // Languageにデータをセット
            Language = newlangarray;

            // フォーム上のテキストを書き換える
            LanguageChange();

            // Languageフォルダーにあるファイルから取得した言語名をコンボボックスに表示
            string langpath = @"Language";

            string[] fileNames0 = Directory.GetFiles(langpath);

            string Reg = @"Language\\(.*)\.txt";
            string[] fileNames = fileNames0.Select(f => Regex.Match(f, Reg).Groups[1].Value).ToArray();

            DataTable langdataTable = new DataTable();
            langdataTable.Columns.Add("langname");

            foreach (string element in fileNames)
            {
                DataRow row = langdataTable.NewRow();
                row["langname"] = element;
                langdataTable.Rows.Add(row);
            }

            comboBoxLanguage.DataSource = langdataTable;
            comboBoxLanguage.DisplayMember = "langname";

            for (int i = 0; i < langdataTable.Rows.Count; i++)
            {
                if (langdataTable.Rows[i]["langname"].ToString() == selectlang)
                {
                    comboBoxLanguage.SelectedIndex = i;
                    break;
                }
            }

            // 保存された設定の適応
            string set = ConfigurationManager.AppSettings["key4"];

            if (set != "")
            {
                string[] setting = JsonConvert.DeserializeObject<string[]>(set);

                radioButtonR.Checked = (setting[0] == "true" ? true : false); // でたらめか
                if(radioButtonR.Checked == false) { radioButton2.Checked = true; }
                textBoxRule.Text = setting[1]; // 制限付きでたらめのルール
                textBoxTimes.Text = setting[2]; // 個数
                checkBox2.Checked = (setting[3] == "true" ? true : false); // 難易度名を残さない
                checkBox1.Checked = (setting[4] == "true" ? true : false); // 上書きする
                radioButtonhistoryon.Checked = (setting[5] == "true" ? true : false); // 履歴を残すか
                if(radioButtonhistoryon.Checked == false) { radioButtonhistoryoff.Checked = true; }
            }
            else
            {
                radioButtonR.Checked = true;
                radioButtonhistoryon.Checked = true;

                DialogResult dialogResult = MessageBox.Show("ダウンロードしてくれてありがとう！！！！！！", "感謝",
                      MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }        

            // 最初から書き込んでおく
            textBox2.Text = "1";
            textBox4.Text = radioButtonR.Checked
                ? $"[Random]({textBox2.Text})"
                : $"[LRandom[{textBoxRule.Text}]]({textBox2.Text})";


            // 履歴があるか
            string log = ConfigurationManager.AppSettings["key2"];

            // ある場合は、コンボボックスに表示
            if (log != "[]")
            {
                DataTable dataTable = MakeDataTable(log);

                DataTableSet(dataTable);

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


        private void button2_Click(object sender, EventArgs e) // 履歴のすべて選択ボタン
        {
            // チェックボックス列の列名
            string checkColumnName = "chkDelete";

            // 全ての行のチェックボックスにチェックを入れる
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[checkColumnName].Value = true;
            }
        }


        private void button4_Click(object sender, EventArgs e) // 履歴のすべて解除ボタン
        {
            // チェックボックス列の列名
            string checkColumnName = "chkDelete";

            // 全ての行のチェックボックスのチェックを外す
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[checkColumnName].Value = false;
            }
        }


        private void button3_Click_1(object sender, EventArgs e) // 履歴の選択中の項目を削除ボタン
        {
            // チェックボックス列の列名
            string checkColumnName = "chkDelete";

            DataTable dt = (DataTable)dataGridView1.DataSource;

            // チェックされている行があるかどうかフラグ
            bool checkedRowExists = false;

            // DataGridViewの行を逆順にループ (削除によるインデックスのずれを防ぐため)
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                // チェックボックスがチェックされているか確認
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[checkColumnName].Value) == true)
                {
                    checkedRowExists = true;
                    dt.Rows.RemoveAt(i);
                }
            }

            // チェックされている行が1つ以上あった場合のみ処理を行う
            if (checkedRowExists)
            {
                // DataGridViewを更新
                dataGridView1.DataSource = dt;

                string json = JsonConvert.SerializeObject(dt);

                ConfigSave("key2", json);
            }
        }


        private void tabControl1_Click(object sender, EventArgs e)
        {
            // 履歴を取得
            string log = ConfigurationManager.AppSettings["key2"];

            // ある場合は、コンボボックスに表示
            if (log != "[]")
            {
                DataTable dataTable = MakeDataTable(log);

                DataTableSet(dataTable);
            }
        }


        private void Form1_DragDrop(object sender, DragEventArgs e) // .osuファイルがドロップされたとき
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string filePath = files[0];

                // テキストボックスにファイル名を表示
                string fileName = Path.GetFileName(filePath);
                textBoxRef2.Text = fileName;

                // 中身を表示
                string data = File.ReadAllText(filePath);
                textBox1.Text = data;

                // box1,2を変える
                box1 = filePath;

                string beforfilePath = filePath.Substring(0, filePath.LastIndexOf('\\'));
                box2 = beforfilePath;

                // 履歴がオフになっている場合はコンボボックスやデータテーブルに関与しない
                if (radioButtonhistoryoff.Checked)
                {
                    return;
                }

                // 履歴を取得
                string log = ConfigurationManager.AppSettings["key2"];

                // 履歴が無ければ新しくデータテーブルを作る
                if (log == "[]")
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.AddRange(new DataColumn[] { new DataColumn("path"), new DataColumn("name") });

                    dataTable.Rows.Add(new object[] { filePath, fileName });

                    string json = JsonConvert.SerializeObject(dataTable);

                    ConfigSave("key2", json);

                    DataTableSet(dataTable);

                }
                else // 履歴がすでにある場合はデータテーブルに変換してコンボボックスに表示
                {
                    DataTable dataTable = MakeDataTable(log);

                    dataTable.Rows.Add(dataTable.NewRow()["path"] = filePath, dataTable.NewRow()["name"] = fileName); // 1行で追加

                    string json = JsonConvert.SerializeObject(dataTable);

                    ConfigSave("key2", json);

                    comboBox1.DataSource = dataTable;
                    comboBox1.DisplayMember = "name";
                    comboBox1.ValueMember = "path";
                }

            }

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


        private void comboBoxLanguage_SelectionChangeCommitted(object sender, EventArgs e)// 言語が選択されたとき
        {
            //選択された言語名を取得
            string selectlang = comboBoxLanguage.Text;

            // 設定する言語のデータを読み取る
            string relativePath = $@"Language\{selectlang}.txt"; // 読み取るファイルの相対パス
            string lang = File.ReadAllText(relativePath, Encoding.UTF8);

            // 空行を削除して１次元配列にする
            List<string> lines = new List<string>(
                lang.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            string[] langarray = lines.ToArray();

            // ２次元配列に加工
            string[,] newlangarray = new string[langarray.Length, 2];

            for (int i = 0; i < langarray.Length; i++)
            {
              　string[] parts = langarray[i].Split(',');

                for (int j = 0; j < 2; j++)
                {
                    newlangarray[i, j] = parts[j].Trim(); // 前後の空白を削除
                }
            }

            // Languageにデータをセット
            Language = newlangarray;

            // フォーム上のテキストを書き換える
            LanguageChange();


            //表の列名は変えられないので、いったんデータを保存して元のデータごと表を削除、そのあと表を作り直す
            string backup = ConfigurationManager.AppSettings["key2"];

            if (dataGridView1.DataSource != null)
            {
                 dataGridView1.DataSource = null;
            }
            if (dataGridView1.Columns.Contains("chkDelete"))
            {
                // チェックボックス列を削除
                dataGridView1.Columns.Remove("chkDelete");
            }

            // 保存したデータ
            ConfigSave("key2", backup);

            // 履歴があるか
            string log = ConfigurationManager.AppSettings["key2"];

            // ある場合は、コンボボックスに表示
            if (log != "[]")
            {
                DataTable dataTable = MakeDataTable(log);

                DataTableSet(dataTable);

            }

            // 選んだ言語をconjigに保存
            ConfigSave("key3", selectlang);
        }


        private void tabControl1_DragEnter(object sender, DragEventArgs e) // ファイルがドラッグアンドドロップされたとき
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                e.Effect = files.Any(file => Path.GetExtension(file).ToLower() == ".osu") ?
                    DragDropEffects.Copy : DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void tabControl1_DragDrop(object sender, DragEventArgs e)
        {
            Form1_DragDrop(sender, e);
            if (tabControl1.SelectedTab == tabPage2) // 履歴でドロップしていたらコンボボックスと表を更新
            {
                tabControl1_Click(sender, e);
            }
            
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // アプリ終了時に設定を保存する
        {
            string[] setting = {
                radioButtonR.Checked ? "true" : "false", // でたらめか
                textBoxRule.Text, // 制限付きでたらめのルール
                textBoxTimes.Text, // 個数
                checkBox2.Checked ? "true" : "false", // 難易度名を残さない
                checkBox1.Checked ? "true" : "false", // 上書きする
                radioButtonhistoryon.Checked ? "true" : "false" // 履歴を残すか
            };

            string json = JsonConvert.SerializeObject(setting);
            ConfigSave("key4", json);
        }


        private int LanguageErrorCount = 0;
        private string GetValue(string[,] array, string num) // 言語設定から文字列を取得
        {
            int rows = array.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                if (array[i, 0] == num)
                {
                    return array[i, 1];
                }
            }
            if (LanguageErrorCount == 0) // 破損があれば一回だけ表示
            {
                DialogResult dialogResult = MessageBox.Show("Languageファイルが破損しています><", "",
                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                label8.Text = "";
            }
            LanguageErrorCount++;
            return ""; // 見つからなかった場合は空白
        }


        private void ConfigSave(string key, string value) // configファイルを書き換える
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }


        private DataTable MakeDataTable(string history) // 履歴からデータテーブルを作る
        {
            JArray jsonArray = JArray.Parse(history);
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
            return dataTable;
        }


        private void DataTableSet(DataTable dt)
        {
            // 履歴のコンボボックス更新
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "path";

            // 履歴の表がない場合は作る
            if (dataGridView1.Columns["path"]?.Width != 75) // null許容演算子、表がないか
            {
                // チェックボックス列が残っていたら削除
                if (dataGridView1.Columns.Contains("chkDelete"))
                {
                    dataGridView1.Columns.Remove("chkDelete");
                }

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["name"].Width = 517;
                dataGridView1.Columns["name"].HeaderText = GetValue(Language, "19");
                dataGridView1.Columns["path"].Width = 65;
                dataGridView1.Columns["path"].HeaderText = GetValue(Language, "20");

                dataGridView1.Columns["path"].DisplayIndex = 1; // 列順入れ替え
                dataGridView1.Columns["name"].DisplayIndex = 0;

                dataGridView1.Columns.Insert(0, new DataGridViewCheckBoxColumn
                {
                    HeaderText = GetValue(Language, "18"),
                    Name = "chkDelete",
                    Width = 40
                });

                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.RowHeadersVisible = false;
            }
        }


        private void LanguageChange()
        {
            tabPage1.Text = GetValue(Language, "1");
            tabPage2.Text = GetValue(Language, "2");
            tabPage3.Text = GetValue(Language, "3");
            label2.Text = GetValue(Language, "4");
            label7.Text = GetValue(Language, "5");
            buttonread.Text = GetValue(Language, "6");
            button1.Text = GetValue(Language, "7");
            label5.Text = GetValue(Language, "8");
            radioButtonR.Text = GetValue(Language, "9");
            radioButton2.Text = GetValue(Language, "10");
            label4.Text = GetValue(Language, "11");
            checkBox2.Text = GetValue(Language, "12");
            checkBox1.Text = GetValue(Language, "13");
            button2.Text = GetValue(Language, "14");
            button4.Text = GetValue(Language, "15");
            button3.Text = GetValue(Language, "16");
            label10.Text = GetValue(Language, "17");
            labellanguage.Text = GetValue(Language, "21");
            label9.Text = GetValue(Language, "22");
            radioButtonhistoryon.Text = GetValue(Language, "23");
            radioButtonhistoryoff.Text = GetValue(Language, "24");
        }
    }

}
