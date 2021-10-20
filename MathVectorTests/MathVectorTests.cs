using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebra;
using System.Collections;

namespace MathVectorTests
{

    [TestClass]
    public class MathVectorTests
    {
        private bool CompareVectors(IMathVector vec1, IMathVector vec2)
        {
            if (vec1.Dimensions != vec2.Dimensions)
                return false;

            for (int i = 0; i < vec1.Dimensions; i++)
            {
                if (vec1[i] != vec2[i])
                    return false;
            }
            return true;

        }

        private MathVector MakeVector(double[] array)
        {
            var vect = new MathVector(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                vect[i] = array[i];
            }
            return vect;
        }

        [TestMethod]
        public void TestSumNumber()
        {
            MathVector vect = MakeVector(new double[] { 0, 1 });
            double number = 2;

            MathVector expected = MakeVector(new double[] { 2, 3 });
            MathVector actual = (MathVector)vect.SumNumber(number);

            Assert.IsTrue(CompareVectors(expected, actual));
        }

        [TestMethod]
        public void TestOperatorPlusNum()
        {
            MathVector vect = MakeVector(new double[] { 5, 1, 4 });
            double number = 7;

            MathVector expected = MakeVector(new double[] { 12, 8, 11 });
            MathVector actual = (MathVector)(vect + number);

            Assert.IsTrue(CompareVectors(expected, actual));
        }

        [TestMethod]
        public void TestSum()
        {
            MathVector vect1 = MakeVector(new double[] { 0, 1 });
            MathVector vect2 = MakeVector(new double[] { 2, 1 });

            MathVector expected = MakeVector(new double[] { 2, 2 });
            MathVector actual = (MathVector)vect1.Sum(vect2);

            Assert.IsTrue(CompareVectors(expected, actual));
        }

        [TestMethod]
        public void TestOperatorPlus()
        {
            MathVector vect1 = MakeVector(new double[] { 0, 1, 7 });
            MathVector vect2 = MakeVector(new double[] { 1, 7, -2 });

            MathVector expected = MakeVector(new double[] { 1, 8, 5 });
            MathVector actual = (MathVector)(vect1 + vect2);

            Assert.IsTrue(CompareVectors(expected, actual));
        }

        [TestMethod]
        public void TestOperatorMinus()
        {
            MathVector vect1 = MakeVector(new double[] { 0, 1, 7 });
            MathVector vect2 = MakeVector(new double[] { 1, 7, -2 });

            MathVector expected = MakeVector(new double[] { -1, -6, 9 });
            MathVector actual = (MathVector)(vect1 - vect2);

            Assert.IsTrue(CompareVectors(expected, actual));
        }
        [TestMethod]
        public void TestSumDifDimensions()
        {
            MathVector vect1 = MakeVector(new double[] { 0, 1, 3 });
            MathVector vect2 = MakeVector(new double[] { 2, 1 });

            Assert.ThrowsException<System.Exception>(() => (MathVector)vect1.Sum(vect2));

        }

        [TestMethod]
        public void TestOperatorPlusDifDims()
        {
            MathVector vect1 = MakeVector(new double[] { 0, 1, 3 });
            MathVector vect2 = MakeVector(new double[] { 2, 1 });

            Assert.ThrowsException<System.Exception>(() => (MathVector)(vect1 + vect2));

        }

        [TestMethod]
        public void TestOperatorMinusDifDims()
        {
            MathVector vect1 = MakeVector(new double[] { 0, 1, 3 });
            MathVector vect2 = MakeVector(new double[] { 2, 1 });

            Assert.ThrowsException<System.Exception>(() => (MathVector)(vect1 - vect2));

        }

        [TestMethod]
        public void TestMultiplyNumber()
        {
            MathVector vect = MakeVector(new double[] { 3, 1 });
            double number = 2;

            MathVector expected = MakeVector(new double[] { 6, 2 });
            MathVector actual = (MathVector)vect.MultiplyNumber(number);

            Assert.IsTrue(CompareVectors(expected, actual));
        }

        [TestMethod]
        public void TestOperatorMultNum()
        {
            MathVector vect = MakeVector(new double[] { 3, 1 });
            double number = 2;

            MathVector expected = MakeVector(new double[] { 6, 2 });
            MathVector actual = (MathVector)(vect * number);

            Assert.IsTrue(CompareVectors(expected, actual));
        }

        [TestMethod]
        public void TestMultiply()
        {
            MathVector vect1 = MakeVector(new double[] { 0, 1 });
            MathVector vect2 = MakeVector(new double[] { 2, 1 });

            MathVector expected = MakeVector(new double[] { 0, 1 });
            MathVector actual = (MathVector)vect1.Multiply(vect2);

            Assert.IsTrue(CompareVectors(expected, actual));
        }

        [TestMethod]
        public void TestOperatorMultVec()
        {
            MathVector vect1 = MakeVector(new double[] { 0, 1 });
            MathVector vect2 = MakeVector(new double[] { 2, 1 });

            MathVector expected = MakeVector(new double[] { 0, 1 });
            MathVector actual = (MathVector)(vect1 * vect2);

            Assert.IsTrue(CompareVectors(expected, actual));
        }

        [TestMethod]
        public void TestOperatorDivVec()
        {
            MathVector vect1 = MakeVector(new double[] { 0, 1, 18 });
            MathVector vect2 = MakeVector(new double[] { 2, 1, 9 });

            MathVector expected = MakeVector(new double[] { 0, 1, 2 });
            MathVector actual = (MathVector)(vect1 / vect2);

            Assert.IsTrue(CompareVectors(expected, actual));
        }

        [TestMethod]
        public void TestOperatorDivNum()
        {
            MathVector vect1 = MakeVector(new double[] { 0, 1, 18 });
            double number = 5;

            MathVector expected = MakeVector(new double[] { 0, 0.2, 3.6 });
            MathVector actual = (MathVector)(vect1 / number);

            Assert.IsTrue(CompareVectors(expected, actual));
        }

        [TestMethod]
        public void TestOperatorDivDifDims()
        {
            MathVector vect1 = MakeVector(new double[] { 0, 1, 3 });
            MathVector vect2 = MakeVector(new double[] { 2, 1 });

            Assert.ThrowsException<System.Exception>(() => (MathVector)(vect1 / vect2));
        }

        [TestMethod]
        public void TestMultiplyDifDimensions()
        {
            MathVector vect1 = MakeVector(new double[] { 0, 1, 3 });
            MathVector vect2 = MakeVector(new double[] { 2, 1 });

            Assert.ThrowsException<System.Exception>(() => (MathVector)vect1.Multiply(vect2));
        }

        [TestMethod]
        public void TestOperatorMultDifDims()
        {
            MathVector vect1 = MakeVector(new double[] { 0, 1, 3 });
            MathVector vect2 = MakeVector(new double[] { 2, 1, 5, 6 });

            Assert.ThrowsException<System.Exception>(() => (MathVector)(vect1 * vect2));
        }


        [TestMethod]
        public void TestOperatorDiv0()
        {
            MathVector vect = MakeVector(new double[] { 3, 1, 88 });
            double number = 0;

            Assert.ThrowsException<System.Exception>(() => (MathVector)(vect / number));
        }

        [TestMethod]
        public void TestOperatorDiv0Vec()
        {
            MathVector vect1 = MakeVector(new double[] { 3, 1, 88 });
            MathVector vect2 = MakeVector(new double[] { 3, 0, 88 }); ;

            Assert.ThrowsException<System.Exception>(() => (MathVector)(vect1 / vect2));
        }

        [TestMethod]
        public void TestScalarMultiply()
        {
            MathVector vect1 = MakeVector(new double[] { 1, 1 });
            MathVector vect2 = MakeVector(new double[] { 2, 1 });

            double expected = 3;
            double actual = vect1.ScalarMultiply(vect2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOperatorScMult()
        {
            MathVector vect1 = MakeVector(new double[] { 1, 1 });
            MathVector vect2 = MakeVector(new double[] { 2, 1 });

            double expected = 3;
            double actual = vect1 % vect2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestScalarMultiplyDifDimensions()
        {
            MathVector vect1 = MakeVector(new double[] { 1, 1 });
            MathVector vect2 = MakeVector(new double[] { 2, 1, 3 });            

            Assert.ThrowsException<System.Exception>(() => vect1.ScalarMultiply(vect2));
        }

        [TestMethod]
        public void TestOperatorScMultDifDims()
        {
            MathVector vect1 = MakeVector(new double[] { 1, 1 });
            MathVector vect2 = MakeVector(new double[] { 2, 1, 3 });

            Assert.ThrowsException<System.Exception>(() => vect1 % vect2);
        }

        [TestMethod]
        public void TestCalcDistance()
        {
            MathVector vect1 = MakeVector(new double[] { 4, 1, 3 });
            MathVector vect2 = MakeVector(new double[] { 1, 3, 4 });

            double expected = 3.741657386;
            double actual = vect1.CalcDistance(vect2);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void TestCalcDistanceDifDimensions()
        {
            MathVector vect1 = MakeVector(new double[] { 0, 1, 3 });
            MathVector vect2 = MakeVector(new double[] { 2, 1 });
            Assert.ThrowsException<System.Exception>(() => vect1.CalcDistance(vect2));
        }

        [TestMethod]
        public void TestLength()
        {
            MathVector vect1 = MakeVector(new double[] { 4, 1, 3 });

            double expected = 5.0990195;
            double actual = vect1.Length;

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void TestDimensions()
        {
            MathVector vect1 = MakeVector(new double[] { 4, 1, 3, 8 });

            int expected = 4;
            double actual = vect1.Dimensions;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRequestToElement()
        {
            MathVector vect1 = MakeVector(new double[] { 4, 1, 3 });

            double expected = 1;
            double actual = vect1[1];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWrongRequestToElementWithIndLess0()
        {
            MathVector vect = MakeVector(new double[] { 4, 1, 3 });

            Assert.ThrowsException<System.Exception>(() => vect[-1]);
        }

        [TestMethod]
        public void TestWrongRequestToElementWithIndMoreDims()
        {
            MathVector vect = MakeVector(new double[] { 4, 1, 3 });

            Assert.ThrowsException<System.Exception>(() => vect[5]);
        }

        [TestMethod]
        public void TestSetElement()
        {
            MathVector vect = new MathVector(3);
            vect[0] = 22;
            vect[1] = 54;
            vect[2] = 3;

            MathVector expected = MakeVector(new double[] { 22, 54, 3 });

            Assert.IsTrue(CompareVectors(expected, vect));
        }

        [TestMethod]
        public void TestWrongSetElementWithIndLess0()
        {
            MathVector vect = new MathVector(3);

            Assert.ThrowsException<System.Exception>(() => vect[-1] = 1);
        }

        [TestMethod]
        public void TestWrongSetElementWithIndMoreDims()
        {
            MathVector vect = new MathVector(3);

            Assert.ThrowsException<System.Exception>(() => vect[5] = 4);
        }

    }
}

  