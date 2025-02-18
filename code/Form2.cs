using System.Windows.Forms;

namespace taiko
{
    public partial class CustomDialog : Form
    {
        public CustomDialog()
        {
            InitializeComponent();

            // OK ボタン
            ButtonSelect.DialogResult = DialogResult.OK;
        }

        public string FirstSelectLanguage
        {
            get { return ComboBoxFirstLanguege.SelectedItem.ToString(); }
        }

        private void CustomDialog_Load(object sender, System.EventArgs e)
        {
            ComboBoxFirstLanguege.Items.Add("日本語");
            ComboBoxFirstLanguege.Items.Add("English");
            ComboBoxFirstLanguege.SelectedIndex = 0;
        }
    }
}
