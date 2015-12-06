﻿using System;
using System.Collections.Generic;
using System.Linq;
using Frapid.Framework;

namespace Frapid.Web
{
    public class StartupRegistration
    {
        public static void Register()
        {
            Type iType = typeof (IStartupRegistration);
            IEnumerable<object> members = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => iType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance);

            foreach (IStartupRegistration member in members)
            {
                member.Register();
            }
        }
    }
}