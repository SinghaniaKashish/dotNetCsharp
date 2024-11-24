namespace JWTAuthorization.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public Product Product { get; set; }
    }
}
