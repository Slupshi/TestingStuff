using System;
using System.Collections.Generic;

namespace TestingStuff
{
    partial class Program
    {
        partial class Lists
        {
            //===============================================================================//
            //                                    Shoes                                      //
            //===============================================================================//

            class Shoes
            {
                static ShoeCloset shoeCloset = new ShoeCloset();
                public static void ShoesMain()
                {
                    while (true)
                    {
                        shoeCloset.PrintShoes();
                        Console.Write("\nPress 'a' to add or 'r' to remove a shoe: ");
                        char key = Console.ReadKey().KeyChar;
                        switch (key)
                        {
                            case 'a':
                            case 'A':
                                shoeCloset.AddShoe();
                                break;
                            case 'r':
                            case 'R':
                                shoeCloset.RemoveShoe();
                                break;
                            default:
                                return;
                        }
                    }
                }

                class Shoe
                {
                    public Style Style
                    {
                        get; private set;
                    }
                    public string Color
                    {
                        get; private set;
                    }
                    public Shoe(Style style, string color)
                    {
                        Style = style;
                        Color = color;
                    }
                    public string Description
                    {
                        get { return $"A {Color} {Style}"; }
                    }
                }//Fin de la class Shoe

                class ShoeCloset
                {
                    private readonly List<Shoe> shoes = new List<Shoe>();
                    public void PrintShoes()
                    {
                        if (shoes.Count == 0)
                        {
                            Console.WriteLine("\nThe shoe closet is empty.");
                        }
                        else
                        {
                            Console.WriteLine("\nThe shoe closet contains:");
                            int i = 1;
                            foreach (Shoe shoe in shoes)
                            {
                                Console.WriteLine($"Shoe #{i++}: {shoe.Description}");
                            }
                        }
                    }
                    public void AddShoe()
                    {
                        Console.WriteLine("\nAdd a shoe");
                        for (int i = 0; i < 6; i++)
                        {
                            Console.WriteLine($"Press {i} to add a {(Style)i}");
                        }
                        Console.Write("Enter a style: ");
                        if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int style))
                        {
                            Console.Write("\nEnter the color: ");
                            string color = Console.ReadLine();
                            Shoe shoe = new Shoe((Style)style, color);
                            shoes.Add(shoe);
                        }
                    }
                    public void RemoveShoe()
                    {
                        Console.Write("\nEnter the number of the shoe to remove: ");
                        if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int shoeNumber) &&
                        (shoeNumber >= 1) && (shoeNumber <= shoes.Count))
                        {
                            Console.WriteLine($"\nRemoving {shoes[shoeNumber - 1].Description}");
                            shoes.RemoveAt(shoeNumber - 1);
                        }
                    }
                }//Fin de la class ShoeCloset

            }//Fin de la class Shoes
        }
    }}     //=====================================|| Fin du namespace ||======================================================//


