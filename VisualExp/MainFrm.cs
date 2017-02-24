using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Ultilities;

namespace VisualExp
{
    public partial class MainFrm : Form
    {
        List<Node> TrainingSet;
        List<Node> ResultPredict;
        List<Node> raw_ResultPredict;
        List<Node> DrawSet;
        List<Node> raw_DrawSet;

        Color[] FColorMap;
        Color[] BColorMap;
        Gaussian sparse = new Gaussian(0, 20);
        Gaussian dense = new Gaussian(0, 5);
        Bitmap b;
        bool ReDrawPredict = true;
        double wStep;
        double hStep;
        int w;
        int h;
        public MainFrm()
        {
            InitializeComponent();

            this.Text = getAppSetting("exefile").Split(new char[] { '.' })[0];
            if (this.Text == "")
                this.Text = "VisualExp";
            txtCommand.Text = getAppSetting("cmd");

            TrainingSet = new List<Node>();
            ResultPredict = new List<Node>();
            DrawSet = new List<Node>();
            raw_DrawSet = new List<Node>();
            raw_ResultPredict = new List<Node>();

            FColorMap = new Color[] { Color.Black, Color.Red, Color.DarkGreen, Color.Blue,
                                         Color.BlueViolet, Color.Teal, Color.Gold, Color.Brown, Color.Purple,
                                        Color.Chocolate, Color.GhostWhite, Color.LightPink, Color.Salmon};
            BColorMap = new Color[] { Color.Gray, Color.LightSalmon, Color.YellowGreen, Color.SteelBlue,
                                    Color.Violet, Color.LightSeaGreen,
                                    ColorTranslator.FromHtml("#EF3054"), Color.DarkGreen, Color.Red, Color.DarkCyan, Color.GreenYellow, Color.HotPink };
            cbColor.SelectedIndex = 0;
            cbType.SelectedIndex = 0;
            w = picData.Size.Width;
            h = picData.Size.Height;
            b = new Bitmap(w + 1, h + 1);
            if (Config.args.Contains("-nonscale"))
            {
                int idx = Config.args.IndexOf("-nonscale");
                double max = w;
                try
                {
                    max = Int32.Parse(Config.args[idx + 1]);
                }
                catch {  } 
                wStep = max / w;
                hStep = max / h;
            }
            else
            {
                wStep = 2.0 / w;
                hStep = 2.0 / h;
            }

            if (Config.args.Contains("-preload"))
            {
                chkMulti.Checked = true;
                LoadTrain();
                picData.Refresh();
            }
            else
            {
                if (Config.args.Contains("-drawpredict"))
                {
                    chkMulti.Checked = true;
                    LoadTrain();
                    LoadPredict();
                    picData.Refresh();
                }
                if (Config.args.Contains("-drawmarker"))
                {
                    LoadDraw();
                    picData.Refresh();
                }
            }

        }

        private void GenerateTest()
        {
            StreamWriter writer = new StreamWriter("nolabel.txt");
            if (chkRegression.Checked)
            {
                double x = -1;
               
                for (int i = 0; i <= w; i++)
                {
                    x = -1 + i * wStep;
                    writer.WriteLine("0 1:{0}", x);
                }
            }
            else
            {
                double x = -1;
                double y = -1;
                for (int j = 0; j <= h; j++)
                {
                    y = -hStep * h / 2 + j * hStep;
                    for (int i = 0; i <= w; i++)
                    {
                        x = -wStep * w / 2 + i * wStep;
                        writer.WriteLine("0 1:{0} 2:{1}", x, y);
                    }
                }
            }
            writer.Close();
        }

        private void LoadPredict()
        {
            StreamReader reader = new StreamReader("predict.txt");
            ResultPredict.Clear();
            raw_ResultPredict.Clear();
            while (!reader.EndOfStream)
            {
                if (chkRegression.Checked)
                {
                    string[] stArr = reader.ReadLine().Split(new char[] { ' ' });
                    double y = Double.Parse(stArr[0]);
                    double x = Double.Parse(stArr[1].Split(new char[] { ':' })[1]);
                    int i = (int)Math.Round(x / wStep, 0);
                    int j = (int)Math.Round(y / hStep, 0);
                    ResultPredict.Add(new Node(i + w / 2, h / 2 - j, 1));
                }
                else
                {
                    string[] stArr = reader.ReadLine().Split(new char[] { ' ' });
                    int label = (int)Double.Parse(stArr[0]);
                    double x, y;
                    if (Double.Parse(stArr[1].Split(new char[] { ':' })[0]) == 1)
                    {
                        x = Double.Parse(stArr[1].Split(new char[] { ':' })[1]);
                        if ((stArr.Length > 2) && (stArr[2].Trim() != ""))
                            y = Double.Parse(stArr[2].Split(new char[] { ':' })[1]);
                        else
                            y = 0;
                    }
                    else
                    {
                        x = 0;
                        y = Double.Parse(stArr[1].Split(new char[] { ':' })[1]);
                    }

                    int i = (int)Math.Round(x / wStep, 0);
                    int j = (int)Math.Round(y / hStep, 0);
                    ResultPredict.Add(new Node(i + w / 2, h / 2 - j, label));
                    raw_ResultPredict.Add(new Node(x,y,label));
                }
            }
            reader.Close();
            ReDrawPredict = true;
        }

        private void LoadDraw()
        {
            StreamReader reader = new StreamReader("draw.txt");
            DrawSet.Clear();
            raw_DrawSet.Clear();
            while (!reader.EndOfStream)
            {
                if (chkRegression.Checked)
                {
                    string[] stArr = reader.ReadLine().Split(new char[] { ' ' });
                    double y = Double.Parse(stArr[0]);
                    double x = Double.Parse(stArr[1].Split(new char[] { ':' })[1]);
                    int i = (int)Math.Round(x / wStep, 0);
                    int j = (int)Math.Round(y / hStep, 0);
                    DrawSet.Add(new Node(i + w / 2, h / 2 - j, 1));
                }
                else
                {
                    string[] stArr = reader.ReadLine().Split(new char[] { ' ' });
                    string[] stLabel = stArr[0].Split(new char[] { ',' });
                    int label = (int)Double.Parse(stLabel[0]);
                    int group = -1;
                    if(stLabel.Length > 1)
                        group = (int)Double.Parse(stLabel[1]);
                    double x, y;
                    if (Double.Parse(stArr[1].Split(new char[] { ':' })[0]) == 1)
                    {
                        x = Double.Parse(stArr[1].Split(new char[] { ':' })[1]);
                        if ((stArr.Length > 2) && (stArr[2].Trim() != ""))
                            y = Double.Parse(stArr[2].Split(new char[] { ':' })[1]);
                        else
                            y = 0;
                    }
                    else
                    {
                        x = 0;
                        y = Double.Parse(stArr[1].Split(new char[] { ':' })[1]);
                    }
                    int i = (int)Math.Round(x / wStep, 0);
                    int j = (int)Math.Round(y / hStep, 0);
                    DrawSet.Add(new Node(i + w / 2, h / 2 - j, label, group));
                    raw_DrawSet.Add(new Node(x, y, label, group));
                }
            }
            reader.Close();
            ReDrawPredict = true;
        }

        private void btnGenerateTest_Click(object sender, EventArgs e)
        {
            GenerateTest();
        }

        private void btnLoadPredict_Click(object sender, EventArgs e)
        {
            LoadPredict();
            picData.Refresh();
        }

        private void LoadTrain()
        {
            int w = picData.Size.Width;
            int h = picData.Size.Height;
            double wStep = 2.0 / w;
            double hStep = 2.0 / h;
            Graphics g = Graphics.FromImage(b);
            StreamReader reader = new StreamReader("train.scale.txt");
            while (!reader.EndOfStream)
            {
                string[] stArr = reader.ReadLine().Split(new char[] { ' ' });
                int label = (int)Double.Parse(stArr[0]);
                double x = Double.Parse(stArr[1].Split(new char[] { ':' })[1]);
                double y = Double.Parse(stArr[2].Split(new char[] { ':' })[1]);
                //int i = (int)Math.Round(x / wStep, 0);
                //int j = (int)Math.Round(y / hStep, 0);
                TrainingSet.Add(new Node(x, y, label + 1));
                //Color c = label > 0 ? Color.Red : Color.Green;
                //g.DrawEllipse(new Pen(c), i + w / 2 - 2, h / 2 + j - 2, 4, 4);
            }
            //picData.Image = b;
            reader.Close();
        }

        private void btnLoadTest_Click(object sender, EventArgs e)
        {
            LoadTrain();
            picData.Refresh();
        }

        private void picData_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //if (ReDrawPredict)
                {
                    ReDrawPredict = false;
                    foreach (Node p in ResultPredict)
                    {
                        Color c;
                        if (chkMulti.Checked)
                            c = BColorMap[p.Label + 1];
                        else
                            c = p.Label == 1 ? BColorMap[1] : BColorMap[2];
                        g.DrawLine(new Pen(c), (int)p.X, (int)p.Y, (int)p.X + 1, (int)p.Y);
                    }
                }

                foreach (Node p in TrainingSet)
                {
                    int i = (int)Math.Round(p.X / wStep, 0);
                    int j = (int)Math.Round(p.Y / hStep, 0);
                    g.FillEllipse(new SolidBrush(FColorMap[p.Label]), i + w / 2 - 2, h / 2 - j - 2, 4, 4);
                }

                foreach (Node p in DrawSet)
                {
                    int marker_w = 6;
                    int marker_hw = 3;
                    int marker_iw = 1;
                    int marker_p = 3;
                    switch (p.Group)
                    {
                        case -1:
                            g.FillRectangle(new SolidBrush(FColorMap[p.Label + 1]),
                                        (int)p.X - 2, (int)p.Y - 2, 4, 4);
                            break;
                        case 0:
                            g.FillEllipse(new SolidBrush(FColorMap[p.Label + 1]),
                                (int)p.X - marker_p, (int)p.Y - marker_p, marker_w, marker_w);
                            break;
                        case 1:
                            g.FillRectangle(new SolidBrush(FColorMap[p.Label + 1]),
                                (int)p.X - marker_p, (int)p.Y - marker_p, marker_w, marker_w);
                            break;
                        case 2:
                            g.FillPolygon(new SolidBrush(FColorMap[p.Label + 1]),
                                new Point[] { new Point((int)p.X - marker_hw - marker_iw, (int)p.Y),
                                          new Point((int)p.X, (int)p.Y  - marker_hw -marker_iw),
                                          new Point((int)p.X + marker_hw + marker_iw, (int)p.Y),
                                          new Point((int)p.X, (int)p.Y  + marker_hw + marker_iw),
                                            });
                            break;
                        case 3:
                            g.FillPolygon(new SolidBrush(FColorMap[p.Label + 1]),
                                new Point[] { new Point((int)p.X - marker_hw - marker_iw, (int)p.Y + marker_hw + marker_iw),
                                          new Point((int)p.X, (int)p.Y  - marker_hw - marker_iw),
                                          new Point((int)p.X + marker_hw + marker_iw, (int)p.Y + marker_hw + marker_iw),
                                            });
                            break;
                        case 4:
                            g.FillPolygon(new SolidBrush(FColorMap[p.Label + 1]),
                                new Point[] { new Point((int)p.X - marker_hw - marker_iw, (int)p.Y - marker_hw - marker_iw),
                                          new Point((int)p.X, (int)p.Y  + marker_hw + marker_iw),
                                          new Point((int)p.X + marker_hw + marker_iw, (int)p.Y - marker_hw - marker_iw),
                                            });
                            break;
                        case 5:
                            g.FillPolygon(new SolidBrush(FColorMap[p.Label + 1]),
                                new Point[] { new Point((int)p.X - marker_hw - marker_iw, (int)p.Y),
                                          new Point((int)p.X + marker_hw + marker_iw, (int)p.Y - marker_hw - marker_iw),
                                          new Point((int)p.X + marker_hw + marker_iw, (int)p.Y + marker_hw + marker_iw),
                                            });
                            break;
                        case 6:
                            g.FillPolygon(new SolidBrush(FColorMap[p.Label + 1]),
                                new Point[] { new Point((int)p.X + marker_hw + marker_iw, (int)p.Y),
                                          new Point((int)p.X - marker_hw - marker_iw, (int)p.Y - marker_hw - marker_iw),
                                          new Point((int)p.X - marker_hw - marker_iw, (int)p.Y + marker_hw + marker_iw),
                                            });
                            break;
                    }

                }

            }
            catch (Exception ex)
            {
                int k = 1;
            }
  
        }
        

        private void picData_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                DataProcess.HideLabel(TrainingSet, 
                    (e.X - w / 2) * wStep, (h / 2 - e.Y) * hStep, 30 * wStep);
                picData.Refresh();
                return;
            }
            switch (cbType.SelectedIndex)
            {
                case 0:
                    TrainingSet.Add(new Node((e.X - w / 2) * wStep, (h / 2 - e.Y) * hStep, cbColor.SelectedIndex));
                    break;
                case 1:
                    for (int i = 0; i < 20; i++)
                    {
                        double x = e.X + sparse.Sample();
                        double y = e.Y + sparse.Sample();
                        TrainingSet.Add(new Node((x - w / 2) * wStep, (h / 2 - y) * hStep, cbColor.SelectedIndex));
                    }
                    break;
                case 2:
                    for (int i = 0; i < 20; i++)
                    {
                        double x = e.X + dense.Sample();
                        double y = e.Y + dense.Sample();
                        TrainingSet.Add(new Node((x - w / 2) * wStep, (h / 2 - y) * hStep, cbColor.SelectedIndex));
                    }
                    break;
            }
            picData.Refresh();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            setAppSetting("cmd", txtCommand.Text);
            string exefile = getAppSetting("exefile");
            if (exefile == "")
            {
                if(!txtCommand.Text.Split(new char[] { ' ' })[0].Contains(".exe"))
                {
                    exefile = "SVM4C.exe";
                    setAppSetting("exefile", exefile);
                }
            }
            ResultPredict.Clear();

            StreamWriter writer = new StreamWriter("train.scale.txt");
            if (chkRegression.Checked)
            {
                foreach (Node node in TrainingSet)
                    writer.WriteLine("{0} 1:{1}", node.Y, node.X);
            }
            else
            {
                foreach (Node node in TrainingSet)
                {
                    // by default, binary prob does not have unlabel data
                    // unlabeled data, by default is a multiclass prob
                    string label = "-1";
                    if (node.Label > 0)
                    {
                        if (chkMulti.Checked)
                            label = Convert.ToString(node.Label - 1);
                        else
                            label = node.Label == 1 ? "1" : "-1";
                    }
                    writer.WriteLine("{0} 1:{1} 2:{2}", label, node.X, node.Y);
                }
                DataProcess.SaveTrueLabel(TrainingSet);
            }
            writer.Close();

            GenerateTest();

            if (Config.args.Contains("-matlab"))
            {
                this.Close();
                return;
            }

            int visual = 0;

            string[] cmd_list = txtCommand.Text.Split(new char[] { '\n' });
            for(int i = 0; i < cmd_list.Length; i++)
            {
                if (cmd_list[i].Contains("-visual 2"))
                    visual = 2;
                if(cmd_list[i].Contains(".exe"))
                {
                    string[] cmd_args = cmd_list[i].Split(new char[] { ' ' }, 2);
                    Process p = new Process();
                    //MessageBox.Show(cmd_args[0] + ".." + cmd_args[1]);
                    p.StartInfo = new ProcessStartInfo(cmd_args[0], cmd_args[1]);
                    //p.StartInfo.UseShellExecute = false;
                    //p.StartInfo.RedirectStandardOutput = true;
                    p.Start();
                    //string output = p.StandardOutput.ReadToEnd();
                    //MessageBox.Show(output);
                    p.WaitForExit();
                    //Thread.Sleep(2000);
                }
                else
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo(exefile, cmd_list[i]);
                    p.Start();
                    p.WaitForExit();
                }

            }

            LoadPredict();
            if (visual == 2)
                LoadDraw();
            picData.Refresh();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TrainingSet = Problem.Read(dlg.FileName);
                picData.Invalidate();
            }
        }
        public string getAppSetting(string key)
        {
            //Load the appsettings
            Configuration config = ConfigurationManager.OpenExeConfiguration(
                                    System.Reflection.Assembly.GetExecutingAssembly().Location);
            //Return the value which matches the key
            if (config.AppSettings.Settings[key] == null)
            {
                //If key exists, delete it
                return "";
            }
            return config.AppSettings.Settings[key].Value;
        }

        public void setAppSetting(string key, string value)
        {
            //Load appsettings
            Configuration config = ConfigurationManager.OpenExeConfiguration(
                                    System.Reflection.Assembly.GetExecutingAssembly().Location);
            //Check if key exists in the settings
            if (config.AppSettings.Settings[key] != null)
            {
                //If key exists, delete it
                config.AppSettings.Settings.Remove(key);
            }
            //Add new key-value pair
            config.AppSettings.Settings.Add(key, value);
            //Save the changed settings
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void nmZoom_ValueChanged(object sender, EventArgs e)
        {
            wStep /= (double)nmZoom.Value;
            hStep /= (double)nmZoom.Value;
            List<Node> tmp_DrawSet = new List<Node>();
            for(int iter = 0; iter < raw_DrawSet.Count; iter++)
            {
                int i = (int)Math.Round(raw_DrawSet[iter].X / wStep, 0);
                int j = (int)Math.Round(raw_DrawSet[iter].Y / hStep, 0);
                tmp_DrawSet.Add(new Node(i + w / 2, h / 2 - j, DrawSet[iter].Label, DrawSet[iter].Group));
            }
            DrawSet = tmp_DrawSet;

            List<Node> tmp_predict = new List<Node>();
            for (int iter = 0; iter < raw_ResultPredict.Count; iter++)
            {
                int i = (int)Math.Round(raw_ResultPredict[iter].X / wStep, 0);
                int j = (int)Math.Round(raw_ResultPredict[iter].Y / hStep, 0);
                tmp_predict.Add(new Node(i + w / 2, h / 2 - j, ResultPredict[iter].Label));
            }
            ResultPredict = tmp_predict;

            picData.Refresh();
        }

        private void nmHideLabel_ValueChanged(object sender, EventArgs e)
        {
            DataProcess.HideLabel(TrainingSet, (double)nmHideLabel.Value / 100.0);
            picData.Refresh();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            cbColor.SelectedIndex = 1;
            cbType.SelectedIndex = 1;
        }
    }
}
