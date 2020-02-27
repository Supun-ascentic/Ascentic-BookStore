

namespace Ascentic.BookStore.Application.Interfaces
{
    using Ascentic.BookStore.Model.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBaseApplication<IEntity,IBaseDTO>
    {

        Task<IBaseDTO> Add(IBaseDTO baseDTO);

        Task<IEnumerable<IBaseDTO>> GetAll();

        void Delete(int key);

        void Update(int key,IBaseDTO baseDTO);

        Task<IBaseDTO> Get(int key);

    }
}




