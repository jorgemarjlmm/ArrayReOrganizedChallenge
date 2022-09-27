using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestArrayOrganizedChallenge.Request;

namespace TestArrayOrganizedChallenge.Interfaz
{
    public interface IReOrganizedArray
    {
        string[] ReOrganizedArrayNames(ReOrganizedArrayRequest reorganizedArrayRequest);
    }
}
