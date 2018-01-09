using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FootballTeamSystem.Data.Model.Contracts;

namespace FootballTeamSystem.Data.Model.Abstraction
{
    public abstract class DataModel: IAuditable, IDeletable
    {
        protected DataModel()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]

        public DateTime? DeletedOn { get; set; }
    }
}
