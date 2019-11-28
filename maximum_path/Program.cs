using System;

namespace maximum_path
{
    public static class Program
    {
        //P.I Work Task
        //Junior Fronted developer / Junior Software developer
        //Abdullah AL-Mousa
        //Mobile +90 531 689 1887
        //email : abdullah.almousa.tr@gmail.com
        static void Main(string[] args)
        {
 
            var result = GFG.GetInput()
                        .TransformInputToArray()
                        .TransformTo2Darray()
                        .ResetAllPrimeNumbers()
                        .WalkThroughTheNode();

            var value = result.ToString();

            Console.WriteLine(value);
            Console.ReadLine();

        }
      

    }

}

