using Microsoft.Extensions.Logging;
using OrderGenius.Core.Entities.OrderAggregate;
using OrderGenius.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderGenius.Infrastracture.SeedData
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(MsSqlContext storeContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!storeContext.CodeConfigs.Any())
                {
                    var codeConfigData = File.ReadAllText("../OrderGenius.Infrastracture/SeedData/CodeConfig.json");
                    var codeConfig = JsonSerializer.Deserialize<List<CodeConfig>>(codeConfigData);
                    foreach (var item in codeConfig)
                    {
                        storeContext.CodeConfigs.AddAsync(item);
                    }
                    await storeContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex, "Something went wrong with your request"); ;
            }
        }
    }
}

