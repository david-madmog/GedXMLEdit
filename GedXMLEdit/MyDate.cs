using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedXMLEdit
{
    public class MyDate
    {
        private int pYear;
        private int pMonth;
        private int pDay;

        public MyDate(DateTime DT)
        {
            pYear = DT.Year;
            pMonth = DT.Month;
            pDay = DT.Day;
        }

        public MyDate(String Year, String Month, String Day)
        {
            this.year = Year;
            this.month = Month;
            this.day = Day;
        }

        public DateTime ToDateTime()
        {
            DateTime DT;
            try
            {
                DT = new DateTime(pYear, pMonth, pDay);
                return DT;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public string day
        {
            set
            {
                try
                {
                    if (value != "")
                        pDay = Int32.Parse(value);
                    else
                        pDay = -1;
                }
                catch (Exception)
                {
                    pDay = -1;
                }
            }
            get
            {
                if (pDay >= 0)
                    return pDay.ToString();
                else
                    return "";
            }
        }

        public string month
        {
            set
            {
                try
                {
                    if (value != "")
                        pMonth = DateTime.Parse("1 " + value + " 1900").Month;
                    else
                        pMonth = -1;
                }
                catch (Exception)
                {
                    pMonth = -1;
                }
            }
            get
            {
                if (pMonth >= 0)
                    return new DateTime(1900, pMonth, 1).ToString("MMMM");
                else
                    return "";
            }
        }

        public string year
        {
            set
            {
                try
                {
                    if (value != "")
                        pYear = Int32.Parse(value);
                    else
                        pYear = -1;
                }
                catch (Exception)
                {
                    pYear = -1;
                }
            }
            get
            {
                if (pYear >= 0)
                    return pYear.ToString();
                else
                    return "";
            }
        }


        public string MedString()
        {
            string sRet = "";
            if (pYear >= 0)
            {
                sRet = pYear.ToString("0000");
            }
            if (pMonth >= 0)
            {
                DateTime DT = new DateTime(1900, pMonth, 1);
                sRet = DT.ToString("MMM") + " " + sRet;
            }
            if (pDay >= 0)
            {
                sRet = pDay.ToString() + " " + sRet.Trim();
            }
            return sRet.Trim();
        }

        public static MyDate Parse(string S)
        {

            MyDate MD;

            // Huge assumptions time
            // * we will have up to 3 elements, split by spaces
            // * they will be in order date, month, year
            // * If two, they will be month, year
            // * If one, it will be year
            char[] delimiterChars = { ' ' };
            string[] words = S.Split(delimiterChars);

            if (words.Length >= 3)
            {
                MD = new MyDate(words[2], words[1], words[0]);
            }
            else if (words.Length >= 2)
            {
                MD = new MyDate(words[1], words[0], "");
            }
            else if (words.Length >= 1)
            {
                MD = new MyDate(words[0], "", "");
            }
            else
            {
                MD = MinValue;
            }

            return MD;
        }

        public static MyDate MinValue = new MyDate(DateTime.MinValue);
        public static MyDate MaxValue = new MyDate(DateTime.MinValue);

    }
}
