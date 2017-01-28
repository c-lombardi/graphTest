using System;
using DiGraph.Edges.Interfaces;
using DiGraph.Nodes;
using GraphX.PCL.Logic.Algorithms;

namespace DiGraph.Edges
{
    internal class Workflow<T> : IEdge<T>
    {
        internal Workflow(DataSource<T> source, DomainModel<T> target, EdgeTypes type, Func<T, T> doWork) : base(source, target, type, doWork)
        {
        }

        internal Workflow(IntermediateModel<T> source, IntermediateModel<T> target, EdgeTypes type, Func<T, T> doWork) : base(source, target, type, doWork)
        {
        }

        internal Workflow(IntermediateModel<T> source, DomainModel<T> target, EdgeTypes type, Func<T, T> doWork) : base(source, target, type, doWork)
        {
        }

        internal Workflow(DataSource<T> source, IntermediateModel<T> target, EdgeTypes type, Func<T, T> doWork) : base(source, target, type, doWork)
        {
        }
    }
}
