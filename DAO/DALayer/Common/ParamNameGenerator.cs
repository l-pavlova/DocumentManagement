using System.Collections.Generic;

namespace DocManagement
{
    public class ParamNameGenerator
    {
        private Dictionary<string, int> paramIndexes;
        public ParamNameGenerator()
        {
            paramIndexes = new Dictionary<string, int>();
        }
        public string GenerateParamName(string condition)
        {
            string currentName = $"@{condition}";
            if (paramIndexes.ContainsKey(currentName))
            {
                paramIndexes[currentName]++;
                currentName += paramIndexes[currentName];
            }
            else
            {
                paramIndexes.Add(currentName, 0);
            }
            return currentName;
        }
    }
}
