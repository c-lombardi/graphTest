using DiGraph.Nodes.Interfaces;
using System;
using System.Diagnostics;

namespace DiGraph.Nodes
{
    internal sealed class Workflow<T> : IWorkflow<T>
    {
        public override T DoWork(INode<T> sourceNode)
        {
            IsDirty = false;
            Data = ModifyDataAndReturnFunc(sourceNode.Data);
            Trace.WriteLine($"I did work and my result was: {Data} ");
            return Data;
        }

        public Workflow(Func<T, T> modifyDataAndReturnFunc) : base(modifyDataAndReturnFunc)
        {
        }
    }
}
