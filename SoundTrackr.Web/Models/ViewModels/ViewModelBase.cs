using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoundTrackr.Web.Models.ViewModels
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            this.Exception = null;
        }

        public Exception Exception { get; set; }
    }
}