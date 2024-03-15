using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO.NET.Course2024.FinalWork
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            var loginUser = textBox1_login.Text;
            var passUser = textBox2_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            try
            {
                adapter.SelectCommand = command;
                adapter.Fill(table);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "БД Northwind не подключена");
            }

            if (table.Rows.Count == 1)
            {
                dataBase.openConnection();
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
                textBox1_login.Enabled = false;
                textBox2_password.Enabled = false;
            }
            else
            {
                MessageBox.Show("Войти в БД Northwind не удалось!", "БД Northwind", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pictureBox4.Visible = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1_login.TextAlign = HorizontalAlignment.Center;
            textBox1_login.CharacterCasing = CharacterCasing.Lower;
            textBox1_login.MaxLength = 5;

            textBox2_password.TextAlign = HorizontalAlignment.Center;
            textBox2_password.CharacterCasing = CharacterCasing.Lower;
            textBox2_password.MaxLength = 5;
            textBox2_password.UseSystemPasswordChar = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.closeConnection();
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            textBox1_login.Clear();
            textBox1_login.Enabled = true;
            textBox1_login.Focus();
            textBox2_password.Clear();
            textBox2_password.Enabled = true;   
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox2_password.UseSystemPasswordChar = true;
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2_password.UseSystemPasswordChar = false;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(pictureBox3.Visible == true)
            {
                Form2 frm2 = new Form2();
                this.Hide();
                frm2.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("БД Northwind не подключена! Выполните подключение!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Visible == true)
            {
                Form3 frm3 = new Form3();
                this.Hide();
                frm3.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("БД Northwind не подключена! Выполните подключение!");
            }
        }
    }
}
