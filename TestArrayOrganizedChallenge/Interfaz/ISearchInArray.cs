using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestArrayOrganizedChallenge.Interfaz
{
    public interface ISearchInArray
    {
        string FindNameByPosition(string[] arrayNames, int position);
    }
}
