using DiGraph.Edges.Interfaces;
using DiGraph.Nodes.Interfaces;
using GraphX.PCL.Logic.Algorithms;
using QuickGraph.Graphviz;
using System.Diagnostics;

namespace DiGraph.Graphs.Interfaces
{
    internal abstract class IHierarchicalGraph<T> : HierarchicalGraph<INode<T>, IEdge<T>>
    {
        public IHierarchicalGraph() : base()
        {
            EdgeAdded += MyGraphOnEdgeAdded;
            EdgeRemoved += MyGraphOnEdgeRemoved;
            VertexAdded += MyGraphOnVertexAdded;
            VertexRemoved += MyGraphOnVertexRemoved;
        }
        public override bool AddEdge(IEdge<T> edge)
        {
            if(InHierarchicalEdgeCount(edge.Target) < edge.Target.MaxNumberOfIncomingEdges)
            {
                edge.EdgeFormatted += EdgeFormatted;
                base.AddEdge(edge);
                return true;
            }
            return false;
        }

        public override bool AddVertex(INode<T> node)
        {
            node.VertexFormatted += VertexFormatted;
            base.AddVertex(node);
            return true;
        }

        private static void VertexFormatted(object sender, FormatVertexEventArgs<INode<T>> formatVertexEventArgs)
        {
            Trace.WriteLine($"{(INode<T>)sender} was formatted");
        }

        private static void EdgeFormatted(object sender, FormatEdgeEventArgs<INode<T>, IEdge<T>> formatEdgeEventArgs)
        {
            Trace.WriteLine($"{(IEdge<T>)sender} was formatted");
        }

        private static void MyGraphOnVertexRemoved(INode<T> vertex)
        {
            Trace.WriteLine($"{vertex} id'd vertex was removed");
        }

        private static void MyGraphOnVertexAdded(INode<T> vertex)
        {
            Trace.WriteLine($"{vertex} id'd vertex was added");
        }

        private static void MyGraphOnEdgeRemoved(IEdge<T> edge)
        {
            Trace.WriteLine($"{edge} was removed, source data is {edge.Source}");
        }

        private static void MyGraphOnEdgeAdded(IEdge<T> edge)
        {
            Trace.WriteLine($"{edge} was added, target data is {edge.Target}");
        }
    }
}
