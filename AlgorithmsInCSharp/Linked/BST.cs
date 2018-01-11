using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Linked
{
    public class BST<TKey,TValue> where TKey:IComparable
    {
        private Node root;
        private class Node
        {
            public TKey Key;
            public TValue Value;
            public int Size;
            public Node LeftLink;
            public Node RightLink;
        }
        public int Size()
        {
            return Size(root);
        }

        private int Size(Node node)
        {
            if(node == null)
            {
                return 0;
            }
            else
            {
                return node.Size;
            }
        }

        public TValue Get(TKey key)
        {
            Node node = Get(root, key);
            if(node == null)
            {
                throw new InvalidOperationException("Key Not Found");
            }
            else
            {
                return node.Value;
            }
        }

        private Node Get(Node node,TKey key)
        {
            if(node == null) { return null; }
            int cmp = key.CompareTo(node.Key);
            if(cmp == 0)
            {
                return node;
            }
            else if(cmp > 0)
            {
                return Get(node.RightLink, key);
            }
            else
            {
                return Get(node.LeftLink, key);
            }
        }

        public void Put(TKey key,TValue value)
        {
            root = Put(root, key, value);
        }

        private Node Put(Node node,TKey key,TValue value)
        {
            if(node == null)
            {
                return new Node()
                {
                    Key = key,
                    Value = value,
                    Size = 1
                };
            }
            int cmp = key.CompareTo(node.Key);
            if(cmp == 0)
            {
                node.Value = value;
            }
            else if(cmp > 0)
            {
                node.RightLink = Put(node.RightLink, key, value);
            }
            else
            {
                node.LeftLink = Put(node.LeftLink, key, value);
            }
            node.Size = Size(node.LeftLink) + Size(node.RightLink) + 1;
            return node;
        }

        public TKey Min()
        {
            return Min(root).Key;
        }
        private Node Min(Node node)
        {
            if(node.LeftLink == null) { return node; }
            return Min(node.LeftLink);
        }

        public TKey Floor(TKey key)
        {
            Node node = Floor(root, key);
            if(node == null)
            {
                throw new InvalidOperationException("No Match Found");
            }
            return node.Key;
        }

        private Node Floor(Node node,TKey key)
        {
            if(node == null) { return null; }
            int cmp = key.CompareTo(node.Key);
            if(cmp == 0) { return node; }
            if(cmp < 0)
            {
                return Floor(node.LeftLink, key);
            }
            Node tRight = Floor(node.RightLink, key);
            if(tRight != null)
            {
                return tRight;
            }
            else
            {
                return node;
            }
        }

        public TKey GetKeyFromRank(int rank)
        {
            Node node = GetKeyFromRank(root, rank);
            if(node == null)
            {
                throw new InvalidOperationException("Key Not found");
            }
            return node.Key;
        }

        private Node GetKeyFromRank(Node node,int rank)
        {
            if(node == null)
            {
                return null;
            }
            int nodeSize = Size(node.LeftLink);
            if(nodeSize > rank)
            {
                return GetKeyFromRank(node.LeftLink, rank);
            }
            else if(nodeSize < rank)
            {
                return GetKeyFromRank(node.RightLink, rank - nodeSize - 1);
            }
            else
            {
                return node;
            }
        }

        public int GetRankOfKey(TKey key)
        {
            return GetRankOfKey(root, key);
        }

        private int GetRankOfKey(Node node,TKey key)
        {
            if (node == null) { return 0; }
            int cmp = key.CompareTo(node.Key);
            if(cmp == 0)
            {
                return Size(node.LeftLink);
            }
            else if (cmp > 0)
            {
                return Size(node.LeftLink) + 1 + GetRankOfKey(node.RightLink, key);
            }
            else
            {
                return GetRankOfKey(node.LeftLink, key);
            }
        }

        public void DeleteMin()
        {
            root = DeleteMin(root);
        }

        private Node DeleteMin(Node node)
        {
            if(node.LeftLink == null)
            {
                return node.RightLink;
            }
            node.LeftLink = DeleteMin(node.LeftLink);
            node.Size = Size(node.LeftLink) + Size(node.RightLink) + 1;
            return node;
        }
    }
}
