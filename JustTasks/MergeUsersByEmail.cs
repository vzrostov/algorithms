using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class MergeUsersByEmail
    {
        internal static void Run()
        {
            Dictionary<string, HashSet<string>> users = new Dictionary<string, HashSet<string>>()
            {
                { "user1", new HashSet<string>() { "a@a.com" } },
                { "user2", new HashSet<string>() { "d@d.com", "c@c.com" } },
                { "user3", new HashSet<string>() { "a@a.com", "b@b.com", "q@q.com" } },
                { "user4", new HashSet<string>() { "b@b.com" } },
                { "user5", new HashSet<string>() { "z@z.com", "c@c.com" } },
                { "user6", new HashSet<string>() { "w@w.com" } }
            };
            Dictionary<string, HashSet<string>> newusers = MergeUsersByEmailFunc(users);
        }

        private static Dictionary<string, HashSet<string>> MergeUsersByEmailFunc(Dictionary<string, HashSet<string>> users)
        {
            Dictionary<string, HashSet<string>> newusers = new Dictionary<string, HashSet<string>>();

            var usersAndEmails = users.SelectMany(u => u.Value, (u, e) => new { user = u, email = e } );
            var emails = usersAndEmails.ToLookup(ue => ue.email, ue => ue.user.Key);
            var groupUsers = new List<HashSet<string>>();
            foreach (var email in emails)
            {
                var usersForEmail = new HashSet<string>(emails[email.Key]);
                var findingGroup = groupUsers.FirstOrDefault(set => set.Intersect(usersForEmail).Count() > 0);
                if(findingGroup != null)
                    findingGroup.UnionWith(usersForEmail);
                else
                    groupUsers.Add(usersForEmail);
            }
            foreach(var groups in groupUsers)
            {
                HashSet<string> emails2 = new HashSet<string>();
                var key = groups.First();
                newusers.Add(key, emails2);
                foreach (var user in groups)
                {
                    newusers[key].UnionWith(users[user]);
                }
            }

            return newusers;                
        }
    }
}
