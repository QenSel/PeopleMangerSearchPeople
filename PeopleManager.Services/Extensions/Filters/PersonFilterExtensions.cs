using PeopleManager.Dto.Filters;
using PeopleManager.Model;

namespace PeopleManager.Services.Extensions.Filters
{
    public static class PersonFilterExtensions
    {
        public static IQueryable<Person> ApplyFilter(this IQueryable<Person> query, PersonFilter? filter)
        {
            if (filter is null)
            {
                return query;
            }

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var searchCriteria = filter.Search.Split(" ");

                foreach (var search in searchCriteria)
                {
                    query = query.Where(p => p.FirstName.ToLowerInvariant().Contains(search.ToLowerInvariant()) ||
                                             p.LastName.ToLowerInvariant().Contains(search.ToLowerInvariant()) ||
                                             p.Email.ToLowerInvariant().Contains(search.ToLowerInvariant()));

                }
            }

            return query;
        }
    }
}
