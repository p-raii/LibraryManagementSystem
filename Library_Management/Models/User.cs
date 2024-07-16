using System.ComponentModel.DataAnnotations;

namespace Library_Management.Models
{
    public class User
    {
      public int Id { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ShowPassword
        {
            get
            {
                return new string('*', Password.Length);
            }
        }
    }
}
