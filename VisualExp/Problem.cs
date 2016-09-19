using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SVM4C_GUI
{
    public static class clsStringFunctions
    {

        public static string SuperTrim(string str)
        {
            int numFrontBlank = 0;
            int numEndBlank = 0;
            int i = 0;
            //scan forward
            while (str[i] == ' ') { numFrontBlank++; i++; }
            if (numFrontBlank > 0) str = str.Remove(0, numFrontBlank);
            //scan backword
            i = str.Length - 1;
            while (str[i] == ' ') { numEndBlank++; i--; }
            if (numEndBlank > 0) str = str.Remove(i + 1, numEndBlank);
            while (str.IndexOf("  ") >= 0)
            {
                str = str.Replace("  ", " ");
            }
            return str;
        }

        public static string GetFileNameWithoutExt(string fileName)
        {
            int posOfDot = fileName.LastIndexOf(".");
            return fileName.Substring(0, posOfDot);
        }
    }
    class Problem
    {
        public static List<Node> Read(Stream stream)
        {

            StreamReader input = new StreamReader(stream);
            List<Node> vx = new List<Node>();
            int max_index = 0;

            while (input.Peek() > -1)
            {
                string[] parts = clsStringFunctions.SuperTrim(input.ReadLine().Trim()).Split();
                Node x = new Node();
                x.Label = int.Parse(parts[0]);
                //KK 2016.08.12 need to be consider when data is unlabel
                switch(x.Label)
                {
                    case 0:
                        x.Label = 1;
                        break;
                    case 1:
                        x.Label = 2;
                        break;
                    case 2:
                        x.Label = 3;
                        break;
                }
                int m = parts.Length - 1;
                
                for (int j = 0; j < m; j++)
                {
                    string[] nodeParts = parts[j + 1].Split(':');
                    if(j == 0)
                        x.X = double.Parse(nodeParts[1]);
                    else
                        x.Y = double.Parse(nodeParts[1]);
                }
                if (m > 0)
                    max_index = 2;
                vx.Add(x);
            }
            return vx;
        }
        public static List<Node> Read(string filename)
        {
            FileStream input = File.OpenRead(filename);
            try
            {
                return Read(input);
            }
            finally
            {
                input.Close();
            }
        }
    }
}
