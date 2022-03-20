using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.Views;
using Xamarin.Forms;

namespace TrackingApp.Extension
{
    public static class ExtensionMethods
    {
        async public static Task<T> GetResultFromModalPage<T>(this INavigation nav, AwaitableContentPage<T> page)
        {
            await nav.PushModalAsync(page, false);
            return await page.PageClosedTask;
        }
    }
}
