using GraphX.PCL.Common.Enums;
using GraphX.PCL.Logic.Algorithms;
using DiGraph.Graphs;
using DiGraph.Nodes;
using DiGraph.Edges;

namespace DiGraph
{
    internal static class Program
    {
        private static readonly DiGraph<int> MyGraph = new DiGraph<int> { EdgeCapacity = 3 };
        private static void Main(string[] args)
        {
            DataSource<int> rootVertex = new DataSource<int>( 100 ) { ID = 1, Angle = 1.5, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            Workflow<int> vertex1 = new Workflow<int>(sourceVal => sourceVal + 2){ ID = 2, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude};
            IntermediateModel<int> vertex2 = new IntermediateModel<int> { ID = 3, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            Workflow<int> vertex3 = new Workflow<int>(sourceVal => sourceVal * 11){ ID = 4, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };
            DomainModel<int> vertex4 = new DomainModel<int> { ID = 5, Angle = 1.2, GroupId = 1, SkipProcessing = ProcessingOptionEnum.Exclude };

            Edge<int> edge1 = new Edge<int>( rootVertex, vertex1, EdgeTypes.Hierarchical, 1);
            Edge<int> edge2 = new Edge<int>( vertex1, vertex2, EdgeTypes.Hierarchical, 2);
            Edge<int> edge3 = new Edge<int>( vertex2, vertex3, EdgeTypes.Hierarchical, 3);
            Edge<int> edge4 = new Edge<int>( vertex3, vertex4, EdgeTypes.Hierarchical, 4);

            MyGraph.AddVertex(rootVertex);
            rootVertex.Description = "Vertex Description";
            MyGraph.AddVertex(vertex1);
            MyGraph.AddVertex(vertex2);
            MyGraph.AddVertex(vertex3);
            MyGraph.AddVertex(vertex4);

            MyGraph.AddEdge(edge1);
            edge1.Description = "Edge 1 description";
            MyGraph.AddEdge(edge2);
            MyGraph.AddEdge(edge3);
            MyGraph.AddEdge(edge4);
            MyGraph.RemoveEdge(edge2);

            MyGraph.ReProcessUpDiGraphFromNode(vertex1);

            //ICypherSessionFactory clientFactory = Fluently.Configure("http://localhost:7474/db/data/").CreateSessionFactory();
            //ICypherSession cypherEndpoint = clientFactory.Create();
            //CypherNet.Graph.Node nodes = cypherEndpoint.CreateNode( rootVertex );


            //how to traverse the graph?
            //breadth-first?
            //depth-first?
        }
    }
}
