using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi.Services
{
    public class ApiInfoService
    {
        protected IContext _context;

        public ApiInfoService(IContext context)
        {
            _context = context;
        }

        public string GetVersion()
        {
            return _context.SendRequest<string>(
                    null,
                    "apiinfo.version"
                    );
        }

        public async Task<string> GetVersionAsync()
        {
            return await _context.SendRequestAsync<string>(
                null,
                "apiinfo.version"
            );
        }
    }
}
