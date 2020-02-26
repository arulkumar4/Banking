namespace Banking.Business.Models.Account
{
    public class CustomerAddress
    {
        public CustomerAddress() { }
        public CustomerAddress(int addressId) => AddressId = addressId;
        public int AddressId { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public bool Validate()
        {
            var isValid = false;
            if (PostalCode == null) isValid = false;
            return isValid;
        }

    }
}
