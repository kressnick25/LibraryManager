using System;
using System.Collections.Generic;

namespace LibraryManager
{
    // Represents a collection of movie DVD's store Movie objects
    public class MovieCollection
    {
        private TreeNode root;

        // Default contructor
        public MovieCollection()
        {
            root = null;
        }

        /// <summary>
        /// Return a Movie stored in this collection
        /// </summary>
        /// <param name="title">Title of the Movie</param>
        /// <returns>Movie object that matches title parameter</returns>
        public Movie Get(string title)
        {
            return Get(title, root);
        }

        /// <summary>
        /// Recursively traverse the Binary Search Tree to find a Movie with a matching title string.
        /// </summary>
        /// <param name="title">Title of the Movie</param>
        /// <param name="n">Current TreeNode to compare</param>
        /// <returns>Movie with matching title or throws KeyNotFound Exception</returns>
        private Movie Get(string title, TreeNode n)
        {
            if (n == null)
                throw new KeyNotFoundException($"Movie with title [{title}] is already on loan or does not exist");
            if (Algorithms.StringCompare(title, n.Data.Title) == 0)
                return n.Data;
            else
                if (Algorithms.StringCompare(title, n.Data.Title) < 0)
                return Get(title, n.Left);
            else
                return Get(title, n.Right);
        }

        /// <summary>
        /// Check if a Movie exists in this collection
        /// </summary>
        /// <param name="title">Title of the movie</param>
        /// <returns>True if the Movie is found, else false</returns>
        public bool Exists(string title)
        {
            try
            {
                Get(title, root);
                return true;
            }catch
            {
                return false;
            }
        }

        /// <summary>
        /// Add a new Movie to this collection.
        /// If an existing Movie is found with the same title, a copy is added to the existing movie.
        /// </summary>
        /// <param name="movie">A Movie object</param>
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
                    Add(movie, root);
                }
            }
        }

        /// <summary>
        /// Recursively traverse the BST to insert a new Movie at the correct position
        /// </summary>
        /// <param name="movie">Movie object to insert</param>
        /// <param name="n">Current TreeNode</param>
        private void Add(Movie movie, TreeNode n)
        {
            if (Algorithms.StringCompare(movie.Title, n.Data.Title) < 0)
            {
                if (n.Left == null)
                    n.Left = new TreeNode(movie);
                else
                    Add(movie, n.Left);
            }
            else
            {
                if (n.Right == null)
                    n.Right = new TreeNode(movie);
                else
                    Add(movie, n.Right);
            }
        }

        /// <summary>
        /// Remove a Movie object from this collection.
        /// </summary>
        /// <param name="title">Title string of the Movie to be removed</param>
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

        /// <summary>
        /// Delete this collection entirely.
        /// </summary>
        public void Clear()
        {
            root = null;
        }

        /// <summary>
        /// Print all Movies currently in this collection.
        /// </summary>
        public void PrintMovies()
        {
            InOrderTraverse(root);
            Console.WriteLine();
        }

        /// <summary>
        /// Recursively traverse the BST and print each Movie.
        /// </summary>
        /// <param name="n">The current TreeNode</param>
        private void InOrderTraverse(TreeNode n)
        {
            if (n != null)
            {
                InOrderTraverse(n.Left);
                Console.Write(n.Data);
                InOrderTraverse(n.Right);
            }
        }
    
        /// <summary>
        /// Get the number of Movies currently in this collection.
        /// </summary>
        /// <returns>Number of Movies currently in this collection.</returns>
        public int Count()
        {
            int count = 0;
            if (root != null)
                count = Count(root);
            return count;
        }

        /// <summary>
        /// Recursively traverse the BST to count all existing Movies
        /// </summary>
        /// <param name="node">The current TreeNode</param>
        /// <returns>The number of objects currently in the BST</returns>
        private int Count(TreeNode node)
        {
            int count = 1;
            if (node.Left != null)
                count += Count(node.Left);
            if (node.Right != null)
                count += Count(node.Right);
            return count;
        }

        /// <summary>
        /// Flatten the BST to an array of Movies
        /// </summary>
        /// <returns>A Movie Array containing all the Movies in the BST, sorted alphabetically</returns>
        public Movie[] ToArray()
        {
            DataStructures.List<Movie> L = new DataStructures.List<Movie>();
            ArrayTraverse(root, ref L);

            return L.ToArray();
        }

        /// <summary>
        ///  Recursively traverse the BST, adding each object to the passed list
        /// </summary>
        /// <param name="n">The current TreeNode</param>
        /// <param name="list">Reference to the List to add the Movies to</param>
        private void ArrayTraverse(TreeNode n, ref DataStructures.List<Movie> list)
        {
            if (n != null)
            {
                ArrayTraverse(n.Left, ref list);
                list.Add(n.Data);
                ArrayTraverse(n.Right, ref list);
            }
        }
    }

    // Represents a Node in a Binary Search Tree
    public class TreeNode
    {
        public Movie Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        
        // Default constructor
        public TreeNode(Movie movie)
        {
            Data = movie;
            Left = null;
            Right = null;
        }
    }
}
