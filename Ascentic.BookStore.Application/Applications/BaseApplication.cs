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
    public abstract class BaseApplication<TEntity,TBaseDTO> : IBaseApplication<TEntity, TBaseDTO>
        where TBaseDTO : class, IBaseDTO
        where TEntity : class, IEntity
    {
        private readonly IMapper mapper;
        private readonly IBaseDomain<TEntity> baseDomain;

        public BaseApplication(IBaseDomain<TEntity> baseDomain, IMapper mapper)
        {
            this.baseDomain = baseDomain;
            this.mapper = mapper;
        }

        public async Task<TBaseDTO> Add(TBaseDTO baseDTO)
        {
            var mappedFrontendData = this.mapper.Map<TEntity>(baseDTO);
            var newlyCreatedBase = await baseDomain.Add(mappedFrontendData);

            var mappedNewBase = this.mapper.Map<TBaseDTO>(newlyCreatedBase);
            return mappedNewBase;
        }

        public void Delete(int key)
        {
            this.baseDomain.Delete(key);
        }

        public async Task<IEnumerable<TBaseDTO>> GetAll()
        {
            var obj =await this.baseDomain.GetAll();
            return this.mapper.Map<TBaseDTO[]>(obj);
        }

        public async Task<TBaseDTO> Get(int key)
        {
            return  this.mapper.Map<TBaseDTO>(this.baseDomain.Get(key));
        }

        public void Update(int key, TBaseDTO baseDTO)
        {
            this.baseDomain.Update(key, this.mapper.Map<TEntity>(baseDTO));
        }
    }
}
