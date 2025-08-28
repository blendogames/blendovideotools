using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace blendovideotools
{
    public partial class Form1 : Form
    {
        BackgroundWorker backgroundWorker;
        DateTime starttime;

        //Make sure this retains order parity with the tabs in the form.
        enum TabIndex
        {
            fileConvert,
            framerateConvert,
            resizeConvert
        }

        public Form1()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);

            textBox_framerate.KeyPress += new KeyPressEventHandler(TextBox_framerate_KeyPress);

            //textBox_width.KeyPress += new KeyPressEventHandler(TextBox_size_KeyPress);
            //textBox_height.KeyPress += new KeyPressEventHandler(TextBox_size_KeyPress);

            //Do ffmpeg check.
            if (!File.Exists("ffmpeg.exe"))
            {
                AddLog("ERROR: You need ffmpeg.exe in the same folder as this program.");
                AddLog("1. Download it from https://ffmpeg.org");
                AddLog("2. Copy it into this program's folder.");
                AddLog("3. Restart this program.");
                tabControl1.Enabled = false;
                listBox1.BackColor = System.Drawing.Color.Pink;
                return;
            }

            AddLog("Drag files into this window.");
        }



        //Only allow numerals and decimal in the framerate textbox.
        void TextBox_framerate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        //Only allow numeral
        void TextBox_size_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        //Drag file into window.
        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length <= 0)
                return;

            starttime = DateTime.Now;

            AddLog_Invoked(" ");
            AddLog_Invoked(" ");
            AddLog_Invoked("-------------------------[ {0} ]-------------------------", starttime.ToString("t"));
            AddLog("Dragged in {0} files:", files.Length.ToString());
            string dragText = string.Empty;
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = new FileInfo(files[i]);

                dragText += file.Name;
                if (i < files.Length - 1)
                    dragText += ", ";
            }
            AddLog(dragText);

            if (tabControl1.SelectedIndex == (int)TabIndex.fileConvert)
            {
                backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += OnConvertDoWork;
                backgroundWorker.RunWorkerCompleted += OnConvertCompleted;
                backgroundWorker.RunWorkerAsync(argument: files);
            }
            else if (tabControl1.SelectedIndex == (int)TabIndex.framerateConvert)
            {
                backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += OnFramerateDoWork;
                backgroundWorker.RunWorkerCompleted += OnConvertCompleted;
                backgroundWorker.RunWorkerAsync(argument: files);
            }
            else if (tabControl1.SelectedIndex == (int)TabIndex.resizeConvert)
            {
                backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += OnResizeDoWork;
                backgroundWorker.RunWorkerCompleted += OnConvertCompleted;
                backgroundWorker.RunWorkerAsync(argument: files);
            }
            else
            {
                AddLog("ERROR: this shouldn't happen...");
            }
        }

        #region RESIZE CONVERTER
        private void OnResizeDoWork(object sender, DoWorkEventArgs e)
        {
            int widthValue = -1;
            if (!string.IsNullOrWhiteSpace(textBox_width.Text))
            {
                if (!int.TryParse(textBox_width.Text, out widthValue))
                {
                    AddLog_Invoked("ERROR: invalid width value.");
                    return;
                }
            }

            int heightValue = -1;
            if (!string.IsNullOrWhiteSpace(textBox_height.Text))
            {
                if (!int.TryParse(textBox_height.Text, out heightValue))
                {
                    AddLog_Invoked("ERROR: invalid height value.");
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(textBox_width.Text) && string.IsNullOrWhiteSpace(textBox_height.Text))
            {
                AddLog_Invoked("ERROR: need at least one width or height value.");
                return;
            }

            string args = GetArgs("args_resizeconverter.txt", "-y -i \"{0}\" -vf scale={1}:{2} \"{3}\"");
            AddLog_Invoked("");
            AddLog_Invoked("Using arguments: {0}", args);

            string[] files = (string[])e.Argument;
            for (int i = 0; i < files.Length; i++)
            {
                DoResizeConvert(files[i], widthValue, heightValue, args);
            }
        }

        void DoResizeConvert(string filename, int _width, int _height, string args)
        {
            //ffmpeg -i input.jpg -vf scale=320:-1 output_320.png

            float framerateValue = float.Parse(textBox_framerate.Text);

            FileInfo file = new FileInfo(filename);

            AddLog_Invoked(" ");
            AddLog_Invoked("Converting size: {0}", file.Name);
            AddLog_Invoked(" ");

            string newFileName = AppendFilenameEdit(file.Name);
            newFileName = Path.Combine(file.DirectoryName, newFileName);

            string arguments;
            try
            {
                arguments = string.Format(args, filename, _width, _height, newFileName);
            }
            catch (Exception e)
            {
                AddLog_Invoked("ERROR: failed to parse arguments:");
                AddLog_Invoked(args);
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffmpeg.exe";
            startInfo.Arguments = arguments;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;
            startInfo.CreateNoWindow = true;
            Process proc = new Process();

            try
            {
                proc.StartInfo = startInfo;
                proc.Start();

                //while (!proc.StandardOutput.EndOfStream)
                //{
                //    string line = proc.StandardOutput.ReadLine();
                //    AddLog_Invoked("    " + line);
                //}

                while (!proc.StandardError.EndOfStream)
                {
                    string line = proc.StandardError.ReadLine();
                    AddLog_Invoked("    " + line);
                }
            }
            catch (Exception err)
            {
                AddLog_Invoked("------------------------------");
                AddLog_Invoked(string.Format("ERROR: {0}", err));
                AddLog_Invoked("------------------------------");
            }
        }
        #endregion

        #region FRAMERATE CONVERTER
        private void OnFramerateDoWork(object sender, DoWorkEventArgs e)
        {
            float framerateValue;
            if (!float.TryParse(textBox_framerate.Text, out framerateValue))
            {
                AddLog_Invoked("ERROR: invalid framerate value.");
                return;
            }

            string args = GetArgs("args_framerateconverter.txt", "-y -i \"{0}\" -framerate {1} -filter_complex \"fps={1}\" \"{2}\"");
            AddLog_Invoked("");
            AddLog_Invoked("Using arguments: {0}", args);

            string[] files = (string[])e.Argument;
            for (int i = 0; i < files.Length; i++)
            {
                DoFramerateConvert(files[i], args);
            }
        }

        void DoFramerateConvert(string filename, string args)
        {
            float framerateValue = float.Parse(textBox_framerate.Text);
            
            FileInfo file = new FileInfo(filename);

            AddLog_Invoked(" ");
            AddLog_Invoked("Converting framerate: {0}", file.Name);
            AddLog_Invoked(" ");

            string newFileName = AppendFilenameEdit(file.Name);
            newFileName = Path.Combine(file.DirectoryName, newFileName);

            string arguments;
            try
            {
                arguments = string.Format(args, filename, framerateValue, newFileName);
            }
            catch (Exception e)
            {
                AddLog_Invoked("ERROR: failed to parse arguments:");
                AddLog_Invoked(args);
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffmpeg.exe";
            startInfo.Arguments = arguments;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;
            startInfo.CreateNoWindow = true;
            Process proc = new Process();

            try
            {
                proc.StartInfo = startInfo;
                proc.Start();

                //while (!proc.StandardOutput.EndOfStream)
                //{
                //    string line = proc.StandardOutput.ReadLine();
                //    AddLog_Invoked("    " + line);
                //}

                while (!proc.StandardError.EndOfStream)
                {
                    string line = proc.StandardError.ReadLine();
                    AddLog_Invoked("    " + line);
                }
            }
            catch (Exception err)
            {
                AddLog_Invoked("------------------------------");
                AddLog_Invoked(string.Format("ERROR: {0}", err));
                AddLog_Invoked("------------------------------");
            }
        }

        #endregion

        private string GetArgs(string filename, string defaultArgs)
        {
            string args = GetFileContents(filename);

            if (string.IsNullOrWhiteSpace(args))
                return defaultArgs;

            return args;
        }

        #region FILE CONVERTER
        private void OnConvertDoWork(object sender, DoWorkEventArgs e)
        {
            string args = GetArgs("args_fileconverter.txt", "-y -i \"{0}\" \"{1}\"");
            AddLog_Invoked("");
            AddLog_Invoked("Using arguments: {0}", args);

            string[] files = (string[])e.Argument;
            for (int i = 0; i < files.Length; i++)
            {
                DoFileConvert(files[i], args);
            }
        }

        void DoFileConvert(string filename, string args)
        {
            FileInfo file = new FileInfo(filename);
            string filenameWithoutExtension = Path.GetFileNameWithoutExtension(filename);

            AddLog_Invoked(" ");
            AddLog_Invoked("Converting filetype: {0}", file.Name);
            AddLog_Invoked(" ");

            string newFileName = string.Format("{0}.{1}", filenameWithoutExtension, textBox_extension.Text);
            newFileName = AppendFilenameEdit(newFileName);
            newFileName = Path.Combine(file.DirectoryName, newFileName);

            string arguments;
            try
            {
                arguments = string.Format(args, filename, newFileName);
            }
            catch (Exception e)
            {
                AddLog_Invoked("ERROR: failed to parse arguments:");
                AddLog_Invoked(args);
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffmpeg.exe";
            startInfo.Arguments = arguments;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;
            startInfo.CreateNoWindow = true;
            Process proc = new Process();

            try
            {
                proc.StartInfo = startInfo;
                proc.Start();

                //while (!proc.StandardOutput.EndOfStream)
                //{
                //    string line = proc.StandardOutput.ReadLine();
                //    AddLog_Invoked("    " + line);
                //}

                while (!proc.StandardError.EndOfStream)
                {
                    string line = proc.StandardError.ReadLine();
                    AddLog_Invoked("    " + line);
                }
            }
            catch (Exception err)
            {
                AddLog_Invoked("------------------------------");
                AddLog_Invoked(string.Format("ERROR: {0}", err));
                AddLog_Invoked("------------------------------");
            }
        }
        #endregion

        private void OnConvertCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TimeSpan delta = DateTime.Now.Subtract(starttime);
            AddLog(" ");
            AddLog("Done. (Total time: {0} seconds)", Math.Round(delta.TotalSeconds, 1).ToString());
        }

        private string AppendFilenameEdit(string filename)
        {
            string filenameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
            string extension = Path.GetExtension(filename);

            DateTime date = DateTime.Now;
            string dateString = string.Format("_edit{0}-{1}{2}-{3}", date.Year, date.Month.ToString("D2"), date.Day.ToString("D2"), date.ToString("HHmmssmm"));

            return string.Format("{0}{1}{2}", filenameWithoutExtension, dateString, extension);
        }

        private void AddLog(string text, params string[] args)
        {
            string displaytext = string.Format(text, args);

            listBox1.Items.Add(displaytext);

            //scroll list down
            int nItems = (int)(listBox1.Height / listBox1.ItemHeight);
            listBox1.TopIndex = listBox1.Items.Count - nItems;

            this.Update();
            this.Refresh();
        }

        private void AddLog_Invoked(string text, params string[] args)
        {
            MethodInvoker mi = delegate () { AddLog(text, args); };
            this.Invoke(mi);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void copyAllToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.BackColor = System.Drawing.Color.White;

            string output = string.Empty;
            foreach (object item in listBox1.Items)
            {
                output += item.ToString() + Environment.NewLine;
            }

            if (string.IsNullOrWhiteSpace(output))
            {
                return;
            }

            Clipboard.SetText(output);
        }

        private void copyLineToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.BackColor = System.Drawing.Color.White;

            string output = string.Empty;

            foreach (object item in listBox1.SelectedItems)
            {
                output += item.ToString() + "\r\n";
            }

            if (string.IsNullOrWhiteSpace(output))
            {
                return;
            }

            Clipboard.SetText(output);
        }

        private string GetFileContents(string filepath)
        {
            string output = string.Empty;

            try
            {
                using (FileStream stream = File.Open(filepath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        output = reader.ReadToEnd(); //dump file contents into a string.
                    }
                }
            }
            catch (Exception e)
            {
                AddLog("ERROR: problem reading file ({0})", e.Message);
                return string.Empty;
            }

            return output;
        }
    }
}
