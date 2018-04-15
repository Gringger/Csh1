using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class User
    {
        private static string[] chineese_zodiac = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Sheep" };

        private DateTime _dateOfBirth;
        private int _age;
        private string _western_zodiac;
        private string _chineese_zodiac;

        public User(DateTime dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
            _western_zodiac = GetWesternZodiac(dateOfBirth);
            _chineese_zodiac = GetEasternZodiac(dateOfBirth);
            _age = GetAge(dateOfBirth);
        }

        public string Western_zodiac { get { return _western_zodiac; } }
        public string Chineese_zodiac { get { return _chineese_zodiac; } }
        public int Age { get { return _age; } }

        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }

        private int GetAge(DateTime dateOfBirth)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (DateTime.Today.Month < dateOfBirth.Month)
                return age - 1;
            if (DateTime.Today.Month == dateOfBirth.Month && DateTime.Today.Day < dateOfBirth.Day)
                return age - 1;
            return age;
        }

        private string GetEasternZodiac(DateTime date)
        {
            return chineese_zodiac[date.Year % 12];
        }

        private string GetWesternZodiac(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                    if (date.Day >= 20)
                        return "Aquarius";
                    if (date.Day <= 19)
                        return "Capricorn";
                    break;
                case 2:
                    if (date.Day >= 19)
                        return "Pisces";
                    if (date.Day <= 18)
                        return "Aquarius";
                    break;
                case 3:
                    if (date.Day >= 21)
                        return "Aries";
                    if (date.Day <= 20)
                        return "Pisces";
                    break;
                case 4:
                    if (date.Day >= 20)
                        return "Taurus";
                    if (date.Day <= 19)
                        return "Aries";
                    break;
                case 5:
                    if (date.Day >= 21)
                        return "Gemini";
                    if (date.Day <= 20)
                        return "Taurus";
                    break;
                case 6:
                    if (date.Day >= 21)
                        return "Cancer";
                    if (date.Day <= 20)
                        return "Taurus";
                    break;
                case 7:
                    if (date.Day >= 23)
                        return "Leo";
                    if (date.Day <= 22)
                        return "Cancer";
                    break;
                case 8:
                    if (date.Day >= 23)
                        return "Virgo";
                    if (date.Day <= 22)
                        return "Leo";
                    break;
                case 9:
                    if (date.Day >= 23)
                        return "Libra";
                    if (date.Day <= 22)
                        return "Virgo";
                    break;
                case 10:
                    if (date.Day >= 23)
                        return "Scorpio";
                    if (date.Day <= 22)
                        return "Libra";
                    break;
                case 11:
                    if (date.Day >= 22)
                        return "Sagittarius";
                    if (date.Day <= 21)
                        return "Scorpio";
                    break;
                case 12:
                    if (date.Day >= 22)
                        return "Capricorn";
                    if (date.Day <= 21)
                        return "Sagittarius";
                    break;
            }
            return "";
        }
    }
}
