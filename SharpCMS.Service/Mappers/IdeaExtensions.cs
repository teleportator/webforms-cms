using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;
using SharpCMS.Model;

namespace SharpCMS.Service.Mappers
{
    public static class IdeaExtensions
    {
        public static IdeaView ConvertToIdeaView(this Idea idea)
        {
            if (idea == null)
            {
                throw new ArgumentNullException();
            }
            return new IdeaView()
            {
                Id = idea.Id.ToString(),
                Title = idea.Title,
                ParentId = idea.ParentId.ToString(),
                Abstract = idea.Abstract,
                Created = idea.Created.ToString("dd MMMM yyyy, HH:mm"),
                CreatedBy = idea.CreatedBy,
                Description = idea.Description,
                IsActive = idea.IsActive,
                Keywords = idea.Keywords,
                Text = idea.Text,
                Updated = idea.Updated.ToString(),
                UpdatedBy = idea.UpdatedBy,
                Category = idea.Category,
                Rating = idea.Rating.ToString()
            };
        }

        public static IEnumerable<IdeaView> ConvertToIdeaViewCollection(this IEnumerable<Idea> ideas)
        {
            List<IdeaView> ideaViewCollection = new List<IdeaView>();
            foreach (Idea idea in ideas)
            {
                ideaViewCollection.Add(idea.ConvertToIdeaView());
            }
            return ideaViewCollection;
        }
    }
}
