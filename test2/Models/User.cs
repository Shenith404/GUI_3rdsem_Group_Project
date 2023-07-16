using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2.Models
{
    public   class User
    {
        public User()
        {
        }

        public User( string userName, string password, string role)
        {
            
            UserName = userName;
            Password = password;
            Role = role;
        }

        [Key]
        public int  Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }    

        
    }
}
