using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.CeGov.Web07.GD.NDQuang.Common.Entity
{
    /// <summary>
    /// Cấp khen thưởng
    /// </summary>
    [Table("rewardlevel")]
    public class RewardLevel
    {
        /// <summary>
        /// ID Cấp khen thưởng
        /// </summary>
        [Key]
        public Guid RewardLevelID { get; set; }

        /// <summary>
        /// MÃ Cấp khen thưởng
        /// </summary>
        public string RewardLevelCode { get; set; }

        /// <summary>
        /// Tên Cấp khen thưởng
        /// </summary>
        public string RewardLevelName { get; set; }

        
    }
}
