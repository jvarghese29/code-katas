using System;
using System.Collections.Generic;
using ProjectKanban.Tasks;

namespace ProjectKanban.Utilities
{
    public static class Helper
    {
        public static string GetIntials(string username)
        {
            var words = username.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string result = "";

            foreach (var word in words)
            {
                result += word[0];
            }

            return result.ToUpper();
        }

        public static readonly Dictionary<string, int> StatusOrder = new()
    {
        { TaskStatus.DONE, 0 },
        { TaskStatus.IN_SIGNOFF, 1 },
        { TaskStatus.IN_PROGRESS, 2 },
        { TaskStatus.BACKLOG, 3 }
    };


        public static int GetStatusRank(string status)
        {
            if (string.IsNullOrEmpty(status))
                return int.MaxValue;

            return Helper.StatusOrder.TryGetValue(status, out var rank) ? rank : int.MaxValue;
        }
    }
}
