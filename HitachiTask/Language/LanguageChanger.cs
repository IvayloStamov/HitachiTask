namespace HitachiTask.Language
{
    public static class LanguageChanger
    {
        public static bool ChangeLanguage(bool isEnglish)
        {
            if(isEnglish == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}