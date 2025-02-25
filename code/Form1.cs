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
using System.Drawing;
using OsuParsers.Decoders;


namespace taiko
{
    public partial class Form1 : Form
    {
        private readonly StructuredOsuMemoryReader _sreader = new StructuredOsuMemoryReader();
        private readonly OsuBaseAddresses _baseAddresses = new OsuBaseAddresses();
        private string _SongsPath; // songsフォルダのパス
        private string _filePath; // .osuファイルのパス
        private string _beforfilePath; // .osuファイルがあるフォルダのパス
        private string[,] _Language; // 選択された言語ファイルの中身
        private string _History; // Json形式の履歴

        public Form1()
        {
            InitializeComponent();
        }


        private void ButtonRead_Click(object sender, EventArgs e) // 読み込む
        {
            Process[] processes = Process.GetProcessesByName("osu!");

            // osu! が起動しているか確認
            if (processes.Length == 0)
            {
                MessageBox.Show($"{GetWord("51")}", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return; // osu! が起動していなければ、処理を中断
            }

            // Songsフォルダのパスを取得
            string osuPath = Path.GetDirectoryName(processes[0].MainModule.FileName);
            SetSongsPath(osuPath);
            processes[0].Dispose();

            // .osuファイルのパスを取得
            _sreader.TryRead(_baseAddresses.Beatmap);

            string filePath = Path.Combine(_SongsPath ?? "", _baseAddresses.Beatmap.FolderName ?? "",
                        _baseAddresses.Beatmap.OsuFileName ?? "");

            // テキストボックスにファイル名を表示
            string fileName = Path.GetFileName(filePath);
            TextBoxSelectedMap.Text = fileName;

            // 譜面のデータをフィールドに保存
            _filePath = filePath;

            string beforfilePath = filePath.Substring(0, filePath.LastIndexOf('\\'));
            _beforfilePath = beforfilePath;

            // 画像をセット
            SetImage();

            // 履歴がオフになっている場合はコンボボックスやデータテーブルに関与しない
            if (RadioButtonHistoryOff.Checked)
            {
                return;
            }

            // 履歴を取得
            string log = _History;

            // 履歴がなければ新しくデータテーブルを作る
            if (log == "[]")
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.AddRange(new DataColumn[] { new DataColumn("path"), new DataColumn("name") });

                dataTable.Rows.Add(new object[] { filePath, fileName });

                string json = JsonConvert.SerializeObject(dataTable);

                _History = json;

                ComboBoxFromHistory.DataSource = dataTable;
                ComboBoxFromHistory.DisplayMember = "name";
                ComboBoxFromHistory.ValueMember = "path";

            }
            else // 履歴がすでにある場合はデータテーブルに変換してコンボボックスに表示
            {
                DataTable dataTable = MakeDataTable(log);

                dataTable.Rows.Add(dataTable.NewRow()["path"] = filePath, dataTable.NewRow()["name"] = fileName);

                string json = JsonConvert.SerializeObject(dataTable);

                _History = json;

                ComboBoxFromHistory.DataSource = dataTable;
                ComboBoxFromHistory.DisplayMember = "name";
                ComboBoxFromHistory.ValueMember = "path";
            }
        }


        private void ButtonMake_Click(object sender, EventArgs e) // 実行ボタン
        {
            // Stopwatch オブジェクトを作成
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            LabelReport.Text = $"{GetWord("41")}";


            // 譜面が選択されていなければエラー
            if(_filePath == null)
            {
                MessageBox.Show($"{GetWord("54")}", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LabelReport.Text = "";

                return;
            }
            // 譜面が消えているか、ファイル名が変わっていたらエラー
            if (!File.Exists(_filePath))
            {
                MessageBox.Show($"{GetWord("76")}", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LabelReport.Text = "";

                return;
            }


            // .osuファイルの中身
            string BaseMapDate = File.ReadAllText(_filePath);


            // 入力されたデータの文字列の後ろ部分が空白や改行だった場合それを削除して、string型の配列にする Todoエラー?
            List<string> lines = BaseMapDate.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();

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


            // カッコの中の数字部分
            int part2 = 1;
            try
            {
                part2 = int.Parse(NumericUpDownNum.Value.ToString());
            }
            catch
            {
                MessageBox.Show($"{GetWord("55")}", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LabelReport.Text = "";
                return;
            }


            // LINQを使って必要な情報を検索
            var data = result.Select((line, index) => new { line, index }) // 行番号も取得
                             .Where(x => x.line.Contains("[HitObjects]") || x.line.StartsWith("HPDrainRate:") ||
                                         x.line.StartsWith("OverallDifficulty:") || x.line.StartsWith("Title:") ||
                                         x.line.StartsWith("Artist:") || x.line.StartsWith("Creator:") ||
                                         x.line.StartsWith("Version:") || x.line.StartsWith("[TimingPoints]"))
                             .ToDictionary(x => x.line.Split(':')[0].Trim(), x => x.index); // キーと行番号の辞書を作成

            if (data.Count < 8) // 必要な情報がすべて見つかったか確認
            {
                MessageBox.Show($"{GetWord("56")}", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LabelReport.Text = "";
                return;
            }

            // 各情報を取得
            int hitnum = data["[HitObjects]"];
            int timingnum = data["[TimingPoints]"];
            int HPnum = data["HPDrainRate"];
            int ODnum = data["OverallDifficulty"];
            string Titlename0 = result[data["Title"]].Substring(6).Trim();
            string Artistname0 = result[data["Artist"]].Substring(7).Trim();
            string Creatorname = result[data["Creator"]].Substring(8).Trim();
            string diffname = result[data["Version"]].Substring(8).Trim();
            int vernum = data["Version"];



            // ここから難易度名を決める

            // random等の処理
            string newrandompart = "";

            if (CheckBoxNoChange.Checked)
            {
                bool randomexist1 = diffname.Contains("[Random]");
                bool randomexist2 = Regex.IsMatch(diffname, @"\[LRandom\[((\d+)(,\d+)*)\]\]");

                if (randomexist1)
                {
                    newrandompart = "[Random]";
                }
                else if (randomexist2)
                {
                    newrandompart = Regex.Match(diffname, @"\[LRandom\[((\d+)(,\d+)*)\]\]").ToString();
                }
            }
            else
            {
                if (RadioButtonR.Checked)
                {
                    newrandompart = "[Random]";
                }
                else
                {
                    if (TextBoxRule.Text.Length == 0) // ルールが入力されていなければエラーで終わり
                    {
                        MessageBox.Show($"{GetWord("65")}", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LabelReport.Text = "";
                        return;
                    }
                    newrandompart = $"[LRandom[{TextBoxRule.Text}]]";
                }
            }

            string diffregRandom = @"(.*)\[Random\](.*)";
            diffname = Regex.Replace(diffname, diffregRandom, "$1$2");

            string diffregLRandom = @"(.*)\[LRandom\[.*?\]\](.*)$";
            diffname = Regex.Replace(diffname, diffregLRandom, "$1$2");



            // odhpの処理
            string newodhp = "";

            string odhpreg = @"\[(OD|HP)[\d.]+(?: HP[\d.]+)?\]";
            string oldodhppart0 = Regex.Match(diffname, odhpreg).ToString();
            string oldodhppart = oldodhppart0.Length > 2 ? oldodhppart0.Substring(1, oldodhppart0.Length - 2) : "";

            bool odmatch = Regex.IsMatch(oldodhppart, @"OD");
            bool hpmatch = Regex.IsMatch(oldodhppart, @"HP");

            string odText = NumericUpDownOD.Value.ToString();
            string hpText = NumericUpDownHP.Value.ToString();

            if (CheckBoxOD.Checked)
            {
                if (Regex.IsMatch(odText, @"^([0-9]|10)(\.[0-9]+)?$") || (Regex.IsMatch(odText, @"^0$")))
                {
                    result[ODnum] = "OverallDifficulty:" + odText;

                    if (odmatch && hpmatch)
                    {
                        string odpattern = @"(OD[\d.]+)";
                        newodhp = Regex.Replace(oldodhppart, odpattern, "OD" + odText);
                    }
                    else if (odmatch)
                    {
                        newodhp = "OD" + odText;
                    }
                    else if (hpmatch)
                    {
                        newodhp = "OD" + odText + " " + oldodhppart;
                    }
                    else
                    {
                        newodhp = "OD" + odText;
                    }
                }
                else
                {
                    MessageBox.Show($"{GetWord("57")}", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LabelReport.Text = "";
                    return;
                }
            }

            if (CheckBoxHP.Checked)
            {
                if (Regex.IsMatch(hpText, @"^([0-9]|10)(\.[0-9]+)?$") || (Regex.IsMatch(hpText, @"^0$")))
                {
                    result[HPnum] = "HPDrainRate:" + hpText;

                    if (odmatch && hpmatch)
                    {
                        string hppattern = @"(HP[\d.]+)";
                        newodhp = odText != "" ? Regex.Replace(newodhp, hppattern, "HP" + hpText)
                                               : Regex.Replace(oldodhppart, hppattern, "HP" + hpText);
                    }
                    else if (odmatch)
                    {
                        newodhp = odText != "" ? newodhp + " HP" + hpText
                                               : oldodhppart + " HP" + hpText;
                    }
                    else if (hpmatch)
                    {
                        string hppattern = @"(HP[\d.]+)";
                        newodhp = odText != "" ? Regex.Replace(newodhp, hppattern, "HP" + hpText)
                                               : Regex.Replace(oldodhppart, hppattern, "HP" + hpText);
                    }
                    else
                    {
                        newodhp = odText != "" ? newodhp + " HP" + hpText
                                               : "HP" + hpText;
                    }
                }
                else
                {
                    MessageBox.Show($"{GetWord("58")}", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LabelReport.Text = "";
                    return;
                }
            }

            newodhp = newodhp != "" ? "[" + newodhp + "]"
                                    : oldodhppart0;

            diffname = Regex.Replace(diffname, @"(.*)\[(OD.* HP.*?|OD.*?|HP.*?)\](.*)$", "$1$3");


            // Timingの範囲を[Corors]の有無によって変える
            int timingcount;
            int coloursnum = Array.IndexOf(result, "[Colours]");
            if (coloursnum != -1)
            {
                timingcount = hitnum - coloursnum - 1;
            }
            else
            {
                timingcount = hitnum - timingnum - 1;
            }

            // オフセットの処理
            string newoffset = "";
            if (NumericUpDownOffset.Value.ToString() != "0")
            {
                List<string> HitObjectPart = result.Skip(hitnum + 1).ToList();
                List<string> TimingPart0 = result.Skip(timingnum + 1).Take(timingcount).ToList();
                List<string> TimingPart = TimingPart0.Where(s => !string.IsNullOrEmpty(s)).ToList();

                int offsetText = int.Parse(NumericUpDownOffset.Value.ToString());

                // hitobjectの時間をずらす
                for (int i = 0; i < HitObjectPart.Count; i++)
                {
                    string[] values = HitObjectPart[i].Split(',');
                    int oldoffset = int.Parse(values[2]);
                    string offset = (oldoffset + offsetText).ToString();
                    values[2] = offset;
                    HitObjectPart[i] = string.Join(",", values);
                }

                // timingの時間をずらす
                for (int i = 0; i < TimingPart.Count; i++)
                {
                    string[] values = TimingPart[i].Split(',');
                    int oldoffset = int.Parse(values[0]);
                    string offset = (oldoffset + offsetText).ToString();
                    values[0] = offset;
                    TimingPart[i] = string.Join(",", values);
                }

                // resultに変更を反映
                result = result.Take(hitnum + 1).Concat(HitObjectPart).ToArray();

                TimingPart.AddRange(Enumerable.Repeat("", 2));
                result = result.Take(timingnum + 1).Concat(TimingPart).Concat(result.Skip(hitnum)).ToArray();

                string offsetreg = @"\[offset([+\-]\d+)]";
                bool offsetexist = Regex.IsMatch(diffname, offsetreg);
                if (offsetexist)
                {
                    Match oldoffsetpart0 = Regex.Match(diffname, offsetreg);
                    int oldoffsetpart = int.Parse(oldoffsetpart0.Groups[1].ToString());

                    newoffset = oldoffsetpart + offsetText > 0 ? "[offset+" + (oldoffsetpart + offsetText).ToString() + "]"
                                                               : "[offset" + (oldoffsetpart + offsetText).ToString() + "]";
                }
                else
                {
                    newoffset = int.Parse(NumericUpDownOffset.Value.ToString()) > 0 ? "[offset+" + offsetText.ToString() + "]"
                                                                                    : "[offset" + offsetText.ToString() + "]";
                }                
            }
            else
            {
                string offsetreg = @"\[offset([+\-]\d+)]";
                bool offsetexist = Regex.IsMatch(diffname, offsetreg);
                if (offsetexist)
                {
                    newoffset = Regex.Match(diffname, offsetreg).ToString();
                }
            }

            string diffregoffset = @"(.*)\[offset([+\-]\d+)\](.*)$";
            diffname = Regex.Replace(diffname, diffregoffset, "$1$3");



            // nosvの処理
            string newnoSV = "";
            if (CheckBoxSV.Checked)
            {
                string[] timingonly = result.Skip(timingnum + 1).Take(timingcount).ToArray();

                // 各行を処理
                for (int i = 0; i < hitnum - timingnum - 1; i++)
                {
                    // カンマで分割して値を取得
                    string[] values = timingonly[i].Split(',');
                    if (values[0] == "")
                    {
                        continue;
                    }

                    // svか小節線のやつかどうかを判定
                    bool issv = double.Parse(values[1]) < 0;

                    if (issv)
                    {        
                        values.SetValue("-100", 1);
                        string nosv = string.Join(",", values.Select(s => s.ToString()));
                        timingonly[i] = nosv;                        
                    }
                }

                Array.Copy(timingonly, 0, result, timingnum + 1, timingonly.Length);

                newnoSV = "[noSV]";
            }
            else
            {
                string noSVreg = @"\[noSV\]";
                bool noSVexist = Regex.IsMatch(diffname, noSVreg);
                if (noSVexist)
                {
                    newnoSV = "[noSV]";
                }
            }

            string diffregnoSV = @"(.*)\[noSV\](.*)$";
            diffname = Regex.Replace(diffname, diffregnoSV, "$1$2");



            // 後ろの数字は新しい難易度に関係ないので消す
            string diffregNumber = @"(.*)\(\d+\)$";
            diffname = Regex.Replace(diffname, diffregNumber, "$1");


            // 元の難易度名を残さない場合の処理
            string newdiffname = diffname + newrandompart + newodhp + newnoSV + newoffset;
            if (CheckBoxOriginalDiff.Checked)
            {
                newdiffname = "" + newrandompart + newodhp + newnoSV + newoffset;
            }


            // 難易度、タイトル、アーティスト名に含まれるパスに使えない文字を削除する
            string invalidChars = @"[\\\/><?:*|""]+";

            string Artistname = Regex.Replace(Artistname0, invalidChars, "");
            string Titlename = Regex.Replace(Titlename0, invalidChars, "");
            string cleannewdiffname = Regex.Replace(newdiffname, invalidChars, "");


            // 同じ譜面ですでに生成された譜面があれば、後ろの番号を取得する
            string escArtistname = Regex.Escape(Artistname);
            string escTitlename = Regex.Escape(Titlename);
            string escCreatorname = Regex.Escape(Creatorname);
            string esccleannewdiffname = Regex.Escape(cleannewdiffname);


            string pattern = $@"{escArtistname} - {escTitlename} \({escCreatorname}\) \[{esccleannewdiffname}\((\d+)\)\]\.osu$";

            List<string> numbers = new List<string>();

            foreach (string fileName in Directory.GetFiles(_beforfilePath))
            {
                Match match = Regex.Match(Path.GetFileName(fileName), pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    string number = match.Groups[1].Value;
                    numbers.Add(number);
                }
            }

            // noSVで[hitobjects]の位置が変わっているかもしれないので新しく取得
            int newhitnum = Array.IndexOf(result, result.FirstOrDefault(x => x.Contains("[HitObjects]")));


            // 繰り返し回数
            int time = 1;
            try
            {
                if (!string.IsNullOrEmpty(NumericUpDowncount.Value.ToString()))
                {
                    time = int.Parse(NumericUpDowncount.Value.ToString());
                }
            }
            catch (FormatException) // 入力が正しくない場合
            {
                MessageBox.Show($"{GetWord("59")}", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LabelReport.Text = "";
                return;
            }

            if (time > 99) // 作る数が100以上ならメッセージを出す
            {
                DialogResult dialogResult = MessageBox.Show($"{GetWord("60")}\n{GetWord("61")}", "",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                if (dialogResult == DialogResult.Cancel)
                {
                    LabelReport.Text = "";
                    return;
                }
            }


            // 生成する譜面の後ろにつける番号をあらかじめ作る
            List<int> intList = numbers.Select(int.Parse).ToList();

            List<int> newnum = Enumerable.Range(part2, time + intList.Count)
                 .Where(n => !intList.Contains(n)).Take(time).ToList();


            // ノーツだけの1次元配列
            string[] noteonly = result.Skip(newhitnum + 1).ToArray();

            // ノーツの位置を0,0に変える
            for (int i = 0; i < noteonly.Length; i++)
            {
                string[] values = noteonly[i].Split(',');
                if (values[0] == "")
                {
                    continue;
                }

                values.SetValue("0", 0);
                values.SetValue("0", 1);
                string locationzero = string.Join(",", values.Select(s => s.ToString()));
                noteonly[i] = locationzero;
            }



            // bigノーツの行番号取得
            List<int> big = new List<int>();
            List<int> big2 = new List<int>();

            for (int i = 0; i < noteonly.Length; i++)
            {
                string[] line = noteonly[i].Split(',');

                try
                {
                    if (line[4] == "4" || line[4] == "6")
                    {
                        big.Add(i);
                    }
                    else if (line[4] == "12")
                    {
                        big2.Add(i);
                    }
                }
                catch
                {
                    MessageBox.Show($"{GetWord("62")} '{newhitnum + i}' {GetWord("63")}\n{GetWord("64")}", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // n行目で～
                    LabelReport.Text = "";
                    return;
                }
            }


            // 譜面のパスのもとを作る
            string beetmapPath = _filePath;

            string Pathcut = Regex.Replace(beetmapPath, @"\\(?!.*\\).*", ""); // 最後の'\'までを削除
            string PathendBase = string.Format("\\{0} - {1} ({2}) [", Artistname, Titlename, Creatorname);
            string PathendEnd = "].osu";


            // 制限付きでたらめの場合1ノーツ目の色をまとめて決める
            List<string> colors1 = new List<string>();
            if (RadioButtonLR.Checked)
            { 
                using (RandomNumberGenerator rngColor = RandomNumberGenerator.Create())
                {
                    byte[] randomNumberColor = new byte[1];
                    for (int i = 0; i < time; i++) // time はループ回数
                    {
                        rngColor.GetBytes(randomNumberColor);
                        string color1 = ((randomNumberColor[0] % 2) * 2).ToString();
                        colors1.Add(color1);
                    }
                }
            }


            // 個数分作るのを繰り返す
            for (int k = 0; k < time; k++)
            {

                // 難易度部分を作成

                string word = "";
                string word2 = "";
                if (CheckBoxOverwrite.Checked) // 同名の難易度がある場合上書きする場合
                {
                    // .osuファイル内の難易度名と、ファイル名の難易度名
                    word = $"{newdiffname}({k + part2})";
                    word2 = $"{cleannewdiffname}({k + part2})";
                }
                else
                {
                    word = $"{newdiffname}({newnum[k]})";
                    word2 = $"{cleannewdiffname}({newnum[k]})";
                }


                // 全体の配列の難易度部分を書き換える
                result[vernum] = $"Version:{word}";


                // 生成したノーツを入れる場所
                List<string> randomafter = new List<string>();

                if (!CheckBoxNoChange.Checked)
                {
                    if (RadioButtonR.Checked) // でたらめの場合
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
                        List<string> randomrule = new List<string>(TextBoxRule.Lines);

                        string[] splrule = randomrule[0].Split(',');

                        try
                        {
                            // ルールの数字から必要な長さのintのリストを作る
                            List<int> box = new List<int>();
                            
                            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                            {
                                byte[] bytes = new byte[4]; // int は 4 バイト
                                int total = 0;

                                for (int i = 0; i < noteonly.Length; i++)
                                {
                                    rng.GetBytes(bytes);
                                    int index = System.Math.Abs(BitConverter.ToInt32(bytes, 0)) % splrule.Length;
                                    int num = int.Parse(splrule[index]);
                                    box.Add(num);
                                    total += num;
                                    if(total > noteonly.Length)
                                    {
                                        break;
                                    }
                                }
                            }


                            // 奇数かたまり目の色と偶数かたまり目の色を決める
                            string color1 = colors1[k];
                            string color2 = (color1 == "0" ? "2" : "0");

                            // ノーツを作る処理
                            int count = 0;
                            for (int j = 0; j < box.Count; j++)
                            {
                                if (count >= noteonly.Length) break;

                                string color = j % 2 == 0 ? color1 : color2;

                                for (int i = 0; i < box[j]; i++)
                                {
                                    if (count >= noteonly.Length) break;

                                    List<string> line = new List<string>(noteonly[count].Split(','))
                                    {
                                        [4] = color
                                    };
                                    randomafter.Add(string.Join(",", line));

                                    count++;
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show($"{GetWord("66")}\n{GetWord("67")})1,2,3", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            LabelReport.Text = ""; // ルールが正しく入力されていない場合
                            return;
                        }
                    }

                    // bigノーツに変換
                    for (int x = 0; x < big.Count; x++)
                    {
                        List<string> line = new List<string>(randomafter[big[x]].Split(','));
                        line[4] = line[4] == "0" ? "4" : "6";
                        randomafter[big[x]] = string.Join(",", line);
                    }
                    for (int x = 0; x < big2.Count; x++)
                    {
                        List<string> line = new List<string>(randomafter[big2[x]].Split(','));
                        line[4] = line[4] == "0" ? "4" : "12";
                        randomafter[big2[x]] = string.Join(",", line);
                    }
                }
                else
                {
                    randomafter = noteonly.ToList();
                }

                // Console.WriteLine($"ノーツの変換までの経過時間: {stopwatch.ElapsedMilliseconds} ミリ秒");

                // ノーツより前の部分と完成したノーツ部分を結合して文字列にする
                string complete = string.Join(Environment.NewLine, result.Take(newhitnum + 1).Concat(randomafter));


                // 譜面のパスを取得
                string Pathend = PathendBase + word2 + PathendEnd; // 変化する部分のみ結合
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
                        MessageBox.Show(
                            $"{GetWord("68")}\n{GetWord("69")} '{newPath.Length}' {GetWord("70")}\n{GetWord("71")}" +
                            $"\n\"{GetWord("72")}\" {GetWord("73")} '{newPath.Length - newdiffname.Length}' {GetWord("74")}", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LabelReport.Text = "";
                        return;
                    }
                    else
                    {
                        MessageBox.Show($"{GetWord("68")}\n{GetWord("75")}", "",
                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LabelReport.Text = "";
                        return;
                    }
                }

                // Console.WriteLine($"１週終わった時の経過時間: {stopwatch.ElapsedMilliseconds} ミリ秒");
            }

            LabelReport.Text = $"{GetWord("42")}";

            stopwatch.Stop();
            Console.WriteLine($"終了時の経過時間: {stopwatch.ElapsedMilliseconds} ミリ秒");
        }


        


        private void Form1_Load(object sender, EventArgs e) // ロード時の処理
        {
            // 保存された設定
            string set = ConfigurationManager.AppSettings["Settings"];

            if (set != "")
            {
                // 言語設定の適応
                string selectlang = ConfigurationManager.AppSettings["Language"];
                SetLanguage(selectlang);

                // 保存された設定の適応
                string[] setting = JsonConvert.DeserializeObject<string[]>(set);

                RadioButtonR.Checked = setting[0] == "true"; // でたらめか
                RadioButtonLR.Checked = !RadioButtonR.Checked;
                TextBoxRule.Text = setting[1]; // 制限付きでたらめのルール
                NumericUpDowncount.Text = setting[2]; // 個数
                NumericUpDownOD.Text = setting[3]; // ODの値
                NumericUpDownHP.Text = setting[4]; // HPの値
                CheckBoxOD.Checked = setting[5] == "true"; // ODを変更
                CheckBoxHP.Checked = setting[6] == "true"; // HPを変更
                CheckBoxSV.Checked = setting[7] == "true"; // noSVに変更
                CheckBoxNoChange.Checked = setting[8] == "true"; // ノーツを変えない
                CheckBoxOriginalDiff.Checked = setting[9] == "true"; // 難易度名を残さない
                CheckBoxOverwrite.Checked = setting[10] == "true"; // 上書きする
                RadioButtonHistoryOn.Checked = setting[11] == "true"; // 履歴を残すか
                RadioButtonHistoryOff.Checked = !RadioButtonHistoryOn.Checked;
                RadioButtonPicOn.Checked = setting[12] == "true"; // 画像を読み込むか
                RadioButtonPicOff.Checked = !RadioButtonPicOn.Checked;
            }
            else
            {
                // 最初の言語選択フォーム
                using (CustomDialog firstlanguage = new CustomDialog())
                {
                    if (firstlanguage.ShowDialog() == DialogResult.OK)
                    {
                        // 選択された言語の適応
                        string selectedValue = firstlanguage.FirstSelectLanguage;
                        SetLanguage(selectedValue);

                        // 選んだ言語をconjigに保存
                        ConfigSave("Language", selectedValue);
                    }
                    else
                    {
                        // キャンセルされた場合
                        System.Windows.Forms.Application.Exit();

                        // 設定が保存されないようにして、次開いた時も言語選択フォームを開くようにする
                        ConfigSave("Settings", "");
                    }
                }

                MessageBox.Show($"{GetWord("98")}", $"{GetWord("99")}",
                      MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            if(RadioButtonPicOn.Checked)
            {
                System.Drawing.Image noimage = System.Drawing.Image.FromFile(@"Images\no image.png");
                PictureBox.Image = noimage;
            }

            // historyファイルのデータを読み取る
            string HistoryPath = $@"History.txt"; // 読み取るファイルの相対パス
            string history = File.ReadAllText(HistoryPath, Encoding.UTF8);

            _History = history;

            // 履歴があるか
            string log = _History;

            // ある場合は、コンボボックスに表示
            if (log != "[]")
            {
                DataTable dataTable = MakeDataTable(log);

                DataTableSet(dataTable);
            }
        }


        private void ComboBoxFromHistory_SelectionChangeCommitted(object sender, EventArgs e) // 履歴から選ばれたとき
        {
            if (ComboBoxFromHistory.SelectedItem is DataRowView selectedRow) // DataRowView型であることを確認
            {
                string name = selectedRow["name"].ToString();
                string filePath = selectedRow["path"].ToString();


                TextBoxSelectedMap.Text = name;

                // フィールドにもセット
                _filePath = filePath;

                string beforfilePath = filePath.Substring(0, filePath.LastIndexOf('\\'));
                _beforfilePath = beforfilePath;

                if (RadioButtonPicOn.Checked)
                {
                    Process[] processes = Process.GetProcessesByName("osu!");

                    if (processes.Length != 0)
                    {                     
                        string osuPath = Path.GetDirectoryName(processes[0].MainModule.FileName);
                        SetSongsPath(osuPath);
                        processes[0].Dispose();
                    }

                    if (_SongsPath != null && Directory.Exists(_SongsPath))
                    {
                        SetImage();
                    }
                    else
                    {
                        PictureBox.Image = null;
                    }
                }

                LabelReport.Text = "";
            }
        }


        private void ButtonAllSelect_Click(object sender, EventArgs e) // 履歴のすべて選択ボタン
        {
            // チェックボックス列の列名
            string checkColumnName = "chkDelete";

            // 全ての行のチェックボックスにチェックを入れる
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                row.Cells[checkColumnName].Value = true;
            }
        }


        private void ButtonAllCancel_Click(object sender, EventArgs e) // 履歴のすべて解除ボタン
        {
            // チェックボックス列の列名
            string checkColumnName = "chkDelete";

            // 全ての行のチェックボックスのチェックを外す
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                row.Cells[checkColumnName].Value = false;
            }
        }


        private void ButtonDelete_Click(object sender, EventArgs e) // 履歴の選択中の項目を削除ボタン
        {
            // チェックボックス列の列名
            string checkColumnName = "chkDelete";

            DataTable dt = (DataTable)DataGridView.DataSource;

            // チェックされている行があるかどうかフラグ
            bool checkedRowExists = false;

            // DataGridViewの行を逆順にループ (削除によるインデックスのずれを防ぐため)
            for (int i = DataGridView.Rows.Count - 1; i >= 0; i--)
            {
                // チェックボックスがチェックされているか確認
                if (Convert.ToBoolean(DataGridView.Rows[i].Cells[checkColumnName].Value) == true)
                {
                    checkedRowExists = true;
                    dt.Rows.RemoveAt(i);
                }
            }

            // チェックされている行が1つ以上あった場合のみ処理を行う
            if (checkedRowExists)
            {
                // DataGridViewを更新
                DataGridView.DataSource = dt;

                string json = JsonConvert.SerializeObject(dt);

                _History = json;
            }
        }


        private void TabControl_Click(object sender, EventArgs e) // タブ移動時
        {
            // 履歴を取得
            string log = _History;

            // ある場合は、コンボボックスに表示
            if (log != "[]")
            {
                DataTable dataTable = MakeDataTable(log);

                DataTableSet(dataTable);
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e) // 履歴の表でクリックしたときに削除列にチェック
        {
            if (e.ColumnIndex >= 0 && DataGridView.Columns[e.ColumnIndex].Name != "chkDelete" && e.RowIndex >= 0)
            {
                // チェックボックス列以外のセルがクリックされた場合
                DataGridViewCheckBoxCell chkCell = DataGridView.Rows[e.RowIndex].Cells["chkDelete"] as DataGridViewCheckBoxCell;
                chkCell.Value = !Convert.ToBoolean(chkCell.Value);
            }
        }


        private void ComboBoxLanguage_SelectionChangeCommitted(object sender, EventArgs e) // 言語が選択されたとき
        {
            //選択された言語名を取得
            string selectlang = ComboBoxLanguage.Text;

            // 設定する言語のデータを読み取る
            string relativePath = $@"Language\{selectlang}.txt"; // 読み取るファイルの相対パス
            string lang = File.ReadAllText(relativePath, Encoding.UTF8);

            // 改行コードを正規化
            lang = lang.Replace("\r\n", "\n").Replace("\r", "\n"); // CRLF を LF に統一

            // 空行を削除して１次元配列にする
            List<string> lines = new List<string>(lang.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries));
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
            _Language = newlangarray;

            // フォーム上のテキストを書き換える
            LanguageChange();


            //表の列名は変えられないので、いったんデータを保存して元のデータごと表を削除、そのあと表を作り直す
            string backup = _History;

            if (DataGridView.DataSource != null)
            {
                DataGridView.DataSource = null;
            }
            if (DataGridView.Columns.Contains("chkDelete"))
            {
                // チェックボックス列を削除
                DataGridView.Columns.Remove("chkDelete");
            }

            // 保存したデータ
            _History = backup;

            // 履歴があるか
            string log = _History;

            // ある場合は、コンボボックスに表示
            if (log != "[]")
            {
                DataTable dataTable = MakeDataTable(log);

                DataTableSet(dataTable);

            }

            // 選んだ言語をconjigに保存
            ConfigSave("Language", selectlang);
        }


        private void CheckBoxNoChange_CheckedChanged(object sender, EventArgs e) // "ノーツを変えない"のときにでたらめ系を選択できなくする
        {
            RadioButtonR.Enabled = !CheckBoxNoChange.Checked;
            RadioButtonLR.Enabled = !CheckBoxNoChange.Checked;
        }


        private void RadioButtonPicOff_Click(object sender, EventArgs e) // 画像なしにしたとき画像を消す
        {
            if (PictureBox.Image != null)
            {
                PictureBox.Image.Dispose();
                PictureBox.Image = null;
            }
        }


        private void TabControl_DragEnter(object sender, DragEventArgs e) // ファイルがドラッグされたとき
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

        private void TabControl_DragDrop(object sender, DragEventArgs e) // .osuファイルがドロップされたとき
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string filePath = files[0];

                // テキストボックスにファイル名を表示
                string fileName = Path.GetFileName(filePath);
                TextBoxSelectedMap.Text = fileName;

                // フィールドにもセット
                 _filePath = filePath;

                string beforfilePath = filePath.Substring(0, filePath.LastIndexOf('\\'));
                _beforfilePath = beforfilePath;

                // 画像を表示
                if (RadioButtonPicOn.Checked)
                {
                    Process[] processes = Process.GetProcessesByName("osu!");

                    if (processes.Length != 0)
                    {
                        string osuPath = Path.GetDirectoryName(processes[0].MainModule.FileName);
                        SetSongsPath(osuPath);
                        processes[0].Dispose();
                    }

                    if (_SongsPath != null && Directory.Exists(_SongsPath))
                    {
                        SetImage();
                    }
                    else
                    {
                        PictureBox.Image = null;
                    }
                }

                // 履歴がオフになっている場合はコンボボックスやデータテーブルに関与しない
                if (RadioButtonHistoryOff.Checked)
                {
                    return;
                }

                // 履歴を取得
                string log = _History;

                // 履歴が無ければ新しくデータテーブルを作る
                if (log == "[]")
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.AddRange(new DataColumn[] { new DataColumn("path"), new DataColumn("name") });

                    dataTable.Rows.Add(new object[] { filePath, fileName });

                    string json = JsonConvert.SerializeObject(dataTable);

                    _History = json;

                    DataTableSet(dataTable);

                }
                else // 履歴がすでにある場合はデータテーブルに変換してコンボボックスに表示
                {
                    DataTable dataTable = MakeDataTable(log);

                    dataTable.Rows.Add(dataTable.NewRow()["path"] = filePath, dataTable.NewRow()["name"] = fileName);

                    string json = JsonConvert.SerializeObject(dataTable);

                    _History = json;

                    ComboBoxFromHistory.DataSource = dataTable;
                    ComboBoxFromHistory.DisplayMember = "name";
                    ComboBoxFromHistory.ValueMember = "path";
                }

                if (TabControl.SelectedTab == TabPage2) // 履歴でドロップしていたらコンボボックスと表を更新
                {
                    TabControl_Click(sender, e);
                }
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // フォームを閉じたとき
        {
            string[] setting = {
                RadioButtonR.Checked ? "true" : "false", // でたらめか
                TextBoxRule.Text, // 制限付きでたらめのルール
                NumericUpDowncount.Value.ToString(), // 個数
                NumericUpDownOD.Value.ToString(), // ODの値
                NumericUpDownHP.Value.ToString(), // HPの値
                CheckBoxOD.Checked ? "true" : "false", // ODを変更
                CheckBoxHP.Checked ? "true" : "false", // HPを変更
                CheckBoxSV.Checked ? "true" : "false", // noSVに変更
                CheckBoxNoChange.Checked ? "true" : "false", // ノーツを変えない
                CheckBoxOriginalDiff.Checked ? "true" : "false", // 難易度名を残さない
                CheckBoxOverwrite.Checked ? "true" : "false", // 上書きする
                RadioButtonHistoryOn.Checked ? "true" : "false", // 履歴を残すか
                RadioButtonPicOn.Checked ? "true" : "false", // 背景を読み込むか
            };

            string json = JsonConvert.SerializeObject(setting);
            ConfigSave("Settings", json);

            using (StreamWriter writer = File.CreateText(@"History.txt"))
            {
                // ファイルにテキストを書き込む
                if (_History == "")
                {
                    writer.Write("[]");
                }
                else
                {
                    writer.Write(_History);
                }
            }
        }





        private void SetImage()
        {
            // 古い画像があれば消す
            PictureBox.Image = null;

            // 必要なら画像を読み取る
            if (RadioButtonPicOn.Checked)
            {
                OsuParsers.Beatmaps.Beatmap beatmapData = BeatmapDecoder.Decode(_filePath);

                string bgPath = Path.Combine(_beforfilePath ?? "", beatmapData.EventsSection.BackgroundImage ?? "");

                try
                {
                    Bitmap bmp = new Bitmap(bgPath);
                    const int resizeWidth = 110; // リサイズ後の幅を110に設定
                    int resizeHeight = (int)(bmp.Height * ((double)resizeWidth / bmp.Width));

                    Bitmap resizeBmp = new Bitmap(resizeWidth, resizeHeight);
                    Graphics graphics = Graphics.FromImage(resizeBmp);
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    graphics.DrawImage(bmp, 0, 0, resizeWidth, resizeHeight); // 描画位置調整
                    graphics.Dispose();

                    const double darknessFactor = 0.75;
                    for (int y = 0; y < resizeHeight; y++)
                    {
                        for (int x = 0; x < resizeWidth; x++)
                        {
                            Color pixel = resizeBmp.GetPixel(x, y);
                            int r = (int)(pixel.R * darknessFactor);
                            int g = (int)(pixel.G * darknessFactor);
                            int b = (int)(pixel.B * darknessFactor);
                            Color darkPixel = Color.FromArgb(r, g, b);
                            resizeBmp.SetPixel(x, y, darkPixel);
                        }
                    }
                    PictureBox.Image = resizeBmp;
                }
                catch
                {
                    System.Drawing.Image noimage = System.Drawing.Image.FromFile(@"Images\no image.png");
                    PictureBox.Image = noimage;
                }
            }
        }


        private void SetSongsPath(string osuPath)
        {
            // Songsフォルダーのパスを取得
            if (_SongsPath == null || !Directory.Exists(_SongsPath))
            {
                string userName = Environment.UserName;
                string file = Path.Combine(osuPath, $"osu!.{userName}.cfg");

                foreach (string readLine in File.ReadLines(file))
                {
                    if (!readLine.StartsWith("BeatmapDirectory")) continue;
                    string path = readLine.Split('=')[1].Trim(' ');
                    _SongsPath = path == "Songs" ? Path.Combine(osuPath, "Songs") : path;
                }

                if (_SongsPath == null)
                {
                    _SongsPath = Path.Combine(osuPath, "Songs");
                }
            }
        }


        private int LanguageErrorCount = 0;
        private string GetWord(string num) // 言語設定から文字列を取得
        {
            int rows = _Language.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                if (_Language[i, 0] == num)
                {
                    return _Language[i, 1];
                }
            }

            if (LanguageErrorCount == 0) // 破損があれば一回だけ表示
            {
                MessageBox.Show($"{GetWord("77")}", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                foreach (JObject jsonObject in jsonArray.Cast<JObject>())
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
            ComboBoxFromHistory.DataSource = dt;
            ComboBoxFromHistory.DisplayMember = "name";
            ComboBoxFromHistory.ValueMember = "path";

            // 履歴の表がない場合は作る
            if (DataGridView.Columns["path"]?.Width != 75) // 表がないか
            {
                // チェックボックス列が残っていたら削除
                if (DataGridView.Columns.Contains("chkDelete"))
                {
                    DataGridView.Columns.Remove("chkDelete");
                }

                DataGridView.DataSource = dt;
                DataGridView.Columns["name"].Width = 470;
                DataGridView.Columns["name"].HeaderText = GetWord("20");
                DataGridView.Columns["path"].Width = 65;
                DataGridView.Columns["path"].HeaderText = GetWord("21");

                DataGridView.Columns["path"].DisplayIndex = 1; // 列順入れ替え
                DataGridView.Columns["name"].DisplayIndex = 0;

                DataGridView.Columns.Insert(0, new DataGridViewCheckBoxColumn
                {
                    HeaderText = GetWord("19"),
                    Name = "chkDelete",
                    Width = 40
                });

                DataGridView.Columns[1].ReadOnly = true;
                DataGridView.Columns[2].ReadOnly = true;
                DataGridView.AllowUserToAddRows = false;
                DataGridView.RowHeadersVisible = false;
            }
        }


        private void SetLanguage(string selectLangage)
        {
            // 設定する言語のデータを読み取る
            string relativePath = $@"Language\{selectLangage}.txt"; // 読み取るファイルの相対パス
            string lang = File.ReadAllText(relativePath, Encoding.UTF8);

            // 改行コードを正規化
            lang = lang.Replace("\r\n", "\n").Replace("\r", "\n"); // CRLF を LF に統一

            // 空行を削除して１次元配列にする
            List<string> lines = new List<string>(lang.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries));
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
            _Language = newlangarray;

            // フォーム上のテキストを書き換える
            LanguageChange();

            // Languageフォルダーにあるファイルから取得した言語名をコンボボックスに表示
            string langpath = @"Language";

            // LINQを使ってファイル名を取得
            var fileNames = Directory.GetFiles(langpath)
                       .Select<string, string>(f => Regex.Match(f, @"Language\\(.*)\.txt").Groups[1].Value)
                       .ToArray();

            // DataTableを作成してComboBoxに設定
            ComboBoxLanguage.DataSource = fileNames.Select(langname => new { langname }).ToList();
            ComboBoxLanguage.DisplayMember = "langname";

            // 選択言語を設定
            int index = Array.IndexOf(fileNames, selectLangage); // fileNamesは string[]
            if (index != -1)
            {
                ComboBoxLanguage.SelectedIndex = index;
            }
        }


        private void LanguageChange()
        {
            // コントロールと対応するキーのペアをDictionaryで管理
            Dictionary<Control, string> controlKeys = new Dictionary<Control, string>()
            {
                { TabPage1, "1" },
                { TabPage2, "2" },
                { TabPage3, "3" },
                { LabelSelectMap, "4" },
                { LabelSelectHistory, "5" },
                { ButtonRead, "6" },
                { ButtonMake, "7" },
                { LabelCount, "8" },
                { RadioButtonR, "9" },
                { RadioButtonLR, "10" },
                { LabelDiffNumber, "11" },
                { CheckBoxOriginalDiff, "12" },
                { CheckBoxOverwrite, "13" },
                { CheckBoxNoChange, "14" },
                { ButtonAllSelect, "15" },
                { ButtonAllCancel, "16" },
                { ButtonDelete, "17" },
                { LabelDelinfo, "18" },
                { LabelLanguage, "22" },
                { LabelHistory, "23" },
                { RadioButtonHistoryOn, "24" },
                { RadioButtonHistoryOff, "25" },
                { LabelBG, "26" },
                { RadioButtonPicOn, "27" },
                { RadioButtonPicOff, "28" }
            };

            // Dictionaryを使ってループ処理
            foreach (var pair in controlKeys)
            {
                pair.Key.Text = GetWord(pair.Value);
            }
        }
    }
}