using Blocks.Domain.Entities;
using Submission.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Domain.Entities
{
    public class Person : IEntity
    {

        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required EmailAdress Email { get; init; }
        public required string Affiliation { get; init; } 
        public string FullName => $"{FirstName} {LastName}";
        public string? Title { get; init; }
        public int? UserId { get; init; }
        public int Id { get; init; }
        public string TypeDiscriminator { get; init; } = null!;
        public IReadOnlyList<ArticleActor> Actors { get; init; }     = null!;
    }
}
 