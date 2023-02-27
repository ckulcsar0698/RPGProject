using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoosePlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _characters;
    [SerializeField]
    private Text _pName;
    private int _playerIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Next()
    {
        if (_playerIndex < _characters.Length - 1)
        {
            _characters[_playerIndex].SetActive(false);
            _playerIndex++;
            _characters[_playerIndex].SetActive(true);
        }
    }

    public void Previous()
    {
        if (_playerIndex > 0 )
        {
            _characters[_playerIndex].SetActive(false);
            _playerIndex--;
            _characters[_playerIndex].SetActive(true);
        }
    }

    public void OnAccept()
    {
        SaveScript.PChar = _playerIndex;
        SaveScript.PName = _pName.text;
        SceneManager.LoadScene(1);
    }
}
