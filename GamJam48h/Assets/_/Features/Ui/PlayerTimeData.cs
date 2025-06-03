using UnityEngine;

namespace UIManager
{
    [System.Serializable]
    public class PlayerTimeData
    {
        public string m_playerName = "player";
        public float[] m_times = new float[3];
        
        public PlayerTimeData() { }

        public PlayerTimeData(string playerName)
        {
            m_playerName = playerName;
            m_times = new float[3];
        }
    }
}
