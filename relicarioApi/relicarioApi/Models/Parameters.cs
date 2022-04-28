namespace relicarioApi.Models
{
    public class Parameters : ModelBase
    {
        public string Param { get; set; }
        public string Value { get; set; }
        public byte[] Content { get; set; }
        public string Categoria { get; set; }
    }
}
