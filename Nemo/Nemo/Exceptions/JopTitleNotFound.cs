using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemo.Exceptions
{
    class JopTitleNotFound:Exception
    {
        public JopTitleNotFound() { }

        public JopTitleNotFound(string message)
            : base(message) { }

        public JopTitleNotFound(string message, Exception inner)
        : base(message, inner) { }

    }
}
