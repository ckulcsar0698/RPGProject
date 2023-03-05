using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MessageScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Text _buttonText;
    [SerializeField]
    private Color32 _messageOff;
    [SerializeField]
    private Color32 _messageOn;
    [SerializeField]
    private Text _shopOwnerText;
    [SerializeField]
    private GameObject[] _shopUI;
    [HideInInspector]
    public int ShopNum { get; set; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _buttonText.color = _messageOn;
        CharacterMove.CanMove = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _buttonText.color = _messageOff;
        CharacterMove.CanMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        _shopOwnerText.text = $"hello {SaveScript.PName} how can i help you";
    }

    public void Message1()
    {
        switch(ShopNum)
        {
            case 0:
                _shopOwnerText.text = $"not much going on around here at the moment";
                break;
            case 1:
                _shopOwnerText.text = $"bla bla bla";
                break;
            default:
                _shopOwnerText.text = "Something Went wrong";
                break;
        }
    }

    public void Message2()
    {
        switch (ShopNum)
        {
            case 0:
                _shopOwnerText.text = $"not much going on around here at the moment";
                break;
            case 1:
                _shopOwnerText.text = $"bla bla bla";
                break;
            default:
                _shopOwnerText.text = "Something Went wrong";
                break;
        }
        _shopUI[ShopNum].GetComponent<BuyScript>().UpdateGoldText();
        //_shopOwnerText.text = $"select items from the list";
        if (null != _shopUI[ShopNum])
            _shopUI[ShopNum].SetActive(true);
    }

    void Update()
    {
        if(CharacterMove.CanMove && CharacterMove.IsMoving && null != _shopUI[ShopNum])
        {
                _shopUI[ShopNum].SetActive(false);
        }
    }
}
