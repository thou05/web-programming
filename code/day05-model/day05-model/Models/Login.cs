using System.ComponentModel.DataAnnotations;

namespace day05_model.Models
{
    public class Login
    {
        public string username { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
