using System.Security;

namespace GraphLibrary
{
    public interface IGraph
    {

    }

    public class Graph
    {
        private List<Vertex> Vertices;
        private List<Edge> Edges;

        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }

        public void AddVertex(Vertex A)
        {
            Vertices.Add(A);
        }

        public void AddEdge(Vertex A, Vertex B)
        {

        }
    }
}