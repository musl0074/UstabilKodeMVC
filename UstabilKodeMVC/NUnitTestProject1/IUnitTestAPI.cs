using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    public interface IUnitTestAPI
    {
        void Get();

        void GetAll();

        void Post();

        void Put();

        void Delete();

        void Concurrency();
    }
}
