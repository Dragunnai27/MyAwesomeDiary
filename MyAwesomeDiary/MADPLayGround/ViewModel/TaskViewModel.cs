using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace MADPLayGround.ViewModel
{
    public class TaskViewModel
    {
        public UserTask UserTask { get; set; }

        public void LoadTasks()
        {

        }        
        public event EventHandler ChangeState;
        public event EventHandler TaskRemove;
        public event EventHandler TaskAdd;
    }
}
