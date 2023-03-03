using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    public enum DirectionState
    {
        AtoB,
        BtoA,
        Both
    }

    public class Edge
    {
        public Vertex A { get; set; }
        public Vertex B { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }

        private bool _IsBidirectional;
        public bool IsBidirectional { get { return _IsBidirectional; } }

        private DirectionState _CurrentState;
        public DirectionState CurrentState
        {
            get { return _CurrentState; }
            set
            {
                _CurrentState = value;
                switch (value)
                {
                    case DirectionState.Both:
                        _IsBidirectional = true;
                        break;
                    default:
                        _IsBidirectional = false;
                        break;
                }
            }
        }

        public Edge()
        {
            CurrentState = DirectionState.Both;
            _IsBidirectional = true;
        }
        
        public Edge(Vertex A, Vertex B, DirectionState Direction)
        {
            this.A = A;
            this.B = B;
            CurrentState = Direction;
        }

        public void SwapVertices()
        {
            Vertex temp = A;
            A = B; 
            B = temp;
        }

        public void ReverseDirection()
        {
            if (CurrentState != DirectionState.Both)
            {
                if (CurrentState == DirectionState.AtoB)
                    CurrentState = DirectionState.BtoA;
                else
                    CurrentState = DirectionState.AtoB;
            }
        }

        public string? ToString(bool ValueToString = false)
        {
            this.ValueToString = ValueToString; 
            return this.ToString();
        }

        private bool ValueToString;
        public override string ToString()
        {
            string direction;
            switch (CurrentState)
            {
                case DirectionState.AtoB: direction = "->"; break;
                case DirectionState.BtoA: direction = "<-"; break;
                default: direction = "<->";break;
            }
            var valA = ValueToString ? A?.Value?.ToString() : A?.Name;
            var valB = ValueToString ? B?.Value?.ToString() : B?.Name;
            return $"{valA ?? "_"}{direction}{valB ?? "_"}";
        }
    }
}
