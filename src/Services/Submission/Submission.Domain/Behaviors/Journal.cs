using Articles.Abstractions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Domain.Entities
{
    public partial class Journal
    {

        public Article CreateArticle(string title, string scope, ArticleType type)
        {
            var article = new Article
            {
                Title = title,
                Scope = scope,
                Type = type,
                Stage = ArticleStage.Created,
                JournalId = this.Id,
                Journal = this
            };
            _articles.Add(article);
            return article;
        }
    }
}
