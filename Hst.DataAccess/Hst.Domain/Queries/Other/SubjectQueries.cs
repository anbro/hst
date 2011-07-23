using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Domain.Queries.Other
{
    public static class SubjectQueries
    {
        public static IQueryable<Subject> GetSubjectsByIds(this IQueryable<Subject> subjects, List<int> ids)
        {
            return subjects.Where(s => ids.Contains(s.Id));
        }
    }
}
