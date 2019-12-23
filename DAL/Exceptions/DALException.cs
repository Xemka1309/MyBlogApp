using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.DAL.Exceptions
{
    public class DALException:Exception
    {
        public DALException(String message) : base(message)
        {

        }
    }
}
