using System.Diagnostics;
using GraphX.PCL.Common.Enums;
using GraphX.PCL.Logic.Algorithms;
using QuickGraph.Graphviz;
using CypherNet;
using CypherNet.Configuration;
using DiGraph.Graphs;
using DiGraph.Edges.Interfaces;
using DiGraph.Nodes.Interfaces;
using DiGraph.Nodes;
using DiGraph.Edges;
using System;

namespace DiGraph
{
    internal static class Program
    {
        private static readonly DiGraph<int> MyGraph = new DiGraph<int> { EdgeCapacity = 3 };
        private static void Main(string[] args)
        {

            MyGraph.EdgeAdded += MyGraphOnEdgeAdded;
            MyGraph.EdgeRemoved += MyGraphOnEdgeRemoved;
            MyGraph.VertexAdded += MyGraphOnVertexAdded;
            MyGraph.VertexRemoved += MyGraphOnVertexRemoved;


            DataSource<int> rootVertex = new DataSource<int>(1){ ID = 1, Angle = 1.5, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            rootVertex.VertexFormatted += VertexFormatted;
            rootVertex.Description = "Vertex Description";
            MyGraph.AddVertex(rootVertex);
            IntermediateModel<int> vertex1 = new IntermediateModel<int>{ ID = 2, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            MyGraph.AddVertex(vertex1);
            IntermediateModel<int> vertex2 = new IntermediateModel<int>{ ID = 3, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            MyGraph.AddVertex(vertex2);
            IntermediateModel<int> vertex3 = new IntermediateModel<int>{ ID = 4, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            MyGraph.AddVertex(vertex3);
            DomainModel<int> vertex4 = new DomainModel<int>{ ID = 5, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            MyGraph.AddVertex(vertex4);
            Workflow<int> edge1 = new Workflow<int>(rootVertex, vertex1, EdgeTypes.General, (rootVertexData => rootVertexData * 2));
            edge1.EdgeFormatted += EdgeFormatted;
            edge1.Description = "Edge 1 description";
            MyGraph.AddEdge(edge1);
            Workflow<int> edge2 = new Workflow<int>(vertex1, vertex2, EdgeTypes.General, (rootVertexData => rootVertexData + 4));
            MyGraph.AddEdge(edge2);
            Workflow<int> edge3 = new Workflow<int>(vertex2, vertex3, EdgeTypes.General, (rootVertexData => rootVertexData / 3));
            MyGraph.AddEdge(edge3);
            Workflow<int> edge4 = new Workflow<int>(vertex3, vertex4, EdgeTypes.General, (rootVertexData => rootVertexData + 8));
            MyGraph.AddEdge(edge4);
            MyGraph.RemoveEdge(edge2);

            //ICypherSessionFactory clientFactory = Fluently.Configure("http://localhost:7474/db/data/").CreateSessionFactory();
            //ICypherSession cypherEndpoint = clientFactory.Create();
            //CypherNet.Graph.Node nodes = cypherEndpoint.CreateNode( rootVertex );


            //how to traverse the graph?
            //breadth-first?
            //depth-first?
        }

        private static void VertexFormatted<T>( object sender, FormatVertexEventArgs<INode<T>> formatVertexEventArgs )
        {
            Trace.WriteLine( $"{(INode<T>)sender} was formatted" );
        }

        private static void EdgeFormatted<T>( object sender, FormatEdgeEventArgs<INode<T>, IEdge<T>> formatEdgeEventArgs )
        {
            Trace.WriteLine( $"{(IEdge<T>)sender} was formatted" );
        }

        private static void MyGraphOnVertexRemoved<T>(INode<T> vertex )
        {
            Trace.WriteLine( $"{vertex} id'd vertex was removed" );
        }

        private static void MyGraphOnVertexAdded<T>( INode<T> vertex )
        {
            Trace.WriteLine($"{vertex} id'd vertex was added");
        }

        private static void MyGraphOnEdgeRemoved<T>(IEdge<T> edge )
        {
            Trace.WriteLine($"{edge} was removed, source data is {edge.Source}");
        }

        private static void MyGraphOnEdgeAdded<T>(IEdge<T> edge)
        {
            Trace.WriteLine($"{edge} was added, target data is {edge.Target}");
        }
    }
}
