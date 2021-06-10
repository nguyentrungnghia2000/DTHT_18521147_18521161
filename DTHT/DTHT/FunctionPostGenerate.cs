using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHT
{
    class FunctionPostGenerate : FunctionNameGenerate
    {

        public FunctionPostGenerate() { }

        public void DividePost(List<string> data_output, string functionPost, string FuncName)
        {
            
            string[] lines = FuncName.Split(new[] { "(", ")" }, StringSplitOptions.None);
            string[] variables_chars = lines[2].Split(new[] { ":" }, StringSplitOptions.None);

            if (variables_chars[1] == "R")
            {
                typeV = "float ";
            }
            else if (variables_chars[1] == "Z")
            {
                typeV = "int ";
            }
            else if (variables_chars[1] == "B")
            {
                typeV = "bool ";
            }
            else if (variables_chars[1] == "char*")
            {
                typeV = "string ";
            }
            
            //tên hàm
            data_output.Add(SetNameForFunction("", FuncName, typeV));
            data_output.Add("\t\t{");
            //khởi tạo các biến kết quả
            if (variables_chars[1] == "char*")
            {
                string CreateResult = string.Format("\t\t\t{0}{1} = null;", typeV, variables_chars[0]);
                data_output.Add(CreateResult);
            }
            else if (variables_chars[1] == "R" || variables_chars[1] == "Z")
            {
                string CreateResult = string.Format("\t\t\t{0}{1} = 0;", typeV, variables_chars[0]);
                data_output.Add(CreateResult);
            }
            else if (variables_chars[1] == "B")
            {
                string CreateResult = string.Format("\t\t\t{0}{1} = true;", typeV, variables_chars[0]);
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
                    if (conditions[i].Contains("&&") == true)
                    {
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
                        string mainClause = string.Format("\t\t\t\t{0};", PreWriteTF(conditions_result[0]));
                        data_output.Add("\t\t\t{");
                        data_output.Add(mainClause);
                        data_output.Add("\t\t\t}");
                    }

                    else
                    {
                        string mainClause = string.Format("\t\t\t{0};", conditions[i]);
                        data_output.Add(mainClause);
                    }

                }
                string returnValue = string.Format("\t\t\treturn {0}; ", variables_chars[0]);
                data_output.Add(returnValue);
                data_output.Add("\t\t}");
            }
            catch
            {
                Console.WriteLine("DividePost Failed");
            }
        }
    }
}
