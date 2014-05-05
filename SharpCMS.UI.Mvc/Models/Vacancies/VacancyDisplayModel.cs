using System;
using System.Collections.Generic;

namespace SharpCMS.UI.Mvc.Models.Vacancies
{
	public class VacancyDisplayModel
	{
	    public Guid Id { get; set; }
	    public IEnumerable<string> Conditions { get; set; }
	    public IEnumerable<string> Demands { get; set; }
	    public string Contact { get; set; }
	    public string Employer { get; set; }
	    public IEnumerable<string> Responsibilities { get; set; }
	    public string Text { get; set; }
	    public string Title { get; set; }
	}
}