using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tort.Models
{
    internal class Role
    {
        public int Role_Id {  get; set; }
        public string? Role_Name { get; set; }
        public string? Role_Descripion { get; set; }
    }
}
