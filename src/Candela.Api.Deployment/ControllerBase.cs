using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Authorization;
using Microsoft.Framework.Configuration;

namespace Candela.Api.Common
{
    public abstract class ControllerBase : Controller
    {
        #region Private fields

        protected ILogger Logger;
        protected IConfiguration Configuration;

        #endregion

        protected ControllerBase(ILogger logger, IConfiguration configuration = null)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger), "Invalid logger.");

            this.Logger = logger;
            this.Configuration = configuration;
        }
    }
}
