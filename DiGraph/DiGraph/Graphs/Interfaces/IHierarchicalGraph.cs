using System;
using System.Collections.Generic;
using DiGraph.Nodes.Interfaces;
using GraphX.PCL.Logic.Algorithms;
using QuickGraph.Graphviz;
using System.Diagnostics;
using System.Linq;
using DiGraph.Nodes;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.ConnectedComponents;
using QuickGraph.Algorithms.Search;
using QuickGraph.Algorithms.ShortestPath;

namespace DiGraph.Graphs.Interfaces
{
    internal abstract class IHierarchicalGraph<T> : HierarchicalGraph<INode<T>, Edges.Interfaces.IEdge<T>>
    {
        protected IHierarchicalGraph()
        {
            EdgeAdded += MyGraphOnEdgeAdded;
            EdgeRemoved += MyGraphOnEdgeRemoved;
            VertexAdded += MyGraphOnVertexAdded;
            VertexRemoved += MyGraphOnVertexRemoved;
        }
        public override bool AddEdge( Edges.Interfaces.IEdge<T> edge)
        {
            if (InHierarchicalEdgeCount(edge.Target) < edge.Target.MaxNumberOfIncomingEdges)
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

        private bool SubGraphIsComplete( INode<T> sourceNode, Type nodeType )
        {
            var asdf = sourceNode.
        }

        private IEnumerable<INode<T>> GetConnectedDataSources( INode<T> node )
        {
            TryFunc<INode<T>, IEnumerable<Edges.Interfaces.IEdge<T>>> shortestPath = GraphExtensions.ToBidirectionalGraph( this ).ShortestPathsDijkstra( edge => edge.Id, node );
            shortestPath.
            return connectedComponentsAlgorithm.Components.Where(component => component.Key.MaxNumberOfIncomingEdges == 0).Select(component => component.Key);
        }
        public void ReProcessUpDiGraphFromNode(INode<T> node)
        {
            DepthFirstSearchAlgorithm<INode<T>, Edges.Interfaces.IEdge<T>> dfsAlgorithm = new DepthFirstSearchAlgorithm<INode<T>, Edges.Interfaces.IEdge<T>>(this);
            foreach ( INode<T> dataSource in GetConnectedDataSources(node))
            {
                dfsAlgorithm.SetRootVertex(dataSource);
                dfsAlgorithm.FinishVertex += vertex =>
                {
                    vertex.IsDirty = false;
                    Workflow<T> workflow = vertex as Workflow<T>;
                    if (workflow == null || !workflow.IsDirty) return;
                    workflow.DoWork(vertex);
                };
            }
            dfsAlgorithm.Compute();
        }

        private IEnumerable<INode<T>> GetSourceNodes(INode<T> node)
        {
            DijkstraShortestPathAlgorithm<INode<T>, Edges.Interfaces.IEdge<T>> shortestPathAlgorithm = new DijkstraShortestPathAlgorithm<INode<T>, Edges.Interfaces.IEdge<T>>( this, edge => edge.Id );
            shortestPathAlgorithm.Compute();
            return Vertices.Where( w => w.MaxNumberOfIncomingEdges == 0 && shortestPathAlgorithm.Distances.ContainsKey( node ) );
        }

        private void VertexFormatted(object sender, FormatVertexEventArgs<INode<T>> formatVertexEventArgs)
        {
            INode<T> senderNode = (INode<T>)sender;
            Trace.WriteLine($"{senderNode} was formatted");
            if (senderNode is DataSource<T>)
            {
                Trace.WriteLine("Node was a datasource");
            }
            ReProcessUpDiGraphFromNode(senderNode);
        }

        private void EdgeFormatted(object sender, FormatEdgeEventArgs<INode<T>, Edges.Interfaces.IEdge<T>> formatEdgeEventArgs)
        {
            Trace.WriteLine($"{( Edges.Interfaces.IEdge<T>)sender} was formatted");
            ReProcessUpDiGraphFromNode( ( ( Edges.Interfaces.IEdge<T> ) sender ).Target );
        }

        private void MyGraphOnVertexRemoved(INode<T> vertex)
        {
            Trace.WriteLine($"{vertex} id'd vertex was removed");
        }

        private void MyGraphOnVertexAdded(INode<T> vertex)
        {
            Trace.WriteLine($"{vertex} id'd vertex was added");
            ReProcessUpDiGraphFromNode(vertex);
        }

        private void MyGraphOnEdgeRemoved( Edges.Interfaces.IEdge<T> edge)
        {
            Trace.WriteLine($"{edge} was removed, source data is {edge.Source}");
            ReProcessUpDiGraphFromNode(edge.Source);
        }

        private void MyGraphOnEdgeAdded( Edges.Interfaces.IEdge<T> edge)
        {
            Trace.WriteLine($"{edge} was added, target data is {edge.Target}");
            ReProcessUpDiGraphFromNode(edge.Target);
        }
    }
}
