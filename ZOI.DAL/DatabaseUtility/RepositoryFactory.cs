using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZOI.DAL.DatabaseUtility;



namespace ZOI.DAL.DatabaseUtility
{
    public class RepositoryFactory : IDisposable
    {
        private ApplicationDbContext Context;

        private Dictionary<string, object> ___repos = new Dictionary<string, object>();

        public RepositoryFactory(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public Repository<T> GetGenericRepository<T>() where T : class
        {
            if (!___repos.ContainsKey(typeof(T).Name))
            {
                var r = new Repository<T>(this.Context);
                ___repos.Add(typeof(T).Name, r);
            }
            return (Repository<T>)___repos[typeof(T).Name];
        }

        //public IEnumerable<TObj> ExecuteSP<TObj>(string ProcName, SqlParameter[] param, bool LazyLoad = true)
        //{
        //    StringBuilder sbParam = new StringBuilder();
        //    foreach (var p in param)
        //    {
        //        if (sbParam.Length > 1) sbParam.Append(", ");
        //        sbParam.Append(p.ParameterName);
        //        if (p.Direction == System.Data.ParameterDirection.Output) sbParam.Append(" out ");
        //    }
        //    IEnumerable<TObj> results = Context.Database.SqlQuery<TObj>(ProcName + " " + sbParam.ToString(), param);
        //    if (!LazyLoad)
        //        results = results.ToList();
        //    return results;
        //}

        public ApplicationDbContext ApplicationContext
        {
            get
            {
                return Context;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
            Context = null;
            ___repos.Clear();
            ___repos = null;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }



    }
}
