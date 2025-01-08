namespace CustomerInformation
{
    public class Customer
    {
        public required string ID { get; set; }
        public required string Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public string? Company { get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }
        public Customer()
        {

        }
        public Customer (string id,String name)
        {
            ID = id;
            Name = name;
        }

    }
}
