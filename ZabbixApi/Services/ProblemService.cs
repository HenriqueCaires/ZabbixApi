using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using ZabbixApi.Entities;
using ZabbixApi.Helper;

namespace ZabbixApi.Services
{
    public interface IProblemService
    {
        IEnumerable<Problem> Get(object filter = null, IEnumerable<ProblemInclude> include = null, Dictionary<string, object> @params = null);
        
    }
    public class ProblemService : ServiceBase<Problem, ProblemInclude>, IProblemService
    {
        public ProblemService(IContext context) : base(context, "problem") { }
        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<ProblemInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));

            @params = @params ?? new Dictionary<string, object>();
            @params.AddIfNotExist("output", "extend");
            @params.AddIfNotExist("selectAcknowledges","extend");
            @params.AddOrReplace("filter", filter);

            return @params;
        }
        


    }
    public enum ProblemInclude
    {
        All = 1,
        None = 2
    }
}
