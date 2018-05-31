using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAwesomeDiary.Model
{
    public class User
    {
        public string UserID { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserAddress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Work { get; set; }
        public string Intro { get; set; }
        [Required]
        public string PrivateAnswer { get; set; }
        [ForeignKey("Nation")]
        public int NationID { get; set; }
        public Nation Nation { get; set; }
       
    }
}
