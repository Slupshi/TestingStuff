using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingStuff
{
    partial class Program
    {

        partial class Dictionary
        {

            partial class LINQ
            {
                class JimmyLinq
                {
                    public static readonly IEnumerable<Review> Reviews = new[] {
                        new Review() { Issue = 36, Critic = Critics.MuddyCritic, Score = 37.6 },
                        new Review() { Issue = 74, Critic = Critics.RottenTornadoes, Score = 22.8 },
                        new Review() { Issue = 74, Critic = Critics.MuddyCritic, Score = 84.2 },
                        new Review() { Issue = 83, Critic = Critics.RottenTornadoes, Score = 89.4 },
                        new Review() { Issue = 97, Critic = Critics.MuddyCritic, Score = 98.1 },
                        };

                    public static void JimmyMain()
                    {
                        var done = false;
                        while (!done)
                        {
                            Console.WriteLine(
                            "\nPress G to group comics by price, R to get reviews, any other key to quit\n");
                            switch (Console.ReadKey(true).KeyChar.ToString().ToUpper())
                            {
                                case "G":
                                    done = GroupComicsByPrice();
                                    break;
                                case "R":
                                    done = GetReviews();
                                    break;
                                default:
                                    done = true;
                                    break;
                            }
                        }
                    }

                    private static bool GroupComicsByPrice()
                    {
                        var groups = ComicAnalyzer.GroupComicsByPrice(Comic.Catalog, Comic.Prices);
                        foreach (var group in groups)
                        {
                            Console.WriteLine($"{group.Key} comics:");
                            foreach (var comic in group)
                                Console.WriteLine($"#{comic.Issue} {comic.Name}: {Comic.Prices[comic.Issue]:c}");
                        }
                        return false;
                    }

                    private static bool GetReviews()
                    {
                        var reviews = ComicAnalyzer.GetReviews(Comic.Catalog, Reviews);
                        foreach (var review in reviews)
                            Console.WriteLine(review);
                        return false;
                    }

                    public class Review
                    {
                        public int Issue { get; set; }
                        public Critics Critic { get; set; }
                        public double Score { get; set; }

                    }//Fin de la class Review

                    static class ComicAnalyzer
                    {
                        private static PriceRange CalculatePriceRange(Comic priceRange)
                        {
                            if (Comic.Prices[priceRange.Issue] < 100) return PriceRange.Cheap;
                            else return PriceRange.Expensive;
                        }

                        public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
                        {
                            var grouped =
                            from comic in comics
                            orderby prices[comic.Issue]
                            group comic by CalculatePriceRange(comic) into priceGroup
                            select priceGroup;
                            return grouped;



                        }
                        public static IEnumerable<string> GetReviews(IEnumerable<Comic> comics, IEnumerable<Review> reviews)
                        {
                            var joined =
                            from comic in comics
                            orderby comic.Issue
                            join review in reviews
                            on comic.Issue equals review.Issue

                            select $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}";
                            return joined;
                        }

                    }//Fin de la static class ComicAnalyzer

                }//Fin de la class JimmyLinq

            }
        }
    }}     //=====================================|| Fin du namespace ||======================================================//


