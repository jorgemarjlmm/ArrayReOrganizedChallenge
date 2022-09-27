using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestArrayOrganizedChallenge.BL;
using TestArrayOrganizedChallenge.Interfaz;
using TestArrayOrganizedChallenge.Request;
using TestArrayOrganizedChallenge.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestArrayOrganizedChallenge.Response;

namespace TestUnitArrayReOrgfanizedChallenge
{
    [TestClass]
    public class UnitTestReOrganizedArrayChallenge
    {
        private readonly ReOrganizedArrayController _reOrganizedArrayController;
        private readonly IReOrganizedArray _iReOrganizedArray;
        private readonly ISearchInArray _iSearchInArray;

        public UnitTestReOrganizedArrayChallenge()
        {            
            _iReOrganizedArray = new ArrayFunctions();
            _reOrganizedArrayController = new ReOrganizedArrayController(_iReOrganizedArray);
            _iSearchInArray = new ArrayFunctions();
        }

        [TestMethod]
        public void TestMethodFindNameByPositionCorrect()
        {            
            string[] names = { "Sonia Maria Wood Dempster", "Laruen Ana Eagles Beneke" };
            int position = 1;

            var result = _iSearchInArray.FindNameByPosition(names, position);

            Assert.AreEqual(result, names[position - 1]);
        }

        [TestMethod]
        public void TestMethodReorganizedArrayCorrect()
        {
            ReOrganizedArrayRequest reOrganizedArrayRequest = new ReOrganizedArrayRequest();            

            string[] names = { "Sonia Maria Wood Dempster", "Laruen Ana Eagles Beneke" };
            int[] order = { 4, 1, 2, 3 };
            string[] namesOrganized = { "Position not found in array Names", "Sonia Maria Wood Dempster", "Laruen Ana Eagles Beneke", "Position not found in array Names" };

            reOrganizedArrayRequest.names = names;
            reOrganizedArrayRequest.order = order;

            var result = _iReOrganizedArray.ReOrganizedArrayNames(reOrganizedArrayRequest);
           
            Assert.IsTrue(namesOrganized.SequenceEqual(result));
        }

        [TestMethod]
        public void TestMethodArrayReOrganizedCorrect()
        {
            ReOrganizedArrayRequest reOrganizedArrayRequest = new ReOrganizedArrayRequest();
            ReOrganizedArrayResponse reOrganizedArrayResponse = new ReOrganizedArrayResponse();

            string[] names = { "Sonia Maria Wood Dempster", "Laruen Ana Eagles Beneke" };
            int[] order = { 4, 1, 2, 3 };
            string[] namesOrganized = { "Position not found in array Names", "Sonia Maria Wood Dempster", "Laruen Ana Eagles Beneke", "Position not found in array Names" };
            
            reOrganizedArrayRequest.names = names;
            reOrganizedArrayRequest.order = order;

            reOrganizedArrayResponse.reorganizedname = namesOrganized;
            string resultOrganized = JsonConvert.SerializeObject(reOrganizedArrayResponse);

            var result = (OkObjectResult)_reOrganizedArrayController.ArrayReOrganized(reOrganizedArrayRequest);

            Assert.IsTrue(result.Value.ToString() == resultOrganized);
        }
    }
}