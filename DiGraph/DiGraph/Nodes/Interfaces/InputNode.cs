namespace DiGraph.Nodes.Interfaces
{
    internal abstract class InputNode<T> : INode<T>
    {
        internal new T Data
        {
            get { return base.Data; }
            private set { base.Data = value; }
        }

        private InputNode()
        {
            MaxNumberOfIncomingEdges = 0;
        }

        protected InputNode(T data) : this() {
            Data = data;
        }
    }
}
