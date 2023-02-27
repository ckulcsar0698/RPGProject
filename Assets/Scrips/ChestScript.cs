using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private Animator _anim;
    [SerializeField]
    private int _goldAmt = 50;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        if (null == _anim)
            Debug.LogError("Chest Animator is null");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && InventoryItems.InventoryHasKey)
        {
            _anim.SetTrigger("open");
            InventoryItems.GoldInInventory += _goldAmt;
            _goldAmt = 0;
            Debug.Log("Gold amount = " + InventoryItems.GoldInInventory);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && InventoryItems.InventoryHasKey)
        {
            _anim.SetTrigger("close");
        }
    }

    public void DesstroyChest()
    {
        Destroy(gameObject);
    }
}
