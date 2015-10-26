using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using NewsMVVMtest.ViewModel;
using PjNewsLib;

namespace NewsMVVMtest
{
    public sealed partial class MainPage
    {
        //public MainViewModel Vm => (MainViewModel)DataContext;

        public MainPage()
        {
            InitializeComponent();

            //            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManagerBackRequested;
            //
            //            Loaded += (s, e) =>
            //            {
            //                Vm.RunClock();
            //            };

            System.Diagnostics.Debug.WriteLine("Method1");
            //Task<NewsObject> news = GetValueTest();
            //var newsObject = news.Result;

            string url = "https://api.import.io/store/data/40ab96a9-c714-4844-9eb6-20bd86cf8501/_query?input/webpage/url=http://www.pja.edu.pl/aktualnosci/projekt-reconcile&_user=ac4a2596-0302-46ee-a01a-153a5b50f8bf&_apikey=ac4a2596030246eea01a153a5b50f8bf8d83fcfebeb20555e1c978bf8baa34cc8783b48aa9648c98236227aa39e38c716a3280346535778f39005f54d0a00eb45cdf4387ab49e5af783d95afa60b5c37";
            var article = NewsGrabber.GetArticleSimply(url);


            textBlockTitle.Text = article.GetTitle();
            textBlockContent.Text = article.GetContent();
            image.Source = new BitmapImage(new Uri(article.GetHeaderImageUrl(), UriKind.Absolute));

            //var title = article.results.First().
        }

        private async Task<NewsObject> GetValueTest()
        {
            string url = "http://www.pja.edu.pl/aktualnosci/projekt-reconcile";
            NewsObject news = await NewsGrabber.GetNewsByUrl(url);
            return news;
        }



        private void SystemNavigationManagerBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        //        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        //        {
        //            Vm.StopClock();
        //            base.OnNavigatingFrom(e);
        //        }
    }
}
