using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _messageBox;
    [SerializeField]
    private int _tavernNumber = 0;

    private void Start()
    {
        _messageBox.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if( other.CompareTag("Player"))
        {
            _messageBox.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var script = _messageBox.GetComponentInChildren<MessageScript>();
            if (null == script)
                Debug.Log("this is null");
            else
                script.ShopNum = _tavernNumber;
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
