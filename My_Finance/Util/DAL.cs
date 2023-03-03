
using System.Data;
using MySql.Data.MySqlClient;
namespace My_Finance.Util
{
  public class DAL
  {
    private static string server = "localhost";
    private static string database = "financial";
    private static string user = "root";
    private static string password = "";
    private string connectionString = $"Server={server};Database={database};Uid={user};Pwd={password}";
    private MySqlConnection connection;

    public DAL()
    {
      this.connection = new MySqlConnection(connectionString);
      this.connection.Open();
    }

    //Execute SQL Statement
    public DataTable RetDataTable(string sql)
    {
      DataTable dataTable = new DataTable();
      MySqlCommand command = new MySqlCommand(sql, connection);
      MySqlDataAdapter da = new MySqlDataAdapter(command);
      da.Fill(dataTable);

      return dataTable;
    }

    //Execute CRUDs
    public void ExecuteSQLCommand(string sql)
    {
      MySqlCommand command = new MySqlCommand(sql, connection);
      command.ExecuteNonQuery();
    }
  }
}
