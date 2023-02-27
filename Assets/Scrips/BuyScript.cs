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
    private int[] _inventoryItems;
    [SerializeField]
    private Text[] _itemAmountText;
    [SerializeField]
    private Text _currencyText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseShop()
    {
        _shopUI.SetActive(false);
    }
}
