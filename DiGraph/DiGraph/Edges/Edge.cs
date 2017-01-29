using System;
using DiGraph.Edges.Interfaces;
using DiGraph.Nodes;
using GraphX.PCL.Logic.Algorithms;

namespace DiGraph.Edges
{
    internal class Edge<T> : IEdge<T>
    {
        internal Edge(DataSource<T> source, Workflow<T> target, EdgeTypes type) : base(source, target, type)
        {
        }

        internal Edge(IntermediateModel<T> source, Workflow<T> target, EdgeTypes type) : base(source, target, type)
        {
        }

        internal Edge(Workflow<T> source, IntermediateModel<T> target, EdgeTypes type) : base(source, target, type)
        {
        }

        internal Edge(Workflow<T> source, DomainModel<T> target, EdgeTypes type) : base(source, target, type)
        {
        }
    }
}
