namespace DiGraph.Nodes.Interfaces
{
    internal abstract class OutputNode<T> : INode<T>
    {
        internal new T Data
        {
            get { return base.Data; }
            set { base.Data = value; }
        }

        protected OutputNode()
        {
            MaxNumberOfIncomingEdges = 1;
        }
    }
}
