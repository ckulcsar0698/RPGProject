using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    [SerializeField]
    private GameObject _inventoryMenu;
    [SerializeField]
    private GameObject _openBook;
    [SerializeField]
    private GameObject _closeBook;
    [SerializeField]
    private Image[] _emptySlots;
    [SerializeField]
    private Sprite[] _inventoryIcons;
    [SerializeField]
    private Sprite _emptyIcon;
    [SerializeField]
    private Text[] _textObjects;
    [SerializeField]
    private Sprite _KeySprite;

    Dictionary<Sprite, int> _itemsInInventory;

    public static int NewIcon { get; set; } = 0;
    public static bool ShouldIconUpdate = false;
    public static bool InventoryHasKey = true;
    public static int GoldInInventory = 0;

    // Start is called before the first frame update
    void Start()
    {
        _inventoryMenu.SetActive(false);
        _openBook.SetActive(false);
        _closeBook.SetActive(true);
        _itemsInInventory = new Dictionary<Sprite, int>();

        foreach(Text obj in _textObjects)
        {
            obj.text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( ShouldIconUpdate )
        {
            int i = 0;
            foreach(Image slot in _emptySlots)
            {
                if(slot.sprite == _inventoryIcons[NewIcon])
                {
                    _itemsInInventory[slot.sprite]++;

                    UpdateItemCount(i, _itemsInInventory[slot.sprite]);

                    break;
                }
                if(slot.sprite == _emptyIcon)
                {
                    slot.sprite = _inventoryIcons[NewIcon];
                    _itemsInInventory.Add(slot.sprite, 1);

                    UpdateItemCount(i, _itemsInInventory[slot.sprite]);

                    if (_itemsInInventory.ContainsKey(_KeySprite))
                        InventoryHasKey = true;

                    break;
                }

                i++;
            }

            ShouldIconUpdate = false;
        }

    }

    void UpdateItemCount(int index, int count)
    {
        _textObjects[index].text = count.ToString();

        if (count > 1)
            _textObjects[index].gameObject.SetActive(true);
    }


    public void OnOpenMenu()
    {
        _inventoryMenu.SetActive(true);
        _openBook.SetActive(true);
        _closeBook.SetActive(false);
        Time.timeScale = 0;
    }
    public void OnCloseMenu()
    {
        _inventoryMenu.SetActive(false);
        _openBook.SetActive(false);
        _closeBook.SetActive(true);
        Time.timeScale = 1;
    }
}
