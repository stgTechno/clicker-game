using System.Numerics;
using TMPro;
using UnityEngine;
public class TestButtonDeductScript : MonoBehaviour, IDataStorage
{
    public Session session;
    public TextMeshProUGUI entropyText;
    
    public void LoadData(GameData data)
    {
        session.sessionEntropy = BigInteger.Parse(data.entropy);
        entropyText.text = session.sessionEntropy.ToString();
    }

    public void SaveData(ref GameData data)
    {
        data.entropy = session.sessionEntropy.ToString();
        print("Added");
    }

    public void MainButtonPress()
    {
        session.sessionEntropy--;
        entropyText.text = session.sessionEntropy.ToString();
    }
}