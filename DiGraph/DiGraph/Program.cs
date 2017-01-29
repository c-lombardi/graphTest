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
            DataSource<int> rootVertex = new DataSource<int>(1){ ID = 1, Angle = 1.5, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            MyGraph.AddVertex(rootVertex);
            rootVertex.Description = "Vertex Description";
            Workflow<int> vertex1 = new Workflow<int>{ ID = 2, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            MyGraph.AddVertex(vertex1);
            IntermediateModel<int> vertex2 = new IntermediateModel<int>{ ID = 3, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            MyGraph.AddVertex(vertex2);
            Workflow<int> vertex3 = new Workflow<int>{ ID = 4, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            MyGraph.AddVertex(vertex3);
            DomainModel<int> vertex4 = new DomainModel<int>{ ID = 5, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            MyGraph.AddVertex(vertex4);
            Edge<int> edge1 = new Edge<int>(rootVertex, vertex1, EdgeTypes.General);
            MyGraph.AddEdge(edge1);
            IEdge<int> foundEdge;
            MyGraph.TryGetEdge(rootVertex, vertex1, out foundEdge);
            foundEdge.Description = "Edge 1 description";
            Edge<int> edge2 = new Edge<int>(vertex1, vertex2, EdgeTypes.General);
            MyGraph.AddEdge(edge2);
            Edge<int> edge3 = new Edge<int>(vertex2, vertex3, EdgeTypes.General);
            MyGraph.AddEdge(edge3);
            Edge<int> edge4 = new Edge<int>(vertex3, vertex4, EdgeTypes.General);
            MyGraph.AddEdge(edge4);
            MyGraph.RemoveEdge(edge2);

            //ICypherSessionFactory clientFactory = Fluently.Configure("http://localhost:7474/db/data/").CreateSessionFactory();
            //ICypherSession cypherEndpoint = clientFactory.Create();
            //CypherNet.Graph.Node nodes = cypherEndpoint.CreateNode( rootVertex );


            //how to traverse the graph?
            //breadth-first?
            //depth-first?
        }
    }
}
