using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public void Start()
    {
        m_WeaponManager = GameObject.FindWithTag("WeaponManager");

        if (!m_IsPlayersWeapon){
            int iAllWeapons = m_WeaponManager.transform.childCount;

            for(int i = 0; i < iAllWeapons; ++i){
                if(m_ID == m_WeaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().m_ID){
                    m_Weapon = m_WeaponManager.transform.GetChild(i).gameObject;
                    print(m_Weapon.name);
                }
            }
        }
    }

    public void Update()
    {
        if (m_Equpped){
        }
    }

    public void ItemUsage()
    {
        // Weapon
        if ("Weapon" == m_ItemType){
            m_Equpped = true;
            m_Weapon.SetActive(true);
        }
    }

    public int m_ID;
    public string m_ItemType;
    public string m_ItemDescription;
    public Sprite m_Icon;
    public bool m_IsPickedUp;

    [HideInInspector]
    public bool m_Equpped;

    [HideInInspector]
    // For Use
    public GameObject m_Weapon;

    [HideInInspector]
    public GameObject m_WeaponManager;

    public bool m_IsPlayersWeapon;



}
