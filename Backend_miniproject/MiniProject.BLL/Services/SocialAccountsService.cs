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
    internal class SocialAccountsService : ISocialAccountsService
    {
        private readonly MiniProjectContext _context;

        public SocialAccountsService(MiniProjectContext context)
        {
            _context = context;
        }
        public SocialAccounts Create(SocialAccounts account)
        {
            var person = _context.SocialAccounts.FirstOrDefault(a => a.PersonId == account.PersonId);
            if (person == null)
            {
                return null;
            } else
            {
                _context.SocialAccounts.Add(account);
                _context.SaveChanges();
                return account;
            }
        }

        public void Delete(int id)
        {
            var account = _context.SocialAccounts
                .FirstOrDefault(a => a.Id == id);

            if (account != null)
            {
                _context.SocialAccounts.Remove(account);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public List<SocialAccounts> GetAll()
        {
            var accounts = _context.SocialAccounts.ToList();
            return accounts;
        }

        public SocialAccounts GetById(int id)
        {
            var skill = _context.SocialAccounts.FirstOrDefault(a => a.Id == id);
            if(skill != null)
            {
                return skill;
            } else
            {
                return null;
            }
        }

        public SocialAccounts Update(int id, SocialAccounts account)
        {
            var existingAccount = _context.SocialAccounts
                .FirstOrDefault(a => a.Id == id);

            if (existingAccount == null)
            {
                return null;
            }

            existingAccount.Type = account.Type;
            existingAccount.Address = account.Address;

            _context.SocialAccounts.Update(existingAccount);
            _context.SaveChanges();
            return account;
        }
    }
}
