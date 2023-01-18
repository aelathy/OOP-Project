// OOP Game/Project
#nullable disable
Console.Clear();

// Global Variable
Random rnd = new Random();
int matchCount = 0;
int winCount = 0;
int drawCount = 0;
int lossCount = 0;
int totalScore = 0;

// Team Name
Console.WriteLine("Team members of the Silent Diplomats soccer team!");

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
    // Menu Loop
    Console.WriteLine("\n Main Menu");
    Console.WriteLine("1. Show Team Members and Stats");
    Console.WriteLine("2. Sort Player Ratings (Lowest - Highest)");
    Console.WriteLine("3. Sort Player Ratings (Highest - Lowest)");
    Console.WriteLine("4. Add New Member");
    Console.WriteLine("5. Remove Member");
    Console.WriteLine("6. Play a Game");
    Console.WriteLine("7. Exit");
    Console.WriteLine("\nSelect a menu option.");
    string userInput = Console.ReadLine();

    if (userInput == "1")
    {
        showMemberStats();
    }
    else if (userInput == "2")
    {
        // Sort player ratings from lowest to highest
        sortLowToHigh();
    }
    else if (userInput == "3")
    {
        // Sort player ratings from highest to lowest
        sortHighToLow();
    }
    else if (userInput == "4")
    {
        // Add new member, max capacity is 9
        if (members.Count < 9)
            addMember();
        else
            Console.WriteLine("Max # of players reached.");
    }
    else if (userInput == "5")
    {
        // Remove member by name
        removeMember();
    }
    else if (userInput == "6")
    {
        // Check if team is empty
        if (members.Count > 0)
            playGame();
        else
            Console.WriteLine("We forfeit. Not enough players.");
    }
    else if (userInput == "7")
    {
        break;
    }
}

// Functions
void showMemberStats()
{
    // Categories
    Console.WriteLine("\nName - Team # - Rating - Goals Scored");
    foreach (Member member in members)
    {
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
<<<<<<< HEAD
    Console.WriteLine("\nAdd a new team member.");
    Console.Write("\nName: ");
    string nameInput = Console.ReadLine();
    Console.Write("Rating (<= 100): ");
    int ratingInput = Convert.ToInt32(Console.ReadLine());
    if (ratingInput > 100)
        ratingInput = 100;
    if (!members.Exists(m => (m.Name == nameInput)))
=======
>>>>>>> efda52cdb0cd62f4374c6dfc9aab1186fb49c146
    {
        Console.WriteLine("\nAdd a new team member.");
        Console.Write("\nName: ");
        string nameInput = Console.ReadLine();
        Console.Write("Rating (<= 100): ");
        int ratingInput = Convert.ToInt32(Console.ReadLine());
        if (ratingInput > 100)
            ratingInput = 100;
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
}

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
            Console.WriteLine($"{nameInput} removed from the team.");
            break;
        }
        else
        {
            nameExists = false;
        }
    }
    if (!nameExists)
    {
        Console.WriteLine("Player not found.");
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
    for (int i = 0; i < 91; i++)
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
        Console.WriteLine("We Won :) - All members gain 5 rating points!");
        winCount++;
        addRatings();
    }
    else if (theirTeam > myTeam)
    {
        Console.WriteLine("We Lost :{ - All members lose 10 rating points.");
        lossCount++;
        subtractRatings();
    }
    else
    {
        Console.WriteLine("We Drew :|");
        drawCount++;
    }

    Console.WriteLine($"\nSilent Diplomats {myTeam} : {theirTeam} Other Team");
    displayGoals();
}

// Add points
void goalScored()
{
    int randNum = rnd.Next(1, members.Count + 1);
    foreach (Member member in members)
    {
        if (member.PlayerNumber == randNum)
        {
            totalScore++;
            member.Score++;
            member.TempScore++;
            if (member.Rating < 100)
            {
                member.Rating++;
            }
        }
    }
}

// Display final count of goals after a match
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

// Remove 10 points from everyone on the team if they lose
void subtractRatings()
{
    foreach (Member member in members)
    {
        if (member.Rating > 11)
        {
            member.Rating -= 10;
        }
        else
        {
            member.Rating = 0;
        }
    }
}

// Add 5 points for everyone if they win (100 is the limit)
void addRatings()
{
    foreach (Member member in members)
    {
        if (member.Rating < 96)
        {
            member.Rating += 5;
        }
        else
        {
            member.Rating = 100;
        }
    }
}

// Reset previous temporary score at the beginning of a every match
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