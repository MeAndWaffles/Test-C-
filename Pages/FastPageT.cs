using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test_C_.Pages
{
    internal class FastPageT : BasePage
    {
        public FastPageT(IWebDriver driver) : base(driver)
        {


        }
        
        public WebElement someElement()
        {
            return findElement("");
        }
    }
}
