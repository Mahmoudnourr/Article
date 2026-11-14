using Articles.Abstractions.Enums;
using Blocks.Exceptions.Exceptions;

namespace Submission.Domain.Entities;

public partial class Article
{

    public void AssignAuthor(Author author, HashSet<ContributionAreas> contributionAreas,bool IsCorrespondingAuthor)
    {
        var Role = IsCorrespondingAuthor ? UserRoleType.CORAUT : UserRoleType.Author;
        if(Actors.Exists(a => a.PersonId == author.Id && a.Role == Role ))
        {
            throw new DomainException($"Author with id {author.Email} is already assigned to this article as {Role}");
        }
        Actors.Add(new ArticleAuthor
        {
            Role = Role,
            TypeDiscriminator = nameof(ArticleAuthor),
            ContributionAreas = contributionAreas
            ,Person=author
        });
    }
}
