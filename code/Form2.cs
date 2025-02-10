using System.Windows.Forms;

namespace taiko
{
    public partial class CustomDialog : Form
    {
        public CustomDialog()
        {
            InitializeComponent();
            comboBoxFirstLanguege.Items.Add("日本語");
            comboBoxFirstLanguege.Items.Add("English");
            comboBoxFirstLanguege.SelectedIndex = 0;

            // OK ボタン
            buttonSelect.DialogResult = DialogResult.OK;
        }

        public string FirstSelectLanguage
        {
            get { return comboBoxFirstLanguege.SelectedItem?.ToString(); }
        }
    }
}
