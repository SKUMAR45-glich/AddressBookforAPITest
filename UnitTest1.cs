using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        /*
        private IRestResponse getAddressList()
        {
            //arrange
            RestRequest request = new RestRequest("/AddressBook", Method.GET);              //Retrieving EmployeesList 

            //act
            IRestResponse response = client.Execute(request);
            return response;
        }

        
        [TestMethod]
        public void OnCallingReturnAddressList()
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
        

        [TestMethod]
        public void OnAddingMultipleNewDatatoAddressBookList()
        {
            //Arrange
            List<AddressBook> addressBookList = new List<AddressBook>();

            addressBookList.Add(new AddressBook { name = "JB", pin = 4 });                         //For Multiple Adding Data to AddressBookList
            addressBookList.Add(new AddressBook { name = "MS", pin = 5 });

            foreach (var item in addressBookList)
            {
                //Act
                RestRequest request = new RestRequest("/AddressBook", Method.POST);                  //For Adding Data to AddressBookList
                JObject jObject = new JObject();
                jObject.Add("name", item.name);
                jObject.Add("pin", item.pin);

                request.AddParameter("application/json", jObject, ParameterType.RequestBody);          //Validation of RestRequest


                IRestResponse response = client.Execute(request);                                   //Executing the response


                //Assert
                Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);                               //Checking Validation
                AddressBook dataResponse = JsonConvert.DeserializeObject<AddressBook>(response.Content);          //Deserializing Object

                Assert.AreEqual(item.name, dataResponse.name);
                Assert.AreEqual(item.pin, dataResponse.pin);
            }
        }
        */

        [TestMethod]

        public void UpdatingDatainAddressBookList()
        {
            //Arrange
            RestRequest request = new RestRequest("/AddressBook/update/2", Method.PUT);
            JObject jobject = new JObject();

            jobject.Add("name", "Mahi");
            jobject.Add("city", "Chennai");

            request.AddParameter("application/json", jobject, ParameterType.RequestBody);

            //Act
            IRestResponse response = client.Execute(request);


            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            AddressBook dataResponse = JsonConvert.DeserializeObject<AddressBook>(response.Content);

            Assert.AreEqual(dataResponse.name, "Mahi");
            Assert.AreEqual(dataResponse.city, "Chennai");
        }
    }
}
