using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kStreamBot.Controllers
{
    

    public interface ISubTask
    {
        //public void SetMode(string Mode);
        public string Operate(string Msg, string Mode = "None");
    }
}
