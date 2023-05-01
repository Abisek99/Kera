namespace HKCR.Domain.Entities
{
    public class Document
    {
        public Guid DocID { get; set; } = new Guid();
        public string DocType { get; set; }
        public string DocImage { get; set; }
        public ICollection<AddUser> AddUsers { get; set; }
    }
}