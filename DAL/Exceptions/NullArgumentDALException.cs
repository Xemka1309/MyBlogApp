using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.DAL.Exceptions
{
    public class NullArgumentDALException:Exception
    {
        public NullArgumentDALException(String message):base(message) 
        {
            
        }
    }
}
