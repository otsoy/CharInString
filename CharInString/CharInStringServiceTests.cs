namespace CharInString
{
    [TestClass]
    public class CharInStringServiceTest
    {
        [DataRow("bicycle", 'k', 0)]
        [DataRow("bicycle", 'c', 2)]
        [TestMethod]
        public void PositiveTest(string str, char c, int expected)
        {
            Assert.AreEqual(expected, CharInStringService.GetCharAmount(str, c));
        }

        [TestMethod]
        public void CaseSensitive()
        {
            //TODO: Clarify requirements for this case.
            // As for business logic reasons case insensitive method could be expected
            Assert.AreEqual(0, CharInStringService.GetCharAmount("bicycle", 'C'));
        }

        [TestMethod]
        public void Number()
        {
            Assert.AreEqual(3, CharInStringService.GetCharAmount("b1icycle11", '1'));
        }

        [TestMethod]
        public void Space()
        {
            Assert.AreEqual(3, CharInStringService.GetCharAmount("bi cy cle ", ' '));
        }

        [TestMethod]
        public void LineBreak()
        {   //Linebreak is character : \n, Unicode : U+000A
            Assert.AreEqual(1, CharInStringService.GetCharAmount($"bi\tcy\ncle ", '\u000A'));
        }

        [TestMethod]
        public void SpecialSymbols()
        {
            Assert.AreEqual(2, CharInStringService.GetCharAmount("bic'ycle", (char)13));
        }

        [TestMethod]
        public void UnicodeEscapeSequence()
        {
            //'\u0062' is unicode b
            Assert.AreEqual(1, CharInStringService.GetCharAmount("bicycle ", '\u0062'));
        }

        [TestMethod]
        public void HexadecimalEscapeSequence()
        {
            Assert.AreEqual(1, CharInStringService.GetCharAmount("bicycle ", '\x0062'));
        }

        [TestMethod]
        public void CastInt()
        {
            Assert.AreEqual(1, CharInStringService.GetCharAmount("bicycle ", (char)98));
        }

        [TestMethod]
        public void VerbatimString()
        {
            Assert.AreEqual(2, CharInStringService.GetCharAmount(@"//bicycle", '/'));
        }

        [TestMethod]
        public void InterpolatedString()
        {
            Assert.AreEqual(2, CharInStringService.GetCharAmount($"//bicycle", '/'));
        }

        [TestMethod]
        public void SymbolContains2Chars()
        {
            //"𐒻𐓟"
            //"𐒻" is ('\ud801') and'('\udcbb')
            //"𐓟" is ('\ud801') and('\udcdf')
            Assert.AreEqual(2, CharInStringService.GetCharAmount("𐒻𐓟", '\ud801'));
        }


        [TestMethod]
        public void EmptyString()
        {
            Assert.AreEqual(2, CharInStringService.GetCharAmount(string.Empty, ' '));
        }

        [Ignore]
        [TestMethod]
        public void MaxLengthString()
        {
            //TODO: clarify requirements
            //Max string length on current machine can vary depend on system characteristics 
            //In worst case this will lead to OutOfMemory exception and app crush
            //I strongly suggest no not rely on this, but set a limitation on input parameter
            var length = 1000000;
            var maxLengthString = string.Concat(Enumerable.Repeat("a", length));
            Assert.AreEqual(length, CharInStringService.GetCharAmount(maxLengthString, 'a'));
        }


    }
}