using System;

namespace MyBlogApp.BLL.Exceptions
{
    public class ServiceNullArgumentException:ServiceException
    {
        public ServiceNullArgumentException(String message) : base(message)
        {

        }
    }
}
