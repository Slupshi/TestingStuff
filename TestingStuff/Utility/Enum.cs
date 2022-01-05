namespace TestingStuff
{

    //============================||Enum pour Cards||============================//
    enum Suits
    {
        Diamonds,
        Clubs,
        Hearts,
        Spades,
    }
    enum Values
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
    }
    enum CardSortCriteria { SuitThenValue, ValueThenSuit, }
    //============================||Enum pour Shoes||============================//
    enum Style { Sneaker, Loafer, Sandal, Flipflop, Wingtip, Clog, }
    //============================||Enum pour Duck||============================//
    enum KindOfDuck { Mallard, Muscovy, Loon, }
    enum DuckSortCriteria { SizeThenKind, KindThenSize, }
    //============================||Enum pour LumberJack||============================//
    enum FlapJack { crispy, soggy, browned, banana, }
    //============================||Enum pour JimmyLinq||============================//
    enum Critics { MuddyCritic, RottenTornadoes, }
    enum PriceRange { Cheap, Expensive, }
    //============================||Enum pour ManualSportSequence||============================//
    enum Sport { Football, Baseball, Basketball, Hockey, Boxing, Rugby, Fencing }

}//Fin du namespace
