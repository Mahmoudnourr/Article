using Articles.Abstractions;
using Articles.Abstractions.Enums;
using Blocks.Domain;
using FluentValidation;
using MediatR;

namespace Submission.Application.Features.CreateArticle;

public record CreateArticleCommand 
    (
       int JournalId,
       string Title,
       string Scope,
       ArticleType ArticleType
    ) : IAuditableAction,IRequest<IdResponse> { 

    public int CreatedById { get; set; }
    public DateTime CreatedOn => DateTime.UtcNow;

}


public class CraeteArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CraeteArticleCommandValidator()
    {
        RuleFor(x => x.JournalId).NotEmpty().GreaterThan(0).WithMessage("JournalId is required and must be a positive integer.");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.").MaximumLength(200);
        RuleFor(x => x.Scope).NotEmpty().WithMessage("Scope is required.").MaximumLength(2000);
        RuleFor(x => x.ArticleType).NotEmpty();
    }
}