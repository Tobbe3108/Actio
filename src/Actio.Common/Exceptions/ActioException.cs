﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Exceptions
{
    public class ActioException : Exception
    {
        public string Code { get; }

        public ActioException()
        {
        }

        public ActioException(string code)
        {
            Code = code;
        }

        public ActioException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public ActioException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public ActioException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public ActioException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }

        public ActioException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}