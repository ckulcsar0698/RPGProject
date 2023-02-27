using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursors : MonoBehaviour
{
    [SerializeField]
    private GameObject _cursorObject;
    [SerializeField]
    private Sprite _cursorBasic;
    [SerializeField]
    private Sprite _cursorHand;
    [SerializeField]
    private Image _cursorImage;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        _cursorObject.transform.position = Input.mousePosition;

        if (Input.GetMouseButton(1))
            _cursorImage.sprite = _cursorHand;
        else
            _cursorImage.sprite = _cursorBasic;
    }
}
