using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Security.Authentication.Web;
using Windows.Security.Authentication.Web.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPAd
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent(); 
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var wap = await WebAuthenticationCoreManager.FindAccountProviderAsync("https://login.microsoft.com", "organizations");
            WebTokenRequest wtr = new WebTokenRequest(wap, string.Empty, "ba789272-8d97-425c-9cdf-e43c6e76d73c");
            const string resource = "https://graph.windows.net";
            //wtr.Properties.Add("resource", resource);
            WebTokenRequestResult wtrr = await WebAuthenticationCoreManager.RequestTokenAsync(wtr);
            if (wtrr.ResponseStatus == WebTokenRequestStatus.Success)
            {
               var userAccount = wtrr.ResponseData[0].WebAccount;
            }
            else
            {
                var x = wtrr.ResponseError;
            }
        }
    }
}
