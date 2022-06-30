﻿using EPAM.FileSharing.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FileSharing.PL.ConsolePL
{
    public class ConsolePL
    {
        static void Main(string[] args)
        {
            var bll = DependencyResolver.Instance.ShareLogic;

            foreach(var item in bll.GetShFiles())
            {
                Console.WriteLine(item);
            }
        }
    }
}