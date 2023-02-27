using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _messageBox;

    private void Start()
    {
        _messageBox.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Player"))
        {
            _messageBox.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _messageBox.SetActive(false);
        }
    }
}
