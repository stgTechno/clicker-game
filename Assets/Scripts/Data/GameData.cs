[System.Serializable]
public class GameData
{
    public string entropy;

    /**
     * Die Werte, die hier definiert sind werden die Standardwerte sein wenn jemand anfängt zu spielen
     */
    public GameData()
    {
        entropy = "0";
    }
}