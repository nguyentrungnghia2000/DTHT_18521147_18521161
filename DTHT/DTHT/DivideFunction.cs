using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHT
{
    class DivideFunction
    {
        public string funcName;
        public string funcPre;

        public DivideFunction() { }
        public void DivideFunctionName(List<string> data_output, string functionName)
        {
            funcName = functionName;
            string[] lines = funcName.Split(new[] { "(", ")" }, StringSplitOptions.None);
            InputFunction(data_output, lines[0], lines[1]);
            OutputFunction(data_output, lines[0], lines[2]);
        }
        public void DividePre(List<string> data_output, string functionPre)
        {
            //tên hàm
            string[] lines = funcName.Split(new[] { "(", ")" }, StringSplitOptions.None);
            string[] variables_chars = lines[1].Split(new[] { ":", "," }, StringSplitOptions.None);
            string functionname = string.Format("\t\tpublic void KiemTra_{0}(", lines[0]);
            for (int i = 0; i < variables_chars.Length; i += 2)
            {
                if (variables_chars[i + 1] == "R")
                {
                    functionname += "float ";
                }
                else if (variables_chars[i + 1] == "Z")
                {
                    functionname += "int ";
                }
                else if (variables_chars[i + 1] == "B")
                {
                    functionname += "bool ";
                }
                if (i == 0)
                {
                    string varName = string.Format("{0}, ", variables_chars[i]);
                    functionname += varName;
                }
                else
                {
                    string varName = string.Format("{0}", variables_chars[i]);
                    functionname += varName;
                }

            }
            functionname += ")";
            data_output.Add(functionname);
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

        public void DividePost(List<string> data_output, string functionPost)
        {

        }

        public void InputFunction(List<string> data_output, string FuncName, string variables) {
            string[] variables_chars = variables.Split(new[] { ":", "," }, StringSplitOptions.None);
            try
            {
                //Tên của hàm nhập và các dữ liệu truyền vào
                string functionname = string.Format("\t\tpublic void Nhap_{0}(", FuncName);
                for (int i = 0; i < variables_chars.Length; i += 2)
                {
                    if (variables_chars[i + 1] == "R")
                    {
                        functionname += "float ";
                    }
                    else if (variables_chars[i + 1] == "Z")
                    {
                        functionname += "int ";
                    }
                    else if (variables_chars[i + 1] == "B")
                    {
                        functionname += "bool ";
                    }
                    if (i == 0)
                    {
                        string varName = string.Format("{0}, ", variables_chars[i]);
                        functionname += varName;
                    }
                    else
                    {
                        string varName = string.Format("{0}", variables_chars[i]);
                        functionname += varName;
                    }
                    
                }
                functionname += ")";
                data_output.Add(functionname);
                data_output.Add("\t\t{");

                // nội dung hàm nhập
                for (int i = 0; i < variables_chars.Length; i += 2)
                {
                    string input = string.Format("\t\t\tConsole.WriteLine(" + "Nhap {0}: \");", variables_chars[i]);
                    data_output.Add(input);
                    string inputWrite = string.Format("\t\t\t{0} =", variables_chars[i]);

                    if (variables_chars[i+1] == "R")
                    {
                        inputWrite += "float.Parse(Console.ReadLine())";
                    }
                    else if (variables_chars[i+1] == "Z")
                    {
                        inputWrite += "int.Parse(Console.ReadLine())";
                    }
                    else if (variables_chars[i+1] == "B")
                    {
                        inputWrite += "bool.Parse(Console.ReadLine())";
                    }
                    data_output.Add(inputWrite);
                }
                data_output.Add("\t\t}");
            }
            catch
            {
                Console.WriteLine("InputFunction Failed");
            }
        }

        public void OutputFunction(List<string> data_output, string FuncName, string result) {
            string[] result_char = result.Split(new[] { ":" }, StringSplitOptions.None);
            try
            {
                string functionname = string.Format("\t\tpublic void Nhap_{0}(", FuncName);
                for (int i = 0; i < result_char.Length; i += 2)
                {
                    if (result_char[i + 1] == "R")
                    {
                        functionname += "float ";
                    }
                    else if (result_char[i + 1] == "Z")
                    {
                        functionname += "int ";
                    }
                    else if (result_char[i + 1] == "B")
                    {
                        functionname += "bool ";
                    }
                    string varName = string.Format("{0}", result_char[i]);
                    functionname += varName;

                }
                functionname += ")";
                data_output.Add(functionname);
                data_output.Add("\t\t{");

                // nội dung hàm nhập
                for (int i = 0; i < result_char.Length; i += 2)
                {
                    string input = string.Format("\t\t\tConsole.WriteLine(" + "Ket qua la: {0} \");", result_char[i]);
                    data_output.Add(input);
                }
                data_output.Add("\t\t}");
            }
            catch
            {
                Console.WriteLine("OutputFunction Failed");
            }
        }

        //public string GetParameter() { return PostParameter; }
    }
}
