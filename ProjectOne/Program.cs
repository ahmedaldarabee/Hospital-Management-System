using System;

namespace ProjectOne
{
    internal class Program
    {
        static void Main(string[] args){
           
        }

        public static void BinaryNumber(){
            for (int i = 0; i <= 1; i++){
                for (int j = 0; j <= 1; j++) {
                    Console.WriteLine("("+i+","+j+")");                    
                }
            }
        }

        public static void TriangleStars(){
            int totalRows = 7;
            int middleRow = totalRows / 2;

            for (int i = 0; i < totalRows; i++){
                int distanceFromMiddle = Math.Abs(i - middleRow);
                int numberOfStars = (2 * (middleRow - distanceFromMiddle)) + 1;
                if (numberOfStars > 0){
                    Console.WriteLine(new string('*', numberOfStars));
                }
            }
        }

        static void Declaration(){
            //declaration:
            int number;

            // assignment
            number = 22;

            //initialization
            int number2 = number;
            Console.WriteLine(number2);
        }

        static void Concatination(){
            string firstName = "ahmed";
            string lastName = "al-darabee";

            //string interpolation ${}
            string fullName = $"{firstName} {lastName}";
            Console.WriteLine("Your full name is: "+fullName);
        }
        
        static void dataTypeDefine(){
            var utilities1 = "Un known needed data type";
            dynamic utilities2 = "data type that known at run time of app!";

            int first = 1_000_000;
            float second = 1.04f;
            
            double third = 55.66d;

        }
    }
}