using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace MADPLayGround.ViewModel
{
    public class CalendarViewModel
    {
        public Calendar Calendar { get; set; }
        public UserEvent UserEvent { get; set; }

        public Calendar Calendar1
        {
            get => default(Calendar);
            set
            {
            }
        }

        public CalendarViewModel()
        {

        }

        public void ShowCalendar()
        {

        }
        public void ShowEvent()
        {

        }
    }
}
