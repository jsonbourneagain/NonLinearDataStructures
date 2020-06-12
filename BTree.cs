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

            if (IsLeaf(root))
                return 0;

            return 1 + Math.Max(Height(root.LeftChild), Height(root.RightChild));
        }

        public int Min() => Min(root);

        // O(n)
        private int Min(Node root)
        {
            if (IsLeaf(root))
                return root.Value;

            var leftMin = Min(root.LeftChild);
            var rightMin = Min(root.RightChild);

            return Math.Min(Math.Min(leftMin, rightMin), root.Value);
        }
        private bool IsLeaf(Node node)
        {
            return node.LeftChild == null && node.RightChild == null;
        }

        // O(log n)
        private int MinForBST(Node root)
        {
            // In a BST, leftmost leaf would be the smallest. Similarly rightmost leaf would be the largest.

            if (root == null)
                throw new ArgumentNullException(nameof(root));

            var current = root;
            var last = current;

            while (current != null)
            {
                last = current;
                // if (current.LeftChild == null)
                //     return current.Value;
                current = current.LeftChild;
            }
            return last.Value;
        }

        public bool IsEqual(BTree tree)
        {
            if (tree == null)
                throw new ArgumentNullException(nameof(tree));

            if (root.Value != tree.root.Value)
                return false;

            var current1 = root.LeftChild;
            var current2 = tree.root.LeftChild;

            while (current1 != null && current2 != null)
            {
                if (current1.Value != current2.Value)
                    return false;

                current1 = current1.LeftChild;
                current2 = current2.LeftChild;
            }
            var current3 = root.RightChild;
            var current4 = tree.root.RightChild;

            while (current3 != null && current4 != null)
            {
                if (current3.Value != current4.Value)
                    return false;

                current3 = current3.RightChild;
                current4 = current4.RightChild;
            }
            return true;
        }

    }
}