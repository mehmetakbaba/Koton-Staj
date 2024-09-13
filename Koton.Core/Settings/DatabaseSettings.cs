using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Core.Settings
{
    public class DatabaseSettings
    {
        public string CategoryCollectionName { get; set; } = string.Empty;
        public string ProductDetailCollectionName { get; set; } = string.Empty;
        public string ProductCollectionName { get; set; } = string.Empty;
        public string ProductImageName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
