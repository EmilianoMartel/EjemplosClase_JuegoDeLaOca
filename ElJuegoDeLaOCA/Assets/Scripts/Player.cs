public class Player
{
    public int playerID;
    public int playerPosition;
    public bool playerLooseTurn;

    public Player(int playerID, int playerPosition)
    {
        this.playerID = playerID;
        this.playerPosition = playerPosition;
        playerLooseTurn = false;
    }
}