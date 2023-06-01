namespace POE_ST10031953
{
    public class Step
    {
        public int Order { get; set; }
        public string Description { get; set; }

        public Step()
        {
            
        }

        public Step(int order, string description)
        {
            Order = order;
            Description = description;
        }
    }
}
