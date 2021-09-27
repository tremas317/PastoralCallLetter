using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCLService.Models
{
    public class Home
    {
        public string Password { get; set; }
        public HttpPostedFileBase CallLetter { get; set; }
        public bool ShowSuccess { get; set; }
        public bool ShowError { get; set; }
        public int TimeoutValue { get; set; }

        public Home()
        {
            Password = string.Empty;
            ShowSuccess = false;
            ShowError = false;
        }
    }
}