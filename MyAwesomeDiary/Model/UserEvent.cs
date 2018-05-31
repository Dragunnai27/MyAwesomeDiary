using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserEvent
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [MaxLength(50)]
        public string Location { get; set; }
        public bool AllDay { get; set; }
        public bool Active { get; set; }
        public string Descriptions { get; set; }
        [ForeignKey("User")]
        public string UserID { get; set; }
        public User User { get; set; }
        [ForeignKey("EventType")]
        public int ETID { get; set; }
        public EventType EventType { get; set; }
        [ForeignKey("EventPriority")]
        public int PID { get; set; }
        public EventPriority EventPriority { get; set; }
       
    }
    public class EventType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
    }

    public class EventPriority
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } 
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }
    }
}
