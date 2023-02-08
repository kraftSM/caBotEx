using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kStreamBot.Controllers
{
    //public enum SubTaskModes { None, Sum, Cnt };
    public class SubTask : ISubTask
    {
        //private SubTaskModes _SubTaskMode;
        //public  SubTask() { _SubTaskMode=SubTaskModes.None; }
        public SubTask() {  }
        public string Operate(string Msg, string Mode)
        {
            switch (Mode)
            {
                case "sum":
                    return DefineIntSumm(Msg);
                    break;
                case "cnt":
                    return DefineCharCnt(Msg); 
                    break;
                default:
                    return  "[Err of Operate]: "+ Msg;
                    break;
            }
            
            throw new NotImplementedException();
        }

        //public void SetMode(string Mode)
        //{
        //    switch (Mode)
        //    { 
        //        case "sum":
        //            _SubTaskMode=SubTaskModes.Sum;
        //        break;
        //    case "cnt":
        //            _SubTaskMode = SubTaskModes.Cnt;
        //        break;
        //    default:
        //        _SubTaskMode = SubTaskModes.None;
        //        break;
        //    }

        //        throw new NotImplementedException();
        //}
        public string DefineIntSumm(string Msg)            
        {
            Console.WriteLine("Сервис DefineSumm выполняется для {0}", Msg); 
            return "DefineIntSumm";
        }
        public string DefineCharCnt(string Msg)
        {
            int chCnt = 0;
            Console.WriteLine("Сервис DefineCharCnt выполняется  для {0}", Msg);
            for (int i=0; i<Msg.Length; i++)
            {
                if (Msg[i] != ' ') chCnt++;

            }

            //string resMsg = "В строке " + Msg + "содержиться " + chCnt.ToString + "символов.";
            string resMsg = "В строке \"" + Msg + "\" содержиться " + chCnt.ToString() + " символа(ов)";
            //return "DefineCharCnt";
            return resMsg;
        }
    }
}
