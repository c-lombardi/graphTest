using DiGraph.Edges.Interfaces;
using DiGraph.Nodes;
using GraphX.PCL.Logic.Algorithms;

namespace DiGraph.Edges
{
    internal class Edge<T> : IEdge<T>
    {
        internal Edge(DataSource<T> source, Workflow<T> target, EdgeTypes type, int id) : base(source, target, type, id)
        {
        }

        internal Edge(IntermediateModel<T> source, Workflow<T> target, EdgeTypes type, int id) : base(source, target, type, id)
        {
        }

        internal Edge(Workflow<T> source, IntermediateModel<T> target, EdgeTypes type, int id) : base(source, target, type, id)
        {
        }

        internal Edge(Workflow<T> source, DomainModel<T> target, EdgeTypes type, int id) : base(source, target, type, id)
        {
        }
    }
}
