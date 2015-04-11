﻿using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;

namespace LunchMoneyMatch
{
    class ArithmeticConverter : IValueConverter
    {
        private const string ArithmeticParseException = "([+\\-*/]{1,1})\\s{0,}(\\-?[\\d\\.]+)";
        private Regex arithmeticRegex = new Regex(ArithmeticParseException);

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double && parameter != null)
            {
                string param = parameter.ToString();
                if (param.Length > 0)
                {
                    Match match = arithmeticRegex.Match(param);
                    if (match != null && match.Groups.Count == 3)
                    {
                        string operation = match.Groups[1].Value.Trim();
                        string numericValue = match.Groups[2].Value;
                        double number = 0;
                        if (double.TryParse(numericValue, out number))
                        {
                            double doubleNumber = (double)value;
                            double returnValue = 0;
                            switch (operation)
                            {
                                case "+":
                                    returnValue = doubleNumber + number;
                                    break;
                                case "-":
                                    returnValue = doubleNumber - number;
                                    break;
                                case "*":
                                    returnValue = doubleNumber * number;
                                    break;
                                case "/":
                                    returnValue = doubleNumber / number;
                                    break;
                            }
                            return returnValue;
                        }
                    }
                }
            }
            return null;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
