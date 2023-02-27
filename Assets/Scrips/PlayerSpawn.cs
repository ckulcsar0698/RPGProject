using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _characterList;
    [SerializeField]
    private Transform _spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_characterList[SaveScript.PChar], _spawnPoint.position, _spawnPoint.rotation);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}

