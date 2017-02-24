using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualExp
{
    class DataProcess
    {
        public static void UnHideLabel(List<Node> data)
        {
            foreach (Node node in data)
                if (node.Label == 0)
                    node.Label = node.TrueLabel;
        }
        public static void HideLabel(List<Node> data, double percent)
        {
            UnHideLabel(data);
            foreach (Node node in data)
                if (node.Label == 0)
                    throw new Exception();

            int n_total = data.Count;
            int n_hide = (int)(percent * data.Count);
            List<int> numbers = new List<int>();
            for (int n = 0; n < n_total; n++)
                numbers.Add(n);
            Random rand = new Random();
            for (int n = 0; n < n_hide; n++)
            {
                int r = rand.Next(numbers.Count);
                int idx = numbers[r];
                data[idx].TrueLabel = data[idx].Label;
                data[idx].Label = 0;
                numbers.RemoveAt(r);        
            }

        }

        public static void HideLabel(List<Node> data, double X, double Y, double R)
        {
            double bottom = Y - R;
            double top = Y + R;
            double left = X - R;
            double right = X + R;

            foreach(Node node in data)
            {
                if((node.X > left) && (node.X < right) && (node.Y > bottom) && (node.Y < top))
                {
                    //if hide already hide datapoint => error
                    if(node.Label > 0)
                    {
                        node.TrueLabel = node.Label;
                        node.Label = 0;
                    }

                }
            }
        }

        public static void SaveTrueLabel(List<Node> data)
        {
            StreamWriter writer = new StreamWriter("train.true.txt");
            //we save in multiclass format
            foreach (Node node in data)
            {
                string label = "";
                if (node.Label > 0)
                        label = Convert.ToString(node.Label - 1);
                else
                    label = Convert.ToString(node.TrueLabel - 1);
                writer.WriteLine("{0} 1:{1} 2:{2}", label, node.X, node.Y);
            }
            writer.Close();
        }
    }
}
