using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace INVENTORY
{
    public partial class LoginForm : Form
    {
        private static SqlConnection SomeConnection = MainForm.SomeConnection;
        public static string user = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            // поиск совпадений пароля и логина для получения логина пользователя который вошел
            try
            {
                string login = textBox1.Text;
                string password = textBox2.Text;
                SomeConnection.Open();
                string sqlExpression = "SELECT [LOGIN_INV_USERS] FROM [INV_USERS] " +
                                        "WHERE ([LOGIN_INV_USERS] = @login AND [PASSWORD_INV_USERS] = @password)";

                SqlCommand SomeCommand = new SqlCommand(sqlExpression, SomeConnection);

                // создаем параметр для логина и добавляем параметр к команде
                SqlParameter loginParam = new SqlParameter("@login", login);
                SomeCommand.Parameters.Add(loginParam);

                // создаем параметр для пароля и добавляем параметр к команде
                SqlParameter passwordParam = new SqlParameter("@password", password);
                SomeCommand.Parameters.Add(passwordParam);

                SqlDataReader reader = SomeCommand.ExecuteReader();
                List<string[]> info = new List<string[]>();

                while (reader.Read())
                {
                    user = reader[0].ToString();
                }
                SomeConnection.Close();

                if (user == "")
                {
                    MessageBox.Show
                    (
                        "Пользователь не найден!" + "\n" + "(проверьте введенные данные')",
                        "[ВНИМАНИЕ]",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                else
                {
                    MainForm MainForm = new MainForm();
                    MainForm.Show();
                    this.Hide();
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
            };
        }
    }
}
