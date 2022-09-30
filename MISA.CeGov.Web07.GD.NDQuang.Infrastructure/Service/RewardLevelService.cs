using MISA.CeGov.Web07.GD.NDQuang.API.Core;
using MISA.CeGov.Web07.GD.NDQuang.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CeGov.Web07.GD.NDQuang.Infrastructure
{
    public class RewardLevelService : BaseService<RewardLevel>, IRewardLevelService
    {
        #region Field
        private IRewardLevelRepository _rewardLevelRepository;

        #endregion

        #region Constructor

        public RewardLevelService(IRewardLevelRepository rewardLevelRepository) : base(rewardLevelRepository)
        {
            _rewardLevelRepository = rewardLevelRepository;
        }

        #endregion
    }
}
