using Ascentic.BookStore.Application.Interfaces;
using Ascentic.BookStore.Model.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ascentic.BookStore.Domain.Interfaces;
using Ascentic.BookStore.Model.DTO;
using Ascentic.BookStore.Model.Entity;

namespace Ascentic.BookStore.Application.Applications
{
    public class RatingApplication : BaseApplication<Rating, RatingDTO>,IRatingApplication
    {
        private readonly IMapper mapper;
        private readonly IRatingDomain ratingDomain;

        public RatingApplication(IRatingDomain ratingDomain, IMapper mapper)
            : base(ratingDomain, mapper)
        {
            this.ratingDomain = ratingDomain;
            this.mapper = mapper;
        }

    }
}
