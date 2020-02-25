

namespace Ascentic.BookStore.Application.Interfaces
{
    using Ascentic.BookStore.Model.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBaseApplication
    {

        Task<IBaseDTO> Add(IBaseDTO baseDTO);

        IEnumerable<IBaseDTO> GetAll();

        void Delete(int key);

        void Update(int key, IBaseDTO baseDTO);

        IBaseDTO Get(int key);

    }
}




