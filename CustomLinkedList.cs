using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class CustomLinkedList<T> : IEnumerable<T>, IDisposable where T:IComparable<T>, new()
    {
        private CustomLinkedListNode<T> headNode;
        private CustomLinkedListNode<T> currentLastNode;

        public CustomLinkedListNode<T> Root
        {
            get { return headNode; }
        }

        public CustomLinkedList()
        {

        }

        public void AddNode(T value)
        {
            var node = new CustomLinkedListNode<T>(value);

            if (headNode == null)
            {
                headNode = node;
                currentLastNode = headNode;
            }
            else
            {                
                currentLastNode.NextNode = node;
                node.PreviousNode = currentLastNode;
                node.NextNode = default;
                
                currentLastNode = node;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomLinkedListEnumerator<T>(headNode);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            headNode = null;
            currentLastNode = null;
        }
    }

    public class CustomLinkedListEnumerator<T> : IEnumerator<T> where T:IComparable<T>, new()
    {
        private CustomLinkedListNode<T> _root;
        private CustomLinkedListNode<T> _currentNode;

        public CustomLinkedListEnumerator(CustomLinkedListNode<T> root)
        {
            _root = root;            
        }

        public T Current => _currentNode.Value;

        object IEnumerator.Current => _currentNode.Value;

        public void Dispose()
        {
            _root = null;
            _currentNode = null;
        }

        public bool MoveNext()
        {
            CustomLinkedListNode<T> nextNode;

            if (_currentNode == null)
            {
                 nextNode = _root;
                _currentNode = nextNode;
                return nextNode!=null;
            }
            else
            {
                _currentNode = _currentNode.NextNode;
            }
                                
            return _currentNode!=null;
        }

        public void Reset()
        {
            _root = null;
        }
    }
}
