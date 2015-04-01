using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SoundTrackr.Repository
{
    public class DbContextFactory : IDbContextFactory
    {
        private string _dataContextKey = "EfObjectContext";

        public SoundTrackrContext Create()
        {
            SoundTrackrContext stContext = null;
            if (HttpContext.Current.Items.Contains(_dataContextKey))
            {
                stContext = HttpContext.Current.Items[_dataContextKey] as SoundTrackrContext;
            }
            else
            {
                stContext = new SoundTrackrContext();
                Store(stContext);
            }
            return stContext;
        }

        private void Store(SoundTrackrContext stContext)
        {
            if (HttpContext.Current.Items.Contains(_dataContextKey))
            {
                HttpContext.Current.Items[_dataContextKey] = stContext;
            }
            else
            {
                HttpContext.Current.Items.Add(_dataContextKey, stContext);
            }
        }
    }
}
