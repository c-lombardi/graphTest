using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GraphX.PCL.Common;
using GraphX.PCL.Common.Enums;
using GraphX.PCL.Logic.Algorithms;
using Neo4j.Driver.V1;
using QuickGraph.Algorithms.Search;
using QuickGraph.Graphviz;
using CypherNet;
using CypherNet.Configuration;
using CypherNet.Graph;

namespace DiGraph
{
    internal static class Program
    {
        private static readonly DiGraph MyGraph = new DiGraph { EdgeCapacity = 3 };
        private static void Main(string[] args)
        {

            MyGraph.EdgeAdded += MyGraphOnEdgeAdded;
            MyGraph.EdgeRemoved += MyGraphOnEdgeRemoved;
            MyGraph.VertexAdded += MyGraphOnVertexAdded;
            MyGraph.VertexRemoved += MyGraphOnVertexRemoved;


            Vertex rootVertex = new Vertex { ID = 1, Angle = 1.5, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            rootVertex.VertexFormatted += RootVertexOnVertexFormatted;
            rootVertex.Description = "Vertex Description";
            MyGraph.AddVertex(rootVertex);
            Vertex vertex1 = new Vertex { ID = 2, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            MyGraph.AddVertex(vertex1);
            Vertex vertex2 = new Vertex { ID = 3, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            MyGraph.AddVertex(vertex2);
            Vertex vertex3 = new Vertex { ID = 4, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            MyGraph.AddVertex(vertex3);
            Vertex vertex4 = new Vertex { ID = 5, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            MyGraph.AddVertex(vertex4);
            Edge edge1 = new Edge(rootVertex, vertex1, EdgeTypes.General);
            edge1.EdgeFormatted += Edge1OnEdgeFormatted;
            edge1.Description = "Edge 1 description";
            MyGraph.AddEdge(edge1);
            Edge edge2 = new Edge(vertex1, vertex2, EdgeTypes.General);
            MyGraph.AddEdge(edge2);
            Edge edge3 = new Edge(vertex2, vertex3, EdgeTypes.General);
            MyGraph.AddEdge(edge3);
            Edge edge4 = new Edge(vertex3, vertex4, EdgeTypes.General);
            MyGraph.AddEdge(edge4);

            ICypherSessionFactory clientFactory = Fluently.Configure("http://localhost:7474/db/data/").CreateSessionFactory();
            ICypherSession cypherEndpoint = clientFactory.Create();
            Node nodes = cypherEndpoint.CreateNode( rootVertex );


            //how to traverse the graph?
            //breadth-first?
            //depth-first?
        }

        private static void RootVertexOnVertexFormatted( object sender, FormatVertexEventArgs<Vertex> formatVertexEventArgs )
        {
            Trace.WriteLine( $"{(Vertex)sender} was formatted" );
        }

        private static void Edge1OnEdgeFormatted( object sender, FormatEdgeEventArgs<Vertex, Edge> formatEdgeEventArgs )
        {
            Trace.WriteLine( $"{(Edge)sender} was formatted" );
        }

        private static void MyGraphOnVertexRemoved( Vertex vertex )
        {
            Trace.WriteLine( $"{vertex} id'd vertex was removed" );
        }

        private static void MyGraphOnVertexAdded( Vertex vertex )
        {
            Trace.WriteLine($"{vertex} id'd vertex was added");
        }

        private static void MyGraphOnEdgeRemoved( Edge edge )
        {
            Trace.WriteLine($"{edge} was removed");
        }

        private static void MyGraphOnEdgeAdded( Edge edge )
        {
            Trace.WriteLine($"{edge} was added");
        }
    }
}
