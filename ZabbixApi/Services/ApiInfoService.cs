using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi.Services
{
    public class ApiInfoService
    {
        protected Context _context;

        public ApiInfoService(Context context)
        {
            _context = context;
        }

        public string GetVersion()
        {
            var @params = new Dictionary<string, object>() { { "id", 1 } };
            return _context.SendRequest<string>(
                    @params,
                    "apiinfo.version",
                    null
                    );
        }

        public async Task<string> GetVersionAsync()
        {
            var @params = new Dictionary<string, object>() { { "id", 1 } };
            return await _context.SendRequestAsync<string>(
                @params,
                "apiinfo.version",
                null
            );
        }
    }
}
