using System;

namespace MyBlogApp.DAL.Exceptions
{
    public class NullArgumentDALException:DALException
    {
        public NullArgumentDALException(String message):base(message) 
        {
            
        }
    }
}
