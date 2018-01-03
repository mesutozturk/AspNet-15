using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCF.Web.Models
{
    interface IFile
    {
        void Open();
    }
    interface IDb
    {
        void Open();
    }
    class UseResource : IFile, IDb
    {
        void IFile.Open()
        {
            Console.WriteLine("file");
        }
        void IDb.Open()
        {
            Console.WriteLine("db");
        }
    }
}