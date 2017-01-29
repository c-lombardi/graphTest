namespace DiGraph.Nodes.Interfaces
{
    internal abstract class IOutputNode<T> : INode<T>
    {
        new internal T Data
        {
            get { return base.Data; }
            set { base.Data = value; }
        }
        public IOutputNode()
        {
            MaxNumberOfIncomingEdges = 1;
        }
    }
}
