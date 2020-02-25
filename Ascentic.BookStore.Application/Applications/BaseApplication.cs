using Ascentic.BookStore.Application.Interfaces;
using Ascentic.BookStore.Model.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ascentic.BookStore.Domain.Interfaces;

namespace Ascentic.BookStore.Application.Applications
{
    class BaseApplication : IBaseApplication
    {
        private readonly IMapper mapper;
        private readonly IBaseDomain baseDomain;

        public BaseApplication(IBaseDomain baseDomain, IMapper mapper)
        {
            this.baseDomain = baseDomain;
            this.mapper = mapper;
        }

        public async Task<IBaseDTO> Add(IBaseDTO baseDTO)
        {
            var mappedFrontendData = this.mapper.Map<IEntity>(baseDTO);
            var newlyCreatedBase = await baseDomain.Add(mappedFrontendData);

            var mappedNewBase = this.mapper.Map<IBaseDTO>(newlyCreatedBase);
            return mappedNewBase;
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IBaseDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IBaseDTO Get(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(int key, IBaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }
    }
}
