using FashionStock.Entities;
using static MudBlazor.Colors;

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

        public void CalculateFinalQuantity(List<StockRecordModel> stockRecords)
        {

            Quantity = 0;

            foreach (var record in stockRecords)
            {

                if (record.ProductId == Id && record.IsDeleted == false)
                {

                    AddOrSubtractQuantity(record.RecordTypeId, record);
                }
            }

            if (Quantity < 0)
            {
                Quantity = 0;
            }
        }

        public void AddOrSubtractQuantity(long recordType, StockRecordModel stockRecordModel)
        {
           
            if (recordType == 2)
            {
                Quantity += stockRecordModel.Quantity;
            }
            
            else if (recordType == 3)
            {
                Quantity -= stockRecordModel.Quantity;
            }
        }

        public void UndoAddOrSubtractQuantity(long recordType, int quantity)
        {
            
            if (recordType == 2)
            {
                Quantity -= quantity;
            }
            
            else if (recordType == 3)
            {
                Quantity += quantity;
            }
        }


    }
}
