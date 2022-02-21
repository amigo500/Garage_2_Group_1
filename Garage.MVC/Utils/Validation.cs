namespace Garage_2_Group_1.Utils
{
    public class Validation
    {
        public Boolean RegIdValidation(string regID)
        {
            regID = regID.Trim();
            regID = regID.ToUpper();
            bool validFirstPart = false;
            bool validSecondPart = false;
            bool valid6thChar = false;

            char[] validChars = "QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
            if (regID.Length == 6)
            {
                validFirstPart = FirstValidationRegId(regID, validFirstPart, validChars);
                validSecondPart = SecondValidationRegId(regID, validSecondPart);
                valid6thChar = ThirdValidationRegId(regID, validChars);
            }
            else
            {
                return false;
            }

            if (validFirstPart && validSecondPart && valid6thChar)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Age validation for 18 years old using the ssn.
        /// </summary>
        /// <param name="ssn"></param>
        /// <returns>true if the person with the ssn is at least 18 years old</returns>
        public bool AgeValidation(long ssn)
        {
            var s = ssn.ToString();

            var ssnYear = Int32.Parse(s.Substring(0, 4));
            var ssnMonth = Int32.Parse(s.Substring(4, 2));
            var ssnDay = Int32.Parse(s.Substring(6, 2));

            var birthday = new DateTime(ssnYear, ssnMonth, ssnDay);

            TimeSpan age = DateTime.Now - birthday;

            var leapYearsAprox = 5;

            return (age.TotalDays >= ((18 * 365) - leapYearsAprox));
        }

        private static bool ThirdValidationRegId(string regID, char[] validChars)
        {
            bool valid6thChar;
            if (validChars.Contains(regID[5]))
            {
                valid6thChar = true;
            }
            else if (int.TryParse(regID[5].ToString(), out _))
            {
                valid6thChar = true;
            }
            else
            {
                valid6thChar = false;
            }

            return valid6thChar;
        }

        private static bool FirstValidationRegId(string regID, bool validFirstPart, char[] validChars)
        {
            for (int i = 0; i < 3; i++)
            {
                if (validChars.Contains(regID[i]))
                {
                    validFirstPart = true;
                }
                else
                {
                    validFirstPart = false;

                }
            }

            return validFirstPart;
        }

        private static bool SecondValidationRegId(string regID, bool validSecondPart)
        {
            for (int i = 3; i < 5; i++)
            {
                if (int.TryParse(regID[i].ToString(), out _))
                {
                    validSecondPart = true;
                }
                else
                {
                    validSecondPart = false;

                }
            }

            return validSecondPart;
        }
    }
}
