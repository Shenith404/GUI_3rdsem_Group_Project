using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2.Models
{
    public class LoginHistory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logtime { get; set; }

        public string Logouttime { get; set; }
        
        public string Date { get; set; }

        
    }
}
