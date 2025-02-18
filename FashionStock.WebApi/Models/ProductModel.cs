using FashionStock.Entities;

namespace FashionStock.WebApi.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public void CalculateQuantity(List<StockRecordModel> stockRecords)
        {
            if (stockRecords == null)
            {
                Quantity = 0;
                return;
            }

            int totalQuantity = 0;
            foreach (var stockRecord in stockRecords)
            {
                if (stockRecord.ProductId == Id)
                {
                    if (stockRecord.RecordTypeId == 2)
                    {
                        totalQuantity += stockRecord.Quantity;
                    }
                    else if (stockRecord.RecordTypeId == 3)
                    {
                        totalQuantity -= stockRecord.Quantity;
                    }
                }
            }
            Quantity = totalQuantity;
        }

        public void AddOrSubtractQuantity(int recordType, StockRecordModel stockRecordModel)
        {
            if (recordType.Equals(3))
            {
                Quantity -= stockRecordModel.Quantity;
            }
            else if (recordType.Equals(2))
            {
                Quantity += stockRecordModel.Quantity;
            }
        }
    }


}
