namespace Banking.Business.Models.Bank
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }

    }
}
