using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int coin = 300;
    public int health = 3;
    public int fast = 1;

    public void ResetHealth() => health = 3;
    public void IncreaseHealth() => health = Mathf.Min(health + 1, 3);
    public void DecreaseHealth() => health = Mathf.Max(health - 1, 0);

   

    
}
