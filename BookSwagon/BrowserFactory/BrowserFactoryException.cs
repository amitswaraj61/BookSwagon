//-----------------------------------------------------------------------
// <copyright file="BrowserFactoryException.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace BookSwagon.BrowserFactory
{
    /// <summary>
    /// create Browser Factory exception class
    /// </summary>
    class BrowserFactoryException:Exception
    {
        public string message;
        public ExceptionType type;

        /// <summary>
        /// create enum Exception type
        /// </summary>
        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION
        }

        /// <summary>
        /// create Browser factory exception constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public BrowserFactoryException(String message, ExceptionType type) : base(message)
        {
            this.message = message;
            this.type = type;
        }
    }
}
