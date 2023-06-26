using MiniProject.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.BLL.Interfaces
{
    public interface ISocialSkillsService
    {
        public List<SocialSkills> GetAll();
        public SocialSkills GetById(int id);
        public SocialSkills Create(SocialSkills skill);
        public SocialSkills Update(int id, SocialSkills skill);
        public void Delete(int id);
    }
}
