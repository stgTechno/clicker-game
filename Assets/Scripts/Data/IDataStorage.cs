public interface IDataStorage
{
    void LoadData(GameData data);
    void SaveData(ref GameData data);
}