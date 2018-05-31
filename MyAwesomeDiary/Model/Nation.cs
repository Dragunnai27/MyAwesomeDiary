using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Nation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NationID { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class SpecialDay
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class NationalDay
    {
        [ForeignKey("Nation")]
        [Key]
        [Column(Order = 0)]
        public int NationID { get; set; }
        public Nation Nation { get; set; }

        [ForeignKey("SpecialDay")]
        [Key]
        [Column(Order = 1)]
        public int SpecialDayID { get; set; }
        public SpecialDay SpecialDay { get; set; }
        public DateTime Start { get; set; }
        
    }
}
