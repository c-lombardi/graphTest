using GraphX.PCL.Logic.Algorithms;
using QuickGraph.Graphviz;
using DiGraph.Nodes.Interfaces;
using DiGraph.Nodes;

namespace DiGraph.Edges.Interfaces
{
    internal abstract class IEdge<T> : TypedEdge<INode<T>>
    {
        public event FormatEdgeAction<INode<T>, IEdge<T>> EdgeFormatted;
        
        internal IEdge(DataSource<T> source, Workflow<T> target, EdgeTypes type, int id ) : base(source, target, type)
        {
            Id = id;
        }

        internal IEdge(IntermediateModel<T> source, Workflow<T> target, EdgeTypes type, int id ) : base(source, target, type)
        {
            Id = id;
        }

        internal IEdge(Workflow<T> source, IntermediateModel<T> target, EdgeTypes type, int id ) : base(source, target, type)
        {
            Id = id;
        }

        internal IEdge(Workflow<T> source, DomainModel<T> target, EdgeTypes type, int id ) : base(source, target, type)
        {
            Id = id;
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

        internal int Id { get; private set; }

    }
}
