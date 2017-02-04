using QuickGraph.Graphviz;
using System;

namespace DiGraph.Nodes.Interfaces
{
    internal abstract class IWorkflow<T> : INode<T>
    {
        public abstract T DoWork(INode<T> sourceNode);
        private Func<T, T> _modifyDataAndReturnFunc;
        internal Func<T, T> ModifyDataAndReturnFunc
        {
            get { return _modifyDataAndReturnFunc; }
            set { _modifyDataAndReturnFunc = value; VertexFormatted.Invoke(this, null); }
        }
        public new event FormatVertexEventHandler<INode<T>> VertexFormatted;

        protected IWorkflow(Func<T, T> modifyDataAndReturnFunc)
        {
            _modifyDataAndReturnFunc = modifyDataAndReturnFunc;
            MaxNumberOfIncomingEdges = int.MaxValue;
        }
    }
}
