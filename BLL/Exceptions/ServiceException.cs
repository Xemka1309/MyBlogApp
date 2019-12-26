using System;

namespace MyBlogApp.BLL.Exceptions
{
    public class ServiceException:Exception
    {
        public ServiceException(String message) : base(message)
        {

        }
    }
}
