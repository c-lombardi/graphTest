using DiGraph.Nodes.Interfaces;

namespace DiGraph.Nodes
{
    internal class DataSource<T> : IInputNode<T>
    {
        public DataSource(T data) : base(data)
        {
        }
    }
}
