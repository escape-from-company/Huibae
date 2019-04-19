using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public void Start()
    {
        m_SlotIconGo = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        m_BackGroundIcon = m_SlotIconGo.GetComponent<Image>().sprite;
        m_SlotIconGo.GetComponent<Image>().sprite = m_Icon;
    }

    public void UseItem()
    {
        m_Item.GetComponent<Item>().ItemUsage();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (null == m_Item) return;

        UseItem();
        Reset();
    }

    private void Reset()
    {
        Destroy(m_Item);
        m_SlotIconGo.GetComponent<Image>().sprite = m_BackGroundIcon;

        m_IsEmpty = true;
    }

    public GameObject m_Item;
    public int m_ID;
    public string m_ItemType;
    public string m_ItemDescription;
    public bool m_IsEmpty;

    public Transform m_SlotIconGo;
    public Sprite m_Icon;

    private Sprite m_BackGroundIcon;
}
