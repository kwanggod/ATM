using UnityEngine;
public class GameManager : MonoBehaviour
{
    public PlayerData playerData { get; private set; }
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                SetupInstance();
            }
            return instance;
        }
    }
    private static void SetupInstance()
    {
        instance = FindAnyObjectByType<GameManager>();
        if (instance == null)
        {
            instance = new GameObject(typeof(GameManager).Name).AddComponent<GameManager>();
            DontDestroyOnLoad(instance.gameObject);
        }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        LoadData();
    }
    public void SaveData()
    {
        PlayerPrefs.SetString("PlayerName", playerData.playerName);
        PlayerPrefs.SetInt("Cash", playerData.cash);
        PlayerPrefs.SetInt("Balance", playerData.balance);
        PlayerPrefs.Save();
    }
    private void LoadData()
    {
        playerData = new PlayerData(
            PlayerPrefs.GetString("PlayerName", "∏£≈∫¿Ã"),
            PlayerPrefs.GetInt("Cash", 100000),
            PlayerPrefs.GetInt("Balance", 50000)
        );
    }
}