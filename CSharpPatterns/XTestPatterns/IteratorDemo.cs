using System;
using System.Linq;
using CSharpPatterns.IteratorPattern;
using Microsoft.VisualStudio.TestPlatform.Common.DataCollection;
using NUnit.Framework;

namespace XTestPatterns
{
    [TestFixture]
    public class IteratorDemo
    {
        [Test]
        public void ManualIteratorTest()
        {
            var root = new Node<int>(1,new Node<int>(2),new Node<int>(3));

            //var it = new InOrderIterator<int>(root);
            //while (it.MoveNext())
            //{
            //    Console.Write($"{it.Current.Value},");
            //}

            //Console.WriteLine();

            //var tree = new BinaryTree<int>(root);

            //Console.WriteLine(string.Join(",",tree.InOrder.Select(x=>x.Value)));


            //foreach (var node in tree)
            //{
            //    Console.WriteLine($"{node.Value} - ");
            //}

            Console.WriteLine("Pre Order");

            
            //Console.WriteLine(string.Join(",",root.PreOrder.Select(x=>x.Value)));
            root.ParentNode = root.LeftNode;
            foreach (var node in root)
            {
                Console.WriteLine(node.Value);
            }
        }

    }
}
