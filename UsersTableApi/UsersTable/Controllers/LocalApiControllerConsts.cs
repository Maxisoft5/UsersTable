using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersTable.Helpers;

namespace UsersTable.Controllers
{
    /// <summary>
    /// Exposes various constants used by API controllers.
    /// </summary>
    static class LocalApiControllerConsts
    {
        /// <summary>
        /// Base root.
        /// </summary>
        public const string BaseRoute = ApiControllerConsts.BaseRoute;

        /// <summary>
        /// The name of the route usually used by controllers.
        /// </summary>
        public const string StandardRoute = BaseRoute + "[controller]";

    }
}
