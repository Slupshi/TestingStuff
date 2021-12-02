﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestingStuff
{
    partial class Program
    {

        partial class Cards
        {
            class Deck : ObservableCollection<Card>
            {
                private static Random random = new Random();
                public Deck() => Reset();

                public void Reset()
                {
                    Clear();
                    for (int suit = 0; suit <= 3; suit++)
                        for (int value = 1; value <= 13; value++)
                            Add(new Card((Values)value, (Suits)suit));
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
            }//Fin de la class Deck

        }
    }}     //=====================================|| Fin du namespace ||======================================================//


