using Wsr1.Core.EntityModels;

namespace Wsr1.Core
{
    public class DataBaseConnectionContext
    {
        public static EntityModels.EntityContext GetContext()
        {
            return new EntityContext();
        }
    }
}
