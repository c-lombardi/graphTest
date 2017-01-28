using DiGraph.Edges.Interfaces;
using DiGraph.Nodes.Interfaces;
using GraphX.PCL.Logic.Algorithms;

namespace DiGraph.Graphs.Interfaces
{
    internal abstract class IHierarchicalGraph<T> : HierarchicalGraph<INode<T>, IEdge<T>>
    {
    }
}
