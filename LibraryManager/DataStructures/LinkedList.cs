using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DataStructures
{
    class LinkedList
    {
        private Node<WithKey> head;

        public LinkedList() { }

        public WithKey Get(string key)
        {
            if (head == null)
                throw new ArgumentException($"Item with key [{key}] not found.");

            Node<WithKey> n = head.next;
            // go to end of list
            while (n.next != null)
            {
                if (n.data.Key == key)
                    return n.data;
                n = n.next;
            }
            // check last node
            if (n.data.Key == key)
                return n.data;
            
            throw new ArgumentException($"Item with key[{key}] not found,");
        }

        // insert to end of list
        public void Insert(WithKey data)
        {
            Node<WithKey> new_node = new Node<WithKey>(data);
            if (head == null)
            {
                head = new_node;
                return;
            }
            // Go to end of list
            Node<WithKey> temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            // add new node as child of current node
            temp.next = new_node;

        }

        // delete node from list
        public void Delete(string key)
        {
            Node<WithKey> temp = head;
            Node<WithKey> prev = null;
            if (temp != null  && temp.data.Key == key)
            { // Delete from front
                head = temp.next;
                return;
            }
            // traverse list to find key
            while (temp != null && temp.data.Key != key)
            {
                prev = temp;
                temp = temp.next;
            }
            if (temp == null)
                return;
            // if node was last node, set prev.next to null
            prev.next = temp.next;
        }
    }

    internal class Node<T>
    {
        internal T data;
        internal Node<T> next;

        public Node(T data)
        {
            this.data = data;
            next = null;
        }
    }
}
