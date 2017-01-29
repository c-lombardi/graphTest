using QuickGraph.Graphviz;
using System;

namespace DiGraph.Nodes.Interfaces
{
    internal abstract class IWorkflow<T> : INode<T>
    {
        public abstract T doWork();
        private Func<T, T> _modifyDataAndReturnFunc;
        internal Func<T, T> modifyDataAndReturnFunc {
            get { return _modifyDataAndReturnFunc; }
            set { modifyDataAndReturnFunc = value; VertexFormatted.Invoke(this, null); }
        }
        new public event FormatVertexEventHandler<INode<T>> VertexFormatted;
        public IWorkflow()
        {
            MaxNumberOfIncomingEdges = int.MaxValue;
        }
    }
}
