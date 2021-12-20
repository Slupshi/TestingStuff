﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace TestingStuff
{
    partial class Program
    {

        partial class Cards
        {
            class Deck : ObservableCollection<Card>
            {
                string cardsFileName = @"D:\Training_Perso\TestingStuff\cardslist.txt";
                private static Random random = new Random();
                public Deck() => Reset();

                public Deck(string filename)
                {
                    using (var reader = new StreamReader(filename))
                    {
                        while (!reader.EndOfStream)
                        {
                            var nextCard = reader.ReadLine();
                            var cardParts = nextCard.Split(new char[] { ' ' });
                            var value = cardParts[0] switch
                            {
                                "Ace" => Values.Ace,
                                "Two" => Values.Two,
                                "Three" => Values.Three,
                                "Four" => Values.Four,
                                "Five" => Values.Five,
                                "Six" => Values.Six,
                                "Seven" => Values.Seven,
                                "Eight" => Values.Eight,
                                "Nine" => Values.Nine,
                                "Ten" => Values.Ten,
                                "Jack" => Values.Jack,
                                "Queen" => Values.Queen,
                                "King" => Values.King,
                                _ => throw new InvalidDataException($"Unrecognized card value: {cardParts[0]}")
                            };
                            var suit = cardParts[2] switch
                            {
                                "Spades" => Suits.Spades,
                                "Clubs" => Suits.Clubs,
                                "Hearts" => Suits.Hearts,
                                "Diamonds" => Suits.Diamonds,
                                _ => throw new InvalidDataException($"Unrecognized card suit: {cardParts[2]}"),
                            };
                            Add(new Card(value, suit));
                        }
                    }
                }

                public void Reset()
                {
                    Clear();
                    for (int suit = 0; suit <= 3; suit++)
                        for (int value = 1; value <= 13; value++)
                            Add(new Card((Values)value, (Suits)suit));
                    WriteCards(cardsFileName);
                }
                public Card Deal(int index)
                {
                    Card cardToDeal = base[index];
                    RemoveAt(index);
                    return cardToDeal;
                }
                public Deck Shuffle()
                {
                    List<Card> copy = new List<Card>(this);
                    Clear();
                    while (copy.Count > 0)
                    {
                        int index = random.Next(copy.Count);
                        Card card = copy[index];
                        copy.RemoveAt(index);
                        Add(card);
                    }
                    return this;
                }
                public void Sort()
                {
                    List<Card> sortedCards = new List<Card>(this);
                    sortedCards.Sort(new CardComparerByValue());
                    Clear();
                    foreach (Card card in sortedCards)
                    {
                        Add(card);
                    }
                }

                public void WriteCards(string fileName)
                {
                    using (var writer = new StreamWriter(fileName))
                    {
                        for (int i = 0; i < Count; i++)
                        {
                            writer.WriteLine(this[i].Name);
                        }
                    }
                }

            }//Fin de la class Deck

        }
    }
}     //=====================================|| Fin du namespace ||======================================================//


