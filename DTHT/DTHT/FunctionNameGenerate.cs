using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHT
{
    public class FunctionNameGenerate
    {
        public string funcName;
        public string funcPre;
        public string typeV;
        public string ifClause;

        public FunctionNameGenerate() { }
        public void DivideFunctionName(List<string> data_output, string functionName)
        {
            funcName = functionName;
            string[] lines = funcName.Split(new[] { "(", ")" }, StringSplitOptions.None);
            InputFunction(data_output, lines[0], lines[1]);
            OutputFunction(data_output, lines[0], lines[2]);
        }
        //Hàm đặt tên cho các hàm
        public string SetNameForFunction(string function, string NameOfFunc, string type)
        {
            if (function == "Xuat")
            {
                string[] lines = NameOfFunc.Split(new[] { "(", ")" }, StringSplitOptions.None);
                string[] variables_chars = lines[2].Split(new[] { ":" }, StringSplitOptions.None);
                string functionname = string.Format("\t\tpublic void {1}{0}(", lines[0], function);
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
                    else if (variables_chars[i + 1] == "char*")
                    {
                        functionname += "string ";
                    }
                    string varName = string.Format("{0}", variables_chars[i]);
                    functionname += varName;
                }
                functionname += ")";
                return functionname;
            }
            else if(function == "")
            {
                string[] lines = NameOfFunc.Split(new[] { "(", ")" }, StringSplitOptions.None);
                string[] variables_chars = lines[1].Split(new[] { ":", "," }, StringSplitOptions.None);
                string functionname = string.Format("\t\tpublic {2}{1}{0}(", lines[0], function, typeV);
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
                    else if (variables_chars[i + 1] == "char*")
                    {
                        functionname += "string ";
                    }
                    if (i == 0)
                    {
                        if (i + 2 >= variables_chars.Length)
                        {
                            string varName = string.Format("{0} ", variables_chars[i]);
                            functionname += varName;
                        }
                        else
                        {
                            string varName = string.Format("{0}, ", variables_chars[i]);
                            functionname += varName;
                        }
                    }
                    else
                    {
                        string varName = string.Format("{0}", variables_chars[i]);
                        functionname += varName;
                    }
                }
                functionname += ")";
                return functionname;
            }
            else if (function == "KiemTra")
            {
                string[] lines = NameOfFunc.Split(new[] { "(", ")" }, StringSplitOptions.None);
                string[] variables_chars = lines[1].Split(new[] { ":", "," }, StringSplitOptions.None);
                string functionname = string.Format("\t\tpublic int {1}{0}(", lines[0], function, typeV);
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
                    else if (variables_chars[i + 1] == "char*")
                    {
                        functionname += "string ";
                    }
                    if (i == 0)
                    {
                        if (i + 2 >= variables_chars.Length)
                        {
                            string varName = string.Format("{0} ", variables_chars[i]);
                            functionname += varName;
                        }
                        else
                        {
                            string varName = string.Format("{0}, ", variables_chars[i]);
                            functionname += varName;
                        }
                    }
                    else
                    {
                        string varName = string.Format("{0}", variables_chars[i]);
                        functionname += varName;
                    }
                }
                functionname += ")";
                return functionname;
            }
            else
            {
                string[] lines = NameOfFunc.Split(new[] { "(", ")" }, StringSplitOptions.None);
                string[] variables_chars = lines[1].Split(new[] { ":", "," }, StringSplitOptions.None);
                string functionname = string.Format("\t\tpublic void {1}{0}(", lines[0], function);
                for (int i = 0; i < variables_chars.Length; i += 2)
                {
                    if (variables_chars[i + 1] == "R")
                    {
                        functionname += "ref float ";
                    }
                    else if (variables_chars[i + 1] == "Z")
                    {
                        functionname += "ref int ";
                    }
                    else if (variables_chars[i + 1] == "B")
                    {
                        functionname += "ref bool ";
                    }
                    else if (variables_chars[i + 1] == "char*")
                    {
                        functionname += "ref string ";
                    }
                    if (i == 0)
                    {
                        if (i + 2 >= variables_chars.Length)
                        {
                            string varName = string.Format("{0} ", variables_chars[i]);
                            functionname += varName;
                        }
                        else
                        {
                            string varName = string.Format("{0}, ", variables_chars[i]);
                            functionname += varName;
                        }
                    }
                    else
                    {
                        string varName = string.Format("{0}", variables_chars[i]);
                        functionname += varName;
                    }
                }
                functionname += ")";
                return functionname;
            }
        }
        //generate hàm main
        public void MainGenerate(List<string> data_output, string funcName)
        {
            data_output.Add("\t\tpublic static void Main(string[] args)");
            data_output.Add("\t\t{");
            //khoi tao bien
            string[] lines = funcName.Split(new[] { "(", ")" }, StringSplitOptions.None);
            string[] variables_chars = lines[1].Split(new[] { ":", "," }, StringSplitOptions.None);
            for (int i = 0; i < variables_chars.Length; i += 2)
            {

                if (variables_chars[i + 1] == "R")
                {
                    typeV = "float ";
                }
                else if (variables_chars[i + 1] == "Z")
                {
                    typeV = "int ";
                }
                else if (variables_chars[i + 1] == "B")
                {
                    typeV = "bool ";
                }
                else if (variables_chars[i + 1] == "char*")
                {
                    typeV = "string ";
                }
                string CreateResult = string.Format("\t\t\t{0}{1} = 0;", typeV, variables_chars[i]);
                data_output.Add(CreateResult);
            }
            string[] variables_chars1 = lines[2].Split(new[] { ":" }, StringSplitOptions.None);
            for (int i = 0; i < variables_chars1.Length; i += 2)
            {

                if (variables_chars1[i + 1] == "R")
                {
                    typeV = "float ";
                    string CreateResult = string.Format("\t\t\t{0}{1} = 0;", typeV, "kq");
                    data_output.Add(CreateResult);
                }
                else if (variables_chars1[i + 1] == "Z")
                {
                    typeV = "int ";
                    string CreateResult = string.Format("\t\t\t{0}{1} = 0;", typeV, "kq");
                    data_output.Add(CreateResult);
                }
                else if (variables_chars1[i + 1] == "B")
                {
                    typeV = "bool ";
                    string CreateResult = string.Format("\t\t\t{0}{1} = true;", typeV, "kq");
                    data_output.Add(CreateResult);
                }
                else if (variables_chars1[i + 1] == "char*")
                {
                    typeV = "string ";
                    string CreateResult = string.Format("\t\t\t{0}{1} = null;", typeV, "kq");
                    data_output.Add(CreateResult);
                }
                
            }
            data_output.Add("\t\t\tProgram p = new Program();");

            //khoi tao ham Nhap trong main
            string functionname = string.Format("\t\t\tp.Nhap{0}(", lines[0]);
            if (variables_chars.Length > 2)
            {
                for (int i = 0; i < variables_chars.Length; i += 2)
                {
                    if (i == 0)
                    {
                        string varName = string.Format("ref {0}, ", variables_chars[i]);
                        functionname += varName;
                    }
                    else
                    {
                        string varName = string.Format("ref {0}", variables_chars[i]);
                        functionname += varName;
                    }
                }
            }
            else
            {
                string varName = string.Format("ref {0}", variables_chars[0]);
                functionname += varName;
            }

            functionname += ");";
            data_output.Add(functionname);
            //Kiem tra dieu kien
            string funcCondition = string.Format("\t\t\tif(p.KiemTra{0}(", lines[0]);
            if (variables_chars.Length > 2)
            {
                for (int i = 0; i < variables_chars.Length; i += 2)
                {
                    if (i == 0)
                    {
                        string varName = string.Format("{0}, ", variables_chars[i]);
                        funcCondition += varName;
                    }
                    else
                    {
                        string varName = string.Format("{0}", variables_chars[i]);
                        funcCondition += varName;
                    }
                }
            }
            else
            {
                string varName = string.Format("{0}", variables_chars[0]);
                funcCondition += varName;
            }
            funcCondition += ")==1)";
            data_output.Add(funcCondition);
            data_output.Add("\t\t\t{");

            string funcCheck = string.Format("\t\t\t\t{1} = p.{0}(", lines[0], "kq");
            if (variables_chars.Length > 2)
            {
                for (int i = 0; i < variables_chars.Length; i += 2)
                {
                    if (i == 0)
                    {
                        string varName = string.Format("{0}, ", variables_chars[i]);
                        funcCheck += varName;
                    }
                    else
                    {
                        string varName = string.Format("{0}", variables_chars[i]);
                        funcCheck += varName;
                    }
                }
            }
            else
            {
                string varName = string.Format("{0}", variables_chars[0]);
                funcCheck += varName;
            }
            funcCheck += ");";
            data_output.Add(funcCheck);

            string funcOut = string.Format("\t\t\t\tp.Xuat{0}(", lines[0]);
            string varName1 = string.Format("{0}", "kq");
            funcOut += varName1;
            funcOut += ");";
            data_output.Add(funcOut);
            data_output.Add("\t\t\t}");
            data_output.Add("\t\t\telse");
            data_output.Add("\t\t\t\tConsole.WriteLine(\"Thong tin nhap khong hop le!\");");
            data_output.Add("\t\t\tConsole.ReadLine();");
            data_output.Add("\t\t}");
        }

        public string PreWrite(string beforePW)
        {
            string afterPW = beforePW;
            if (afterPW.Contains("=") &&
                 !afterPW.Contains(">=") &&
                 !afterPW.Contains("<=") &&
                 !afterPW.Contains("!=") &&
                 !afterPW.Contains("=="))
            {
                afterPW = afterPW.Replace("=", "==");
            }
            
            return afterPW;
        }

        public string PreWriteTF(string beforePW)
        {
            string afterPW = beforePW;
            if (afterPW.Contains("FALSE"))
            {
                afterPW = afterPW.Replace("FALSE", "false");
            }
            if (afterPW.Contains("TRUE"))
            {
                afterPW = afterPW.Replace("TRUE", "true");
            }
            return afterPW;
        }

        public void InputFunction(List<string> data_output, string FuncName, string variables)
        {
            string[] variables_chars = variables.Split(new[] { ":", "," }, StringSplitOptions.None);
            try
            {
                data_output.Add(SetNameForFunction("Nhap", funcName, typeV));
                data_output.Add("\t\t{");

                // nội dung hàm nhập
                for (int i = 0; i < variables_chars.Length; i += 2)
                {
                    string input = string.Format("\t\t\tConsole.WriteLine(" + "\"Nhap {0}: \");", variables_chars[i]);
                    data_output.Add(input);
                    string inputWrite = string.Format("\t\t\t{0} =", variables_chars[i]);

                    if (variables_chars[i + 1] == "R")
                    {
                        inputWrite += "float.Parse(Console.ReadLine());";
                    }
                    else if (variables_chars[i + 1] == "Z")
                    {
                        inputWrite += "int.Parse(Console.ReadLine());";
                    }
                    else if (variables_chars[i + 1] == "B")
                    {
                        inputWrite += "bool.Parse(Console.ReadLine());";
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

        public void OutputFunction(List<string> data_output, string FuncName, string result)
        {
            string[] result_char = result.Split(new[] { ":" }, StringSplitOptions.None);
            try
            {

                data_output.Add(SetNameForFunction("Xuat", funcName, typeV));
                data_output.Add("\t\t{");

                // nội dung hàm nhập
                for (int i = 0; i < result_char.Length; i += 2)
                {
                    string input = string.Format("\t\t\tConsole.WriteLine(" + "\"Ket qua la: \" + {0});", result_char[i]);
                    data_output.Add(input);
                }
                data_output.Add("\t\t}");
            }
            catch
            {
                Console.WriteLine("OutputFunction Failed");
            }
        }
    }
}
