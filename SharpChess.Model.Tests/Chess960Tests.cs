using NUnit.Framework;
using SharpChess.Model;

namespace SharpChess.Tests
{
    [TestFixture]
    public class Chess960Tests
    {
        [Test]
        public void TestChess960Setup_BishopsOnOppositeColors()
        {
            char[] position = Chess960Setup.GenerateChess960Position();
            int firstBishopIndex = -1, secondBishopIndex = -1;

            for (int i = 0; i < position.Length; i++)
            {
                if (position[i] == 'B')
                {
                    if (firstBishopIndex == -1)
                        firstBishopIndex = i;
                    else
                        secondBishopIndex = i;
                }
            }

            Assert.AreNotEqual(-1, firstBishopIndex);
            Assert.AreNotEqual(-1, secondBishopIndex);
            Assert.AreNotEqual(firstBishopIndex % 2, secondBishopIndex % 2);
        }

        [Test]
        public void TestChess960Setup_KingBetweenRooks()
        {
            char[] position = Chess960Setup.GenerateChess960Position();
            int kingIndex = -1, firstRookIndex = -1, secondRookIndex = -1;

            for (int i = 0; i < position.Length; i++)
            {
                if (position[i] == 'K')
                    kingIndex = i;
                else if (position[i] == 'R')
                {
                    if (firstRookIndex == -1)
                        firstRookIndex = i;
                    else
                        secondRookIndex = i;
                }
            }

            Assert.IsTrue(firstRookIndex < kingIndex && kingIndex < secondRookIndex);
        }
    }
}
