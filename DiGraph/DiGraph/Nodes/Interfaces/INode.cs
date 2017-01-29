using GraphX.PCL.Common.Models;
using QuickGraph.Graphviz;

namespace DiGraph.Nodes.Interfaces
{
    internal abstract class INode<T> : VertexBase
    {
        private string _description;
        internal virtual string Description
        {
            get { return _description; }
            set { _description = value; VertexFormatted.Invoke(this, null); }
        }

        private T _data;
        protected T Data {
            get { return _data; }
            set { _data = value; if (VertexFormatted != null) { VertexFormatted.Invoke(this, null); } }
        }

        public event FormatVertexEventHandler<INode<T>> VertexFormatted;

        public override string ToString()
        {
            return $"{Data}";
        }
        internal int MaxNumberOfIncomingEdges;
    }
}
