using System.Collections.Generic;

namespace MiniProject.DAL.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<SocialSkills> SocialSkills { get; set; } = new List<SocialSkills>();
        public List<SocialAccounts> SocialAccounts { get; set; } = new List<SocialAccounts>();

    }
}
