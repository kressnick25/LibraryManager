using LibraryManager.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    /*
     * Represents a collection of movie DVDs
     * Uses a binary tree as a class member to store the movie DVDs
     */
    class MovieCollection
    {
        public TreeNode root;

        public MovieCollection(Movie rootValue)
        {
            this.root = new TreeNode(rootValue);
        }

        private TreeNode find(TreeNode root, string key)
        {
            if (root == null)
                return null;
            if (key == root.Data.Key)
                return root;

            int c = Algorithms.StringCompare(key, root.Data.Key);
            if (c == -1)
                return find(root.LeftChild, key);
            else
                return find(root.RightChild, key);
        }

        /* Computes recursively the height of the binary tree
         * 
         * returns: the height of the tree, or -1 if tree is empty
         * Levitin. pg 183
         */
        private int height(TreeNode rootNode)
        {
            if (rootNode == null)
            {
                return -1;
            }

            return Math.Max(height(root.LeftChild), height(root.RightChild)) + 1;
        }

        private TreeNode remove(TreeNode root, string key)
        {
            if (root == null)
                return root;
            int c = Algorithms.StringCompare(key, root.Data.Key);
            if (c == -1) // key < K(root)
            {
                root.LeftChild = remove(root.LeftChild, key);
            }
            else if (c == 1) // key > K(root)
            {
                root.RightChild = remove(root.RightChild, key);
            }
            else
            {
                if (root.LeftChild == null)
                {
                    return root.RightChild;
                }
                else if (root.RightChild == null)
                {
                    return root.LeftChild;
                }

                root.Data = inOrderSuccessor(root.RightChild);
                root.RightChild = remove(root.RightChild, root.Data.Key);
            }

            return root;
        }

        private Movie inOrderSuccessor(TreeNode root)
        {
            Movie minimum = root.Data;
            while (root.LeftChild != null)
            {
                minimum = root.LeftChild.Data;
                root = root.LeftChild;
            }
            return minimum;
        }

        private TreeNode insert(TreeNode root, Movie data)
        {
            // tree is empty
            if (root == null)
                return new TreeNode(data);
            // recur down tree
            int c = Algorithms.StringCompare(data.Key, root.Data.Key);
            if (c == -1 || c == 0) // key <= K(root)
            {
                root.LeftChild = insert(root.LeftChild, data);
            }
            else // key > K(root)
            {
                root.RightChild = insert(root.RightChild, data);
            }

            return root;
        }

        public Movie Find(string key)
        {
            TreeNode res = find(this.root, key);

            return res.Data;
        }

        public int Height
        {
            get { return height(this.root); }
        }

        public void Remove(string key)
        {
            this.root = remove(this.root, key);
        }

        public void Insert(Movie data)
        {
            if (Find(data.Key) != null)
                throw new ArgumentException($"Node with key [{data.Key}] already exists in tree");
            this.root = insert(this.root, data);
        }
    }

    internal class TreeNode
    {
        public Movie Data { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public TreeNode(Movie data, TreeNode leftChild = null, TreeNode rightChild = null)
        {
            this.Data = data;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }
    }
}
