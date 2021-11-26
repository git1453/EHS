namespace EHS.Entities
{
    public partial class EhsQuestion
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Levels { get; set; }
        public string Answer { get; set; }
        public int Belongtosection { get; set; }
        public string Belongtolib { get; set; }
        public string Optionanalysis { get; set; }
    }
}
