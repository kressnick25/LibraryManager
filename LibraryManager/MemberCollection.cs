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
        public int Length { get; private set; }

        public MemberCollection()
        {
            members = new Member[10];
            Length = 0;
        }

        
        private void IncreaseSize()
        {
            Member[] resizedArray = new Member[this.Length + 10];
            for (int i = 0; i < Length; i++)
            {
                resizedArray[i] = members[i];
            }
            members = resizedArray;
        }

        /// <summary>
        /// Add a new Member to the List.
        /// Performs sort on insert function so that List remains sorted internally.
        /// </summary>
        /// <param name="newMember">new Member</param>
        public void Add(Member newMember)
        {
            if (indexOf(newMember.Name) != -1)
                throw new KeyNotFoundException($"User with name [{newMember}] already in collection");
            if (members.Length - Length <= 5)
            {
                this.IncreaseSize();
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
                    j--;
                }
                members[j + 1] = v;
            }
        }

        /// <summary>
        /// Find a Member using the Member's full name
        /// </summary>
        /// <param name="fullName">Member's full name ie. "Jane Doe"</param>
        /// <returns>The corresponding Member object that matches the username</returns>
        public Member Find(string fullName)
        {
            int i = indexOf(fullName);
            if (i == -1)
                throw new KeyNotFoundException($"User with name [{fullName}] was not found in collection.");
            else
                return members[i];
        }

        /// <summary>
        /// Find a Member using the Member's username
        /// </summary>
        /// <param name="userName">Member's username string ie. "DoeJane"</param>
        /// <returns>The corresponding Member object that matches the username</returns>
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
        
        /// <summary>
        /// Get the index in the array of a Member using the members fullname string.
        /// Uses binary search to achieve average time complexity of O(log n)
        /// </summary>
        /// <param name="fullName">Full name of Member</param>
        /// <returns>Number of the matching members index in the interanal array</returns>
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
    }
}
