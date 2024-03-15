using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO.NET.Course2024.FinalWork
{
    public partial class Form2 : Form
    {
        DataBase dataBase = new DataBase();
        
        private DataSet NorthwindDataset = new DataSet("Northwind");
        private DataTable CustomersTable = new DataTable("Customers");
        SqlDataAdapter SqlDataAdapter1 = new SqlDataAdapter();

        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlDataAdapter1 = new SqlDataAdapter("SELECT * FROM Customers", dataBase.getConnection());
            NorthwindDataset.Tables.Add(CustomersTable);

            SqlCommandBuilder commands = new SqlCommandBuilder(SqlDataAdapter1);

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            NorthwindDataset.EndInit();
            SqlDataAdapter1.Update(NorthwindDataset.Tables["Customers"]);

        }

        private void FillTableButton_Click(object sender, EventArgs e)
        {
            SqlDataAdapter1.Fill(NorthwindDataset.Tables["Customers"]);
            dataGridView1.DataSource = NorthwindDataset.Tables["Customers"];
        }

        private void DeleteRowButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {

                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    NorthwindDataset.Tables["Customers"].Rows[i.Index].Delete();
                }
            }
        }

       
    }
}
