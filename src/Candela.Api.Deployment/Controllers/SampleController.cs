//#define ENABLE_AUTHORIZATION

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Authorization;
using Microsoft.Framework.Configuration;

using Candela.Api.Common;

namespace Candela.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class SampleController : ControllerBase
    {
        public SampleController(ILogger<SampleController> logger, IConfiguration configuration) : 
            base(logger, configuration)
        {
        }
    }
}
