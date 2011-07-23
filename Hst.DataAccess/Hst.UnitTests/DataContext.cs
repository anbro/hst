using System;
using System.Configuration;
using System.Data.EntityClient;
using System.Text;
using System.Collections.Generic;
using System.Linq;
//using Hst.DataAccess;
using Hst.Core.Storage;
using Hst.Core.Storage.Ef;
using Hst.Domain.Model;
using Hst.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hst.UnitTests
{
    [TestClass]
    public class DataContext
    {
        
        [TestMethod]
        public void DeployDB()
        {
            using (var db = ServiceEngine.Instance.IoC.Resolve<IEntityStore>() )
            {
                School s = new School();
                s.SchoolName = "Test School";
                s.JoinedOn = DateTime.Today;

                db.AddEntity(s);
                db.SaveChanges();
            }
        }
    }
}
