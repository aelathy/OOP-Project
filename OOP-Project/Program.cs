// OOP Game/Project
#nullable disable
using System.Text.Json;
Console.Clear();

// Global Variable
Random rnd = new Random();
int matchCount = 0;
int winCount = 0;
int drawCount = 0;
int lossCount = 0;

// Team Name
Console.WriteLine("Team members of the Silent Diplomats soccer team!");

// Categories
Console.WriteLine("\nName - Team # - Rating - Goals Scored");

// Initialize list of members
List<Member> members = new List<Member>();

// Add members to list of members
members.Add(new Member("Adam", 1, 76));
members.Add(new Member("Jason", 2, 73));
members.Add(new Member("Jack", 3, 84));
members.Add(new Member("Kyle", 4, 81));
members.Add(new Member("John", 5, 63));
members.Add(new Member("Joe", 6, 93));

showMemberStats();

bool menuLoop = true;
while (menuLoop)
{
    Console.WriteLine("\n Main Menu");
    Console.WriteLine("1. Show Team Members and Stats");
    Console.WriteLine("2. Sort Player Ratings (Lowest - Highest)");
    Console.WriteLine("3. Sort Player Ratings (Highest - Lowest)");
    Console.WriteLine("4. Add New Member");
    Console.WriteLine("5. Remove Member");
    Console.WriteLine("8. Play a Game");
    Console.WriteLine("\nSelect a menu option or quit.");
    string userInput = Console.ReadLine();

    if (userInput == "1")
    {
        showMemberStats();
    }
    else if (userInput == "2")
    {
        sortLowToHigh();
    }
    else if (userInput == "3")
    {
        sortHighToLow();
    }
    else if (userInput == "4")
    {
        addMember();
    }
    else if (userInput == "5")
    {
        removeMember();
    }
    else if (userInput == "6")
    {

    }
    else if (userInput == "7")
    {

    }
    else if (userInput == "8")
    {
        playGame();
    }
    else if (userInput == "9")
    {
        break;
    }
}

// Functions
void showMemberStats()
{
    int totalScore = 0;
    foreach (Member member in members)
    {
        totalScore += member.Score;
        Console.WriteLine($"{member.Name} - {member.PlayerNumber} - {member.Rating} - {member.Score}");
    }
    Console.WriteLine($"\nTotal Goals Scored: {totalScore}");
    Console.WriteLine($"Matches Played: {matchCount}");
    Console.WriteLine($"Wins: {winCount}");
    Console.WriteLine($"Draws: {drawCount}");
    Console.WriteLine($"Losses: {lossCount}");
}

void addMember()
{
    Console.WriteLine("\nAdd a new team member.");
    Console.Write("\nName: ");
    string nameInput = Console.ReadLine();
    Console.Write("Rating (<= 100): ");
    int ratingInput = Convert.ToInt32(Console.ReadLine());
    if (ratingInput > 100)
        ratingInput = 100;
    // if (!checkName(nameInput))
    // {
    //     Console.WriteLine(nameInput + " added to list.");
    // }
    // else
    // {
    //     Console.WriteLine($"{nameInput} is already in the team.");
    // }
    if (!members.Exists(m => (m.Name == nameInput)))
    {
        members.Add(new Member(nameInput, members.Last().PlayerNumber + 1, ratingInput));
        Console.WriteLine($"{nameInput} added to team.");
    }
    else
    {
        Console.WriteLine($"{nameInput} is already in the team.");
    }
}

// bool checkName(string name)
// {
//     foreach (Member member in members)
//     {
//         if (name == member.Name)
//         {
//             return true;
//         }
//     }
//     return false;
// }

void removeMember()
{
    Console.WriteLine("\nRemove a team member.");
    Console.Write("\nName: ");
    string nameInput = Console.ReadLine();
    bool nameExists = true;
    foreach (Member member in members)
    {
        if (member.Name == nameInput)
        {
            members.Remove(member);
            Console.WriteLine("Aly removed from the team.");
            break;
        }
        else
        {
            nameExists = false;
        }
    }
    if (nameExists)
    {
        Console.WriteLine("Player already in list.");
    }
}

void sortLowToHigh()
{
    // Sort by rating from lowest to highest, then display
    members.Sort((m1, m2) => m1.Rating.CompareTo(m2.Rating));
    showMemberStats();
}

void sortHighToLow()
{
    // Sort by rating from highest to lowest, then display
    members.Sort((m1, m2) => m2.Rating.CompareTo(m1.Rating));
    showMemberStats();
}

void playGame()
{
    resetTempScore();
    matchCount++;
    int myTeam = 0;
    int theirTeam = 0;
    for (int i = 0; i < 90; i++)
    {
        int randNum = rnd.Next(1, 31);
        if (randNum == 1)
        {
            myTeam++;
            goalScored();
        }
        else if (randNum == 2)
        {
            theirTeam++;
        }
    }

    if (myTeam > theirTeam)
    {
        Console.WriteLine("We Won :)");
        winCount++;
    }
    else if (theirTeam > myTeam)
    {
        Console.WriteLine("We Lost :{");
        lossCount++;
    }
    else
    {
        Console.WriteLine("We Drew :|");
        drawCount++;
    }

    Console.WriteLine($"\nSilent Diplomats {myTeam} : {theirTeam} Other Team");
    displayGoals();
}

void goalScored()
{
    int randNum = rnd.Next(1, members.Count + 1);
    foreach (Member member in members)
    {
        if (member.PlayerNumber == randNum)
        {
            member.Score++;
            member.TempScore++;
            if (member.Rating < 100)
            {
                member.Rating++;
            }
        }
    }
}

void displayGoals()
{
    foreach (Member member in members)
    {
        if (member.TempScore == 1)
        {
            Console.WriteLine($"{member.TempScore} goal scored by {member.Name}.");
        }
        else if (member.TempScore > 1)
        {
            Console.WriteLine($"{member.TempScore} goals scored by {member.Name}.");
        }
    }
}

void resetTempScore()
{
    foreach (Member member in members)
    {
        member.TempScore = 0;
    }
}



class Member
{
    public string Name { get; set; }
    public int PlayerNumber { get; set; }
    public int Rating { get; set; }
    public int Score { get; set; }
    public int TempScore { get; set; }

    public Member(string name, int age, int rating)
    {
        Name = name;
        PlayerNumber = age;
        Rating = rating;
    }
}