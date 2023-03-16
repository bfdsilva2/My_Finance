using My_Finance.Util;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Linq;

namespace My_Finance.Models
{
    public class AccountPlanModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Description is required.")]       
        public string Description { get; set; }

        //[Required(ErrorMessage = "Type is required.")]
        public string Type { get; set; }
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

        public AccountPlanModel() { }

        public AccountPlanModel(IHttpContextAccessor httpContextAccessor)
        {
            SetHttpContextAccessor(httpContextAccessor);
        }
        public List<AccountPlanModel> ListAccountPlans()
        {
            List<AccountPlanModel> list = new List<AccountPlanModel>();
            AccountPlanModel item;
            //string id_logged_user = HttpContextAccessor.HttpContext.Session.GetString("LoggedUserId");
            string sql = $"SELECT id, description, type, user_id FROM account_plan WHERE user_id = {IdLoggedUser}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            foreach (DataRow dr in dt.Rows)
            {
                item = new AccountPlanModel();
                item.Id = int.Parse(dr["id"].ToString());
                item.Description = dr["description"].ToString();
                item.Type = dr["type"].ToString();
                item.User_Id = int.Parse(dr["user_id"].ToString());
                list.Add(item);
            }
            return list;
        }

        public AccountPlanModel LoadAccountPlan(int id)
        {
            AccountPlanModel item = new AccountPlanModel();

            string sql = $"SELECT id, description, type, user_id FROM account_plan WHERE id = {id}";            
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            foreach (DataRow dr in dt.Rows)
            {
                item.Id = int.Parse(dr["id"].ToString());
                item.Description = dr["description"].ToString();
                item.Type = dr["type"].ToString();
                item.User_Id = int.Parse(dr["user_id"].ToString());
            }

            return item;
        }

        public void Insert()
        {
            string sql = $"INSERT INTO account_plan (description, type, user_id) VALUES ('{Description}','{Type}','{IdLoggedUser}')";
            DAL objDAL = new DAL();
            objDAL.ExecuteSQLCommand(sql);
        }

        public void Update()
        {
            string sql = $"UPDATE account_plan SET description = '{Description}', type = '{Type}' WHERE id={Id}";
            DAL objDAL = new DAL();
            objDAL.ExecuteSQLCommand(sql);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM account_plan WHERE id = '{id}'";
            DAL objDAL = new DAL();
            objDAL.ExecuteSQLCommand(sql);
        }


    }
}
