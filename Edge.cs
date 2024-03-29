﻿using System;
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

    public enum ToStringOption
    {
        ValueToString,
        NameToString
    }

    public class Edge
    {
        public Vertex A { get; set; }
        public Vertex B { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }

        private bool _IsBidirectional;
        public bool IsBidirectional { get { return _IsBidirectional; } }
        private List<Vertex> _References = new List<Vertex>();
        public IEnumerable<Vertex> References { get { return _References.AsEnumerable(); } }

        private DirectionState _CurrentState;
        public DirectionState CurrentState
        {
            get { return _CurrentState; }
            set
            {
                _CurrentState = value;
                _References.Clear();
                switch (value)
                {
                    case DirectionState.Both:
                        _IsBidirectional = true;
                        _References.Add(A);
                        _References.Add(B);
                        break;
                    case DirectionState.AtoB:
                        _References.Add(A);
                        _IsBidirectional = false;
                        break;
                    case DirectionState.BtoA:
                        _References.Add(B);
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
            this.Name = ToString(false);
        }

        public void ReversePresentation()
        {
            SwapVertices();
            ReverseDirection();
        }

        public void SwapVertices()
        {
            Vertex temp = A;
            A = B; 
            B = temp;
            CurrentState = CurrentState;
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

        public static ToStringOption ToStringOption { get; set; } = ToStringOption.NameToString;

        public string ToString(bool PrintValues)
        {
            ToStringOption = PrintValues ? ToStringOption.ValueToString : ToStringOption.NameToString;
            return ToString();
        }

        public override string ToString()
        {
            string direction;
            switch (CurrentState)
            {
                case DirectionState.AtoB: direction = "->"; break;
                case DirectionState.BtoA: direction = "<-"; break;
                default: direction = "<->";break;
            }
            var valA = A?.ToString(ToStringOption == ToStringOption.ValueToString);
            var valB = B?.ToString(ToStringOption == ToStringOption.ValueToString);
            return $"{valA ?? "_"} {direction} {valB ?? "_"}";
        }

        public bool Contains(object obj, bool CompareValues = false)
        {
            if (obj == null)
                return false;
            else if (obj is Vertex v)
                return v.GetAdjacentVertexFromEdge(this, CompareValues) != null;
            else if (obj is Edge e)
            {
                if (CompareValues && e.Value != null && Value != null)
                    return e.Value.Equals(Value);
                else if (!CompareValues && e.Name != null && Name != null)
                    return e.Name == Name;
            }
            return false;
        }
    }
}
