using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PjNewsLib
{
    public class ViewModel
    {
        //private Article acrticle = new Article();


        //public Article Acrticle
        //{
        //    get { return acrticle; }
        //}

        private News news = new News();

        public News News
        {
            get { return news; }
        }

        public ViewModel()
        {
            news = NewsGrabber.GetNews();

        }
    }
}
