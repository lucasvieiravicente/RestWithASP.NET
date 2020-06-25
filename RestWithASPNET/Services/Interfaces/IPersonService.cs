using RestWithASPNET.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Services.Interfaces
{
    public interface IPersonService
    {
        PersonVO Create(PersonVO PersonVO);
        PersonVO FindById(Guid personId);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO PersonVO);
        void Delete(Guid personId);
    }
}
