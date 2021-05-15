using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace INVENTORY
{
    public partial class MainForm : Form
    {
        // строка подключение к базе
        public static SqlConnection SomeConnection { get; set; } =
            new SqlConnection("Data Source=HOME-PC\\SQLEXPRESS;Initial Catalog=INVENTORY;Integrated Security=True");

        public MainForm()
        {
            InitializeComponent();
            this.dataGridView1.DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;

            groupBox1.Text = "";
            InsertDataBtn.Enabled = false;
            UpdateDataBtn.Enabled = false;
            ClearTableBtn.Enabled = false;

            // всплывающие подсказки при наведении на кнопки
            ToolTip t = new ToolTip();
            t.SetToolTip(SelectFloorsBtn, "Вывод таблицы: 'Этажи'");
            t.SetToolTip(SelectRoomTypesBtn, "Вывод таблицы: 'Типы помещений'");
            t.SetToolTip(SelectRoomsBtn, "Вывод таблицы: 'Помещения'");
            t.SetToolTip(InsertDataBtn, "Открыть окно добавления новой записи в текущую (открытую) таблицу");
            t.SetToolTip(UpdateDataBtn, "Открыть окно изменения записи по выбору в текущей (открытой) таблице");
            t.SetToolTip(ClearTableBtn, "Очистка окна вывода таболицы");
            this.Text += "   [Вы вошли как: " + LoginForm.user + "]";
        }

        // событие кнопки вывода таблицы этажей
        private void SelectFloorsBtn_Click(object sender, EventArgs e)
        {
            QuerySelectFloors("SELECT * FROM [INV_FLOORS]");
            groupBox1.Text = "Таблица: 'Этажи'";
            InsertDataBtn.Enabled = true;
            UpdateDataBtn.Enabled = true;
            ClearTableBtn.Enabled = true;
        }

        // событие кнопки вывода таблицы типов помещений
        private void SelectRoomTypesBtn_Click(object sender, EventArgs e)
        {
            QuerySelectRoomTypes("SELECT * FROM [INV_ROOM_TYPES]");
            groupBox1.Text = "Таблица: 'Типы помещений'";
            InsertDataBtn.Enabled = true;
            UpdateDataBtn.Enabled = true;
            ClearTableBtn.Enabled = true;
        }

        // событие кнопки вывода таблицы помещений
        private void SelectRoomsBtn_Click(object sender, EventArgs e)
        {
            QuerySelectRooms("SELECT * FROM [INV_ROOMS]");
            groupBox1.Text = "Таблица: 'Помещения'";
            InsertDataBtn.Enabled = true;
            UpdateDataBtn.Enabled = true;
            ClearTableBtn.Enabled = true;
        }

        //  событие кнопки открытия формы для добавления новой записи
        private void InsertDataBtn_Click(object sender, EventArgs e)
        {
            InsertData(groupBox1.Text);
        }

        //  событие кнопки открытия формы редактирования записей
        private void UpdateDataBtn_Click(object sender, EventArgs e)
        {
            UpdateData(groupBox1.Text);
        }

        //  событие кнопки очистки окна вывода таблицы
        private void ClearTableBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            groupBox1.Text = "";
            InsertDataBtn.Enabled = false;
            UpdateDataBtn.Enabled = false;
            ClearTableBtn.Enabled = false;
        }

        // функция открытия окна добавления новой записи (заполнение полей нового окна, 
        //      получения данных в комбо боксы из базы и прочее)
        public void InsertData(string TabNameString)
        {
            switch (TabNameString)
            {
                case "Таблица: 'Этажи'":
                    {
                        InsertForm InsertFloorsForm = new InsertForm();
                        InsertFloorsForm.groupBox1.Text += "'Этажи'";

                        InsertFloorsForm.label1.Text = "Код этажа * :";
                        InsertFloorsForm.label2.Text = "Краткое наименование * :";
                        InsertFloorsForm.label3.Text = "Полное наименование:";
                        InsertFloorsForm.label4.Text = "Описание:";
                        InsertFloorsForm.label5.Text = "HELP:";
                        InsertFloorsForm.label6.Text = "Примечание:";

                        InsertFloorsForm.label7.Visible = false;
                        InsertFloorsForm.comboBox1.Visible = false;
                        InsertFloorsForm.label8.Visible = false;
                        InsertFloorsForm.comboBox2.Visible = false;

                        InsertFloorsForm.ShowDialog();
                        QuerySelectFloors("SELECT * FROM [INV_FLOORS]");
                        return;
                    }
                case "Таблица: 'Типы помещений'":
                    {
                        InsertForm InsertFloorsForm = new InsertForm();
                        InsertFloorsForm.groupBox1.Text += "'Типы помещений'";

                        InsertFloorsForm.label1.Visible = false;
                        InsertFloorsForm.textBox1.Visible = false;

                        InsertFloorsForm.label2.Text = "Краткое наименование * :";
                        InsertFloorsForm.label3.Text = "Полное наименование:";
                        InsertFloorsForm.label4.Text = "Описание:";
                        InsertFloorsForm.label5.Text = "HELP:";
                        InsertFloorsForm.label6.Text = "Примечание:";

                        InsertFloorsForm.label7.Visible = false;
                        InsertFloorsForm.comboBox1.Visible = false;
                        InsertFloorsForm.label8.Visible = false;
                        InsertFloorsForm.comboBox2.Visible = false;

                        InsertFloorsForm.ShowDialog();
                        QuerySelectRoomTypes("SELECT * FROM [INV_ROOM_TYPES]");
                        return;
                    }
                case "Таблица: 'Помещения'":
                    {
                        InsertForm InsertFloorsForm = new InsertForm();
                        InsertFloorsForm.groupBox1.Text += "'Помещения'";

                        InsertFloorsForm.label1.Text = "Код помещения * :";
                        InsertFloorsForm.label2.Text = "Краткое наименование * :";
                        InsertFloorsForm.label3.Text = "Полное наименование:";
                        InsertFloorsForm.label4.Text = "Описание:";
                        InsertFloorsForm.label5.Text = "HELP:";
                        InsertFloorsForm.label6.Text = "Примечание:";
                        InsertFloorsForm.label7.Text = "Код этажа * :";
                        InsertFloorsForm.label8.Text = "Кр. наим. типа помещения * :";

                        InsertFloorsForm.ShowDialog();
                        QuerySelectRooms("SELECT * FROM [INV_ROOMS]");
                        return;
                    }
                default: 
                    return;
            }
        }

        // функция открытия окна изменения записей (заполнение полей нового окна,
        //      получения данных в комбо боксы из базы и прочее)
        public void UpdateData(string TabNameString)
        {
            switch (TabNameString)
            {
                case "Таблица: 'Этажи'":
                    {
                        UpdateForm UpdateForm = new UpdateForm();
                        UpdateForm.groupBox1.Text += "'Этажи'";
                        UpdateForm.label0.Text = "ID:";
                        UpdateForm.label1.Text = "Код этажа * :";
                        UpdateForm.label2.Text = "Краткое наименование * :";
                        UpdateForm.label3.Text = "Полное наименование:";
                        UpdateForm.label4.Text = "Описание:";
                        UpdateForm.label5.Text = "HELP:";
                        UpdateForm.label6.Text = "Примечание:";
                        UpdateForm.label7.Visible = false;
                        UpdateForm.comboBox1.Visible = false;
                        UpdateForm.label8.Visible = false;
                        UpdateForm.comboBox2.Visible = false;

                        UpdateForm.ShowDialog();
                        QuerySelectFloors("SELECT * FROM [INV_FLOORS]");
                        return;
                    }
                case "Таблица: 'Типы помещений'":
                    {
                        UpdateForm UpdateForm = new UpdateForm();
                        UpdateForm.groupBox1.Text += "'Типы помещений'";
                        UpdateForm.label0.Text = "ID:";
                        UpdateForm.label1.Visible = false;
                        UpdateForm.textBox1.Visible = false;
                        UpdateForm.label2.Text = "Краткое наименование * :";
                        UpdateForm.label3.Text = "Полное наименование:";
                        UpdateForm.label4.Text = "Описание:";
                        UpdateForm.label5.Text = "HELP:";
                        UpdateForm.label6.Text = "Примечание:";
                        UpdateForm.label7.Visible = false;
                        UpdateForm.comboBox1.Visible = false;
                        UpdateForm.label8.Visible = false;
                        UpdateForm.comboBox2.Visible = false;

                        UpdateForm.ShowDialog();
                        QuerySelectRoomTypes("SELECT * FROM [INV_ROOM_TYPES]");
                        return;
                    }
                case "Таблица: 'Помещения'":
                    {
                        UpdateForm UpdateForm = new UpdateForm();
                        UpdateForm.groupBox1.Text += "'Помещения'";
                        UpdateForm.label0.Text = "ID:";
                        UpdateForm.label1.Text = "Код помещения * :";
                        UpdateForm.label2.Text = "Краткое наименование * :";
                        UpdateForm.label3.Text = "Полное наименование:";
                        UpdateForm.label4.Text = "Описание:";
                        UpdateForm.label5.Text = "HELP:";
                        UpdateForm.label6.Text = "Примечание:";
                        UpdateForm.label7.Text = "Код этажа * :";
                        UpdateForm.label8.Text = "Кр. наим. типа помещения * :";

                        UpdateForm.ShowDialog();
                        QuerySelectRooms("SELECT * FROM [INV_ROOMS]");
                        return;
                    }
                default:
                    return;
            }
        }

        // функция получения данных таблицы этажей из базы
        public void QuerySelectFloors(string query)
        {
            try
            {
                dataGridView1.Columns.Clear();
                SomeConnection.Open();
                SqlCommand SomeCommand = new SqlCommand(query, SomeConnection);
                SqlDataReader reader = SomeCommand.ExecuteReader();
                List<string[]> info = new List<string[]>();

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ID" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Код этажа" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Краткое наименование" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Полное наименование" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Описание" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "HELP" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Примечание" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LOG" });

                while (reader.Read())
                {
                    info.Add(new string[8]);

                    info[info.Count - 1][0] = reader[0].ToString();
                    info[info.Count - 1][1] = reader[1].ToString();
                    info[info.Count - 1][2] = reader[2].ToString();
                    info[info.Count - 1][3] = reader[3].ToString();
                    info[info.Count - 1][4] = reader[4].ToString();
                    info[info.Count - 1][5] = reader[5].ToString();
                    info[info.Count - 1][6] = reader[6].ToString();
                    info[info.Count - 1][7] = reader[7].ToString();
                }
                SomeConnection.Close();
                foreach (string[] s in info)
                    dataGridView1.Rows.Add(s);
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
            }
        }

        // функция получения данных таблицы типов помещений из базы
        public void QuerySelectRoomTypes(string query)
        {
            try
            { 
                dataGridView1.Columns.Clear();
                SomeConnection.Open();
                SqlCommand SomeCommand = new SqlCommand(query, SomeConnection);
                SqlDataReader reader = SomeCommand.ExecuteReader();
                List<string[]> info = new List<string[]>();

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ID" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Краткое наименование" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Полное наименование" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Описание" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "HELP" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Примечание" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LOG" });

                while (reader.Read())
                {
                    info.Add(new string[7]);

                    info[info.Count - 1][0] = reader[0].ToString();
                    info[info.Count - 1][1] = reader[1].ToString();
                    info[info.Count - 1][2] = reader[2].ToString();
                    info[info.Count - 1][3] = reader[3].ToString();
                    info[info.Count - 1][4] = reader[4].ToString();
                    info[info.Count - 1][5] = reader[5].ToString();
                    info[info.Count - 1][6] = reader[6].ToString();
                }
                SomeConnection.Close();
                foreach (string[] s in info)
                    dataGridView1.Rows.Add(s);
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
            }
        }

        // функция получения данных таблицы помещений из базы
        public void QuerySelectRooms(string query)
        {
            try
            {
                dataGridView1.Columns.Clear();
                SomeConnection.Open();
                SqlCommand SomeCommand = new SqlCommand(query, SomeConnection);
                SqlDataReader reader = SomeCommand.ExecuteReader();
                List<string[]> info = new List<string[]>();

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ID" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Код помещения" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Краткое наименование" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Полное наименование" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Описание" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "HELP" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Примечание" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ID этажа" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ID типа помещения" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LOG" });

                while (reader.Read())
                {
                    info.Add(new string[10]);

                    info[info.Count - 1][0] = reader[0].ToString();
                    info[info.Count - 1][1] = reader[1].ToString();
                    info[info.Count - 1][2] = reader[2].ToString();
                    info[info.Count - 1][3] = reader[3].ToString();
                    info[info.Count - 1][4] = reader[4].ToString();
                    info[info.Count - 1][5] = reader[5].ToString();
                    info[info.Count - 1][6] = reader[6].ToString();
                    info[info.Count - 1][7] = reader[7].ToString();
                    info[info.Count - 1][8] = reader[8].ToString();
                    info[info.Count - 1][9] = reader[9].ToString();
                }
                SomeConnection.Close();
                foreach (string[] s in info)
                    dataGridView1.Rows.Add(s);
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
            }
        }

        // событие закрытие формы = закрытие программы
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
