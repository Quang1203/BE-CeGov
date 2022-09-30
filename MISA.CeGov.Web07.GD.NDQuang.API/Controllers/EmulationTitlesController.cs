using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CeGov.Web07.GD.NDQuang.API.Core;
using MISA.CeGov.Web07.GD.NDQuang.Common.Entity;
using MISA.CeGov.Web07.GD.NDQuang.Core;

namespace MISA.CeGov.Web07.GD.NDQuang.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmulationTitlesController : BasesController<EmulationTitle>
    {
        #region Field

        private IEmulationTitleService _emulationTitleService;

        #endregion

        #region Constructor

        public EmulationTitlesController(IEmulationTitleService emulationTitleService) : base(emulationTitleService)
        {
            _emulationTitleService = emulationTitleService;
        }

        #endregion
    }
}
