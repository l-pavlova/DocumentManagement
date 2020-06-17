using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    public static class ConditionExtension
    {
        public static bool TryCast<T>(this Condition condition, out T result)
        {
            var destinationType = typeof(T);
            if (condition.Value == null)
            {
                result = default(T);

                return false;
            }

            var underlyingType = Nullable.GetUnderlyingType(destinationType) ?? destinationType;

            if (underlyingType == typeof(Guid))
            {
                if (condition.Value is Guid)
                {
                    condition.Value = new Guid("'" + condition.Value as string + "'");
                }
                if (condition.Value is byte[])
                {
                    condition.Value = new Guid(condition.Value as byte[]);
                }
                result = (T)Convert.ChangeType(condition.Value, underlyingType);
                return true;
            }

            result = (T)Convert.ChangeType(condition.Value, underlyingType);
            return true;
        }
    }
}
