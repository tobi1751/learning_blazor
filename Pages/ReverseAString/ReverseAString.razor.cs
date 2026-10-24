namespace tasker.Pages.ReverseAString;

public partial class ReverseAString
{
    private string message = "Reverse Me";
    private string reversedMessage = "";
    private bool IsPalindrome = false;

    private void ReverseMe()
    {
        reversedMessage = "";

        for (int i = message.Length - 1; i >= 0; i--)
        {
            reversedMessage += message[i];
        }

        if (message == reversedMessage)
        {
            IsPalindrome = true;
        }
        else
        {
            IsPalindrome = false;
        }
    }
    private void ClearMe() => reversedMessage = "";
}