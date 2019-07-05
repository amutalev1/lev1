using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Seldat.Utils
{
    public class DIManager
    {

        static UnityContainer _container = new UnityContainer();

        public static UnityContainer Container
        {
            get
            {
                return _container;
            }
        }
    }
}
