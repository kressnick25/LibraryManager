using NUnit.Framework;
using BSTreeInterface;
using BSTreeClass;

namespace LibraryManagerTests
{
    public class Tests
    {
		// build a binary search tree
		IBSTree aBSTree = new BSTree();

		[SetUp]
        public void Setup()
        {
			aBSTree.Insert('M');
			aBSTree.Insert('D');
			aBSTree.Insert('G');
			aBSTree.Insert('A');
			aBSTree.Insert('W');
			aBSTree.Insert('P');
		}

        [Test]
        public void Traversal()
        {
			// pre-order traversal
			Assert.DoesNotThrow(() =>
			{
				aBSTree.PreOrderTraverse();
				// in-order traversal
				aBSTree.InOrderTraverse();
				// post-order traversal
				aBSTree.PostOrderTraverse();
			});
		}

		[Test]
		public void Delete()
		{
			// delete a leaf A
			aBSTree.Delete('A');

			Assert.DoesNotThrow(() =>
			{
				// pre-order traversal
				aBSTree.PreOrderTraverse();
				// in-order traversal
				aBSTree.InOrderTraverse();
				// post-order traversal
				aBSTree.PostOrderTraverse();
			});
			
		}

		
		[Test]
		public void Insert()
		{
			// put A back aBStree
			aBSTree.Insert('A');
			// delete a node W, which has only one child
			aBSTree.Delete('W');

			Assert.DoesNotThrow(() =>
			{
				// pre-order traversal
				aBSTree.PreOrderTraverse();
				// in-order traversal
				aBSTree.InOrderTraverse();
				// post-order traversal
				aBSTree.PostOrderTraverse();
			});
			
		}
		

		[Test]
		public void Clear()
		{
			// clear the binary tree
			aBSTree.Clear();
			Assert.DoesNotThrow(() =>
			{
				// pre-order traversal
				aBSTree.PreOrderTraverse();
			});
			
		}

		
    }
}