using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsImplementation : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth playerHealth;

    private void Awake()
    {
        PlayerLife();
    }
    //life stats
    [SerializeField]
    private int flatLife = 100;
    public int FlatLife 
    { 
        get { return flatLife; }
        set { flatLife += value; PlayerLife(); }
    }
    private int increasedLife = 0;
    public int IncreasedLife 
    {
        get { return increasedLife; }
        set { increasedLife += value; PlayerLife(); }
    }    
    void PlayerLife()
    {
        int life;
        life = flatLife * 1 + (increasedLife / 100);
        //playerHealth.maxHealth = life;
    }
}
