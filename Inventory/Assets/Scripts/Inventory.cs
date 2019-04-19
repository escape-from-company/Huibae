using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    void Start()
    {
        m_SlotNum = 15;

        m_Slots = new GameObject[m_SlotNum];

        for (int i = 0; i < m_SlotNum; ++i) {
            m_Slots[i] = m_SlotHolder.transform.GetChild(i).gameObject;

            if (null == m_Slots[i].GetComponent<Slot>().m_Item)
                m_Slots[i].GetComponent<Slot>().m_IsEmpty = true;
        }
    }

    void CheckKey()
    {
        if (Input.GetKeyDown(KeyCode.I)) m_IsEnabledInventory = !m_IsEnabledInventory;

        if (m_IsEnabledInventory) m_Inventory.SetActive(true);
        else m_Inventory.SetActive(false);

    }

    void Update()
    {
        CheckKey();
    }

    void AddItem(GameObject itemObject, int iItemID, string strItemType, string strItemDescription, Sprite itemIcon)
    {
        for(int i = 0; i < m_SlotNum; ++i){
            if (m_Slots[i].GetComponent<Slot>().m_IsEmpty){
                itemObject.GetComponent<Item>().m_IsPickedUp = true;

                m_Slots[i].GetComponent<Slot>().m_Item = itemObject;
                m_Slots[i].GetComponent<Slot>().m_ID = iItemID;
                m_Slots[i].GetComponent<Slot>().m_ItemType = strItemType;
                m_Slots[i].GetComponent<Slot>().m_ItemDescription = strItemDescription;
                m_Slots[i].GetComponent<Slot>().m_Icon = itemIcon;

                itemObject.transform.parent = m_Slots[i].transform;
                itemObject.SetActive(false);

                m_Slots[i].GetComponent<Slot>().UpdateSlot();
                m_Slots[i].GetComponent<Slot>().m_IsEmpty = false;

                return;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ("Item" == other.tag){
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.m_ID, item.m_ItemType, item.m_ItemDescription, item.m_Icon);
        }

    }



    public GameObject m_Inventory;
    public GameObject m_SlotHolder;

    private bool m_IsEnabledInventory;
    private int m_SlotNum;
    private int m_EnabledSlots;

    private GameObject[] m_Slots;
}
