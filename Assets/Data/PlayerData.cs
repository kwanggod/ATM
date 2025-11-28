[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int cash;
    public int balance;
    public PlayerData(string playerName, int cash, int balance)
    {
        this.playerName = playerName;
        this.cash = cash;
        this.balance = balance;
    }
}