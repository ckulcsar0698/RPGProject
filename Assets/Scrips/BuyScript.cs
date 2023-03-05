using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _shopUI;
    [SerializeField]
    private int[] _itemAmounts;
    [SerializeField]
    private int[] _itemCost;
    [SerializeField]
    private int[] _iconNum;
    [SerializeField]
    private Text[] _itemAmountText;
    [SerializeField]
    private Text _currencyText;

    // Start is called before the first frame update
    void Start()
    {
        _currencyText.text = InventoryItems.GoldInInventory.ToString();
        for(int i = 0; i < _itemAmountText.Length; i++)
        {
            _itemAmountText[i].text = _itemAmounts[i].ToString();
        }
    }

    public void OnBuy(int item)
    {
        if(InventoryItems.GoldInInventory >= _itemCost[item] && _itemAmounts[item] > 0)
        {
            UpdateInventory(item);
            UpdateShop(item);
        }
    }

    void UpdateInventory(int item)
    {
        InventoryItems.NewIcon = _iconNum[item];
        InventoryItems.ShouldIconUpdate = true;
        InventoryItems.GoldInInventory -= _itemCost[item];
    }

    void UpdateShop(int item)
    {
        _itemAmounts[item]--;
        _itemAmountText[item].text = _itemAmounts[item].ToString();
        _currencyText.text = InventoryItems.GoldInInventory.ToString();
    }

    public void CloseShop()
    {
        _shopUI.SetActive(false);
    }

    public void UpdateGoldText()
    {
        _currencyText.text = InventoryItems.GoldInInventory.ToString();
    }
}
