using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace INVENTORY
{
    public partial class InsertForm : Form
    {
        private static SqlConnection SomeConnection = MainForm.SomeConnection;

        public InsertForm()
        {
            InitializeComponent();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // события при загрузке формы (заполнение полей комбобоксов и прочего по данным из базы)
        private void InsertForm_Load(object sender, EventArgs e)
        {
            if (this.groupBox1.Text == "Новая запись для таблицы: 'Помещения'")
            {
                try
                { 
                    SqlCommand query = new SqlCommand("SELECT [ID_INV_FLOORS], [NUMBER_INV_FLOORS] FROM [INV_FLOORS]", SomeConnection);
                    DataTable tbl = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(query);
                    da.Fill(tbl);
                    this.comboBox1.DataSource = tbl;
                    this.comboBox1.DisplayMember = "NUMBER_INV_FLOORS";     // столбец для отображения c номером этажа
                    this.comboBox1.ValueMember = "ID_INV_FLOORS";           //столбец с id
                    this.comboBox1.SelectedIndex = -1;

                    query = new SqlCommand("SELECT [ID_INV_ROOM_TYPES], [SHORT_NAME_INV_ROOM_TYPES] FROM [INV_ROOM_TYPES]", SomeConnection);
                    tbl = new DataTable();
                    da = new SqlDataAdapter(query);
                    da.Fill(tbl);
                    this.comboBox2.DataSource = tbl;
                    this.comboBox2.DisplayMember = "SHORT_NAME_INV_ROOM_TYPES";     // столбец для отображения c кр.наим. типа
                    this.comboBox2.ValueMember = "ID_INV_ROOM_TYPES";               //столбец с id
                    this.comboBox2.SelectedIndex = -1;
                }
                catch
                {
                    MessageBox.Show
                    (
                        "Ошибка выполнения!" + "\n" + "(невозможно получить данные из базы!)",
                        "[ОШИБКА]",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    SomeConnection.Close();
                }
            }
        }

        // событие кнопки отпраки данных (с логикой пнимания в какую таблицу)
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (
                (textBox1.Visible == true && textBox1.Text == "") ||
                (textBox2.Text == "") ||
                (comboBox1.Visible == true && comboBox1.SelectedIndex == -1) ||
                (comboBox2.Visible == true && comboBox2.SelectedIndex == -1)
               )
            {
                MessageBox.Show
                (
                "Не заполненны обязательные поля" + "\n" + "(помеченные знаком '*')",
                "[ВНИМАНИЕ]",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
                );
            }
            else
            {
                InputBoxForm InputBoxForm = new InputBoxForm();
                InputBoxForm.inputBoxFormText = "ДОБАВИТЬ";
                var result = InputBoxForm.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else
                try
                {
                    switch (this.groupBox1.Text)
                    {
                        case "Новая запись для таблицы: 'Этажи'":
                            {
                                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                                DataAdapter.InsertCommand = new SqlCommand("INSERT INTO [INV_FLOORS] " +
                                                                            "([NUMBER_INV_FLOORS],[SHORT_NAME_INV_FLOORS],[FULL_NAME_INV_FLOORS]," +
                                                                                "[DESCRIPTION_NAME_INV_FLOORS],[HELP_NAME_INV_FLOORS],[NOTE_INV_FLOORS],[LOG_INV_FLOORS]) " +
                                                                            "VALUES(@DATA1,@DATA2,@DATA3,@DATA4,@DATA5,@DATA6,@DATA7)", SomeConnection);
                                DataAdapter.InsertCommand.Parameters.Add("@DATA1", SqlDbType.VarChar).Value = textBox1.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA2", SqlDbType.VarChar).Value = textBox2.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA3", SqlDbType.VarChar).Value = textBox3.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA4", SqlDbType.VarChar).Value = textBox4.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA5", SqlDbType.VarChar).Value = textBox5.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA6", SqlDbType.VarChar).Value = textBox6.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA7", SqlDbType.VarChar).Value = LoginForm.user + "_" + "I" + "_" + DateTime.Now;

                                SomeConnection.Open();
                                DataAdapter.InsertCommand.ExecuteNonQuery();
                                SomeConnection.Close();

                                MessageBox.Show
                                (
                                    "Данные успешно занесены в таблицу!",
                                    "[СООБЩЕНИЕ]",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                                this.Close();
                                return;
                            }
                        case "Новая запись для таблицы: 'Типы помещений'":
                            {
                                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                                DataAdapter.InsertCommand = new SqlCommand("INSERT INTO [INV_ROOM_TYPES] " +
                                                                            "([SHORT_NAME_INV_ROOM_TYPES],[FULL_NAME_INV_ROOM_TYPES],[DESCRIPTION_NAME_INV_ROOM_TYPES]," +
                                                                                "[HELP_NAME_INV_ROOM_TYPES],[NOTE_INV_ROOM_TYPES],[LOG_INV_ROOM_TYPES]) " +
                                                                            "VALUES(@DATA1,@DATA2,@DATA3,@DATA4,@DATA5,@DATA6)", SomeConnection);
                                DataAdapter.InsertCommand.Parameters.Add("@DATA1", SqlDbType.VarChar).Value = textBox2.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA2", SqlDbType.VarChar).Value = textBox3.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA3", SqlDbType.VarChar).Value = textBox4.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA4", SqlDbType.VarChar).Value = textBox5.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA5", SqlDbType.VarChar).Value = textBox6.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA6", SqlDbType.VarChar).Value = LoginForm.user + "_" + "I" + "_" + DateTime.Now;

                                SomeConnection.Open();
                                DataAdapter.InsertCommand.ExecuteNonQuery();
                                SomeConnection.Close();

                                MessageBox.Show
                                (
                                    "Данные успешно занесены в таблицу!",
                                    "[СООБЩЕНИЕ]",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                                this.Close();
                                return;
                            }
                        case "Новая запись для таблицы: 'Помещения'":
                            {
                                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                                DataAdapter.InsertCommand = new SqlCommand("INSERT INTO [INV_ROOMS] " +
                                                                            "([NUMBER_INV_ROOMS],[SHORT_NAME_INV_ROOMS],[FULL_NAME_INV_ROOMS]," +
                                                                                "[DESCRIPTION_NAME_INV_ROOMS],[HELP_NAME_INV_ROOMS],[NOTE_INV_ROOMS]," +
                                                                                "[FLOOR_INV_ROOMS_ID],[TYPE_INV_ROOMS_ID],[LOG_INV_ROOMS]) " +
                                                                            "VALUES(@DATA1,@DATA2,@DATA3,@DATA4,@DATA5,@DATA6,@DATA7,@DATA8,@DATA9)", SomeConnection);
                                DataAdapter.InsertCommand.Parameters.Add("@DATA1", SqlDbType.VarChar).Value = textBox1.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA2", SqlDbType.VarChar).Value = textBox2.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA3", SqlDbType.VarChar).Value = textBox3.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA4", SqlDbType.VarChar).Value = textBox4.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA5", SqlDbType.VarChar).Value = textBox5.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA6", SqlDbType.VarChar).Value = textBox6.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA7", SqlDbType.Int).Value = comboBox1.SelectedValue;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA8", SqlDbType.Int).Value = comboBox2.SelectedValue;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA9", SqlDbType.VarChar).Value = LoginForm.user + "_" + "I" + "_" + DateTime.Now;

                                SomeConnection.Open();
                                DataAdapter.InsertCommand.ExecuteNonQuery();
                                SomeConnection.Close();

                                MessageBox.Show
                                (
                                    "Данные успешно занесены в таблицу!",
                                    "[СООБЩЕНИЕ]",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                                this.Close();
                                return;
                            }
                        default:
                            return;
                    }
                }
                catch
                {
                    MessageBox.Show
                    (
                        "Ошибка выполнения!" + "\n" + "(данные не занесены!)",
                        "[ОШИБКА]",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    SomeConnection.Close();
                }
            }
        }

        // событе для полей с многострочным вводом (запрет на перенос строки)
        private void textBoxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
