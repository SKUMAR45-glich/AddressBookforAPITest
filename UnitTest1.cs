using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace AddressBookforRestSharpTesting
{
    [TestClass]
    public class UnitTest1
    {
        RestClient client;                                                      //Declaration of Client

        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient("http://localhost:4000");                      //Setting Link for the Client 
        }

        private IRestResponse getAddressList()
        {
            //arrange
            RestRequest request = new RestRequest("/AddressBook", Method.GET);              //Retrieving EmployeesList 

            //act
            IRestResponse response = client.Execute(request);
            return response;
        }


        [TestMethod]
        public void OnCallingReturnEmployeeList()
        {
            IRestResponse response = getAddressList();

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);                                 //Checking the Status
            List<AddressBook> dataResponse = JsonConvert.DeserializeObject<List<AddressBook>>(response.Content);          //Desrializing Object
            Assert.AreEqual(3, dataResponse.Count);                                                          //Counting the responses that matches


            //Retrieving the data from the DataResponse 
            foreach (var item in dataResponse)
            {
                Console.WriteLine("Pin Code: " + item.pin + " Name: " + item.name + " City: " + item.city);
            }
        }

    }
}
