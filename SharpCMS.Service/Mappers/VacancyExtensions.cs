using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;
using SharpCMS.Model;

namespace SharpCMS.Service.Mappers
{
    public static class VacancyExtensions
    {
        public static VacancyView ConvertToVacancyView(this Vacancy vacancy)
        {
            if (vacancy == null)
            {
                throw new ArgumentNullException();
            }
            return new VacancyView()
            {
                Id = vacancy.Id.ToString(),
                Title = vacancy.Title,
                ParentId = vacancy.ParentId.ToString(),
                Abstract = vacancy.Abstract,
                Created = vacancy.Created.ToString("dd MMMM yyyy"),
                CreatedBy = vacancy.CreatedBy,
                Description = vacancy.Description,
                IsActive = vacancy.IsActive,
                Keywords = vacancy.Keywords,
                Text = vacancy.Text,
                Updated = vacancy.Updated.ToString(),
                UpdatedBy = vacancy.UpdatedBy,
                Employer = vacancy.Employer,
                Contact = vacancy.Contact,
                Responsibilities = vacancy.Responsibilities,
                Demands = vacancy.Demands,
                Conditions = vacancy.Conditions
            };
        }

        public static IEnumerable<VacancyView> ConvertToVacancyViewCollection(this IEnumerable<Vacancy> vacancies)
        {
            List<VacancyView> vacancyViewCollection = new List<VacancyView>();
            foreach (Vacancy vacancy in vacancies)
            {
                vacancyViewCollection.Add(vacancy.ConvertToVacancyView());
            }
            return vacancyViewCollection;
        }
    }
}
