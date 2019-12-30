using JCommon.Extensions;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace JCommon
{
    public static class StringUtils
    {
        public const int MIN_PLAYER_NAME_LENTH = 4;
        public const int MAX_PLAYER_NAME_LENTH = 14;
        private static readonly string[] LIMIT_CHAR = new string[] { "%", ",", "*", "^", "#", "$", "&", ":", "_", "[", "]", "|" };

        public static bool ValidLogin(this string str)
        {
            if (ValidLength(str, MIN_PLAYER_NAME_LENTH, MAX_PLAYER_NAME_LENTH))
            {
                return ValidNamePattern(str);
            }
            return false;
        }

        public static bool ValidPassword(this string str)
        {
            if (ValidLength(str, MIN_PLAYER_NAME_LENTH, MAX_PLAYER_NAME_LENTH))
            {
                return ValidNamePattern(str);
            }
            return false;
        }

        public static bool CompareTo(this string A, string B, bool IsAEncripted = false, bool IsBEncripted = false)
        {
            var a = IsAEncripted ? A.StringToDSA() : A;
            var b = IsBEncripted ? B.StringToDSA() : B;
            return a.Equals(b, StringComparison.InvariantCulture);
        }

        private static bool ValidNamePattern(string name)
        {
            if (IsBlank(name))
            {
                return false;
            }

            foreach (string element in LIMIT_CHAR)
            {
                if (name.Contains(element))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsBlank(this string name)
        {
            return string.IsNullOrEmpty(name);
        }

        public static bool IsAlphaNumericNoSpace(this string data)
        {
            return Regex.IsMatch(data, @"^[a-zA-Z0-9]+$");
        }

        public static bool IsAlphaNumericWithSpaceSpace(this string data)
        {
            return Regex.IsMatch(data, @"^[a-zA-Z0-9 ]+$");
        }

        public static bool IsAllowedUsername(this string data)
        {
            return Regex.IsMatch(data, @"^[a-zA-Z0-9]+$") && ValidLength(data.Length, 4, 14);
        }

        public static bool IsAllowedPassWord(this string data)
        {
            return Regex.IsMatch(data, @"^[a-zA-Z0-9]+$") && !ValidLength(data.Length, 4, 14);
        }

        private static bool ValidLength(int length, int min, int max)
        {
            return length >= min && length <= max;
        }

        private static int ToEncode(string element, Encoding encoding)
        {
            return encoding.GetBytes(element).Length;
        }

        private static int ToDefaultEncoding(string element)
        {
            return Encoding.UTF8.GetBytes(element).Length;
        }

        public static bool ValidLength(this string element, int minLength = MIN_PLAYER_NAME_LENTH, int maxLength = MAX_PLAYER_NAME_LENTH)
        {
            try
            {
                return ValidLength(ToEncode(element, Encoding.UTF8), minLength, maxLength);
            }
            catch
            {
            }
            try
            {
                return ValidLength(ToEncode(element, Encoding.ASCII), minLength, maxLength);
            }
            catch
            {
            }
            try
            {
                return ValidLength(ToEncode(element, Encoding.Default), minLength, maxLength);
            }
            catch
            {
            }
            return ValidLength(ToDefaultEncoding(element), minLength, maxLength);
        }

    }
}
