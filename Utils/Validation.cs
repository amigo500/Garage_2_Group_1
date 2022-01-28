namespace Garage_2_Group_1.Utils
{
    public class Validation
    {
        public Boolean RegIdValidation(string regID)
        {
            regID = regID.Trim();
            regID = regID.ToUpper();

            char[] validChars = "QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
            if (regID.Length == 6)
            {
                bool valid;
                for (int i = 0; i < 3; i++)
                {
                    if (validChars.Contains(regID[i]))
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                        return false;
                    }
                }
                for (int i = 3; i < 5; i++)
                {
                    if (int.TryParse(regID[i].ToString(), out _))
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                        return valid;
                    }
                }
                if (validChars.Contains(regID[5]))
                {
                    valid = true;
                }
                else if (int.TryParse(regID[5].ToString(), out _))
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }
                return valid;
            }
            else
            {
                return false;
            }   
        }
    }
}
