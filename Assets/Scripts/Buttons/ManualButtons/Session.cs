using System;
using System.Numerics;
using UnityEngine;

public class Session : MonoBehaviour, IDataStorage
{
    public BigInteger sessionEntropy;
    private bool isQuitting;

    private void OnEnable()
    {
        Application.quitting += HandleApplicationQuitting;
    }

    private void OnDisable()
    {
        Application.quitting -= HandleApplicationQuitting;
    }

    private void HandleApplicationQuitting()
    {
        isQuitting = true;
        sessionEntropy = 0;
    }

    public void LoadData(GameData data)
    {
        sessionEntropy = BigInteger.Parse(data.entropy);
    }

    public void SaveData(ref GameData data)
    {
        if (data != null && !isQuitting)
        {
            data.entropy = sessionEntropy.ToString();
        }
    }
}