using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStock.Entities
{
    public class StockRecord : BaseEntity
    {
        public long ProductId {  get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public long RecordTypeId { get; set; }
        public RecordType RecordType { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
