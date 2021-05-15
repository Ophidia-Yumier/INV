using System;
using System.Windows.Forms;

namespace INVENTORY
{
    public partial class InputBoxForm : Form
    {
        public static string inputBoxFormText;
        public InputBoxForm()
        {
            InitializeComponent();
        }

        // события при загрузке формы (добавление к лэйблу "проверочного слова" 
        // для добавления или редактирования данных)
        private void InputBoxForm_Load(object sender, EventArgs e)
        {
            label1.Text += inputBoxFormText;
        }

        // событие кнопки подтверждения (проверка совпадения вводимого "проверочного слова" с необходимым)
        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == inputBoxFormText)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show
                (
                    "Неверный ввод!" + "\n" + "(проверьте правильность ввода слова подтверждения)",
                    "[ВНИМАНИЕ]",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // событие кнопки отмены действий
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
