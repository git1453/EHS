namespace EHS.Entities
{
    [System.Obsolete]
    public partial class EhsQuestion : BaseEntity
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
