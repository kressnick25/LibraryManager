using BSTreeInterface;
using BSTreeClass;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace LibraryManager
{
    public class MovieCollection
    {
        private TreeNode root;

        public MovieCollection()
        {
            root = null;
        }

        public Movie Get(string title)
        {
            return get(title, root);
        }

        private Movie get(string title, TreeNode n)
        {
            if (n == null)
                throw new KeyNotFoundException($"Movie with title [{title}] is already on loan or does not exist");
            if (Algorithms.StringCompare(title, n.Data.Title) == 0)
                return n.Data;
            else
                if (Algorithms.StringCompare(title, n.Data.Title) < 0)
                return get(title, n.Left);
            else
                return get(title, n.Right);
        }

        //public Movie Get(string title)
        //{
        //    return get(title, root);
        //}

        //private Movie get(string title, TreeNode n)
        //{
        //    if (n == null)
        //        throw new KeyNotFoundException($"Movie with title [{title}] does not exist");

        //    if (Algorithms.StringCompare(title, n.Data.Title) == 0)
        //        return n.Data;
        //    else
        //        if (Algorithms.StringCompare(title, n.Data.Title) < 0)
        //        return get(title, n.Left);
        //    else
        //        return get(title, n.Right);

        //}

        public bool Exists(string title)
        {
            try
            {
                get(title, root);
                return true;
            }catch
            {
                return false;
            }
        }

        public void Add(Movie movie)
        {
            if (root == null)
            {
                root = new TreeNode(movie);
            }
            else
            {
                // if already a copy of movie in collection, add a copy.
                if (Exists(movie.Title))
                {
                    Get(movie.Title).CoppiesAvailable++;
                }else
                {
                    add(movie, root);
                }
            }
        }

        private void add(Movie movie, TreeNode n)
        {
            if (Algorithms.StringCompare(movie.Title, n.Data.Title) < 0)
            {
                if (n.Left == null)
                    n.Left = new TreeNode(movie);
                else
                    add(movie, n.Left);
            }
            else
            {
                if (n.Right == null)
                    n.Right = new TreeNode(movie);
                else
                    add(movie, n.Right);
            }
        }

        public void Delete(string title)
        {
            TreeNode n = root;
            TreeNode parent = null;
            while (n != null && Algorithms.StringCompare(title, n.Data.Title) != 0)
            {
                parent = n;
                if (Algorithms.StringCompare(title, n.Data.Title) < 0)
                    n = n.Left;
                else
                    n = n.Right;
            }

            if (n != null)
            {
                if (n.Left != null && n.Right != null)
                {
                    if (n.Left.Right == null)
                    {
                        n.Data = n.Left.Data;
                        n.Left = n.Left.Left;
                    }
                    else
                    {
                        TreeNode p = n.Left;
                        TreeNode pp = n;
                        while(p.Right != null)
                        {
                            pp = p;
                            p = p.Right;
                        }
                        n.Data = p.Data;
                        pp.Right = p.Left;
                    }
                }
                else
                {
                    TreeNode c;
                    if (n.Left != null)
                        c = n.Left;
                    else
                        c = n.Right;

                    // remove node pt
                    if (n == root)
                        root = c;
                    else
                    {
                        if (n == parent.Left)
                            parent.Left = c;
                        else
                            parent.Right = c;
                    }
                }
            }
        }

        public void Clear()
        {
            root = null;
        }

        public void PrintMovies(bool descending)
        {
            InOrderTraverse(root);
            Console.WriteLine();
        }

        private void InOrderTraverse(TreeNode n)
        {
            if (n != null)
            {
                InOrderTraverse(n.Left);
                Console.Write(n.Data);
                InOrderTraverse(n.Right);
            }
        }

        public int Count()
        {
            int count = 0;
            if (root != null)
                count = Count(root);
            return count;
        }
        private int Count(TreeNode node)
        {
            int count = 1;
            if (node.Left != null)
                count += Count(node.Left);
            if (node.Right != null)
                count += Count(node.Right);
            return count;
        }
    }

    public class TreeNode
    {
        public Movie Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode(Movie movie)
        {
            Data = movie;
            Left = null;
            Right = null;
        }
    }
}
