using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace MADPLayGround.ViewModel
{
    public class DiaryViewModel
    {
        public Diary UserDiary { get; set; }
        public DiaryViewModel()
        {

        }
        public void LoadDiary()
        {

        }
        public void SaveDiary()
        {

        }
        public event EventHandler DiaryChange;
        public event EventHandler DiaryArchive;
    }
}
