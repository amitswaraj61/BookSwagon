using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSwagon.BrowserFactory
{
    class BrowserFactoryException:Exception
    {
        public String message;
        public ExceptionType type;
        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION
        }

        public BrowserFactoryException(String message, ExceptionType type) : base(message)
        {
            this.message = message;
            this.type = type;
        }
    }
}
