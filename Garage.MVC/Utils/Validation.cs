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
