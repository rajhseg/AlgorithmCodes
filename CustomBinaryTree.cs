using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class CustomBinaryTree<T> where T:IComparable<T>,new()
    {
        public CustomBinaryNode<T> Root { get; set; }

        public CustomBinaryTree()
        {

        }

        public CustomBinaryNode<T> InsertValue(T value)
        {            
            return TraversalInsert(value);
        }

        private CustomBinaryNode<T> TraversalInsert(T value)
        {
            if (Root == null)
            {
                Root = new CustomBinaryNode<T>(value);                
                return Root;
            }

            Root = InsertRecursive(Root, value);

            return Root;
        }

        private CustomBinaryNode<T> InsertRecursive(CustomBinaryNode<T> current, T data)
        {
            if (current == null)
            {
                return new CustomBinaryNode<T>(data);
            }

            if (data.CompareTo(current.Value) == -1)
            {
                current.Left = InsertRecursive(current.Left, data);
            }
            else if (data.CompareTo(current.Value)==1)
            {
                current.Right = InsertRecursive(current.Right, data);
            }

            return current;
        }

        public CustomBinaryNode<T> SearchNode(T value)
        {
            return TraverseNode(Root, value);
        }

        public bool ContainsValue(T value)
        {
            var node = SearchNode(value);
            return node != null;
        }

        public void PrintInOrderTree()
        {
            Traversal(Root, BinaryTreeTraversal.InOrder);
        }

        public void PrintPreOrderTree()
        {
            Traversal(Root, BinaryTreeTraversal.PreOrder);
        }

        public void PrintPostOrderTree()
        {
            Traversal(Root, BinaryTreeTraversal.PostOrder);
        }

        private void Traversal(CustomBinaryNode<T> node, BinaryTreeTraversal traversal)
        {
            if (node == null)
                return;

            if (traversal == BinaryTreeTraversal.InOrder)
            {
                Traversal(node.Left, traversal);
                Console.WriteLine("--" + node.Value + "--");
                Traversal(node.Right, traversal);
            }
            else if(traversal == BinaryTreeTraversal.PreOrder)
            {
                Console.WriteLine("--" + node.Value + "--");
                Traversal(node.Left, traversal);               
                Traversal(node.Right, traversal);
            }
            else
            {
                Traversal(node.Left, traversal);                
                Traversal(node.Right, traversal);
                Console.WriteLine("--" + node.Value + "--");
            }
        }

        public int GetHeight(CustomBinaryNode<T> node)
        {
            int height = 0;
            return TraverseBinaryTree(node, height);
        }

        public int GetHeightOfTree()
        {
            int height = 0;
            return TraverseBinaryTree(this.Root, height);
        }

        private int TraverseBinaryTree(CustomBinaryNode<T> node, int height)
        {
            if(node==null)
                return height;

            if (node != null)
            {
                height++;
            }

            int a = TraverseBinaryTree(node.Left, height);
            int b = TraverseBinaryTree(node.Right, height);

            int c = Math.Max(height, Math.Max(a, b));
            return c;
        }

        public void TraverseInOrder(CustomBinaryNode<T> node, List<T> list)
        {
            if (node == null)
                return;

            TraverseInOrder(node.Left, list);
            list.Add(node.Value);
            TraverseInOrder(node.Right, list);
        }

        private CustomBinaryNode<T> TraverseNode(CustomBinaryNode<T> node, T value)
        {
            if (node.Value.CompareTo(value) == 0)
            {
                return node;
            }
            else if (node.Value.CompareTo(value) == 1)
            {
                return TraverseNode(node.Right, value);
            }
            else if (node.Value.CompareTo(value) == -1)
            {
                return TraverseNode(node.Left, value);
            }
            else
            {
                return null;
            }
        }
    }

    public enum BinaryTreeTraversal
    {
        InOrder,
        PreOrder,
        PostOrder
    }
}
