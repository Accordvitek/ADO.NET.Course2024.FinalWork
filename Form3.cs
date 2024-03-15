using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO.NET.Course2024.FinalWork
{
    public partial class Form3 : Form
    {
        DataBase dataBase = new DataBase();

        private DataSet NorthwindDataset = new DataSet("Northwind");
        private DataTable ProductsTable = new DataTable("Products");
        SqlDataAdapter SqlDataAdapter1 = new SqlDataAdapter();

        public Form3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

       

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            NorthwindDataset.EndInit();
            SqlDataAdapter1.Update(NorthwindDataset.Tables["Products"]);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlDataAdapter1 = new SqlDataAdapter("SELECT * FROM Products WHERE CategoryID = 1", dataBase.getConnection());
            NorthwindDataset.Tables.Add(ProductsTable);
            SqlDataAdapter1.Fill(NorthwindDataset.Tables["Products"]);
            dataGridView1.DataSource = NorthwindDataset.Tables["Products"];

            SqlCommandBuilder commands = new SqlCommandBuilder(SqlDataAdapter1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NorthwindDataset.EndInit();
            SqlDataAdapter1.Update(NorthwindDataset.Tables["Products"]);
        }
    }
}
