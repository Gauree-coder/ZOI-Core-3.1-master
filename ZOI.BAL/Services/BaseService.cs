using System;
using System.Collections.Generic;
using System.Text;
using ZOI.DAL.DatabaseUtility;

namespace ZOI.BAL.Services
{
    class BaseService
    {
        protected RepositoryFactory RepositoryFactory;


        public BaseService(RepositoryFactory RepositoryFactory)
        {
            this.RepositoryFactory = RepositoryFactory;
          
        }

    }
}
