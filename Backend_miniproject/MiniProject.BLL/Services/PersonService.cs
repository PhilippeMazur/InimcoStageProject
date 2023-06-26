using Microsoft.EntityFrameworkCore;
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
    public class PersonService : IPersonService
    {
        private readonly MiniProjectContext _context;

        public PersonService(MiniProjectContext context)        {
            _context = context;
        }


        public Person Create(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(int id)
        {
            var person = _context.Persons
                .Include(p => p.SocialSkills)
                .Include(p => p.SocialAccounts)
                .FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                _context.Persons.Remove(person);
                _context.SaveChanges();
            } else
            {
                throw new KeyNotFoundException();
            }
            
        }

        public List<Person> GetAll()
        {
            var persons = _context.Persons
                .Include(p => p.SocialSkills)
                .Include(p => p.SocialAccounts)
                .ToList();

            return persons;
        }

        public Person GetById(int id)
        {
            var person = _context.Persons
                .Include(p => p.SocialSkills)
                .Include(p => p.SocialAccounts)
                .FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                return person;
            } else
            {
                return null;
            }
        }

        public Person Update(int id,Person updatedPerson)
        {
            var person = _context.Persons
                .Include(p => p.SocialSkills)
                .Include(p => p.SocialAccounts)
                .FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return null;
            }

            person.Firstname = updatedPerson.Firstname;
            person.Lastname = updatedPerson.Lastname;
            person.SocialAccounts = updatedPerson.SocialAccounts;
            person.SocialSkills = updatedPerson.SocialSkills;

            _context.Persons.Update(person);
            _context.SaveChanges();
            return updatedPerson;
        }
    }
}
