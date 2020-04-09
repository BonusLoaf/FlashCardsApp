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

        public static Subject[] subjectArray = new Subject[3];
        //
        public static CardData[] cardArray = new CardData[3];
        public static CardData[] cardArray0 = new CardData[3];
        public static CardData[] cardArray1 = new CardData[3];
        public static CardData[] cardArray2 = new CardData[3];

        public static string[] testSubjectArray = new string[3];

        public static void subjectArrayTests()
        {
           // Subject[] subjectArray = new Subject[3];
           // CardData[] cardArray = new CardData[3];




            cardArray0[0] = new CardData("sub 0 question 0", "sub 0 answer 0");
            cardArray0[1] = new CardData("sub 0 question 1", "sub 0 answer 1");
            cardArray0[2] = new CardData("sub 0 question 2", "sub 0 answer 2");
            
            cardArray1[0] = new CardData("sub 1 question 0", "sub 1 answer 0");
            cardArray1[1] = new CardData("sub 1 question 1", "sub 1 answer 1");
            cardArray1[2] = new CardData("sub 1 question 2", "sub 1 answer 2");
            
            cardArray2[0] = new CardData("sub 2 question 0", "sub 2 answer 0");
            cardArray2[1] = new CardData("sub 2 question 1", "sub 2 answer 1");
            cardArray2[2] = new CardData("sub 2 question 2", "sub 2 answer 2");

            //for (int i = 0; i < subjectArray.Length; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        cardArray[j] = new CardData("sub " + i + ", question " + j, "answer " + j);
            //    }
            //    subjectArray[i] = new Subject("Subject name " + i, 3, cardArray);
            //}
            subjectArray[0] = new Subject("Subject name 0", 3, cardArray0);
            subjectArray[1] = new Subject("Subject name 1", 3, cardArray1);
            subjectArray[2] = new Subject("Subject name 2", 3, cardArray2);

            //CreateSubject("Brand new subject");

            //CreateCard(1);

            //updateArrayTests();

        }

        public static void updateArrayTests() 
        {
            for (int i = 0; i < subjectArray.Length; i++)
            {
                for (int j = 0; j < subjectArray[i].getNumberOfCards(); j++)
                {
                    cardArray[j] = new CardData("sub " + i + " question " + j, "sub " + i + "answer " + j);
                }
                subjectArray[i] = new Subject("Subject name " + i, subjectArray[i].getNumberOfCards(), cardArray);
            }
        }


        //*********************************************************************
        //                       CARD CONTROL START
        //*********************************************************************

        public static void CreateCard(int selectedSubject)
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

            subjectArray[selectedSubject].getCardData()[newNumCards -1] = new CardData("new card question", "new card answer");

            //subjectArray[selectedSubject].getCardData()[newNumCards].setCardQuestion(newCardQuestion);
            //subjectArray[selectedSubject].getCardData()[newNumCards].setCardAnswer(newCardAnswer);
        }

        public static void deleteCard(int selectedSubject, int selectedCard)
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

        public static void editCard(int selectedSubject, int selectedCard, string newCardQuestion, string newCardAnswer)
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

        //test Complete, works as intended
        public static void CreateSubject(string newSubjectName)
        {
            
            //creates a temporary card so no errors are thrown when accessing new subject for the first time
            CardData[] newcardArray = new CardData[1];
            newcardArray[0] = new CardData("Enter question here", "enter answer here");


            //resizes the subject array and sets the number of cards in the new array to one (so it isnt null)
            Array.Resize(ref subjectArray, subjectArray.Length + 1);
            subjectArray[subjectArray.Length - 1] = new Subject("new Subject", 1, newcardArray);
        }

        //test Complete, works as intended
        public static void DeleteSubject(int selectedSubject) 
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

        //test Incomplete
        public static void EditSubject(int selectedSubject, string newSubjectName)
        {
            subjectArray[selectedSubject].setSubjectName(newSubjectName);
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
