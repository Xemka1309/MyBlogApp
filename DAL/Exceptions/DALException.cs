using System;

namespace MyBlogApp.DAL.Exceptions
{
    public class DALException:Exception
    {
        public DALException(String message) : base(message)
        {

        }
    }
}
