using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualExp
{
    class Node
    {
        public double X;
        public double Y;
        public int Label;
        public int Group; //another label
        public int TrueLabel; //if label = -1, then consider TrueLabel here
        public Node(double x, double y, int label)
        {
            X = x; Y = y; Label = label; Group = -1;
            TrueLabel = -1;
        }
        public Node(double x, double y, int label, int group) : this(x, y, label)
        {
            Group = group;
        }
        public Node()
            :this(0,0,0,0)
        { }
    }
}
