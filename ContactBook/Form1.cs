using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ContactBook
{
    public partial class Form1 : Form
    {
        private String dataSource = "ContactBookDB.sqlite";
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection.CreateFile(dataSource);
            button1.Text = "DatabaseCreated!";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SQLiteConnection dbConn = new SQLiteConnection("Data Source=" + dataSource);
            dbConn.Open();
            SQLiteCommand dbCmd = dbConn.CreateCommand();
            dbCmd.CommandText = "CREATE TABLE TelephoneBook(personID varchar(20),telephone varchar(30),type varchar(20))";
            dbCmd.ExecuteNonQuery();
            dbCmd.CommandText = "INSERT INTO TelephoneBook VALUES('MTB','1234567890','not mobile')";
            dbCmd.ExecuteNonQuery();
            dbCmd.CommandText = "SELECT * FROM TelephoneBook";
            SQLiteDataReader dataReader = dbCmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            if (dataReader.HasRows)
            {
                dataTable.Load(dataReader);
            }

            dataGridView1.DataSource = dataTable;
            dataReader.Close();
            dbConn.Close();
            button2.Text = "TableCreated!";
        }

    }
}
