using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OperasWebSites.Models;

namespace OperasWebSites.Controllers
{
    public class OperasApiController : ApiController
    {
        private OperasDB context = new OperasDB();

        public IEnumerable<Opera> GetOperas()
        {
            return context.Operas.AsEnumerable();
        }

        public Opera GetOperas(int id)
        {
            Opera opera = context.Operas.Find(id);
            if(opera == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return opera;
        }
    }
}
