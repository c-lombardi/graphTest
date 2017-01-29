namespace DiGraph.Nodes.Interfaces
{
    internal abstract class IInputNode<T> : INode<T>
    {
        new internal T Data
        {
            get { return base.Data; }
            private set { base.Data = value; }
        }
        public IInputNode()
        {
            MaxNumberOfIncomingEdges = 0;
        }
        public IInputNode(T data) : this() {
            Data = data;
        }
    }
}
