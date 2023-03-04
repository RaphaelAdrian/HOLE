using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveScoreToLeaderboard(int[] highScores) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = GetAppPath("leaderboards");
        FileStream stream = new FileStream(path, FileMode.Create);

        LeaderboardsData data = new LeaderboardsData(highScores);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static LeaderboardsData LoadLeaderboards() {
        string path = GetAppPath("leaderboards");
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LeaderboardsData data = formatter.Deserialize(stream) as LeaderboardsData;
            stream.Close();

            return data;
        }
        else {
            LeaderboardsData data = new LeaderboardsData();
            return data;
        }
    }
    private static string GetAppPath(string fileName) {
        return Application.persistentDataPath + "/" + fileName + ".dat";
    }
}
