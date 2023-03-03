using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public Vertex? GetAdjacentVertexFromEdge(Edge edge, bool CompareValues)
        {
            if (edge == null)
                return null;
            else if (edge.A == null || edge.B == null)
                return null;
            else if (edge.A.Equals(this, CompareValues))
                return edge.B;
            else if (edge.B.Equals(this, CompareValues))
                return edge.A;
            else
                return null;
        }

        public string? ToString(bool ValueToString)
        {
            return (ValueToString) ? Value?.ToString() : this.ToString();
        }

        public override string ToString()
            => Name;

        public bool Equals(object obj, bool CompareValues)
        {
            if(obj == null)
                return false;
            if (obj is Vertex vertex)
            {
                if (CompareValues && vertex.Value != null && Value != null)
                    return Value.Equals(vertex.Value);
                else if (!CompareValues && vertex.Name != null && Name != null)
                    return Name.Equals(vertex.Name);
            }
            else if (CompareValues && Value != null)
                return Value.Equals(obj);
            return false;
        }
    }
}
