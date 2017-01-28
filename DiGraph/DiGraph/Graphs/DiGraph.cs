using DiGraph.Edges;
using DiGraph.Graphs.Interfaces;
using DiGraph.Nodes;
using System.Collections.Generic;

namespace DiGraph.Graphs
{
    internal class DiGraph<T> : IHierarchicalGraph<T>
    {
        internal void AddDataSources(IEnumerable<DataSource<T>> dataSources)
        {
            AddVertexRange(dataSources);
        }
        internal void AddDataSource(DataSource<T> dataSource)
        {
            AddVertex(dataSource);
        }


        internal void AddDomainModels(IEnumerable<DomainModel<T>> domainModels)
        {
            AddVertexRange(domainModels);
        }
        internal void AddDomainModel(DomainModel<T> domainModel)
        {
            AddVertex(domainModel);
        }

        internal void ReplaceDomainModel(DomainModel<T> originalModel, DomainModel<T> newModel)
        {
            this.
        }


        internal void AddWorkflow(Workflow<T> workflow)
        {
            AddEdge(workflow);
        }

        internal void RemoveWorkflow(Workflow<T> workflow)
        {
            RemoveEdge(workflow);
        }
    }
}
