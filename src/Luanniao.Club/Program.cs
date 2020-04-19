using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using LuanNiao.Blazor.Core;
using Luanniao.Club.Properties;

namespace Luanniao.Club
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            Translater.AddLanguageFile(new Translater.SourceItem[] {
    new Translater.SourceItem(){ CultureName="cn", ItemType= Translater.SourceItemType.OrignalString, Data=Resources.cn },
    new Translater.SourceItem(){ CultureName="en", ItemType= Translater.SourceItemType.OrignalString, Data=Resources.en },
            });
            Translater.ConvertTo("en");
            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddLuanNiaoBlazor();
            await builder.Build().RunAsync();
        }
    }
}
