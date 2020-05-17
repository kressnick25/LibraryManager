using System;
using System.Collections.Generic;
namespace LibraryManager
{
    /*
     * Represents a collection of registered members.
     */
    public class MemberCollection
    {
        private Member[] members;

        // size of list
        public int Length { get; private set; }

        public MemberCollection()
        {
            members = new Member[10];
            Length = 0;
        }

        // TODO check this works
        // increase size
        private void increaseSize()
        {
            //Array.Resize<Member>(ref members, this.Length + 10);
            Member[] resizedArray = new Member[this.Length + 10];
            for (int i = 0; i < Length; i++)
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
                throw new KeyNotFoundException($"User with name [{newMember}] already in collection");
            if (members.Length - Length <= 5)
            {
                this.increaseSize();
            }
            // insert at last position
            members[Length++] = newMember;
            // sort array using insertion sort (Levitin)
            for (int i = 1; i < Length; i++)
            {
                Member v = members[i];
                int j = i - 1;
                while (j >= 0 && Algorithms.StringCompare(members[j].Name, newMember.Name) == -1)
                {
                    members[j + 1] = members[j];
                    j = j - 1;
                }
                members[j + 1] = v;
            }
        }

        // get a member by name
        public Member Find(string fullName)
        {
            int i = indexOf(fullName);
            if (i == -1)
                throw new KeyNotFoundException($"User with name [{fullName}] was not found in collection.");
            else
                return members[i];
        }

        public Member FindUsername(string userName)
        {
            for (int i = 0; i < Length; i++)
            {
                if (members[i].UserName == userName)
                {
                    return members[i];
                }
            }
            throw new KeyNotFoundException($"User with name [{userName}] was not found in collection.");
        }
        // index of member
        private int indexOf(string fullName)
        {
            // use binary search to find index of member with matching fullName (Levitin)
            int l = 0;
            int r = this.Length - 1;
            while (l <= r)
            {
                int m = Math.Abs((l + r) / 2);
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
