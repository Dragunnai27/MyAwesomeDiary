using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADPLayGround.ViewModel
{
    public class Calendar
    {
        //private Tuple<int, int> tupCalendar;   
        //public Tuple<int, int> TupCalendar { get => tupCalendar; set => tupCalendar = value; }
        public int[] days;
        public Calendar()
        {
            days = new int[42];
        }
        private decimal Century(decimal year) => Math.Floor(year);
        private int Month(int month) => 0;
        private int Year(int year) => year % 100;
        private int Zeller(int day, int month, int year, int century) 
            => ((13 * month - 1) / 5 + year / 4 + century / 4 + day + year - 2 * century) % 7;
        private int DaysInMonth(int month, int year) => 0;
        private int[] DaysOfCalendar() => new int[42];
    }
}
