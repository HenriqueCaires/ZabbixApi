using System.Collections.Generic;
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
            return _context.SendRequest<string>(
                    new Dictionary<string, object>(),
                    "apiinfo.version",
                    null
                    );
        }

        public async Task<string> GetVersionAsync()
        {
            return await _context.SendRequestAsync<string>(
                new Dictionary<string, object>(),
                "apiinfo.version",
                null
            );
        }
    }
}
