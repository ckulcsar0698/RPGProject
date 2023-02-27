using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _roof;
    [SerializeField]
    private GameObject _props;
    // Start is called before the first frame update
    void Start()
    {
        _roof.SetActive(true);
        _props.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _roof.SetActive(false);
            _props.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _roof.SetActive(true);
            _props.SetActive(false);
        }
    }
}
