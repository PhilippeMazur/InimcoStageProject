namespace MiniProject.DAL.Model
{
    public class SocialAccounts
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public int PersonId { get; set; }
    }
}
