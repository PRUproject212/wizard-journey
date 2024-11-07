using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    public int coin = 300;
    public int health = 3;
    public int fast = 1;

    public void Start()
    {
        LoadGameData();
    }
    public void ResetHealth()
    {
        health = 3;
        SaveGameData(); // Save data after resetting health
    }

    public void IncreaseHealth()
    {
        health = Mathf.Min(health + 1, 3);
        SaveGameData(); // Save data after increasing health
    }

    public void DecreaseHealth()
    {
        health = Mathf.Max(health - 1, 0);
        SaveGameData(); // Save data after decreasing health
    }



    public void SaveGameData()
    {
        GameData data = new GameData
        {
            coin = this.coin,
            health = this.health,
            fast = this.fast
        };

        string saveFilePath = Path.Combine(Application.persistentDataPath, "gamedata.json");
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(saveFilePath));
            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(saveFilePath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                    Debug.Log("Game data saved.");
                    Debug.Log(saveFilePath);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error occured when trying to save data to file: " + saveFilePath + "\n" + ex);
        }
    }

    public void LoadGameData()
    {
        string saveFilePath = Path.Combine(Application.persistentDataPath, "gamedata.json");
        GameData loadedData = null;
        if (File.Exists(saveFilePath)) 
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(saveFilePath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
                if (loadedData != null)
                {
                    this.coin = loadedData.coin;
                    this.health = loadedData.health;
                    this.fast = loadedData.fast;
                    Debug.Log("Game data loaded successfully.");
                }
            }
            catch (Exception ex) 
            {
                Debug.LogError("Error occured when trying to load data from file" + saveFilePath + "\n" + ex);
            }
        }
        
    }

    public void buyShop(int signal)
    {
        if (signal == 1)
        {
            if (coin >= 200)
            {
                fast++;
                coin -= 200;
                SaveGameData(); // Save data after purchase
                FindObjectOfType<ShopController>().buySuccessPopup.SetActive(true);
                FindObjectOfType<UIShopController>().coinText.text = coin.ToString();
            }
            else
            {
                FindObjectOfType<ShopController>().buyFailPopup.SetActive(true);
            }
        }
        else
        {
            if (coin >= 300 && health < 3)
            {
                health++;
                coin -= 300;
                SaveGameData(); // Save data after purchase
                FindObjectOfType<ShopController>().buySuccessPopup.SetActive(true);
                FindObjectOfType<UIShopController>().coinText.text = coin.ToString();
            }
            else
            {
                FindObjectOfType<ShopController>().buyFailPopup.SetActive(true);
            }
        }
    }

    public void buyShopPopup(int signal) // Main Screen
    {
        if (signal == 1)
        {
            if (coin >= 200)
            {
                fast++;
                coin -= 200;
                SaveGameData(); // Save data after successful purchase
                FindObjectOfType<ShopPopupController>().buySuccessPopup.SetActive(true);
                FindObjectOfType<PlayerPoint>().UpdateHealth();
                FindObjectOfType<Energy>().amountText.text = fast.ToString();
            }
            else
            {
                FindObjectOfType<ShopPopupController>().buyFailPopup.SetActive(true);
            }
        }
        else
        {
            if (coin >= 300 && health < 3)
            {
                health++;
                coin -= 300;
                SaveGameData(); // Save data after successful purchase
                FindObjectOfType<ShopPopupController>().buySuccessPopup.SetActive(true);
                FindObjectOfType<PlayerPoint>().UpdateHealth();
            }
            else
            {
                FindObjectOfType<ShopPopupController>().buyFailPopup.SetActive(true);
            }
        }
    }
}