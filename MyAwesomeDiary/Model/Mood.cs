using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Mood
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
    }
    public class UserMood
    {
        [ForeignKey("User")]
        [Key]
        [Column(Order = 0)]
        public string UserID { get; set; }
        public User User { get; set; }
        [ForeignKey("Mood")]
        [Key]
        [Column(Order = 1)]
        public int MID { get; set; }
        public Mood Mood { get; set; }
        public DateTime Start { get; set; }
       
    }
}
