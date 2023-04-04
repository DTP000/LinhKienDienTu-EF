using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinhKienDienTu.Common
{
    public enum OrderStatus
    {
        [Display(Name = "Chờ xác nhận")]
        CHO_XAC_NHAN = 1,
        [Display(Name = "Đã xác nhận")]
        DA_XAC_NHAN = 2,
        [Display(Name = "Đã giao")]
        DA_GIAO = 3,
        [Display(Name = "Đã hủy đơn")]
        DA_HUY_DON = 4,
    }

    public enum IsDeleted
    {
        [Display(Name = "Chưa xóa")]
        CHUA_XOA = 0,
        [Display(Name = "Đã xóa")]
        DA_XOA = 1,
    }
}
