using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersTable.Helpers
{
    /// <summary>
    /// Exposes various constants used by API controllers.
    /// </summary>
    public static class ApiControllerConsts
    {
        /// <summary>
        /// Base root.
        /// </summary>
        public const string BaseRoute = "api/";

        /// <summary>
        /// The name of the route usually used by controllers.
        /// </summary>
        public const string StandardRoute = BaseRoute + "[controller]";
    }
}
