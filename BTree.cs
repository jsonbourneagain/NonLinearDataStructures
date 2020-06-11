using System;

namespace NonLinearDataStructures
{
    public class BTree
    {
        private class Node
        {
            public int Value;
            public Node LeftChild;
            public Node RightChild;

            public Node(int value) => this.Value = value;
        }
        private Node root;
        private int count = default;
        public void Insert(int value)
        {
            var node = new Node(value);
            if (count == 0)
            {
                root = node;
            }
            else
            {
                var current = root;

                while (current != null)
                {
                    if (value > current.Value)
                    {
                        if (current.RightChild != null)
                        {
                            current = current.RightChild;
                        }
                        else
                        {
                            current.RightChild = node;
                            break;
                        }
                    }
                    else
                    {
                        if (current.LeftChild != null)
                        {
                            current = current.LeftChild;
                        }
                        else
                        {
                            current.LeftChild = node;
                            break;
                        }
                    }
                }
            }

            count++;
        }
        public bool Find(int value)
        {
            var current = root;

            while (current != null)
            {
                if (current.Value == value)
                {
                    return true;
                }
                else if (value > current.Value && current.RightChild != null)
                {
                    current = current.RightChild;
                }
                else if (value < current.Value && current.LeftChild != null)
                {
                    current = current.LeftChild;
                }
                else
                    break;
            }
            return false;
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(root);
        }
        private void PreOrderTraversal(Node root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine(root.Value);
            PreOrderTraversal(root.LeftChild);
            PreOrderTraversal(root.RightChild);
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(root);
        }
        private void InOrderTraversal(Node root)
        {
            if (root == null)
            {
                return;
            }
            InOrderTraversal(root.LeftChild);
            System.Console.WriteLine(root.Value);
            InOrderTraversal(root.RightChild);
        }
        public void PostOrderTraversal()
        {
            PostOrderTraversal(root);
        }
        private void PostOrderTraversal(Node root)
        {
            if (root == null)
            {
                return;
            }
            PostOrderTraversal(root.LeftChild);
            PostOrderTraversal(root.RightChild);
            System.Console.WriteLine(root.Value);
        }
        public int Height() => Height(root);
        private int Height(Node root)
        {
            if (root == null)
                return -1;
            
            if (root.LeftChild == null && root.RightChild == null)
                return 0;
           
            return 1 + Math.Max(Height(root.LeftChild), Height(root.RightChild));
        }
    }
}