using System;
using System.Collections.Generic;
using ClasesRegulares.Clase8;
using UnityEngine;

[Serializable]
public struct Costumer
{
    public string costumerName;
    public string costumerID;
}

public struct CharacterData
{
    public string id;
    public string characterName;
    public int characterAge;

    public override string ToString()
    {
        string l_characterString = string.Empty;
        l_characterString += "Character name: " + characterName + ", " + "Character age: " +
                             characterAge;
        return l_characterString;
    }
}

public struct InventoryItem
{
    public int amount;
    public ItemData itemData;
}

public struct ItemData
{
    public string id;
}

public class Inventory
{
    private Dictionary<string, InventoryItem> m_items;

    public void AddToInventory(ItemData p_itemData, int p_quantity)
    {
        if (m_items.ContainsKey(p_itemData.id))
        {
            var l_inventoryItem = m_items[p_itemData.id];
            l_inventoryItem.amount += p_quantity;
            m_items[p_itemData.id] = l_inventoryItem;
        }
        else
        {
            var l_inventoryItem = new InventoryItem();
            l_inventoryItem.itemData = p_itemData;
            l_inventoryItem.amount = p_quantity;
            m_items.Add(p_itemData.id, l_inventoryItem);
        }
    }

    public void UseItemFromInventory(string p_id, int p_quantity)
    {
        if (m_items.ContainsKey(p_id))
        {
            var l_inventoryItem = m_items[p_id];
            l_inventoryItem.amount -= p_quantity;
            if (l_inventoryItem.amount <= 0)
            {
                m_items.Remove(p_id);
                return;
            }

            m_items[p_id] = l_inventoryItem;
        }
        else
        {
            Debug.LogWarning($"{p_id} was not found");
        }
    }
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] m_enemiesToSpawn;

    [SerializeField] private List<Enemy> m_enemiesList;
    [SerializeField] private Enemy m_enemy;
    [SerializeField] private List<int> m_myInts;
    private List<Costumer> m_myCostumers = new List<Costumer>();

    [SerializeField] private List<Transform> m_spawnPositions;

    [SerializeField] private Queue<int> m_costumersQueue = new Queue<int>();
    [SerializeField] private Stack<Costumer> m_costumersStack = new Stack<Costumer>();

    private Dictionary<string, CharacterData> m_charactersDictionary = new Dictionary<string, CharacterData>();

    private void Awake()
    {
        // m_enemiesToSpawn = new Enemy[100];
        // m_enemiesList = new List<Enemy>();
        // m_enemiesList.Add(m_enemiesToSpawn[0]);
        // m_enemiesList.RemoveAt(2);

        // Destroy(m_enemy.gameObject);
        CharacterData m_marioData = new CharacterData()
        {
            characterAge = 25,
            characterName = "Mario",
            id = "Mario"
        };

        m_charactersDictionary.Add("Mario", m_marioData);


        PrintInfoFromMario("Mario");
        RemoveInfoFromMario("Mario");
        if (HasKey("Mario"))
        {
            Debug.Log("Tiene a mario");
        }
        else
        {
            Debug.Log("No tiene a mario");
        }

        PrintInfoFromMario("Mario");

        InstantiateAllEnemies();
        // var l_obtainedCostumer = TryGetCostumer(out Costumer p_myCostumer);
        //
        // if (l_obtainedCostumer)
        // {
        //     Debug.Log(p_myCostumer.costumerName);
        // }
    }

    private Transform GetRandomPosition()
    {
        int l_randomIndex = UnityEngine.Random.Range(0, m_spawnPositions.Count);
        return m_spawnPositions[l_randomIndex];
    }

    private void InstantiateAllEnemies()
    {
        // for (int i = 0; i < m_enemiesList.Count; i++)
        // {
        //     Enemy l_enemyToInstantiate = m_enemiesList[i];
        //     Instantiate(l_enemyToInstantiate);
        // }

        foreach (Enemy l_enemy in m_enemiesList)
        {
            Transform l_spawnTransform = GetRandomPosition();
            Instantiate(l_enemy, l_spawnTransform.position, Quaternion.identity);
        }

        Debug.Log("Exit");
    }


    private void PrintInfoFromMario(string p_key)
    {
        if (m_charactersDictionary.TryGetValue(p_key, out CharacterData l_marioData))
        {
            Debug.Log(l_marioData);
        }
        else
        {
            Debug.LogWarning($"Key {p_key} not found");
        }
    }

    private void RemoveInfoFromMario(string p_key)
    {
        var l_couldRemove = m_charactersDictionary.Remove(p_key);

        if (!l_couldRemove)
        {
            Debug.LogWarning($"Couldn't remove {p_key} because it doesn't exist");
        }
    }

    private bool HasKey(string p_key)
    {
        return m_charactersDictionary.ContainsKey(p_key);
    }

    private void AddCostumer(Costumer p_costumer)
    {
        m_costumersStack.Push(p_costumer);
    }

    private bool TryGetLastCostumer(out Costumer p_costumer)
    {
        return m_costumersStack.TryPop(out p_costumer);
    }

    // private bool TryGetCostumer(out Costumer p_costumer)
    // {
    //     return m_costumersQueue.TryDequeue(out p_costumer);
    //
    //     // if (m_costumersQueue.Count > 0)
    //     // {
    //     //     return m_costumersQueue.Dequeue();
    //     // }
    //     //
    //     // return default;
    // }

    // private Costumer ObtainCostumer()
    // {
    //     if (m_myCostumers.Count > 0)
    //     {
    //         var l_myCostumer = m_myCostumers[0];
    //         m_myCostumers.RemoveAt(0);
    //         return l_myCostumer;
    //     }
    //
    //     return default;
    // }
    //
    // private Costumer ObtainCheatCostumer()
    // {
    //     if (m_myCostumers.Count > 0)
    //     {
    //         var l_myCostumer = m_myCostumers[m_myCostumers.Count - 1];
    //         m_myCostumers.RemoveAt(m_myCostumers.Count - 1);
    //         return l_myCostumer;
    //     }
    //
    //     return default;
    // }

    [ContextMenu("Print name from last index")]
    private void GetNameFromLastIndex()
    {
        Debug.Log(m_enemiesToSpawn[m_enemiesToSpawn.Length - 1].name);
        Debug.Log(m_enemiesList[m_enemiesList.Count - 1].name);
    }
}