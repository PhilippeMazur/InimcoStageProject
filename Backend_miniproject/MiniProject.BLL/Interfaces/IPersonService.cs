using MiniProject.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.BLL.Interfaces
{
    public interface IPersonService
    {
        public List<Person> GetAll();
        public Person GetById(int id);
        public Person Create(Person person);
        public Person Update(int id, Person person);
        public void Delete(int id);
    }
}
