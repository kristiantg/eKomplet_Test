using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKomplet_Test.Service
{
    public class ExceptionThrower
    {
        public void ThrowException()
        {
            try
            {
                throw new DBexception(308);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
