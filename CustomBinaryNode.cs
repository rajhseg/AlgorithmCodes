using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class BinaryNode<T> where T: IComparable<T>, new()
    {
        private BinaryNode<T> left;
        private BinaryNode<T> right;

        public T Value { get; set; }

        public BinaryNode<T> Left
        {
            get { return left; }
            set { left = value; }
        }

        public BinaryNode<T> Right
        {
            get { return right; }
            set { right = value; }
        }

        public BinaryNode(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }
}
