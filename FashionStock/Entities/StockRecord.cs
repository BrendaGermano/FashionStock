using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStock.Entities
{
    public class StockRecord : BaseEntity
    {
        public int ProductId {  get; set; }
        public int UserId { get; set; }
        public int RecordTypeId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
