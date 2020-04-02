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
        //*****************DATABASE END *********************

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this);
        //}

        public static Subject[] subjectArray;

        public static string[] testSubjectArray = new string[3];


        //*********************************************************************
        //                       CARD CONTROL START
        //*********************************************************************

        public void CreateCard(int selectedSubject, string newCardQuestion, string newCardAnswer)
        {

            //gets the number of cards in the array currently and creates a temporary array with their data
            int newNumCards = subjectArray[selectedSubject].getNumberOfCards() +1;
            CardData[] tempCardArray = subjectArray[selectedSubject].getCardData();

            //resizes the temporary array so it has an extra space in it
            Array.Resize(ref tempCardArray, tempCardArray.Length + 1);

            //changes the stored value of the number of cards
            subjectArray[selectedSubject].setNumberOfCards(newNumCards);

            //replaces the original cardArray with the temporary one (which has the extra slot at the end)
            subjectArray[selectedSubject].setCardData(tempCardArray);

            //sets the values for the empty card at the end of the array
            subjectArray[selectedSubject].getCardData()[newNumCards].setCardQuestion(newCardQuestion);
            subjectArray[selectedSubject].getCardData()[newNumCards].setCardAnswer(newCardAnswer);
        }

        public void deleteCard(int selectedSubject, int selectedCard)
        {
           
            //gets number of cards
            int numCards = subjectArray[selectedSubject].getNumberOfCards();

            //creates temporary array one smaller than current subjects
            CardData[] tempCardArray = new CardData[numCards - 1];

            for (int i = 0; i < selectedCard; i++)
            {
                //fills temporary array with cards up to the card to be deleted
                tempCardArray[i].setCardQuestion(subjectArray[selectedSubject].getCardData()[i].getCardQuestion());
                tempCardArray[i].setCardAnswer(subjectArray[selectedSubject].getCardData()[i].getCardAnswer());
               

            }
            for (int j = selectedCard; j < (numCards - 1); j++)
            {
                //from where the last loop left off, skips the card to be deleted and fills in the remaining slots with the rest of the cards
                tempCardArray[j].setCardQuestion(subjectArray[selectedSubject].getCardData()[j + 1].getCardQuestion());
                tempCardArray[j].setCardAnswer(subjectArray[selectedSubject].getCardData()[j + 1].getCardAnswer());
            }

            //finally, replaces the old array with the new temp one with the card removed
            subjectArray[selectedSubject].setCardData(tempCardArray);
            subjectArray[selectedSubject].setNumberOfCards(numCards - 1);
        }

        public void editCard(int selectedSubject, int selectedCard, string newCardQuestion, string newCardAnswer)
        {
            //uses the int value of the selected subject and card to find the card to be edited...
            //...and sets the values of the question and answer to the input values. 
            subjectArray[selectedSubject].getCardData()[selectedCard].setCardQuestion(newCardQuestion);
            subjectArray[selectedSubject].getCardData()[selectedCard].setCardAnswer(newCardAnswer);
        }

        //*********************************************************************
        //                       CARD CONTROL END
        //*********************************************************************


        //*********************************************************************
        //                       SUBJECT CONTROL START
        //*********************************************************************

        public void CreateSubject(string newSubjectName)       
        {
            //resizes the subject array and sets the number of cards in the new array to zero (so it isnt null)
            Array.Resize(ref subjectArray, subjectArray.Length + 1);
            subjectArray[subjectArray.Length - 1].setNumberOfCards(0);

            string tempQuestion = "Enter question here";
            string tempAnswer = "enter answer here";

            //creates a temporary card so no errors are thrown when accessing new subject for the first time
            CreateCard((subjectArray.Length - 1), tempQuestion, tempAnswer);
        }

        public void DeleteSubject(int selectedSubject) 
        {
            //Grabs number of total subjects
            int numSubjects = subjectArray.Length;

            //creates a temporary array one smaller than max number of subjects
            Subject[] tempSubject = new Subject[numSubjects - 1];

            //fills in temprary array up to the selected subject
            for (int i = 0; i < selectedSubject; i++)
            {
                tempSubject[i] = subjectArray[i];
            }

            //skips selected subject and fills in remaining slots
            for (int j = selectedSubject; j < (numSubjects - 1); j++)
            {
                tempSubject[j] = subjectArray[j + 1];
            }

            //replaces original subject array with temporary array
            subjectArray = tempSubject;
        }

        //*********************************************************************
        //                       SUBJECT CONTROL END
        //*********************************************************************


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
