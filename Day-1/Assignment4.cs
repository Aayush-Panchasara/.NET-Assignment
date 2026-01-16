public class UserProfile
{
    public string? Username {get; set;}
    public string? Email {get; set;}
    public int? Age {get; set;}
    
    public void DisplayUserInfo()
    {
        System.Console.WriteLine($"Username = {Username ?? "N/A"}");
        System.Console.WriteLine($"Email = {Email ?? "N/A"}");

        if (Age.HasValue)
        {
            System.Console.WriteLine($"Age = {Age.Value}");
        }
        else
        {
            System.Console.WriteLine($"Age = N/A");
        }
    }
}

public class Program
{
    public static void Main()
    {
        UserProfile user1 = new UserProfile
        {
            Username = "User 1",
            Email = "user.one@google.com",
            Age = 21
        };
        System.Console.WriteLine("User1 Info");
        user1.DisplayUserInfo();
        System.Console.WriteLine();

        UserProfile user2 = new UserProfile
        {
            Username = "User 2",
            Email = null,
            Age = 22
        };
        System.Console.WriteLine("User2 Info");
        user2.DisplayUserInfo();
        System.Console.WriteLine();

        UserProfile user3 = new UserProfile
        {
            Username = "User 3",
            Email = null,
            Age = null
        };
        System.Console.WriteLine("User3 Info");
        user3.DisplayUserInfo();
    }
}