using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.BLL.Exceptions
{
    public class ServiceNullArgumentException:Exception
    {
        public ServiceNullArgumentException(String message) : base(message)
        {

        }
    }
}
