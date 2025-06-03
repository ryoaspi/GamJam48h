using System.IO;
using TMPro;
using UnityEngine;

namespace UIManager
{
    public class EndGame : MonoBehaviour
    {
        #region Api Unity
        
        void Start()
        {
            
            string path = Path.Combine(Application.persistentDataPath, "TimerData.json");
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            PlayerTimeData player = data.players.Find(p => p.m_playerName == PlayerName.m_playerName);
            if (player != null)
            {
                _nameText.text = "Joueur : " + data.players;
                _scoreText.text = "Temps total : " + TimerData.GetTotalTime().ToString("0.00") + " sec";
            }
            else
            {
                _nameText.text = "Pas de données trouvées.";
                _scoreText.text = "";
            }
        }

        
        void Update()
        {
        
        }
        
        #endregion
        
        
        #region Private And Public

        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _scoreText;

        #endregion
    }
}
