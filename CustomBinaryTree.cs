﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class BinaryTree<T> : IDisposable where T:IComparable<T>, new()
    {
        public BinaryNode<T> Root { get; set; }

        public BinaryTree()
        {

        }

        public BinaryNode<T> InsertValue(T value)
        {            
            return TraversalInsert(value);
        }

        public void DeleteValue(T value)
        {
            this.Root = DeleteRecursive(this.Root, value);
        }

        public bool IsTreeBalanced()
        {
            return IsNodeBalanced(this.Root);
        }

        public void ConvertToBalancedTree()
        {
            List<T> result = new List<T>();
            TraverseInOrder(this.Root, result);

            if (result != null)
            {
                this.Root = Clear(Root);
                this.Root = BuildTree(result, 0, result.Count - 1);
            }
        }

        private BinaryNode<T> BuildTree(List<T> nodes, int start, int end)
        {
            if (start > end)
                return null;

            int mid = Math.Abs((start + end) / 2);

            BinaryNode<T> node = new BinaryNode<T>(nodes[mid]);

            node.Left = BuildTree(nodes, start, mid - 1);
            node.Right = BuildTree(nodes, mid+1, end);

            return node;
        }

        public bool IsNodeBalanced(BinaryNode<T> node)
        {
            int lh = 0;
            int rh = 0;

            if (node != null)
            {
                lh = GetHeight(node.Left);
                rh = GetHeight(node.Right);

                if (Math.Abs(lh - rh) <= 1 && IsNodeBalanced(node.Left) && IsNodeBalanced(node.Right))
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

            return false;
        }

        private BinaryNode<T> DeleteRecursive(BinaryNode<T> node, T value)
        {
            if (node == null)
                return node;

            if(value.CompareTo(node.Value) == -1)
            {
                node.Left = DeleteRecursive(node.Left, value);
            } 
            else if(value.CompareTo(node.Value) == 1)
            {
                node.Right = DeleteRecursive(node.Right, value);
            }
            else
            {
                // value matches with node
                if (node.Left == null && node.Right == null)
                {
                    node = null;
                }
                else if (node.Left == null)
                {
                    node = node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                else
                {
                    T minValue = GetMinValue(node.Right);
                    node.Value = minValue;
                    node.Right = DeleteRecursive(node.Right, node.Value);
                }
            }

            return node;
        }

        private T GetMinValue(BinaryNode<T> node)
        {
            T value = node.Value;

            while (node.Left != null)
            {
                value = node.Left.Value;
                node = node.Left;
            }

            return value;
        }

        private BinaryNode<T> TraversalInsert(T value)
        {
            if (Root == null)
            {
                Root = new BinaryNode<T>(value);                
                return Root;
            }

            Root = InsertRecursive(Root, value);

            return Root;
        }

        private BinaryNode<T> InsertRecursive(BinaryNode<T> current, T data)
        {
            if (current == null)
            {
                return new BinaryNode<T>(data);
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

        public BinaryNode<T> SearchNode(T value)
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

        private void Traversal(BinaryNode<T> node, BinaryTreeTraversal traversal)
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

        public int GetHeight(BinaryNode<T> node)
        {
            int height = 0;
            return TraverseBinaryTree(node, height);
        }

        public int GetHeightOfTree()
        {
            int height = 0;
            return TraverseBinaryTree(this.Root, height);
        }

        private int TraverseBinaryTree(BinaryNode<T> node, int height)
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

        public int GetHeightOfNode(T val)
        {
            return GetHeightOfNode(this.Root, 0, val);
        }

        public int GetHeightOfNode(BinaryNode<T> node)
        {
            return GetHeightOfNode(this.Root, 0, node.Value);
        }

        private int GetHeightOfNode(BinaryNode<T> node, int height, T val)
        {
            if (node == null)
            {
                return -1;
            }
            
            height++;

            if(node.Value.CompareTo(val)==0)
            {
                return height;
            }

            int a = GetHeightOfNode(node.Left, height, val);
            int b = GetHeightOfNode(node.Right, height, val);

            if (a != -1)
                return a;

            if (b != -1)
                return b;

            return -1;
        }

        public void TraverseInOrder(BinaryNode<T> node, List<T> list)
        {
            if (node == null)
                return;

            TraverseInOrder(node.Left, list);
            list.Add(node.Value);
            TraverseInOrder(node.Right, list);
        }

        private BinaryNode<T> TraverseNode(BinaryNode<T> node, T value)
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

        public void Dispose()
        {
           this.Root = Clear(this.Root);
        }

        private BinaryNode<T> Clear(BinaryNode<T> node)
        {
            if (node == null)
                return null;

            node.Left = Clear(node.Left);
            node.Right = Clear(node.Right);

            node = null;
            return node;
        }
    }

    public enum BinaryTreeTraversal
    {
        InOrder,
        PreOrder,
        PostOrder
    }
}
