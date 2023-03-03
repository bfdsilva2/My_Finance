using My_Finance.Util;
using System.Data;

namespace My_Finance.Models
{
  public class HomeModel
  {
    public string ReadUserName()
    {
      DAL objDAL = new DAL();
      DataTable dt = objDAL.RetDataTable("select * from user");
      if(dt.Rows.Count > 0)
      {
        return dt.Rows[0]["name"].ToString();
      }

      return "Nome não encontrado";
    }
  }
}
