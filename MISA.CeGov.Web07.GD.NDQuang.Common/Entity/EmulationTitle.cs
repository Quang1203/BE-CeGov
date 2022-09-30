using MISA.CeGov.Web07.GD.NDQuang.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.CeGov.Web07.GD.NDQuang.Common.Entity
{
    /// <summary>
    /// Danh hiệu thi đua
    /// </summary>
    [Table("emulationtitle")]
    public class EmulationTitle
    {
        #region Property

        /// <summary>
        /// ID Danh hiệu thi đua
        /// </summary>
        [Key]
        public Guid EmulationTitleID { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Mã Danh hiệu thi đua
        /// </summary>
        public string EmulationTitleCode { get; set; }

        /// <summary>
        /// Tên Danh hiệu thi đua
        /// </summary>
        public string EmulationTitleName { get; set; }

        /// <summary>
        /// Đối tượng khen thưởng( 1:Cá nhân, 2:Tập thể , 3:Cá nhân và tập thể , 4: Hộ gia đình)
        /// </summary>
        public RewardObject RewardObject { get; set; }

        /// <summary>
        /// ID Cấp khen thưởng
        /// </summary>
        public Guid RewardLevelID { get; set; }

        /// <summary>
        /// Tên Cấp khen thưởng
        /// </summary>
        public string RewardLevelName { get; set; }

        /// <summary>
        /// Loại phong trào(1: Thường xuyên , 2:Theo đợt (chuyên đề) )
        /// </summary>
        public MovementType MovementType { get; set; }

        /// <summary>
        /// Trạng thái( 1: Sử dung, 2: Ngưng sử dụng)
        /// </summary>
        public Status Status { get; set; }

       
        #endregion
    }
}
