using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsInCSharp.Linked
{
    public class RedBlackBST<TKey,TValue> where TKey:IComparable
    {
        private static readonly bool BLACK = false;
        private static readonly bool RED = true;

        private class Node
        {
            public TKey Key;
            public TValue Value;
            public Node LeftLink;
            public Node RightLink;
            public int Size;
            public bool Color;
        }
        private Node root;
        public int Size()
        {
            return Size(root);
        }

        private int Size(Node node)
        {
            if (node == null) return 0;
            else return node.Size;
        }

        private Node RotateLeft(Node input)
        {
            Node outpt = input.RightLink;
            input.RightLink = outpt.LeftLink;
            outpt.LeftLink = input;
            outpt.Color = input.Color;
            outpt.Size = input.Size;
            input.Color = RED;
            input.Size = 1 + Size(input.LeftLink) + Size(input.RightLink);
            return outpt;
        }

        private Node RotateRight(Node input)
        {
            Node outpt = input.LeftLink;
            input.LeftLink = outpt.RightLink;
            outpt.RightLink = input;
            outpt.Color = input.Color;
            outpt.Size = input.Size;
            input.Color = RED;
            input.Size = 1 + Size(input.LeftLink) + Size(outpt.RightLink);
            return outpt;
        }

        private void FlipColors(Node node)
        {
            node.LeftLink.Color = BLACK;
            node.RightLink.Color = BLACK;
            node.Color = RED;
        }

        private bool isRed(Node node)
        {
            if(node == null)
            {
                return false;
            }
            return node.Color == RED;
        }

        public TValue Get(TKey key)
        {
            Node node = Get(root, key);
            if(node == null)
            {
                throw new InvalidOperationException("Key not found");
            }
            else
            {
                return node.Value;
            }
        }

        private Node Get(Node node,TKey key)
        {
            if(node == null)
            {
                return null;
            }
            int cmp = key.CompareTo(node.Key);
            if(cmp > 0)
            {
                return Get(node.RightLink, key);
            }
            else if(cmp < 0)
            {
                return Get(node.LeftLink, key);
            }
            else
            {
                return node;
            }
        }

        public void Put(TKey key,TValue value)
        {
            root = Put(root, key, value);
            root.Color = BLACK;
        }

        private Node Put(Node node,TKey key,TValue value)
        {
            if(node == null)
            {
                return new Node()
                {
                    Key = key,
                    Value = value,
                    Color = RED,
                    Size = 1
                };
            }
            int cmp = key.CompareTo(node.Key);
            if(cmp > 0)
            {
                node.RightLink = Put(node.RightLink, key, value);
            }
            else if(cmp < 0)
            {
                node.LeftLink = Put(node.LeftLink, key, value);
            }
            else
            {
                node.Value = value;
            }
            if(isRed(node.RightLink) && !isRed(node.LeftLink))
            {
                RotateLeft(node);
            }
            if(isRed(node.LeftLink) && isRed(node.LeftLink.LeftLink))
            {
                RotateRight(node);
            }
            if(isRed(node.LeftLink) && isRed(node.RightLink))
            {
                FlipColors(node);
            }
            node.Size = 1 + Size(node.LeftLink) + Size(node.RightLink);
            return node;
        }
    }
}
