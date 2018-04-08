using System;
using System.Web.Http;
using WebApiAkqa.Models;

namespace WebApiAkqa.Controllers
{
    public class NumberIntoWordController : ApiController
    {
        #region WEB API Calculate Action
        /// <summary>
        /// WebAPI method for converting Price into words
        /// </summary>
        /// <param name="username"></param>
        /// <param name="priceDecimal"></param>
        /// <returns></returns>
        [HttpGet]
        public Akqa Calculate(string username, double priceDecimal)
        {
            var akqaModel = new Akqa();
            try
            {
                akqaModel.UserName = username;
                if (username != null)
                {
                    var wordnumber = $"{priceDecimal:0.00}";
                    if (wordnumber == "0.00")
                    {
                        akqaModel.UserName = "Error : ";
                        akqaModel.PriceinWord = "Please Enter Number above than 0.00";
                        return akqaModel;
                    }
                    akqaModel.PriceinWord = ConvertNumbertoWord(wordnumber);
                    
                    return akqaModel;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region ConvertNumbertoWord Function 
        /// <summary>
        /// This method will seprate whole number and decimal number and return the result in price
        /// </summary>
        /// <param name="wordnumber"></param>
        /// <returns></returns>
        private static string ConvertNumbertoWord(string wordnumber)
        {
            string val = "", wholeNo = wordnumber;
            string andStr = "", pointStr = "";
            const string wholenoend = "dollor";
            var endStr = "Only";
            try
            {
                if (wordnumber != null)
                {
                    int decimalPlace = wordnumber.IndexOf(".", StringComparison.Ordinal);
                    if (decimalPlace > 0)
                    {
                        wholeNo = wordnumber.Substring(0, decimalPlace);
                        var points = wordnumber.Substring(decimalPlace + 1);
                        if (Convert.ToInt32(points) > 0)
                        {
                            andStr = "and";
                            endStr = "Cents " + endStr;
                            pointStr = ConvertWholeNumber(points);
                        }
                    }

                    val = wholeNo == "0"
                        ? $"{pointStr} {endStr}"
                        : $"{ConvertWholeNumber(wholeNo).Trim()} {wholenoend} {andStr} {pointStr} {endStr}";
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return val;
        }
        #endregion

        #region ConvertWholeNumber Function 
        /// <summary>
        /// This method is for converting the Whole number into words
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static string ConvertWholeNumber(string number)
        {
            string word = "";
            try
            {
                var isDone = false;
                double dblAmt = (Convert.ToDouble(number));
                if (dblAmt > 0)
                {
                    var numDigits = number.Length;
                    int pos = 0;
                    String place = "";
                    switch (numDigits)
                    {
                        case 1://ones' range

                            word = Ones(number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = Tens(number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7:
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        if (number.Substring(0, pos) != "0" && number.Substring(pos) != "0")
                        {
                           word = ConvertWholeNumber(number.Substring(0, pos)) + place + ConvertWholeNumber(number.Substring(pos));
                        }
                        else
                        {
                            word = ConvertWholeNumber(number.Substring(0, pos)) + ConvertWholeNumber(number.Substring(pos));
                        }
                    }
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return word.Trim();
        }
        #endregion

        #region ConvertDecimals Function 
        private static string ConvertDecimals(string number)
        {
            string cd = "";
            foreach (var t in number)
            {
                var digit = t.ToString();
                var engOne = digit.Equals("0") ? "Zero" : Ones(digit);
                cd += " " + engOne;
            }
            return cd;
        }
        #endregion

        #region Tens Function 
        private static string Tens(string numb)
        {
            int number = Convert.ToInt32(numb);
            String name = null;
            switch (number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (number > 0)
                    {
                        name = Tens(numb.Substring(0, 1) + "0") + " " + Ones(numb.Substring(1));
                    }
                    break;
            }
            return name;
        }
        #endregion

        #region Ones Function 
        private static string Ones(string num)
        {
            int number = Convert.ToInt32(num);
            var name = "";
            switch (number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        #endregion
    }
}