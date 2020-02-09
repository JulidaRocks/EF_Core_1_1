namespace Data.Entities
{
    public class User : BaseEntity
    {
        public string AuthID { get; set; }
        public string Name { get; set; }
        public string ProfilePicUrl { get; set; }
        public virtual Account Account { get; set; }
    }
}
