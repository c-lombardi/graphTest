using DiGraph.Nodes.Interfaces;

namespace DiGraph.Nodes
{
    internal sealed class DataSource<T> : InputNode<T>
    {
        public DataSource(T data) : base(data)
        {
        }
    }
}
