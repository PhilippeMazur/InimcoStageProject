using MiniProject.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.BLL.Interfaces
{
    public interface ISocialAccountsService
    {
        public List<SocialAccounts> GetAll();
        public SocialAccounts GetById(int id);
        public SocialAccounts Create(SocialAccounts account);
        public SocialAccounts Update(int id, SocialAccounts account);
        public void Delete(int id);
    }
}
