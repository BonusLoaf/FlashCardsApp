using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using Newtonsoft.Json;
//using System.Net;
//using System.Threading.Tasks;
//using Microsoft.Azure.Cosmos;

namespace FlashCardsApp
{
    class ArrayControl
    {
        //    //*****************DATABASE START*********************
        //
        //    //add endpoint 
        //    private static readonly string EndpointUri = "";
        //
        //    // The primary key for the Azure Cosmos account (to be added)
        //    private static readonly string PrimaryKey = "";
        // 
        //    // The Cosmos client instance
        //    private CosmosClient cosmosClient;
        // 
        //    // The database we will create
        //    private Database database;
        // 
        //    // The container we will create.
        //    private Container container;
        // 
        //    // The name of the database and container we will create
        //    private string databaseId = "SubjectsDB";
        //    private string containerId = "Items";
        // 
        //
        //      public async Task Go()
        //      {
        //          //createsan instance of cosmos client
        //          this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey)
        //
        //          
        //      }

        //    ********************** PUT IN MAIN
        //            {
        //                 ArrayControl p = new ArrayControl();
        //                 await p.Start();
        //
        //            }
        //
        // ********************
        //
        //
        //
        //
        //
        //
        //
        //
        //
        // 
        //*****************DATABASE END *********************

        public static Subject[] subjectArray;

        public static string[] testSubjectArray = new string[3];


        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this);
        //}



            public static void fillArray()
        {

            for (int i = 0; i < testSubjectArray.Length; i++)
            {
                testSubjectArray[i] = "billy" + i.ToString();
            }

        }

        public ArrayControl()
        {







            

        }

    }
}
