using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caTestSubTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var res = DefineIntSumm(" 152 rr 34 567 7,6 56. 2 ");
            Console.WriteLine(res);
            Console.ReadKey();
        }
        protected static string DefineIntSumm(string Msg)
        {
            int TotalSumm = 0;
            bool Leader = true;
            string tmpStr, TotalStr = "";
            Console.WriteLine("Сервис DefineSumm выполняется для [{0}]", Msg);
            //String.split
            var inStrs = Msg.Split(' ');
            //foreach (var stIn in inStrs) { Console.WriteLine("Сервис DefineSumm выполняется для {0}", stIn);  }

            for (int i=0; i < inStrs.Length; i++)
            {
                string inStr = inStrs[i].Trim();
                    if (string.IsNullOrEmpty(inStr)) continue;
                Console.WriteLine($"DefineSumm: {i}:[{inStrs[i]}]");
                if (AddStrIntSumm(ref TotalSumm, inStr))
                { 
                    tmpStr = $"+{inStr}";
                    
                }                
                else { tmpStr = $"+[{inStr}]"; }

                if (Leader) tmpStr = tmpStr.Substring(1); Leader = false;
                TotalStr = TotalStr + tmpStr;
                //TotalStr.Concat(tmpStr);

                Console.WriteLine($"{TotalStr}={TotalSumm}. ({i}:+{inStrs[i]} )");
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
    }
}
