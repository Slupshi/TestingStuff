using System;
using System.Collections.Generic;

namespace TestingStuff
{
    partial class Program
    {

        partial class Lists
        {
            //===============================================================================//
            //                                     Duck                                      //
            //===============================================================================//

            class Duck : IComparable<Duck>
            {
                public static void Ducks()
                {
                    List<Duck> ducks = new List<Duck>() {
                new Duck() { Kind = KindOfDuck.Mallard, Size = 17 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 18 },
                new Duck() { Kind = KindOfDuck.Loon, Size = 14 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 11 },
                new Duck() { Kind = KindOfDuck.Mallard, Size = 14 },
                new Duck() { Kind = KindOfDuck.Loon, Size = 13 }, };
                    IComparer<Duck> sizeComparer = new DuckComparerBySize();
                    ducks.Sort(sizeComparer);
                    PrintDucks(ducks);
                    DuckComparer comparer = new DuckComparer();
                    Console.WriteLine("\nSorting by kind then size\n");
                    comparer.SortBy = DuckSortCriteria.KindThenSize;
                    ducks.Sort(comparer);
                    PrintDucks(ducks);
                    Console.WriteLine("\nSorting by size then kind\n");
                    comparer.SortBy = DuckSortCriteria.SizeThenKind;
                    ducks.Sort(comparer);
                    PrintDucks(ducks);
                }

                public int Size
                {
                    get; set;
                }
                public KindOfDuck Kind
                {
                    get; set;
                }
                public int CompareTo(Duck duckToCompare)
                {
                    if (this.Size > duckToCompare.Size)
                        return 1;
                    else if (this.Size < duckToCompare.Size)
                        return -1;
                    else
                        return 0;
                }
                public static void PrintDucks(List<Duck> ducks)
                {
                    foreach (Duck duck in ducks)
                    {
                        Console.WriteLine($"{duck.Size} inch {duck.Kind}");
                    }
                }

                class DuckComparerBySize : IComparer<Duck>
                {
                    public int Compare(Duck x, Duck y)
                    {
                        if (x.Size < y.Size)
                            return -1;
                        if (x.Size > y.Size)
                            return 1;
                        return 0;
                    }
                }//Fin de la class DuckComparerBySize

                class DuckComparerByKind : IComparer<Duck>
                {
                    public int Compare(Duck x, Duck y)
                    {
                        if (x.Kind < y.Kind)
                            return -1;
                        if (x.Kind > y.Kind)
                            return 1;
                        else
                            return 0;
                    }
                }//Fin de la class DuckComparerBykind

                class DuckComparer : IComparer<Duck>
                {
                    public DuckSortCriteria SortBy = DuckSortCriteria.SizeThenKind;
                    public int Compare(Duck x, Duck y)
                    {
                        if (SortBy == DuckSortCriteria.SizeThenKind)
                            if (x.Size > y.Size)
                                return 1;
                            else if (x.Size < y.Size)
                                return -1;
                            else
                            if (x.Kind > y.Kind)
                                return 1;
                            else if (x.Kind < y.Kind)
                                return -1;
                            else
                                return 0;
                        else
                        if (x.Kind > y.Kind)
                            return 1;
                        else if (x.Kind < y.Kind)
                            return -1;
                        else
                        if (x.Size > y.Size)
                            return 1;
                        else if (x.Size < y.Size)
                            return -1;
                        else
                            return 0;
                    }
                }//Fin de la class DuckComparer

            }//Fin de la class Duck
        }
    }}     //=====================================|| Fin du namespace ||======================================================//


