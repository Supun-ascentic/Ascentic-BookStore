using Ascentic.BookStore.Domain.Interfaces;
using Ascentic.BookStore.Infrastructure.Interfaces;
using Ascentic.BookStore.Model.Entity;
using Ascentic.BookStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ascentic.BookStore.Domain.Domain
{
    public class RatingDomain : BaseDomain<Rating>,IRatingDomain
    {
        private readonly IUnitOfWork unitOfWork;

        public RatingDomain(IUnitOfWork unitOfWork)
           : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<Rating> Add(Rating entity)
        {
            await this.unitOfWork.RatingRepository.Add(entity);
            await this.unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async void Delete(int key)
        {
            await this.unitOfWork.RatingRepository.Delete(key);
            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task<Rating> Get(int key)
        {
            var entity = await this.unitOfWork.RatingRepository.Get(key);
            return entity;
        }

        public async Task<List<Rating>> GetAll()
        {
            var entity =await this.unitOfWork.RatingRepository.GetAll();
            return entity;
        }

        public void Update(int id, Rating entity)
        {
            this.unitOfWork.RatingRepository.Update(id, entity);
            this.unitOfWork.SaveChangesAsync();
        }

    }
}
