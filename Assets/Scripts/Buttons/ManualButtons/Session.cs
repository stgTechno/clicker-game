using System.Numerics;
using UnityEngine;

public class Session : MonoBehaviour, IDataStorage
{
    public BigInteger sessionEntropy;

    public void LoadData(GameData data)
    {
        sessionEntropy = BigInteger.Parse(data.entropy);
    }

    public void SaveData(ref GameData data)
    {
        if (data != null)
        {
            data.entropy = sessionEntropy.ToString();
        }
    }

    private void OnApplicationQuit()
    {
        sessionEntropy = 0;
    }
}
