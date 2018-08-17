namespace Common
{
    public class MyData
    {
        public string Country { get; set; }
        public string UserId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public override string ToString() => $"{Country}/{UserId}";
    }
}
