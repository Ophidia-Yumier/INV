using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace INVENTORY
{
    public partial class UpdateForm : Form
    {
        private static SqlConnection SomeConnection = MainForm.SomeConnection;

        public UpdateForm()
        {
            InitializeComponent();
            this.comboBox0.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // события при загрузке формы (заполнение полей комбобоксов и прочего по данным из базы)
        private void UpdateForm_Load(object sender, EventArgs e)
        {
            if (this.groupBox1.Text == "Редактирование записи таблицы: 'Помещения'")
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

            // получение всех данных по выбранному ID в комбобоксе
            try
            { 
                switch (this.groupBox1.Text)
                {
                    case "Редактирование записи таблицы: 'Этажи'":
                        {
                            SqlCommand query = new SqlCommand("SELECT [ID_INV_FLOORS] FROM [INV_FLOORS]", SomeConnection);
                            DataTable tbl = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(query);
                            da.Fill(tbl);
                            this.comboBox0.DataSource = tbl;
                            this.comboBox0.DisplayMember = "ID_INV_FLOORS";     // столбец для отображения c номером этажа
                            this.comboBox0.ValueMember = "ID_INV_FLOORS";           //столбец с id
                            this.comboBox0.SelectedIndex = -1;
                            return;
                        }
                    case "Редактирование записи таблицы: 'Типы помещений'":
                        {
                            SqlCommand query = new SqlCommand("SELECT [ID_INV_ROOM_TYPES] FROM [INV_ROOM_TYPES]", SomeConnection);
                            DataTable tbl = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(query);
                            da.Fill(tbl);
                            this.comboBox0.DataSource = tbl;
                            this.comboBox0.DisplayMember = "ID_INV_ROOM_TYPES";     // столбец для отображения c номером этажа
                            this.comboBox0.ValueMember = "ID_INV_ROOM_TYPES";           //столбец с id
                            this.comboBox0.SelectedIndex = -1;
                            return;
                        }
                    case "Редактирование записи таблицы: 'Помещения'":
                        {
                            SqlCommand query = new SqlCommand("SELECT [ID_INV_ROOMS] FROM [INV_ROOMS]", SomeConnection);
                            DataTable tbl = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(query);
                            da.Fill(tbl);
                            this.comboBox0.DataSource = tbl;
                            this.comboBox0.DisplayMember = "ID_INV_ROOMS";     // столбец для отображения c номером этажа
                            this.comboBox0.ValueMember = "ID_INV_ROOMS";           //столбец с id
                            this.comboBox0.SelectedIndex = -1;
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
                    "Ошибка выполнения!" + "\n" + "(невозможно получить данные из базы!)",
                    "[ОШИБКА]",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                SomeConnection.Close();
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
        // событе для комбобокса (отлавливает изменение выбранного 
        // элемента для переключения между данными под каждый ID из базы)
        private void comboBox0_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.textBox1.Enabled = true;
                this.textBox2.Enabled = true;
                this.textBox3.Enabled = true;
                this.textBox4.Enabled = true;
                this.textBox5.Enabled = true;
                this.textBox6.Enabled = true;
                this.comboBox1.Enabled = true;
                this.comboBox2.Enabled = true;
                SubmitBtn.Enabled = true;

                switch (this.groupBox1.Text)
                {
                    case "Редактирование записи таблицы: 'Этажи'":
                        {
                            SomeConnection.Open();
                            string sqlExpression = "SELECT * FROM [INV_FLOORS] WHERE [ID_INV_FLOORS] = @SelectedValue";

                            SqlCommand SomeCommand = new SqlCommand(sqlExpression, SomeConnection);
                            // создаем параметр и добавляем параметр к команде
                            SqlParameter SelectedValueParam = new SqlParameter("@SelectedValue", comboBox0.SelectedValue);
                            SomeCommand.Parameters.Add(SelectedValueParam);

                            SqlDataReader reader = SomeCommand.ExecuteReader();
                            List<string[]> info = new List<string[]>();

                            while (reader.Read())
                            {
                                textBox1.Text = reader[1].ToString();
                                textBox2.Text = reader[2].ToString();
                                textBox3.Text = reader[3].ToString();
                                textBox4.Text = reader[4].ToString();
                                textBox5.Text = reader[5].ToString();
                                textBox6.Text = reader[6].ToString();
                            }
                            SomeConnection.Close();
                            return;
                        }
                    case "Редактирование записи таблицы: 'Типы помещений'":
                        {
                            SomeConnection.Open();
                            string sqlExpression = "SELECT * FROM [INV_ROOM_TYPES] WHERE [ID_INV_ROOM_TYPES] = @SelectedValue";

                            SqlCommand SomeCommand = new SqlCommand(sqlExpression, SomeConnection);
                            // создаем параметр и добавляем параметр к команде
                            SqlParameter SelectedValueParam = new SqlParameter("@SelectedValue", comboBox0.SelectedValue);
                            SomeCommand.Parameters.Add(SelectedValueParam);

                            SqlDataReader reader = SomeCommand.ExecuteReader();
                            List<string[]> info = new List<string[]>();

                            while (reader.Read())
                            {
                                textBox2.Text = reader[1].ToString();
                                textBox3.Text = reader[2].ToString();
                                textBox4.Text = reader[3].ToString();
                                textBox5.Text = reader[4].ToString();
                                textBox6.Text = reader[5].ToString();
                            }
                            SomeConnection.Close();
                            return;
                        }
                    case "Редактирование записи таблицы: 'Помещения'":
                        {
                            SomeConnection.Open();
                            string sqlExpression = "SELECT * FROM [INV_ROOMS] WHERE [ID_INV_ROOMS] = @SelectedValue";

                            SqlCommand SomeCommand = new SqlCommand(sqlExpression, SomeConnection);
                            // создаем параметр и добавляем параметр к команде
                            SqlParameter SelectedValueParam = new SqlParameter("@SelectedValue", comboBox0.SelectedValue);
                            SomeCommand.Parameters.Add(SelectedValueParam);

                            SqlDataReader reader = SomeCommand.ExecuteReader();
                            List<string[]> info = new List<string[]>();

                            while (reader.Read())
                            {
                                textBox1.Text = reader[1].ToString();
                                textBox2.Text = reader[2].ToString();
                                textBox3.Text = reader[3].ToString();
                                textBox4.Text = reader[4].ToString();
                                textBox5.Text = reader[5].ToString();
                                textBox6.Text = reader[6].ToString();
                                comboBox1.SelectedValue = reader[7].ToString();
                                comboBox2.SelectedValue = reader[8].ToString();
                            }
                            SomeConnection.Close();
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
                    "Ошибка выполнения!" + "\n" + "(невозможно получить данные из базы!)",
                    "[ОШИБКА]",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                SomeConnection.Close();
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
                InputBoxForm.inputBoxFormText = "ИЗМЕНИТЬ";
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
                        case "Редактирование записи таблицы: 'Этажи'":
                            {
                                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                                DataAdapter.InsertCommand = new SqlCommand("UPDATE [INV_FLOORS] " +
                                    "SET [NUMBER_INV_FLOORS]=@DATA1,[SHORT_NAME_INV_FLOORS]=@DATA2,[FULL_NAME_INV_FLOORS]=@DATA3," +
                                        "[DESCRIPTION_NAME_INV_FLOORS]=@DATA4,[HELP_NAME_INV_FLOORS]=@DATA5,[NOTE_INV_FLOORS]=@DATA6,[LOG_INV_FLOORS]=@DATA7 " +
                                    "WHERE [ID_INV_FLOORS]=@DATA0", SomeConnection);
                                DataAdapter.InsertCommand.Parameters.Add("@DATA0", SqlDbType.Int).Value = comboBox0.SelectedValue;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA1", SqlDbType.VarChar).Value = textBox1.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA2", SqlDbType.VarChar).Value = textBox2.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA3", SqlDbType.VarChar).Value = textBox3.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA4", SqlDbType.VarChar).Value = textBox4.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA5", SqlDbType.VarChar).Value = textBox5.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA6", SqlDbType.VarChar).Value = textBox6.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA7", SqlDbType.VarChar).Value = LoginForm.user + "_" + "U" + "_" + DateTime.Now;


                                SomeConnection.Open();
                                DataAdapter.InsertCommand.ExecuteNonQuery();
                                SomeConnection.Close();

                                MessageBox.Show
                                (
                                    "Данные успешно изменены!",
                                    "[СООБЩЕНИЕ]",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                                this.Close();
                                return;
                            }
                        case "Редактирование записи таблицы: 'Типы помещений'":
                            {
                                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                                DataAdapter.InsertCommand = new SqlCommand("UPDATE [INV_ROOM_TYPES] " +
                                    "SET [SHORT_NAME_INV_ROOM_TYPES]=@DATA1,[FULL_NAME_INV_ROOM_TYPES]=@DATA2,[DESCRIPTION_NAME_INV_ROOM_TYPES]=@DATA3," +
                                        "[HELP_NAME_INV_ROOM_TYPES]=@DATA4,[NOTE_INV_ROOM_TYPES]=@DATA5,[LOG_INV_ROOM_TYPES]=@DATA6 " +
                                    "WHERE [ID_INV_ROOM_TYPES]=@DATA0", SomeConnection);
                                DataAdapter.InsertCommand.Parameters.Add("@DATA0", SqlDbType.Int).Value = comboBox0.SelectedValue;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA1", SqlDbType.VarChar).Value = textBox2.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA2", SqlDbType.VarChar).Value = textBox3.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA3", SqlDbType.VarChar).Value = textBox4.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA4", SqlDbType.VarChar).Value = textBox5.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA5", SqlDbType.VarChar).Value = textBox6.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA6", SqlDbType.VarChar).Value = LoginForm.user + "_" + "U" + "_" + DateTime.Now;

                                SomeConnection.Open();
                                DataAdapter.InsertCommand.ExecuteNonQuery();
                                SomeConnection.Close();

                                MessageBox.Show
                                (
                                    "Данные успешно изменены!",
                                    "[СООБЩЕНИЕ]",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                                this.Close();
                            return;
                            }
                        case "Редактирование записи таблицы: 'Помещения'":
                            {
                                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                                DataAdapter.InsertCommand = new SqlCommand("UPDATE [INV_ROOMS] " +
                                    "SET [NUMBER_INV_ROOMS]=@DATA1,[SHORT_NAME_INV_ROOMS]=@DATA2,[FULL_NAME_INV_ROOMS]=@DATA3," +
                                        "[DESCRIPTION_NAME_INV_ROOMS]=@DATA4,[HELP_NAME_INV_ROOMS]=@DATA5,[NOTE_INV_ROOMS]=@DATA6," +
                                        "[FLOOR_INV_ROOMS_ID]=@DATA7,[TYPE_INV_ROOMS_ID]=@DATA8,[LOG_INV_ROOMS]=@DATA9 " +
                                    "WHERE [ID_INV_ROOMS]=@DATA0", SomeConnection);
                                DataAdapter.InsertCommand.Parameters.Add("@DATA0", SqlDbType.Int).Value = comboBox0.SelectedValue;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA1", SqlDbType.VarChar).Value = textBox1.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA2", SqlDbType.VarChar).Value = textBox2.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA3", SqlDbType.VarChar).Value = textBox3.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA4", SqlDbType.VarChar).Value = textBox4.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA5", SqlDbType.VarChar).Value = textBox5.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA6", SqlDbType.VarChar).Value = textBox6.Text;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA7", SqlDbType.Int).Value = comboBox1.SelectedValue;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA8", SqlDbType.Int).Value = comboBox2.SelectedValue;
                                DataAdapter.InsertCommand.Parameters.Add("@DATA9", SqlDbType.VarChar).Value = LoginForm.user + "_" + "U" + "_" + DateTime.Now;

                                SomeConnection.Open();
                                DataAdapter.InsertCommand.ExecuteNonQuery();
                                SomeConnection.Close();

                                MessageBox.Show
                                (
                                    "Данные успешно изменены!",
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
                        "Ошибка выполнения!" + "\n" + "(данные не изменены!)",
                        "[ОШИБКА]",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    SomeConnection.Close();
                }
            }
        }
    }
}
