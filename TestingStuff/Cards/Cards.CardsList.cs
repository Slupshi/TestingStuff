using System;
using System.Collections.Generic;
using System.Threading;

namespace TestingStuff
{
    partial class Program
    {
        partial class Cards
        {
            class CardsList
            {
                static List<CardsList> myCardList = new List<CardsList>();
                public Values Value { get; private set; }
                public Suits Suit { get; private set; }
                public string Name { get { return $"{Value} of {Suit}"; } }
                public CardsList(Values value, Suits suit)
                {
                    this.Value = value;
                    this.Suit = suit;

                }
                private static readonly Random random = new Random();

                public static void CardsListMain()
                {
                    while (true)
                    {
                        Console.Write("How many cards do you want to peek ? ");
                        int numberOfCards;
                        if (int.TryParse(Console.ReadLine(), out numberOfCards))
                        {
                            Console.Clear();
                            Console.Write($"How many cards do you want to peek ? [{numberOfCards}]\n");
                            Thread.Sleep(200);
                            int loadingTimeCard = numberOfCards * 30;
                            if (numberOfCards == 1) { Console.Write($"\nPeeking {numberOfCards} random card"); }
                            else { Console.Write($"\nPeeking {numberOfCards} random cards"); }
                            Thread.Sleep(loadingTimeCard);
                            Console.Write(" .");
                            Thread.Sleep(loadingTimeCard);
                            Console.Write(".");
                            Thread.Sleep(loadingTimeCard);
                            Console.Write(".");
                            Thread.Sleep(loadingTimeCard);
                            Console.WriteLine("\nHere are your cards !\n");
                            Thread.Sleep(300);
                            CreateCardsList(numberOfCards);
                            bool sort = true;
                            while (sort)
                            {
                                Console.Write($"\nDo you want to sort them ? [Y/N]\n");
                                char input = Char.ToUpper(Console.ReadKey(true).KeyChar);
                                if (input == 'Y') { sort = true; Console.Clear(); CardSorting(); }
                                else if (input == 'N') { sort = false; EmptyCardList(); }
                                else return;
                            }
                        }
                    }
                }

                private static void PrintCardList()
                {
                    foreach (CardsList myCards in myCardList)
                    {
                        Console.WriteLine(myCards.Name);
                        Thread.Sleep(200);
                    }
                }

                private static void CreateCardsList(int numberOfCardsToPeek)
                {

                    for (int i = 0; i < numberOfCardsToPeek; i++)
                    {
                        int numberBetween0and3 = random.Next(4);
                        int numberBetween1and13 = random.Next(1, 14);
                        CardsList myCards = new CardsList((Values)numberBetween1and13, (Suits)numberBetween0and3);
                        myCardList.Add(myCards);

                    }
                    PrintCardList();
                }

                public static CardSortCriteria SortBy;
                public static void CardSorting()
                {
                    CardComparer comparer = new CardComparer();
                    Console.WriteLine($"Do you want to sort them by Suit then by Value ? [S]");
                    Console.WriteLine($"Or Do you want to sort them by Value then Suit ? [V]\n");
                    char input = Char.ToUpper(Console.ReadKey(true).KeyChar);
                    if (input == 'S') { SortBy = CardSortCriteria.SuitThenValue; myCardList.Sort(comparer); PrintCardList(); CardsCounter(); }
                    else if (input == 'V') { SortBy = CardSortCriteria.ValueThenSuit; myCardList.Sort(comparer); PrintCardList(); CardsCounter(); }
                    else return;
                }

                private static void EmptyCardList()
                {
                    Console.Write($"\nDo you want to keep your list ? [Y/N]\n");
                    char input = Char.ToUpper(Console.ReadKey(true).KeyChar);
                    if (input == 'Y') { Console.Clear(); }
                    else if (input == 'N')
                    {
                        for (int i = myCardList.Count - 1; i >= 0; i--)
                        {
                            myCardList.RemoveAt(i);
                        }
                        Console.WriteLine("Your list is now empty ! Please Wait..");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                    else return;
                }

                private static void CardsCounter()
                {
                    SuitCounter();
                    ValueCounter();
                }

                private static void SuitCounter()
                {
                    int counterDiamonds = 0;
                    int counterClubs = 0;
                    int counterHearts = 0;
                    int counterSpades = 0;
                    string sDiamonds = "s ";
                    string sClubs = "s ";
                    string sHearts = "s ";
                    string sSpades = "s ";
                    foreach (CardsList myCards in myCardList)
                    {
                        switch (myCards.Suit)
                        {
                            case Suits.Diamonds:
                                counterDiamonds++;
                                break;
                            case Suits.Clubs:
                                counterClubs++;
                                break;
                            case Suits.Hearts:
                                counterHearts++;
                                break;
                            case Suits.Spades:
                                counterSpades++;
                                break;
                        }
                    }
                    if (counterDiamonds == 0 || counterDiamonds == 1) { sDiamonds = " "; }
                    if (counterClubs == 0 || counterClubs == 1) { sClubs = " "; }
                    if (counterHearts == 0 || counterHearts == 1) { sHearts = " "; }
                    if (counterSpades == 0 || counterSpades == 1) { sSpades = " "; }

                    Thread.Sleep(200);
                    Console.WriteLine($"\nThere are {counterDiamonds} Diamond{sDiamonds}/ {counterClubs} Club{sClubs}/ " +
                        $"{counterHearts} Heart{sHearts}/ {counterSpades} Spade{sSpades}");
                }

                private static void ValueCounter()
                {
                    int counterAce = 0;
                    int counterTwo = 0;
                    int counterThree = 0;
                    int counterFour = 0;
                    int counterFive = 0;
                    int counterSix = 0;
                    int counterSeven = 0;
                    int counterEight = 0;
                    int counterNine = 0;
                    int counterTen = 0;
                    int counterJack = 0;
                    int counterQueen = 0;
                    int counterKing = 0;
                    string sJack = "s ";
                    string sQueen = "s ";
                    string sKing = "s ";
                    foreach (CardsList myCards in myCardList)
                    {
                        switch (myCards.Value)
                        {
                            case Values.Ace:
                                counterAce++;
                                break;
                            case Values.Two:
                                counterTwo++;
                                break;
                            case Values.Three:
                                counterThree++;
                                break;
                            case Values.Four:
                                counterFour++;
                                break;
                            case Values.Five:
                                counterFive++;
                                break;
                            case Values.Six:
                                counterSix++;
                                break;
                            case Values.Seven:
                                counterSeven++;
                                break;
                            case Values.Eight:
                                counterEight++;
                                break;
                            case Values.Nine:
                                counterNine++;
                                break;
                            case Values.Ten:
                                counterTen++;
                                break;
                            case Values.Jack:
                                counterJack++;
                                break;
                            case Values.Queen:
                                counterQueen++;
                                break;
                            case Values.King:
                                counterKing++;
                                break;
                        }
                    }
                    if (counterJack == 0 || counterJack == 1) { sJack = " "; }
                    if (counterQueen == 0 || counterQueen == 1) { sQueen = " "; }
                    if (counterKing == 0 || counterKing == 1) { sKing = " "; }
                    Thread.Sleep(200);
                    Console.WriteLine($"\nThere are {counterAce} Ace / {counterTwo} Two / {counterThree} Three / {counterFour} Four " +
                        $"/ {counterFive} Five / {counterSix} Six / " +
                        $"{counterSeven} Seven / {counterEight} Eight / {counterNine} Nine / {counterTen} Ten / {counterJack} Jack{sJack}" +
                        $"/ {counterQueen} Queen{sQueen}/ \n{counterKing} King{sKing}");

                }

                class CardComparer : IComparer<CardsList>
                {
                    public int Compare(CardsList x, CardsList y)
                    {
                        if (SortBy == CardSortCriteria.SuitThenValue)
                            if (x.Suit > y.Suit)
                                return 1;
                            else if (x.Suit < y.Suit)
                                return -1;
                            else
                            if (x.Value > y.Value)
                                return 1;
                            else if (x.Value < y.Value)
                                return -1;
                            else
                                return 0;
                        else
                        if (x.Value > y.Value)
                            return 1;
                        else if (x.Value < y.Value)
                            return -1;
                        else
                        if (x.Suit > y.Suit)
                            return 1;
                        else if (x.Suit < y.Suit)
                            return -1;
                        else
                            return 0;
                    }
                }//Fin de la class CardComparer

            }//Fin de la class CardsList

        }
    }}     //=====================================|| Fin du namespace ||======================================================//


