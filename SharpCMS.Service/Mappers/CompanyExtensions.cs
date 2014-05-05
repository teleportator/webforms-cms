using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;
using SharpCMS.Model;

namespace SharpCMS.Service.Mappers
{
    public static class CompanyExtensions
    {
        public static CompanyView ConvertToCompanyView(this Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException();
            }
            return new CompanyView()
            {
                Id = company.Id.ToString(),
                Title = company.Title,
                ParentId = company.ParentId.ToString(),
                Abstract = company.Abstract,
                Created = company.Created.ToString(),
                CreatedBy = company.CreatedBy,
                Description = company.Description,
                IsActive = company.IsActive,
                Keywords = company.Keywords,
                Text = company.Text,
                Updated = company.Updated.ToString(),
                UpdatedBy = company.UpdatedBy,
                Logo = company.Logo,
                PhoneNumber = company.PhoneNumber,
                Address = company.Address,
                Email = company.Email,
                Hyperlink = company.Hyperlink
            };
        }

        public static IEnumerable<CompanyView> ConvertToCompanyViewCollection(this IEnumerable<Company> companyList)
        {
            List<CompanyView> companyViewCollection = new List<CompanyView>();
            foreach (Company company in companyList)
            {
                companyViewCollection.Add(company.ConvertToCompanyView());
            }
            return companyViewCollection;
        }
    }
}
