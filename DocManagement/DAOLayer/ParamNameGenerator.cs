using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    public class ParamNameGenerator
    {
        public ParamNameGenerator()
        {
            paramIndexes = new Dictionary<string, int>();
        }
        private Dictionary<string, int> paramIndexes; 
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
