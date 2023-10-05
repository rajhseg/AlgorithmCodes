using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class CustomBinaryNode<T> where T: IComparable<T>, new()
    {
        private CustomBinaryNode<T> left;
        private CustomBinaryNode<T> right;

        public T Value { get; set; }

        public CustomBinaryNode<T> Left
        {
            get { return left; }
            set { left = value; }
        }

        public CustomBinaryNode<T> Right
        {
            get { return right; }
            set { right = value; }
        }

        public CustomBinaryNode(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }
}
