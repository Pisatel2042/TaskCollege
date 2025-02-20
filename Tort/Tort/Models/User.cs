using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tort.Models
{
    public class User
    {
        public int User_id {  get; set; }
        public string? User_Name { get; set; }
        public string? User_FirstName { get; set; }
        public string? User_LastName { get; set; }
        public string? User_Login { get; set; }
        public int User_Role { get; set; }
        public string? Password { get; set; }
        public string? User_Email { get; set; }
    }
}
