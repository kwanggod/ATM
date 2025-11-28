using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    private List<GameObject> Ui = new List<GameObject>();

    [Header("Main")]
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI cash;
    [SerializeField] private TextMeshProUGUI balance;

    [Header("UIObject")]
    [SerializeField] private GameObject choice;
    [SerializeField] private GameObject withdrawal;
    [SerializeField] private GameObject deposit;
    [SerializeField] private GameObject popupError;

    [Header("Input")]
    [SerializeField] private TMP_InputField withdrawalAmountinput;
    [SerializeField] private TMP_InputField depositAmountinput;


    private void Start()
    {
        UpdateUI();
        SetUi();
    }
    #region UI
    public void UpdateUI()
    {
        playerName.text = GameManager.Instance.playerData.playerName;
        cash.text = string.Format("{0:N0}", GameManager.Instance.playerData.cash);
        balance.text = string.Format("{0:N0}", GameManager.Instance.playerData.balance);
        GameManager.Instance.SaveData();
    }
    private void SetUi()
    {
        Ui.Add(choice);
        Ui.Add(withdrawal);
        Ui.Add(deposit);
    }
    public void TriggerUi(GameObject target)
    {
        SetOffUi();
        target.SetActive(true);
    }
    private void SetOffUi()
    {
        for (int i = 0; i < Ui.Count; i++)
        {
            Ui[i].SetActive(false);
        }
    }
    #endregion


    public void DepositAmount(int Amount)
    {
        if (Amount > GameManager.Instance.playerData.cash)
        {
            popupError.SetActive(true);
        }
        else
        {
            GameManager.Instance.playerData.cash -= Amount;
            GameManager.Instance.playerData.balance += Amount;
        }
        UpdateUI();
    }
    public void WithdrawalAmount(int Amount)
    {
        if (Amount > GameManager.Instance.playerData.balance)
        {
            popupError.SetActive(true);
        }
        else
        {
            GameManager.Instance.playerData.balance -= Amount;
            GameManager.Instance.playerData.cash += Amount;
        }
        UpdateUI();
    }
    public void InputAmountButton(string inOut)
    {
        int amount;
        if (inOut == "Deposit")
        {
            amount = int.Parse(depositAmountinput.text);
            DepositAmount(amount);
        }
        else if (inOut == "Withdrawal")
        {
            amount = int.Parse(withdrawalAmountinput.text);
            WithdrawalAmount(amount);
        }
    }
    [ContextMenu("testButton")]
    public void del()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}