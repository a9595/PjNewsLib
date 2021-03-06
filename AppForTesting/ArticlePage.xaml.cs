﻿using System;
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
using PjNewsLib;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AppForTesting
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArticlePage : Page
    {
        public ArticlePage()
        {
            this.InitializeComponent();

          

        
        }
      

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var result = e.Parameter as NewsResult;
            if (result != null)
            {

                //string url = "https://api.import.io/store/data/40ab96a9-c714-4844-9eb6-20bd86cf8501/_query?input/webpage/url=http://www.pja.edu.pl/aktualnosci/projekt-reconcile&_user=ac4a2596-0302-46ee-a01a-153a5b50f8bf&_apikey=ac4a2596030246eea01a153a5b50f8bf8d83fcfebeb20555e1c978bf8baa34cc8783b48aa9648c98236227aa39e38c716a3280346535778f39005f54d0a00eb45cdf4387ab49e5af783d95afa60b5c37";

                var currentNewsResult = result;
                
                ArticleAlternative thisArticle = new ArticleAlternative();
                thisArticle = NewsGrabber.GetAlternativeArticleSimply(currentNewsResult.Link);



                //currentNewsResult.ArticleItem = NewsGrabber.GetArticleSimply(url);
                textBlockTitle.Text = thisArticle.GetTitle();
                textBlockContent.Text = thisArticle.GetContent();
            }
            else
            {
                
            }
            base.OnNavigatedTo(e);

        }
         //this.Frame.Navigate(typeof(MainPage));
     

    }
}
