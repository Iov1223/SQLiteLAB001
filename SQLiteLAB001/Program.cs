using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SQLite
{
    public delegate void SQLiteCommandDelegate();//SQLiteCommand command);
    public class SQL 
    { 
        public void _createDB(string ConnectParametr, string SQLCommand)
        {
            try
            {
                SQLiteConnection _sqlite = new SQLiteConnection(ConnectParametr);
                _sqlite.Open();
                SQLiteCommand cmd = _sqlite.CreateCommand();
                cmd.CommandText = (SQLCommand);
                SQLiteDataReader _sql = cmd.ExecuteReader();
                Console.WriteLine("Таблица создана.");
                _sqlite.Close();
            }
            catch
            {
                Console.WriteLine("Таблица уже создана.");
            }            
        }
        public void _addData(string ConnectParametr, string SQLCommand)
        {

        }
    }

    internal class Program
    {
        
        static void Main(string[] args)
        {

            string ConnectParametr = @"Data source = inventory.db; Version = 3;Mode=ReadWriteCreate;";
            string SQLCommand_create = "CREATE TABLE workplace " +
                "(id INTEGER PRIMARY KEY ASC AUTOINCREMENT, " +
                "name VARCHAR (1, 50), display  VARCHAR (1, 50), " +
                "keyboard VARCHAR (1, 50), mouse VARCHAR (1, 50));";
            SQL mySQL = new SQL();
            mySQL._createDB(ConnectParametr, SQLCommand_create);

        }
    }
}
