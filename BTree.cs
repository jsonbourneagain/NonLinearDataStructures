using System;
using System.Collections.Generic;

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

        public bool IsEqual(BTree other)
        {
            if (other == null)
                return false;
            return IsEqual(root, other.root);
        }
        private bool IsEqual(Node first, Node second)
        {
            if (first == null && second == null)
                return true;

            if (first != null && second != null)
                return first.Value == second.Value &&
                        IsEqual(first.LeftChild, second.LeftChild) &&
                        IsEqual(first.RightChild, second.RightChild);
            return false;
        }

        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(root, Int32.MinValue, Int32.MaxValue);
        }

        private bool IsBinarySearchTree(Node root, int min, int max)
        {
            if (root == null)
                return true;

            if (root.Value < min || root.Value > max)
                return false;

            return IsBinarySearchTree(root.LeftChild, Int32.MinValue, root.Value - 1) &&
                    IsBinarySearchTree(root.RightChild, root.Value + 1, Int32.MaxValue);
        }

        public void Swap()
        {
            var temp = root.LeftChild;
            root.LeftChild = root.RightChild;
            root.RightChild = temp;
        }

        public void PrintNodeAtDistanceK(int k)
        {
            PrintNodeAtDistanceK(root, k);
        }

        private void PrintNodeAtDistanceK(Node root, int k)
        {
            if (root == null)
                return;
            if (k == 0)
            {
                System.Console.WriteLine(root.Value);
                return;
            }

            PrintNodeAtDistanceK(root.LeftChild, k - 1);
            PrintNodeAtDistanceK(root.RightChild, k - 1);

        }

        public List<int> GetNodesAtDistanceK(int k)
        {
            var nodes = new List<int>();
            GetNodesAtDistanceK(root, k, ref nodes);
            return nodes;
        }
        private void GetNodesAtDistanceK(Node root, int k, ref List<int> nodes)
        {
            if (root == null)
                return;
            if (k == 0)
            {
                nodes.Add(root.Value);
            }
            GetNodesAtDistanceK(root.LeftChild, k - 1, ref nodes);
            GetNodesAtDistanceK(root.RightChild, k - 1, ref nodes);
        }

        public void TraverseLevelOrder()
        {
            var height = Height();
            for (int i = 0; i <= height; i++)
            {
                var nodes = GetNodesAtDistanceK(i);

                foreach (var item in nodes)
                {
                    System.Console.Write(item);
                    System.Console.Write(" ");
                }
                System.Console.WriteLine();
            }
        }

        public int Size()
        {
            return Size(root);
        }
        private int Size(Node root)
        {
            if (root == null)
                return 0;

            return 1 + Size(root.LeftChild) + Size(root.RightChild);
        }

        public int CountLeaves()
        {
            int noOfLeaves = 0;
            CountLeaves(root, ref noOfLeaves);
            return noOfLeaves;
        }
        private void CountLeaves(Node root, ref int noOfLeaves)
        {
            if (root == null)
                return;

            if (root.LeftChild == null && root.RightChild == null)
                noOfLeaves++;

            CountLeaves(root.LeftChild, ref noOfLeaves);
            CountLeaves(root.RightChild, ref noOfLeaves);

        }
    }
}