
[System.Serializable]
public class LeaderboardsData
{
    public int[] highScores;
   
    public LeaderboardsData(int[] highScores) {
        this.highScores = highScores;
    }
    public LeaderboardsData() { 
        this.highScores = new int[10];
    }
}