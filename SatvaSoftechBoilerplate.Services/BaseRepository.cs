using SatvaSoftechBoilerplate.Model.Config;
using Microsoft.Extensions.Options;

namespace SatvaSoftechBoilerplate.Service
{
    public abstract class BaseRepository
    {
        public readonly IOptions<DataConfig> _dataConfig;

        public BaseRepository(IOptions<DataConfig> dataConfig)
        {
            _dataConfig = dataConfig;
        }
    }
}
