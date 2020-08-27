//-----------------------------------------------------------------------
// <copyright file="Credentials.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.IO;

namespace BookSwagon
{
    /// <summary>
    /// create Credentials class
    /// </summary>
    class Credentials
    {
        public string email = "";
        public string password = "";
        public string json = "";
        public string sendPassword = "";
        public string recEmail = "";

        /// <summary>
        /// create Credentials constructor
        /// </summary>
        public Credentials()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\Kis\\source\\repos\\BookSwagon\\BookSwagon\\Amitswaraj.json"))
            {
                json = r.ReadToEnd();
            }
            dynamic array = JsonConvert.DeserializeObject(json);
            Console.WriteLine("Array::::" + array["email"]);
            email = array["email"];
            password = array["password"];
            sendPassword = array["sender-password"];
            recEmail = array["receiver-email"];
        }
    }
}
