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
        string typeV;
        string ifClause;

        public DivideFunction() { }
        public void DivideFunctionName(List<string> data_output, string functionName)
        {
            funcName = functionName;
            string[] lines = funcName.Split(new[] { "(", ")" }, StringSplitOptions.None);
            InputFunction(data_output, lines[0], lines[1]);
            OutputFunction(data_output, lines[0], lines[2]);
        }
        //Hàm đặt tên cho các hàm
        string SetNameForFunction(string function)
        {
            if (function == "Xuat")
            {
                string[] lines = funcName.Split(new[] { "(", ")" }, StringSplitOptions.None);
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
            else
            {
                string[] lines = funcName.Split(new[] { "(", ")" }, StringSplitOptions.None);
                string[] variables_chars = lines[1].Split(new[] { ":", "," }, StringSplitOptions.None);
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
        public void DividePre(List<string> data_output, string functionPre)
        {
            data_output.Add(SetNameForFunction("KiemTra"));
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
            //đặt tên
            data_output.Add(SetNameForFunction(""));
            data_output.Add("\t\t{");

            //khoi tao bien result
            string[] lines = funcName.Split(new[] { "(", ")" }, StringSplitOptions.None);
            string[] variables_chars = lines[2].Split(new[] { ":" }, StringSplitOptions.None);
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
                string CreateResult = string.Format("\t\t\t{0}{1};", typeV, variables_chars[i]);
                data_output.Add(CreateResult);
            }
            //nội dung hàm post
            try
            {
                functionPost = functionPost.Replace("post", string.Empty).Replace(" ", string.Empty);
                string[] conditions = functionPost.Split(new[] { "||" }, StringSplitOptions.None);
                for (int i = 0; i < conditions.Length; i++)
                {
                    conditions[i] = conditions[i].Replace("(", string.Empty).Replace(")", string.Empty);
                    string[] conditions_result = conditions[i].Split(new[] { "&&" }, StringSplitOptions.None);
                    if (conditions_result.Length > 2)
                    {
                        for (int j = 1; j < conditions_result.Length; j++)
                        {
                            if (j == 1)
                            {
                                conditions_result[j] = PreWrite(conditions_result[j]);
                                ifClause = string.Format("\t\t\tif ({0} ", conditions_result[j]);
                            }
                            else if (j == conditions_result.Length - 1)
                            {
                                conditions_result[j] = PreWrite(conditions_result[j]);
                                ifClause += string.Format("&& {0})", conditions_result[j]);
                            }
                            else
                            {
                                conditions_result[j] = PreWrite(conditions_result[j]);
                                ifClause += string.Format("&& {0} ", conditions_result[j]);
                            }
                        }
                    }
                    else
                    {
                        conditions_result[1] = PreWrite(conditions_result[1]);
                        ifClause = string.Format("\t\t\tif ({0})", conditions_result[1]);
                    }
                    data_output.Add(ifClause);
                    string mainClause = string.Format("\t\t\t\t{0};", conditions_result[0]);
                    data_output.Add("\t\t\t{");
                    data_output.Add(mainClause);
                    data_output.Add("\t\t\t}");

                }
                data_output.Add("\t\t}");
            }
            catch
            {
                Console.WriteLine("DividePost Failed");
            }
        }

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
                }
                else if (variables_chars1[i + 1] == "Z")
                {
                    typeV = "int ";
                }
                else if (variables_chars1[i + 1] == "B")
                {
                    typeV = "bool ";
                }
                else if (variables_chars1[i + 1] == "char*")
                {
                    typeV = "string ";
                }
                string CreateResult = string.Format("\t\t\t{0}{1} = 0;", typeV, variables_chars1[i]);
                data_output.Add(CreateResult);
            }
            data_output.Add("\t\t\tProgram p = new Program();");

            //khoi tao ham Nhap trong main
            string functionname = string.Format("\t\t\tp.Nhap{0}(", lines[0]);
            for (int i = 0; i < variables_chars.Length; i += 2)
            {
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

            functionname += ");";
            data_output.Add(functionname);
            //Kiem tra dieu kien
            string funcCondition = string.Format("\t\t\tif(p.KiemTra{0}(", lines[0]);
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
            funcCondition += ")==1)";
            data_output.Add(funcCondition);
            data_output.Add("\t\t\t{");

            string funcCheck = string.Format("\t\t\t\t{1} = p.KiemTra{0}(", lines[0], variables_chars1[0]);
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
            funcCheck += ");";
            data_output.Add(funcCheck);

            string funcOut = string.Format("\t\t\t\tp.Xuat{0}(", lines[0]);
            string varName1 = string.Format("{0}", variables_chars1[0]);
            funcOut += varName1;
            funcOut += ");";
            data_output.Add(funcOut);
            data_output.Add("\t\t\t}");
            data_output.Add("\t\t\telse");
            data_output.Add("\t\t\t\tConsole.WriteLine(\"Thong tin nhap khong hop le!\");");
            data_output.Add("\t\t\tConsole.ReadLine();");
            data_output.Add("\t\t}");
        }

        string PreWrite(string beforePW)
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
                data_output.Add(SetNameForFunction("Nhap"));
                data_output.Add("\t\t{");

                // nội dung hàm nhập
                for (int i = 0; i < variables_chars.Length; i += 2)
                {
                    string input = string.Format("\t\t\tConsole.WriteLine(" + "\"Nhap {0}: \");", variables_chars[i]);
                    data_output.Add(input);
                    string inputWrite = string.Format("\t\t\t{0} =", variables_chars[i]);

                    if (variables_chars[i + 1] == "R")
                    {
                        inputWrite += "float.Parse(Console.ReadLine())";
                    }
                    else if (variables_chars[i + 1] == "Z")
                    {
                        inputWrite += "int.Parse(Console.ReadLine())";
                    }
                    else if (variables_chars[i + 1] == "B")
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

        public void OutputFunction(List<string> data_output, string FuncName, string result)
        {
            string[] result_char = result.Split(new[] { ":" }, StringSplitOptions.None);
            try
            {

                data_output.Add(SetNameForFunction("Xuat"));
                data_output.Add("\t\t{");

                // nội dung hàm nhập
                for (int i = 0; i < result_char.Length; i += 2)
                {
                    string input = string.Format("\t\t\tConsole.WriteLine(" + "\"Ket qua la: {0} \");", result_char[i]);
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
