using System;
using System.Collections.Generic;
using System.Text;

namespace LinkGroup.DemoTests.ReusableFile
{
    public class InputDataFile
    {
        private static InputDataFile instance;

        public static InputDataFile getInstance()
        {
            if (instance == null)
            {
                instance = new InputDataFile();
            }
            return instance;
        }

        public void closeInstance()
        {
            instance = null;
        }
        public string linkGroupUrl = "https://www.linkgroup.eu/";
        public string expectedSearchResults = "Leeds";
        public string linkFundSolutionsUrl = "https://www.linkfundsolutions.co.uk/";
        public string expectedFundForUK = "UK";
        public string expectedFundForSwiss = "Swiss";
    }
}
