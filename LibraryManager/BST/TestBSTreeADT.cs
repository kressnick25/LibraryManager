// File: TestBSTreeADT.cs
// Test the BTree ADT
// Maolin Tang
// 25 March 2006

using System;
using BSTreeInterface;
using BSTreeClass;

public class TestBSTreeADT
{
	static public void Main()
	{
		// build a binary search tree
		IBSTree aBSTree = new BSTree();
		aBSTree.Insert('M');
		aBSTree.Insert('D');
		aBSTree.Insert('G');
		aBSTree.Insert('A');
		aBSTree.Insert('W');
		aBSTree.Insert('P');

		// pre-order traversal
		aBSTree.PreOrderTraverse();
		// in-order traversal
		aBSTree.InOrderTraverse();
		// post-order traversal
		aBSTree.PostOrderTraverse();

		// delete a leaf A
		aBSTree.Delete('A');

		// pre-order traversal
		aBSTree.PreOrderTraverse();
		// in-order traversal
		aBSTree.InOrderTraverse();
		// post-order traversal
		aBSTree.PostOrderTraverse();

		// put A back aBStree
		aBSTree.Insert('A');
		// delete a node W, which has only one child
		aBSTree.Delete('W');

		// pre-order traversal
		aBSTree.PreOrderTraverse();
		// in-order traversal
		aBSTree.InOrderTraverse();
		// post-order traversal
		aBSTree.PostOrderTraverse();

		// clear the binary tree
		aBSTree.Clear();
		
		// pre-order traversal
		aBSTree.PreOrderTraverse();

	}
}

        















