using QuickGraph.Graphviz;

namespace DiGraph.Nodes.Interfaces
{
    internal interface IINode<T>
    {
        event FormatVertexEventHandler<INode<T>> VertexFormatted;

        string ToString();
    }
}