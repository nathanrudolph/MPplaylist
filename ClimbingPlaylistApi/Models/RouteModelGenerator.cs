using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPplaylist.Models
{
    internal class RouteModelGenerator
    {
        //pass in DbContext?

        public RouteModel Generate(int id)
        {
            throw new NotImplementedException();
            //check if Id is valid
            
            //check RouteCache db table
            try
            {
                return GetRouteFromDb(id);
            }
            catch
            {
                //scrape from web
            }

            return new RouteModel();
        }

        public RouteModel Generate(string url)
        {
            throw new NotImplementedException ();

            //check if Id is valid

            //get Id from url
            int id = GetIdFromUrl(url);

            return this.Generate(id);
        }

        private RouteModel GetRouteFromDb(int id) 
        {
            throw new NotImplementedException();
        }

        private int GetIdFromUrl(string url)
        {
            throw new NotImplementedException();
        }
    }
}
