namespace MobileRecharge.SupportModels
{
    public class SupRecharge
    {
        public int Id { get; set; }
        public double? Minutes { get; set; }
        public double? Data { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int RechargeTypeId { get; set; }
    }
}
