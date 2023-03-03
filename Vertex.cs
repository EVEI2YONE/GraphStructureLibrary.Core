using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    public class Vertex
    {
        public string Name { get; set; }
        public object? Value { get; set; }
        public List<Vertex> AdjacentVertices { get; set; }
        public List<Edge> AdjacencyList { get; set; }

        public Vertex(string name, object obj) : this(name)
        {
            Value = obj;
        }

        public Vertex(string name)
        {
            this.Name = name;
            AdjacentVertices = new List<Vertex>();
            AdjacencyList = new List<Edge>();
        }

        public string? ToString(bool ValueToString = false)
        {
            return (ValueToString) ? Value?.ToString() : this.ToString();
        }

        public override string ToString()
            => Name;

        public Vertex? GetAdjacentVertexFromEdge(Edge edge)
        {
            Vertex? adjacentVertex;
            if (edge == null)
                adjacentVertex = null;
            else if (edge.A == this)
                adjacentVertex = edge.B;
            else if (edge.B == this)
                adjacentVertex = edge.A;
            else
                adjacentVertex = null;
            return adjacentVertex;
        }
    }
}
