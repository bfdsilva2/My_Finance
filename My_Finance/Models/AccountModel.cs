using My_Finance.Util;
using Mysqlx.Crud;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Cryptography.Xml;

namespace My_Finance.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Saldo { get; set; }
        public int User_Id { get; set; }

        private IHttpContextAccessor httpContextAccessor;

        public IHttpContextAccessor GetHttpContextAccessor()
        {
            return httpContextAccessor;
        }

        public void SetHttpContextAccessor(IHttpContextAccessor value)
        {
            httpContextAccessor = value;
            IdLoggedUser = GetHttpContextAccessor().HttpContext.Session.GetString("LoggedUserId");
        }

        string IdLoggedUser; 

        public AccountModel() { }

        //Context to get the session variables
        public AccountModel(IHttpContextAccessor httpContextAccessor)
        {
            SetHttpContextAccessor(httpContextAccessor);            
        }
        public List<AccountModel> ListAccountModels()
        {
            List<AccountModel> list = new List<AccountModel>();
            AccountModel item;
            //string id_logged_user = HttpContextAccessor.HttpContext.Session.GetString("LoggedUserId");
            string sql = $"SELECT id, name, saldo, user_id FROM account WHERE user_id = {IdLoggedUser}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            foreach (DataRow dr in dt.Rows) 
            {
                item = new AccountModel();
                item.Id = int.Parse(dr["id"].ToString());
                item.Name = dr["name"].ToString();
                item.Saldo = double.Parse(dr["saldo"].ToString());
                item.User_Id = int.Parse(dr["user_id"].ToString());
                list.Add(item);
            }
            return list;
        }

        public void Insert()
        {
            string sql = $"INSERT INTO account (name, saldo, user_id) VALUES ('{Name}','{Saldo}','{IdLoggedUser}')";
            DAL objDAL = new DAL();
            objDAL.ExecuteSQLCommand(sql);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM account WHERE id = '{id}'";
            DAL objDAL = new DAL();
            objDAL.ExecuteSQLCommand(sql);
        }

    }

}
