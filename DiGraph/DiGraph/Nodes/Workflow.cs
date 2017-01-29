using DiGraph.Nodes.Interfaces;
using System;

namespace DiGraph.Nodes
{
    internal class Workflow<T> : IOutputNode<T>
    {
        public T doWork(Func<T, T> modifyWorkflowDataFunc)
        {
            return modifyWorkflowDataFunc(Data);
        }
    }
}
