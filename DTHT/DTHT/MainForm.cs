using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DTHT
{
    public partial class Form1 : Form
    {

        string temp;
        string functionName;
        string functionPre;
        string functionPost;
        DivideFunction divideFunction = new DivideFunction();
        public Form1()
        {
            InitializeComponent();
        }

        private void tsbSaveFile_Click(object sender, EventArgs e)
        {
            StreamWriter writeFile = new StreamWriter(txbExeFileName.Text, true);
            writeFile.WriteLine(txbDataOutput.Text);
            writeFile.Close();
        }

        private void tsbOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string fileName;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                txbExeFileName.Text = fileName;
                StreamReader readFile = new StreamReader(fileName);
                txbDataInput.Text = readFile.ReadToEnd();
                readFile.Close();
            }
        }

        public void CutStringOfFileInput()
        {
            string[] arrListString = txbDataInput.Text.Split('\n');
            temp = txbDataInput.Text;
            temp = temp.Replace("\n", string.Empty).Replace("\t", string.Empty).Replace(" ", string.Empty).Replace("\r", string.Empty);
            txbDataOutput.Text = temp;
            int lastCh = temp.Length;
            int prePos = temp.IndexOf("pre");
            int postPos = temp.IndexOf("post");
            functionName = temp.Substring(0, prePos);
            functionPre = temp.Substring(prePos, postPos - prePos);
            functionPost = temp.Substring(postPos, lastCh - postPos);
            
        }
        public List<string> Generate()
        {
            List<string> DataOutput = new List<string>();
            DataOutput.Add("using| System;");
            DataOutput.Add("namespace| FormalSpecification");
            DataOutput.Add("{");//name space
            DataOutput.Add(string.Format("\tpublic| class| Program"));
            DataOutput.Add("\t{");
            //chia file thành 3 phần tên hàm, pre, post
            CutStringOfFileInput();
            //generate phần tên hàm
            divideFunction.DivideFunctionName(DataOutput, functionName);
            //generate phần pre
            divideFunction.DividePre(DataOutput, functionPre);
            //generate phần post
            divideFunction.DividePost(DataOutput, functionPost);
            DataOutput.Add("\t}");//class program
            DataOutput.Add("}");//name 

            return DataOutput;
        }
        private void btnBuildSolution_Click(object sender, EventArgs e)
        {
            List<string> dataoutput = Generate();
            for (int i = 0; i < dataoutput.Count; i++)
            {
                Console.WriteLine(dataoutput[i]);
            }
            //Console.WriteLine(functionPre);
        }
    }
}
