using My_Finance.Util;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace My_Finance.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-mail is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Birth date is required.")]
        public string BirthDate { get; set; }
        
        public bool ValidLogin()
        {
            string sql = $"SELECT id, name, born_date FROM user WHERE email = '{Email}' AND password = '{Password}'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);
            if (dt != null && dt.Rows.Count == 1)
            {
                Id = int.Parse(dt.Rows[0]["id"].ToString());
                Name = dt.Rows[0]["name"].ToString();
                BirthDate = dt.Rows[0]["born_date"].ToString();
            }

            return dt != null && dt.Rows.Count == 1;
        }

        public void Register()
        {
            string birthDate = DateTime.Parse(BirthDate).ToString("yyyy/MM/dd");
            string sql = $"INSERT INTO user (name, email, password, born_date) VALUES ('{Name}','{Email}','{Password}', '{birthDate}')";
            DAL objDAL = new DAL();
            objDAL.ExecuteSQLCommand(sql);
        }
    }
}

