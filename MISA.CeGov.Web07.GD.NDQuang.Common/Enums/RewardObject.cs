using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CeGov.Web07.GD.NDQuang.Common.Enums
{
    /// <summary>
    /// Đối tượng khen thưởng( 1:Cá nhân, 2:Tập thể , 3:Cá nhân và tập thể , 4: Hộ gia đình)
    /// </summary>
    public enum RewardObject
    {
        /// <summary>
        /// Cá nhân
        /// </summary>
        Personally = 1,

        /// <summary>
        /// Tập thể
        /// </summary>
        Group = 2,

        /// <summary>
        /// Cá nhân và tập thể
        /// </summary>
        Both = 3,

        /// <summary>
        /// Hộ gia đình
        /// </summary>
        Family = 3
    }
}
