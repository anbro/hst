using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Storage.Mappings
{
    [Serializable]
    public class TestResultMapping : EntityMapping<TestResult>
    {
        public TestResultMapping()
        {
            Property(tr => tr.Correct)
                .IsRequired();

            Property(tr => tr.Incorrect)
                .IsRequired();

            Property(tr => tr.NotAnswered)
                .IsRequired();

        }
    }
}
