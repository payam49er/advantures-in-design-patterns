using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPatterns.IteratorPattern
{

    //building a binary tree

    public class Node<T>
    {
        public T Value;
        public Node<T> ParentNode;
        public Node<T> LeftNode;
        public Node<T> RightNode;

        public Node ( T value )
        {
            this.Value = value;
        }

        public Node ( T value, Node<T> leftNode, Node<T> rightNode )
        {
            Value = value;
            LeftNode = leftNode;
            RightNode = rightNode;
            leftNode.ParentNode = rightNode.ParentNode = this;
        }


        public PreOrderIterator<T> GetEnumerator ()
        {
            return new PreOrderIterator<T>(ParentNode);
        }


    }


    public class PreOrderIterator<T>
    {
        private readonly Node<T> root;
        public Node<T> Current { get; set; }
        private bool yieldedStart;

        public PreOrderIterator ( Node<T> root )
        {
            this.root = root;
            this.Current = root;
        }

        public bool MoveNext ()
        {
            if (!yieldedStart)
            {
                yieldedStart = true;
                return true;
            }

            if (Current.ParentNode == null)
                return false;


            while (Current.LeftNode != null)
            {
                Current = Current.LeftNode;
                return true;
            }


            while (Current != null && Current.RightNode != null)
            {
                Current = Current.RightNode;
                return true;

            }


            return Current != null;

        }

    }


    //this is the method to do the iteration, C++ style
    public class InOrderIterator<T>
    {
        private readonly Node<T> root;
        public Node<T> Current { get; set; }
        private bool yieldedStart;


        public InOrderIterator ( Node<T> root )
        {
            this.root = root;
            Current = root;
            while (Current.LeftNode != null)
            {
                Current = Current.LeftNode;
            }
        }

        public bool MoveNext ()
        {
            if (!yieldedStart)
            {
                yieldedStart = true;
                return true;
            }

            if (Current.RightNode != null)
            {
                Current = Current.RightNode;
                while (Current.LeftNode != null)
                    Current = Current.LeftNode;
                return true;
            }
            else
            {
                var parent = Current.ParentNode;
                while (parent != null && Current == parent.RightNode)
                {
                    Current = parent;
                    parent = parent.ParentNode;
                }

                Current = parent;
                return Current != null;
            }
        }

        public void Reset ()
        {

        }

    }



    //better way

    public class BinaryTree<T>
    {
        private Node<T> root;

        public BinaryTree ( Node<T> root )
        {
            this.root = root;
        }
        public InOrderIterator<T> GetEnumerator ()
        {
            return new InOrderIterator<T>(root);
        }


        public IEnumerable<Node<T>> InOrder
        {
            get
            {
                IEnumerable<Node<T>> Traverse ( Node<T> current )
                {
                    if (current.LeftNode != null)
                    {
                        foreach (var left in Traverse(current.LeftNode))
                        {
                            yield return left;
                        }
                    }

                    yield return current;

                    if (current.RightNode != null)
                    {
                        foreach (Node<T> right in Traverse(current.RightNode))
                        {
                            yield return right;
                        }
                    }

                }

                foreach (var node in Traverse(root))
                {
                    yield return node;
                }

            }
        }


    }
}
