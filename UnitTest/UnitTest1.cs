using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //MathVector = new Mathvector();
            //arrange

            //act

            //assert
        }
    }
}

/*
 var vect1 = new MathVector(2);
            var vect2 = new MathVector(2);
            var vect3 = new MathVector(2);
            var vect4 = new MathVector(2);
            var vect5 = new MathVector(2);
            var vect6 = new MathVector(2);
            var vect7 = new MathVector(2);
            var vect8 = new MathVector(3);
            //MathVector vect8 = new MathVector(2);
            vect1[0] = 1;
            vect1[1] = 1;

            vect8[0] = 1;
            vect8[1] = 2;
            vect8[2] = 3;
            //vect1[2] = 1;
            Console.WriteLine("Different dimensions:");
            vect8 = (MathVector)vect8.Sum(vect1);
            Console.WriteLine("vect8 (sum with different dim): (" + vect8[0] + ";" + vect8[1] + ";" + vect8[2] + ")");
            vect7 = (MathVector)vect7.Sum(vect8);
            Console.WriteLine("vect7 (sum with different dim): (" + vect7[0] + ";" + vect7[1] + ";" + vect7[2] + ")");

            Console.WriteLine("\nRealisation methods:");
            Console.WriteLine(vect1[3]);
            Console.WriteLine("vect1: (" + vect1[0] + ";" + vect1[1] + ")");
            Console.WriteLine("Length vect1: " + vect1.Length);
            vect2 = (MathVector)vect1.SumNumber(3);
            Console.WriteLine("vect1 + 3 (SumNumber): (" + vect2[0] + ";" + vect2[1] + ")");
            vect3 = (MathVector)vect1.MultiplyNumber(3);
            Console.WriteLine("vect1 * 3 (MultiplyNumber): (" + vect3[0] + ";" + vect3[0] + ")");
            vect4 = (MathVector)vect2.Sum(vect3);
            Console.WriteLine("vect2 + vect3 (Sum): (" + vect4[0] + ";" + vect4[0] + ")");
            vect5 = (MathVector)vect2.Multiply(vect3);
            Console.WriteLine("vect2 * vect3 (Multiply): (" + vect5[0] + ";" + vect5[0] + ")");
            Console.WriteLine("vect2 * vect3 (sc): " + vect2.ScalarMultiply(vect3));
            Console.WriteLine("Distance (vect2, vect3): " + vect2.CalcDistance(vect3));

            Console.WriteLine("\nOperator overloading:");
            Console.WriteLine("vect2: (" + vect2[0] + ";" + vect2[1] + ")");
            Console.WriteLine("vect3: (" + vect3[0] + ";" + vect3[1] + ")");
            var vect9 = new MathVector(2);
            var vect10 = new MathVector(2);
            var vect11 = new MathVector(2);
            var vect12 = new MathVector(2);
            var vect13 = new MathVector(2);
            var vect14 = new MathVector(2);
            vect6 =(MathVector)(vect3 + vect2);
            Console.WriteLine("vect3 + vect2: (" + vect6[0] + ";" + vect6[1] + ")");
            vect9 = (MathVector)(vect3 - vect2);
            Console.WriteLine("vect3 - vect2: (" + vect9[0] + ";" + vect9[1] + ")");
            vect10 = (MathVector)(vect3 * vect2);
            Console.WriteLine("vect3 * vect2: (" + vect10[0] + ";" + vect10[1] + ")");
            vect11 = (MathVector)(vect3 / vect2);
            Console.WriteLine("vect3 / vect2: (" + vect11[0] + ";" + vect11[1] + ")");
            vect12 = (MathVector)(vect3 + 2);
            Console.WriteLine("vect3 + 2: (" + vect12[0] + ";" + vect12[1] + ")");
            vect13 = (MathVector)(vect3 / 3);
            Console.WriteLine("vect3 / 3: (" + vect13[0] + ";" + vect13[1] + ")");
            Console.WriteLine("vect3 % vect2: (" + vect3 % vect4 + ")");
            Console.ReadKey();
*/