using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCollect : MonoBehaviour
{
    [SerializeField]
    private GameObject _spellsUI;
    [SerializeField]
    private GameObject _magicUI;
    public bool IsMagicBook { set; get; } = false;
    public bool IsSpellBook { set; get; } = false; 
    private bool _magicCollected = false;
    private bool _spellsCollected = false;
    // Start is called before the first frame update
    void Start()
    {
        _spellsUI.SetActive(false);
        _magicUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(IsMagicBook)
            {
                if(!_magicCollected)
                {
                    _magicUI.SetActive(true);
                    _magicCollected = true;
                }
            }

            if (IsSpellBook)
            {
                if (!_spellsCollected)
                {
                    _spellsUI.SetActive(true);
                    _spellsCollected = true;
                }
            }
        }
    }
}
