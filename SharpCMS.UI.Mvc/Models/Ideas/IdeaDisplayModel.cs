using System;

namespace SharpCMS.UI.Mvc.Models.Ideas
{
    public class IdeaDisplayModel
    {
        public Guid Id { set; get; }
        public string Text { get; set; }
        public string Title { get; set; }
        public string Created { get; set; }
        public string CreatedBy { get; set; }
    }
}