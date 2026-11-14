using Articles.Abstractions;
using Articles.Abstractions.Enums;
using Blocks.EntityFrameWork;
using MediatR;
using Submission.Domain.Entities;
using Submission.Persistance.Repositories;

namespace Submission.Application.Features.CreateArticle;

public class CreateArticleCommandHandler(Repository<Journal> _JournalRepository) : IRequestHandler<CreateArticleCommand, IdResponse>
{
    public async Task<IdResponse> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var Journal = await _JournalRepository.FindByIdOrThrowAsync(request.JournalId);
        var Article = Journal.CreateArticle(request.Title, request.Scope, request.ArticleType);
        await AssignCurrentUserAsAuthor(Article, request);
        await _JournalRepository.SaveChangesAsync(cancellationToken);
      
        return new IdResponse(Article.Id);

    }
    private async Task AssignCurrentUserAsAuthor(Article article, CreateArticleCommand Command)
    {
        var author = _JournalRepository.Context.Authors.SingleOrDefault(t => t.UserId == Command.CreatedById);
        if (author is not null)
        {
            article.AssignAuthor(author, [ContributionAreas.OriginalDraft], true);
        }
    }
}
