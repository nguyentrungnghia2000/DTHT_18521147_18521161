using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHT
{
    public class FunctionPreGenerate : FunctionNameGenerate
    {
        public FunctionPreGenerate() {  }

        public void DividePre(List<string> data_output, string functionPre, string FuncName)
        {
            data_output.Add(SetNameForFunction("KiemTra", FuncName, typeV));
            data_output.Add("\t\t{");
            // nội dung hàm pre
            try
            {
                funcPre = functionPre;
                funcPre = funcPre.Replace("pre", "").Replace(" ", string.Empty);
                if (funcPre == "")
                {
                    data_output.Add("\t\t\treturn 1;");
                }
                else
                {
                    string condition = string.Format("\t\t\tif({0})", funcPre);
                    data_output.Add(condition);
                    data_output.Add("\t\t\t{");
                    data_output.Add("\t\t\t\treturn 1;");
                    data_output.Add("\t\t\t}");
                    data_output.Add("\t\t\treturn 0;");
                }
            }
            catch
            {
                Console.WriteLine("DividePre Failed");
            }
            data_output.Add("\t\t}");
        }
    }
}
