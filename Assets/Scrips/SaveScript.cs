using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int PChar { get; set; } = 0;
    public static string PName { get; set; } = "player";

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
