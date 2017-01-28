using System.Diagnostics;
using GraphX.PCL.Logic.Algorithms;
using QuickGraph;
using QuickGraph.Graphviz;

namespace DiGraph
{
    internal sealed class Edge : TypedEdge<Vertex>
    {
        private string _description;
        internal string Description
        {
            get { return _description; }
            set { _description = value; EdgeFormatted.Invoke(this, null); }
        }

        public event FormatEdgeAction<Vertex, Edge> EdgeFormatted;

        internal Edge( Vertex source, Vertex target, EdgeTypes type ) : base( source, target, type )
        {
        }

        public override string ToString()
        {
            return $"I connected {Source.ID} to {Target.ID}";
        }
    }
}
