using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField]
    private int _itemNumber;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            InventoryItems.NewIcon = _itemNumber;
            InventoryItems.ShouldIconUpdate = true;
            Destroy(gameObject);
        }
    }
}
