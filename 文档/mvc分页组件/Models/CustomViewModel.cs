using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;

namespace Webdiyer.MvcPagerDemo.Models
{
    public class CustomViewModel
    {
        public IPagedList<Tuple<int, string, string>> Users { get; set; }
        public IPagedList<Article> Articles { get; set; }
    }
}