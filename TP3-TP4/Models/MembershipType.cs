namespace TP3.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        public float SignUpFee { get; set; }
        public int DurationInMonth { get; set; }
        public float DiscountRate { get; set; }

        public string? Name { get; set; }

        //Navigation Property
        public List<Customer>? Customers { get; set; }
    }
}
