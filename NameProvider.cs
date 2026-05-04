using System.Collections.Generic;
using System.Linq;
using MoreTownNames;

namespace TownNamesMod
{
    public static class NameProvider
    {
        public static List<string> GetCustomNames()
        {
            var raw = TownNamesPlugin.CustomNames.Value;

            return raw
                .Split('\n')
                .Select(n => n.Trim())
                .Where(n => !string.IsNullOrEmpty(n))
                .ToList();
        }
    }
}