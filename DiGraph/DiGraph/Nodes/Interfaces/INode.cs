using GraphX.PCL.Common.Models;
using QuickGraph.Graphviz;

namespace DiGraph.Nodes.Interfaces
{
    internal abstract class INode<T> : VertexBase, IINode<T>
    {
        //properties
        private string _description;
        internal string Description
        {
            get { return _description; }
            set { _description = value; VertexFormatted.Invoke(this, null); }
        }

        private T _data;
        internal T Data
        {
            get { return _data; }
            set { _data = value; if (VertexFormatted != null) { VertexFormatted.Invoke(this, null); } }
        }

        private bool _isDirty;
        internal bool IsDirty
        {
            get { return _isDirty; }
            set { _isDirty = value; VertexFormatted.Invoke(this, null); }
        }

        //static
        internal int MaxNumberOfIncomingEdges;

        //Methods
        public event FormatVertexEventHandler<INode<T>> VertexFormatted;

        public override string ToString()
        {
            return $"{Data}";
        }

        protected INode()
        {
            _isDirty = true;
        }
    }
}
