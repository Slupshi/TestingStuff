namespace TestingStuff.Notes
{
    class Notes
    {
        //Si on veut out une variable il faut lui attribuer une valeur avant de return
        public static int ReturnThreeValues(int value, out double half, out int twice)
        {
            half = value / 2f;
            twice = value * 2;
            return value + 1;
        }
        //il faut mettre en argument les out a chaque appel de la methode

        //On peut passer des arguments par référence pour modifier directement une variable au lieu d'en créer une copie
        class Guy
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public override string ToString() => $"a {Age}-year-old named {Name}";
        }
        static void ModifyAnIntAndGuy(ref int valueRef, ref Guy guyRef)
        {
            valueRef += 10;
            guyRef.Name = "Bob";
            guyRef.Age = 37;
        }
        //Qui va modifier la variable value (int) et guy (Guy) qu'on lui passera


        //Les lignes commençant par un # sont des directives (like #if DEBUG de MSM)
        //Pour forcer une ref à être null on met un '?' coller à la fin du type (ex : public string? Name { get; set; } )
        // avoir '??' à la fin d'une ligne check si le contenu de cette ligne est null, si oui ca retourne une alternative
        //(ex : var nextLine = stringReader.ReadLine() ?? String.Empty; )

        //On peut transformer ca :
        static void nonNull(string nextLine)
        {
            if (nextLine == null)
                nextLine = "(the first line is null)";
        }
        //En ça : nextLine ??= "(the first line was empty)";

        // Nullable<T> or T?
        //--> Nullable<bool> optionalYesNoAnswer = null; or bool? anotherYesNoAnswer = false;
        //On peut convertir les variable Nullable dans variable standard : int? myNullableInt = 9321; -> int = myNullableInt.Value;






    }
}


















