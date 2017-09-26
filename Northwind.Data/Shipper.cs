using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data
{
    [Table("Shippers")]
    public class Shipper
    {
        #region Column Mappings
        [Key]
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        #endregion

        #region Navigational Properties
        public virtual ICollection<Order> Orders { get; set; }
        #endregion
    }
}