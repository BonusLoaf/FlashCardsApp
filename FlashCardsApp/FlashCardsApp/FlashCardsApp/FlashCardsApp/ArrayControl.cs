using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

using System.Configuration;

using Newtonsoft.Json.Linq;


namespace FlashCardsApp
{
    class ArrayControl
    {

        public static Subject[] subjectArray = new Subject[3];

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

            subjectArray[0] = new Subject("Subject name 0", 3, cardArray0);
            subjectArray[1] = new Subject("Subject name 1", 3, cardArray1);
            subjectArray[2] = new Subject("Subject name 2", 3, cardArray2);

            //SaveArray();
            
        }

        //*****************************************************************************//
        //                         JSON SAVE START
        //*****************************************************************************//

        public static void SaveArrayToText()
        {

            //runs the jsonArray method and stores the array 
            JArray subStore = JsonPacker();

            //Console.WriteLine(subStore.ToString());


            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, "testfile.txt");

            //Console.WriteLine(filePath);

            using (StreamWriter text = new StreamWriter(File.Create(filePath)))
            {
                //text.WriteLine(Convert.ToString(subjectArray.Length));
                text.WriteLine(subStore.ToString());
            }

            Console.WriteLine(File.ReadAllText(filePath));
        }


        //this method makes and returns a jsonArray
        public static JArray JsonPacker()
        {
            //creates the jsonArray that will be filled with data
            JArray JsonStorage = new JArray();

            //loops based on the number of subjects created
            for (int i = 0; i < subjectArray.Length; i++)
            {
                //creates a temporary object to store data for a single subject
                JObject sub = new JObject();

                //adds the name and number of cards to the sub object
                sub.Add(subjectArray[i].getSubjectName(), "Sub_name");
                sub.Add(Convert.ToString(subjectArray[i].getNumberOfCards()), "Sub_card_num");

                //creates a temporary object to store card info in
                JObject cards = new JObject();

                //loops based on number of cards the subject has
                for (int j = 0; j < subjectArray[i].getNumberOfCards(); j++)
                {
                    //adds the card questions and answers to the temporary card object
                    cards.Add(subjectArray[i].getCardData()[j].getCardQuestion(), "Card_question");
                    cards.Add(subjectArray[i].getCardData()[j].getCardAnswer(), "Card_answer");
                }
                //adds the temporary card object to the subject object
                sub.Add(JsonConvert.SerializeObject(cards, Formatting.Indented), "Card_data");

                //adds the temp subject object to the JsonArray
                JsonStorage.Add(sub);
            }

            //returns the JsonArray
            return JsonStorage;
        }

        public static void JsonReader()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, "testfile.txt");

            StreamReader storageFile = new StreamReader("testfile.txt");

            int numSubjects = Convert.ToInt32(storageFile.ReadLine());

            for (int i = 0; i < numSubjects; i++)
            {

            }

        }

        //*****************************************************************************//
        //                         JSON SAVE END
        //*****************************************************************************//

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
            int newNumCards = subjectArray[selectedSubject].getNumberOfCards() + 1;
            CardData[] tempCardArray = subjectArray[selectedSubject].getCardData();

            //resizes the temporary array so it has an extra space in it
            Array.Resize(ref tempCardArray, tempCardArray.Length + 1);

            //changes the stored value of the number of cards
            subjectArray[selectedSubject].setNumberOfCards(newNumCards);

            //replaces the original cardArray with the temporary one (which has the extra slot at the end)
            subjectArray[selectedSubject].setCardData(tempCardArray);

            //sets the values for the empty card at the end of the array

            subjectArray[selectedSubject].getCardData()[newNumCards - 1] = new CardData("new card question", "new card answer");

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

                tempCardArray[i] = new CardData(subjectArray[selectedSubject].getCardData()[i].getCardQuestion(), subjectArray[selectedSubject].getCardData()[i].getCardAnswer());

            }

            for (int j = selectedCard; j < (numCards - 1); j++)
            {
                ////from where the last loop left off, skips the card to be deleted and fills in the remaining slots with the rest of the cards
                tempCardArray[j] = new CardData(subjectArray[selectedSubject].getCardData()[j + 1].getCardQuestion(), subjectArray[selectedSubject].getCardData()[j + 1].getCardAnswer());

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
            subjectArray[subjectArray.Length - 1] = new Subject(newSubjectName, 1, newcardArray);
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

    }
}
