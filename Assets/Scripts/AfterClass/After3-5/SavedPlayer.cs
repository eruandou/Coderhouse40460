using System;
using System.IO;
using UnityEngine;

namespace AfterClass.After3_5
{
    /*
        public class SaveData
        {
            private string m_currentHealthKey = "CurrentHealth";
            private string m_playerNameKey = "PlayerName";
            private string m_characterFloatsKey = "CharacterFloats";
            private string m_positionKey = "CharacterPosition";
    
            public float currentHealth;
            public string playerName;
            public bool characterFloats;
            public Vector3 characterPosition;
    
            public void Save()
            {
                PlayerPrefs.SetFloat(m_currentHealthKey, currentHealth);
                PlayerPrefs.SetString(m_playerNameKey, playerName);
                SaveBool(m_characterFloatsKey, characterFloats);
                SaveVector3(m_positionKey, characterPosition);
                PlayerPrefs.Save();
            }
    
            public void Load()
            {
                currentHealth = PlayerPrefs.GetFloat(m_currentHealthKey);
                playerName = PlayerPrefs.GetString(m_playerNameKey);
                characterFloats = GetBool(m_characterFloatsKey);
                characterPosition = LoadVector3(m_positionKey);
            }
    
            private void SaveVector3(string p_key, Vector3 p_vector)
            {
                var l_x = p_vector.x;
                var l_y = p_vector.y;
                var l_z = p_vector.z;
    
                PlayerPrefs.SetFloat(characterPosition + "x", l_x);
                PlayerPrefs.SetFloat(characterPosition + "y", l_y);
                PlayerPrefs.SetFloat(characterPosition + "z", l_z);
            }
    
            private Vector3 LoadVector3(string p_key)
            {
                float l_x = PlayerPrefs.GetFloat(characterPosition + "x");
                float l_y = PlayerPrefs.GetFloat(characterPosition + "y");
                float l_z = PlayerPrefs.GetFloat(characterPosition + "z");
    
                Vector3 l_loadedVector = new Vector3(l_x, l_y, l_z);
    
                return l_loadedVector;
            }
    
            private void SaveBool(string p_key, bool p_bool)
            {
                int l_value;
                if (p_bool)
                {
                    l_value = 1;
                }
                else
                {
                    l_value = 0;
                }
    
                PlayerPrefs.SetInt(p_key, l_value);
            }
    
            private bool GetBool(string p_key)
            {
                var l_intValue = PlayerPrefs.GetInt(p_key, 0);
    
                if (l_intValue == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    */
    [Serializable]
    public struct SavedPlayerData
    {
        public float currentHealth;
        public string playerName;
        public bool characterFloats;
        public Vector3 characterPosition;

        public SavedPlayerData(float p_currentHealth, string p_playerName, bool p_characterFloats,
            Vector3 p_characterPosition)
        {
            currentHealth = p_currentHealth;
            playerName = p_playerName;
            characterFloats = p_characterFloats;
            characterPosition = p_characterPosition;
        }
    }

    public class SavedPlayer : MonoBehaviour
    {
        [SerializeField] private float m_speed;
        [SerializeField] private string m_playerName;
        [SerializeField] private float m_maxHealth;
        [SerializeField] private bool m_characterFloats;
        private float m_currentHealth;

        private void Awake()
        {
            if (!IsValidName(m_playerName))
            {
                Debug.LogWarning("The player doesn't have a valid name");
            }

            m_currentHealth = m_maxHealth;
        }

        private bool IsValidName(string p_name)
        {
            var l_isNullOrWhiteSpace = string.IsNullOrWhiteSpace(p_name);
            return !l_isNullOrWhiteSpace;
        }


        private void Move(Vector3 p_direction)
        {
            transform.position += ((transform.forward * p_direction.z) + (transform.right * p_direction.x)) *
                                  (m_speed * Time.deltaTime);
        }


        private void Update()
        {
            //Cuando el jugador presiona la tecla K, recibe 1 de daño

            var l_horizontal = Input.GetAxis("Horizontal");
            var l_vertical = Input.GetAxis("Vertical");


            var l_direction = new Vector3(l_horizontal, 0, l_vertical);

            Move(l_direction);

            if (Input.GetKeyDown(KeyCode.K))
            {
                Save();
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                Load();
            }
        }

        [ContextMenu("Take damage")]
        private void TakeDamage()
        {
            m_currentHealth -= 10;
        }

        private void Save()
        {
            // var l_saveData = new SaveData();
            // l_saveData.characterFloats = m_characterFloats;
            // l_saveData.currentHealth = m_currentHealth;
            // l_saveData.playerName = m_playerName;
            // l_saveData.characterPosition = transform.position;
            // l_saveData.Save();

            var l_data = new SavedPlayerData(m_currentHealth, m_playerName, m_characterFloats, transform.position);
            string l_jsonData = JsonUtility.ToJson(l_data, true);
            var l_persistenData = Application.persistentDataPath;
            var l_path = Application.dataPath + "/data.json";
            File.WriteAllText(l_path, l_jsonData);
        }

        private void Load()
        {
            // var l_currentHealth = PlayerPrefs.GetFloat("CurrentHealth", -1);
            // if (l_currentHealth >= 0)
            // {
            //     m_currentHealth = l_currentHealth;
            //     Debug.Log($"My current health is {m_currentHealth}");
            // }

            // var l_saveData = new SaveData();
            // l_saveData.Load();
            //
            // m_currentHealth = l_saveData.currentHealth;
            // m_playerName = l_saveData.playerName;
            // m_characterFloats = l_saveData.characterFloats;
            // transform.position = l_saveData.characterPosition;
            var l_path = Application.dataPath + "/data.json";
            var l_jsonData = File.ReadAllText(l_path);
            var l_loadedJson = JsonUtility.FromJson<SavedPlayerData>(l_jsonData);

            
            m_currentHealth = l_loadedJson.currentHealth;
            m_playerName = l_loadedJson.playerName;
            m_characterFloats = l_loadedJson.characterFloats;
            transform.position = l_loadedJson.characterPosition;
        }
    }
}