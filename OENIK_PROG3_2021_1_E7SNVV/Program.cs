// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System;

[assembly: CLSCompliant(false)]

namespace WineryByTheLake.Program
{
    /// <summary>
    /// Everything starts here.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            Factory factory = new Factory();
            ExtensionClass.Start(factory);
        }
    }
}
