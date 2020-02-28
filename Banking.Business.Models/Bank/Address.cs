namespace Banking.Business.Models
{
    public class Address
    {
        //public Address() { }
        //public Address(int addressId) => AddressId = addressId;
        public int Id { get; set; }
        //public int AddressType { get; set; }
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
