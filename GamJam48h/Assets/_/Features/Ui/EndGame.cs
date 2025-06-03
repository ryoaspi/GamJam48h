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
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                TimerData data = JsonUtility.FromJson<TimerData>(json);
                _nameText.text = "Joueur : " + data.m_playerName;
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
