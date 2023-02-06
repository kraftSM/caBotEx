using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kStreamBot.Controllers
{
    public enum SubTaskModes { None, Sum, Cnt };
    public class SubTask : ISubTask
    {
        private SubTaskModes _SubTaskMode;
        public  SubTask() { _SubTaskMode=SubTaskModes.None; }
        public string Operate(string Msg)
        {
            switch (_SubTaskMode)
            {
                case SubTaskModes.Sum:
                    return DefineIntSumm(Msg);
                    break;
                case SubTaskModes.Cnt:
                    return DefineCharCnt(Msg); 
                    break;
                default:
                    return  "Err";
                    break;
            }
            
            throw new NotImplementedException();
        }

        public void SetMode(string Mode)
        {
            switch (Mode)
            { 
                case "sum":
                    _SubTaskMode=SubTaskModes.Sum;
                break;
            case "cnt":
                    _SubTaskMode = SubTaskModes.Cnt;
                break;
            default:
                _SubTaskMode = SubTaskModes.None;
                break;
            }

                throw new NotImplementedException();
        }
        public string DefineIntSumm(string Msg)            
        {
            Console.WriteLine("Сервис DefineSumm выполняется"); 
            return "DefineIntSumm";
        }
        public string DefineCharCnt(string Msg)
        {
            Console.WriteLine("Сервис DefineCharCnt выполняется");
            return "DefineCharCnt";
        }
    }
}
