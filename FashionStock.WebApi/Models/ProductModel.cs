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

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }

            set
            {
                _quantity = Math.Max(0, value);
            }

        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


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

        public void UndoAddOrSubtractQuantity(int recordType, int quantity)
        {

            if (recordType == 3)
            {
                Quantity += quantity;
            }
            else if (recordType == 2)
            {
                Quantity -= quantity;
            }
        }

        //public void CalculateQuantity(List<StockRecordModel> stockRecords)
        //{
        //    if (stockRecords == null)
        //    {
        //        Quantity = 0;
        //        return;
        //    }

        //    int totalQuantity = 0;
        //    foreach (var stockRecord in stockRecords)
        //    {
        //        if (stockRecord.ProductId == Id)
        //        {
        //            if (stockRecord.RecordTypeId == 2)
        //            {
        //                totalQuantity += stockRecord.Quantity;
        //            }
        //            else if (stockRecord.RecordTypeId == 3)
        //            {
        //                totalQuantity -= stockRecord.Quantity;
        //            }
        //        }
        //    }
        //    Quantity = totalQuantity;
        //}

    }
}
