using MiniProject.BLL.Interfaces;
using MiniProject.DAL.Contexts;
using MiniProject.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.BLL.Services
{
    internal class SocialSkillsService : ISocialSkillsService
    {
        private readonly MiniProjectContext _context;

        public SocialSkillsService(MiniProjectContext context)
        {
            _context = context;
        }
        public SocialSkills Create(SocialSkills skill)
        {
            var person = _context.SocialSkills.FirstOrDefault(s => s.PersonId == skill.PersonId);
            if (person == null)
            {
                return null;
            } else
            {
                _context.SocialSkills.Add(skill);
                _context.SaveChanges();
                return skill;
            }
        }

        public void Delete(int id)
        {
            var skill = _context.SocialSkills
                .FirstOrDefault(s => s.Id == id);

            if (skill != null)
            {
                _context.SocialSkills.Remove(skill);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public List<SocialSkills> GetAll()
        {
            var skills = _context.SocialSkills.ToList();
            return skills;
        }

        public SocialSkills GetById(int id)
        {
            var skill = _context.SocialSkills.FirstOrDefault(p => p.Id == id);

            if (skill != null)
            {
                return skill;
            } else
            {
                return null;
            }
        }

        public SocialSkills Update(int id, SocialSkills skill)
        {
            var person = _context.SocialSkills.FirstOrDefault(s => s.PersonId == skill.PersonId);
            if (person == null)
            {
                return null;
            }

            var existingSkill = _context.SocialSkills
                .FirstOrDefault(s => s.Id == id);

            existingSkill.Description = skill.Description;

            _context.SocialSkills.Update(existingSkill);
            _context.SaveChanges();
            return skill;
        }
    }
}
