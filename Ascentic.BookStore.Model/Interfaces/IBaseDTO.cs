using System;

namespace Ascentic.BookStore.Model.Interfaces
{
    public interface IBaseDTO
    {
        public int ID { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
