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
        public static string DefineIntSumm(string Msg)
        {
            int TotalSumm = 0;
            bool Leader = true;
            string tmpStr, TotalStr = "";
            Console.WriteLine("Сервис DefineSumm выполняется для [{0}]", Msg);
            //String.split
            var inStrs = Msg.Split(' ');
            //foreach (var stIn in inStrs) { Console.WriteLine("Сервис DefineSumm выполняется для {0}", stIn);  }

            for (int i = 0; i < inStrs.Length; i++)
            {
                string inStr = inStrs[i].Trim();
                if (string.IsNullOrEmpty(inStr)) continue;
                //Console.WriteLine($"DefineSumm: {i}:[{inStrs[i]}]");
                if (AddStrIntSumm(ref TotalSumm, inStr))
                {
                    tmpStr = $"+{inStr}";

                }
                else { tmpStr = $"+[{inStr}]"; }

                if (Leader) tmpStr = tmpStr.Substring(1); Leader = false;
                TotalStr = TotalStr + tmpStr;
                //TotalStr.Concat(tmpStr);
                //Console.WriteLine($"{TotalStr}={TotalSumm}. ({i}:+{inStrs[i]} )");
            }

            return $"{TotalStr}={TotalSumm}";
        }
        protected static bool AddStrIntSumm(ref int Sum, string Msg)
        {
            bool res = false;
            try
            {
                var Add = Convert.ToInt32(Msg);
                Sum += Add;
                res = true;
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine($"{ex.StackTrace}");
                return res;
                //throw;
            }
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
