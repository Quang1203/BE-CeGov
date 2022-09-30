using MISA.CeGov.Web07.GD.NDQuang.API.Core;
using MISA.CeGov.Web07.GD.NDQuang.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CeGov.Web07.GD.NDQuang.Infrastructure
{
    public class EmulationTitleService : BaseService<EmulationTitle>, IEmulationTitleService
    {
        #region Field
        private IEmulationTitleRepository _emulationTitleRepository;

        #endregion

        #region Constructor

        public EmulationTitleService(IEmulationTitleRepository emulationTitleRepository) : base(emulationTitleRepository)
        {
            _emulationTitleRepository = emulationTitleRepository;
        }
        #endregion
    }
}
