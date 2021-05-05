using System;

public class Player : IComparable<Player>
{
    public string name;
    public bool isLost;
    public int score;

    public int CompareTo(Player comparePart)
    {
        if (comparePart == null)
            return 1;
        else
            return score.CompareTo(comparePart.score);
    }
}
