using GraphX.PCL.Logic.Algorithms;
using QuickGraph.Graphviz;
using DiGraph.Nodes.Interfaces;
using DiGraph.Nodes;
using System;

namespace DiGraph.Edges.Interfaces
{
    internal abstract class IEdge<T> : TypedEdge<INode<T>>
    {
        public event FormatEdgeAction<INode<T>, IEdge<T>> EdgeFormatted;
        
        internal IEdge(DataSource<T> source, DomainModel<T> target, EdgeTypes type, Func<T, T> doWork) : base(source, target, type)
        {
            target.Data = doWork(source.Data);
        }

        internal IEdge(IntermediateModel<T> source, IntermediateModel<T> target, EdgeTypes type, Func<T, T> doWork) : base(source, target, type)
        {
            target.Data = doWork(source.Data);
        }

        internal IEdge(IntermediateModel<T> source, DomainModel<T> target, EdgeTypes type, Func<T, T> doWork) : base(source, target, type)
        {
            target.Data = doWork(source.Data);
        }

        internal IEdge(DataSource<T> source, IntermediateModel<T> target, EdgeTypes type, Func<T, T> doWork) : base(source, target, type)
        {
            target.Data = doWork(source.Data);
        }
        
        public override string ToString()
        {
            return $"I connected {Source.ID} to {Target.ID}";
        }

        private string _description;
        internal string Description
        {
            get { return _description; }
            set { _description = value; EdgeFormatted.Invoke(this, null); }
        }


    }
}
