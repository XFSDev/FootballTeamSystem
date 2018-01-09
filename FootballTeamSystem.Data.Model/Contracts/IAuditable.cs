using System;

namespace FootballTeamSystem.Data.Model.Contracts
{
    public interface IAuditable
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
