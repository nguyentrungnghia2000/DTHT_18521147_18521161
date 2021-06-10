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
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;

namespace DTHT
{
    public partial class Form1 : Form
    {

        string temp;
        string functionName;
        string functionPre;
        string functionPost;
        Stack<int> UndoFlag = new Stack<int>();
        Stack<int> RedoFlag = new Stack<int>();


        FunctionNameGenerate fng = new FunctionNameGenerate();
        FunctionPreGenerate fprg = new FunctionPreGenerate();
        FunctionPostGenerate fpsg = new FunctionPostGenerate();
        public Form1()
        {
            InitializeComponent();
        }

        public void CutStringOfFileInput()
        {
            string[] arrListString = txbDataInput.Text.Split('\n');
            temp = txbDataInput.Text;
            temp = temp.Replace("\n", string.Empty).Replace("\t", string.Empty).Replace(" ", string.Empty).Replace("\r", string.Empty);
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
            DataOutput.Add("using System;");
            DataOutput.Add("namespace FormalSpecification");
            DataOutput.Add("{");//name space
            DataOutput.Add(string.Format("\tpublic class Program"));
            DataOutput.Add("\t{");
            //chia file thành 3 phần tên hàm, pre, post
            CutStringOfFileInput();
            //generate phần tên hàm
            fng.DivideFunctionName(DataOutput, functionName);
            //generate phần pre
            fprg.DividePre(DataOutput, functionPre, functionName);
            //generate phần post
            fpsg.DividePost(DataOutput, functionPost, functionName);
            fng.MainGenerate(DataOutput, functionName);
            DataOutput.Add("\t}");//class program
            DataOutput.Add("}");//name 

            return DataOutput;
        }
        private void btnBuildSolution_Click(object sender, EventArgs e)
        {
            if(txbDataInput.Text!="")
            {
                txbDataOutput.Clear();
                List<string> dataoutput = Generate();
                for (int i = 0; i < dataoutput.Count; i++)
                {
                    txbDataOutput.Text += dataoutput[i] + "\n";
                    Console.WriteLine(dataoutput[i]);
                }
                this.LoadTextInputOutput();
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txbClassName.Text = "";
            txbExeFileName.Text = "";
            txbDataInput.Text = "";
            txbDataOutput.Text = "";
            //txbDataInput.LoadFile();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
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
            this.LoadTextInputOutput();
            txbDataOutput.Text = "";
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (txbExeFileName.Text == "")
            {
                if (txbDataInput.Text != "")
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (Stream s = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
                        using (StreamWriter sw = new StreamWriter(s))
                        {
                            sw.Write(txbDataOutput.Text);
                        }
                    }
                    MessageBox.Show("Lưu file thành công");
                }
                else
                {
                    MessageBox.Show("Lưu file thất bại vì không có nội dung");
                }
            }
            else
            {
                string path = @txbExeFileName.Text;
                File.WriteAllText(txbExeFileName.Text, txbDataInput.Text);
                MessageBox.Show("Lưu file thành công");
            }
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = this.ActiveControl as RichTextBox;
            if (textBox.SelectedText != string.Empty)
                Clipboard.SetData(DataFormats.Text, textBox.SelectedText);
            textBox.SelectedText = string.Empty;
            pasteToolStripButton.Enabled = true;
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            int position = ((RichTextBox)this.ActiveControl).SelectionStart;
            this.ActiveControl.Text = this.ActiveControl.Text.Insert(position, Clipboard.GetText());
            this.LoadTextInputOutput();
        }
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = this.ActiveControl as RichTextBox;
            if (textBox.SelectedText != string.Empty)
                Clipboard.SetData(DataFormats.Text, textBox.SelectedText);
            pasteToolStripButton.Enabled = true;
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            if (UndoFlag.Peek() == 1)
            {
                txbDataInput.Undo();
                //UndoFlag.Push();
            }
            else
            {
                txbDataOutput.Undo();
            }
            RedoFlag.Push(UndoFlag.Peek());
            UndoFlag.Pop();
            toolStripLabel4.Enabled = true;
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            if(RedoFlag.Peek()==1)
            {
                txbDataInput.Redo();
            }
            else
            {
                txbDataOutput.Redo();
            }
            UndoFlag.Push(RedoFlag.Peek());
            RedoFlag.Pop();
            if(RedoFlag.Count==0)
            {
                toolStripLabel4.Enabled = false;
            }    
            //toolStripLabel3.Enabled = true;
            //toolStripLabel4.Enabled = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txbClassName.Text = "";
            txbExeFileName.Text = "";
            txbDataInput.Text = "";
            txbDataOutput.Text = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
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
            this.LoadTextInputOutput();
            txbDataOutput.Text = "";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txbExeFileName.Text == "")
            {
                if (txbDataInput.Text != "")
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (Stream s = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
                        using (StreamWriter sw = new StreamWriter(s))
                        {
                            sw.Write(txbDataOutput.Text);
                        }
                    }
                    MessageBox.Show("Lưu file thành công");
                }
                else
                {
                    MessageBox.Show("Lưu file thất bại vì không có nội dung");
                }    
            }
            else
            {
                string path = @txbExeFileName.Text;
                File.WriteAllText(txbExeFileName.Text, txbDataInput.Text);
                MessageBox.Show("Lưu file thành công");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void HighLight_Syntax(RichTextBox richTextBox, string[] find, int ColorCase)
        {
            for (int i = 0; i < find.Length; i++)
            {
                int index = 0;
                string findword = find[i];
                RichTextBox temp = richTextBox;
                while (index <= temp.Text.LastIndexOf(findword) && (index != -1))
                {
                    temp.Find(findword, index, temp.TextLength, RichTextBoxFinds.None);
                    if (temp.Find(findword, index, temp.TextLength, RichTextBoxFinds.None) != 0)
                    {
                        string str = temp.Text.Substring(temp.Find(findword, index, temp.TextLength, RichTextBoxFinds.None) - 1, 1);
                        if (hasSpecialChar(str))
                        {
                            switch (ColorCase)
                            {
                                case 1:
                                    temp.SelectionColor = Color.Blue;
                                    break;
                                case 2:
                                    temp.SelectionColor = Color.Red;
                                    break;
                                case 3:
                                    temp.SelectionColor = Color.Brown;
                                    break;
                                case 4:
                                    temp.SelectionColor = Color.Green;
                                    break;
                            }
                        }
                    }
                    else
                        temp.SelectionColor = Color.Blue;
                    index = temp.Text.IndexOf(findword, index + 1);
                }
                richTextBox = temp;
            }
        }
        public static bool hasSpecialChar(string input)
        {
            string[] checkstr = { "\t", "\n", "(", ")", ":", "&", " ", "=" };
            foreach (var item in checkstr)
            {
                if (input == item)
                    return true;
            }
            return false;
        }
        public String[] CaseText(int CaseColor)
        {
            string[] str = { };
            if (CaseColor == 1)
            {
                str = new string[] { "pre", "post", "if", "else", "namespace", "public", "static", "void", "class", "ref", "return", "int", "float", "double", "string", "new", "using" };
            }
            else if (CaseColor == 2)
            {
                str = new string[] { "R" };
            }
            else if (CaseColor == 3)
            {
                str = new string[] { "&&", "||", "Program" };
            }
            else if (CaseColor == 4)
            {
                str = new string[] { "Console" };
            }
            return str;
        }
        public void LoadTextInputOutput()
        {
            for (int i = 1; i <= 4; i++)
            {
                this.HighLight_Syntax(txbDataInput, CaseText(i), i);
                this.HighLight_Syntax(txbDataOutput, CaseText(i), i);
            }
        }

        private void txbDataInput_TextChanged(object sender, EventArgs e)
        {
            UndoFlag.Push(1);
        }

        private void txbDataOutput_TextChanged(object sender, EventArgs e)
        {
            UndoFlag.Push(2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            string Output = "Out.exe";
            Button ButtonObject = (Button)sender;

            richTextBox1.Text = "";
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            //Make sure we generate an EXE, not a DLL
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = Output;
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, txbDataOutput.Text);

            if (results.Errors.Count > 0)
            {
                richTextBox1.ForeColor = Color.Red;
                foreach (CompilerError CompErr in results.Errors)
                {
                    richTextBox1.Text = richTextBox1.Text +
                                "Line number " + CompErr.Line +
                                ", Error Number: " + CompErr.ErrorNumber +
                                ", '" + CompErr.ErrorText + ";" +
                                Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                //Successful Compile
                //textBox2.ForeColor = Color.Blue;
                //textBox2.Text = "Success!";
                //If we clicked run then launch our EXE
                if (ButtonObject.Text == "Run") Process.Start(Output);
            }
        }
        //private RichTextBox GetRichTextBox()
        //{
        //    RichTextBox rtb = null;
        //    TabPage tp = TabControl.SelectedTab;
        //    return rtb;
        //}
    }
}
