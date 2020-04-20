using System;
using System.Collections.Generic;
using System.Text;
namespace LibraryManager
{
    /*
     * Represents a collection of registered members.
     */
    class MemberCollection
    {
        private Member[] members;
        private int actualSize;
        // size of list
        public int Length
        {
            get { return actualSize; }
        }
        public MemberCollection()
        {
            members = new Member[10];
            actualSize = 0;
        }

        // TODO check this works
        // increase size
        private void increaseSize()
        {
            //Array.Resize<Member>(ref members, this.Length + 10);
            Member[] resizedArray = new Member[this.Length + 10];
            for (int i=0; i < actualSize; i++)
            {
                resizedArray[i] = members[i];
            }
            members = resizedArray;
        }

        // Sort array on insert, dont need to batch insert.
        // allows us to find members more efficiently
        public void Add(Member newMember)
        {
            if (indexOf(newMember.Name) != -1)
                throw new ArgumentException($"User with name [{newMember.}]")
            if (members.Length - actualSize <= 5)
            {
                this.increaseSize();
            }
            // insert at last position
            members[actualSize++] = newMember;
            // sort array using insertion sort (Levitin)
            for (int i=1; i < actualSize; i++)
            {
                Member v = members[i];
                int j = i - 1;
                while (j >= 0 && Algorithms.StringCompare(members[j].Name, newMember.Name) == -1)
                {
                    members[j + 1] = members[j];
                    j = j - 1;
                }
                members[j+1] = v;
            }
        }

        // get a member by name
        public Member Find(string fullName)
        {
            int i = indexOf(fullName);
            if (i == -1)
                throw new KeyNotFoundException($"User with name [{fullName}] was not found in collection.");
            else
                return members[this.indexOf(fullName)];
        }

        // index of member
        public int indexOf(string fullName)
        {
            // use binary search to find index of member with matching fullName (Levitin)
            int l = 0;
            int r = this.Length - 1;
            while (l <= r)
            {
                int m = Math.Abs((l+r)/2);
                if (fullName == members[m].Name)
                    return m;
                else if (Algorithms.StringCompare(fullName, members[m].Name) == -1)
                    r = m - 1;
                else
                    l = m + 1;
            }
            return -1;
        }

        public void Remove(string fullName)
        {
            // Assignment spec does not require the ability to remove members
            throw new NotImplementedException();
        }
    }
}
