using GraphX.PCL.Common.Models;
using QuickGraph.Graphviz;

namespace DiGraph
{
    internal sealed class Vertex : VertexBase
    {
        private string _description;
        internal string Description
        {
            get { return _description; }
            set { _description = value; VertexFormatted.Invoke( this, null ); }
        }
        public event FormatVertexEventHandler<Vertex> VertexFormatted; 
        public override string ToString()
        {
            return $"{ID}";
        }
    }
}
