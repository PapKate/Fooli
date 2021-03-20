using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fooli
{
    /// <summary>
    /// Helper - additional methods for all the controllers
    /// </summary>
    public static class ControllersHelper
    {
        public static bool SaveChanges(FooliDBContext context)
        {
            // Saves the changes if there are any
            return (context.SaveChanges() >= 0);
        }

    }
}
