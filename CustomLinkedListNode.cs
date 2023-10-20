using System;

namespace ConsoleApp2
{
    public class CustomLinkedListNode<T> : IComparable<T> where T: IComparable<T>, new()
    {
        private T _value;

        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private CustomLinkedListNode<T> _prevNode;

        public CustomLinkedListNode<T> PreviousNode
        {
            get { return _prevNode; }
            set { _prevNode = value; }
        }

        private CustomLinkedListNode<T> _nextNode;

        public CustomLinkedListNode<T> NextNode
        {
            get { return _nextNode; }
            set
            {
                _nextNode = value;
            }
        }

        public CustomLinkedListNode(T value)
        {            
            Value = value;
        }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }
    }
}
