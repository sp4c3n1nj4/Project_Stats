using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponSkill 
{
    public GameObject WeaponSprite;
    public GameObject SkillPrefab;
}

public class SkillManager : MonoBehaviour
{
    public int weaponToAdd;

    [SerializeField]
    public WeaponSkill[] weapons;

    [SerializeField]
    private GameObject player;

    private void Start()
    {
        AddWeapon(weaponToAdd);
    }

    private void AddWeapon(int index)
    {
        Instantiate(weapons[index].WeaponSprite, player.transform.Find("Aim").transform.Find("AimTarget"));
        Instantiate(weapons[index].SkillPrefab, player.transform);
    }
}
