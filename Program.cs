using System;

namespace NonLinearDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            BTree tree = new BTree();

            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(10);

            //tree.PreOrderTraversal();
            // System.Console.WriteLine(tree.Height());
            //System.Console.WriteLine(tree.Min()); 
            BTree tree1 = new BTree(); 

            tree1.Insert(7);
            tree1.Insert(19);
            tree1.Insert(1);
            tree1.Insert(6);
            tree1.Insert(9);
            tree1.Insert(8);
            tree1.Insert(10);
            tree1.Insert(0);
            // tree1.PreOrderTraversal();
            // tree.PreOrderTraversal();
            // Console.WriteLine(tree.IsEqual(tree1));
        //    tree.Swap(); 
            // Console.WriteLine(tree.PrintKthNode(3));
            // tree1.GetNodesAtDistanceK(2);
            // tree1.TraverseLevelOrder();
            // foreach( var item in tree1.GetNodesAtDistanceK(9)){
            //     System.Console.WriteLine(item);
            // }
            // System.Console.WriteLine(tree1.Size());
            // System.Console.WriteLine(tree1.CountLeaves());
            // System.Console.WriteLine(tree1.Max());
            // System.Console.WriteLine(tree1.Contains(8));
            // System.Console.WriteLine(tree1.AreSiblings(1,19));
            foreach(var item in tree1.GetAncestors(6)){
                System.Console.WriteLine(item);
            }
        }
    }
}
