using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    private LayerMask _moveLayer;

    private Animator _anim;
    private NavMeshAgent _nav;
    private Ray _ray;
    private RaycastHit _hit;
    private float _velocity;

    private CinemachineTransposer _ct;
    public CinemachineVirtualCamera _playerCamera;
    private Vector3 _pos;
    private Vector3 _currentPos;
    private Vector3 _newPos;

    public static bool CanMove { get; set; } = true;
    public static bool IsMoving { get; set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _ct = _playerCamera.GetCinemachineComponent<CinemachineTransposer>();
        _currentPos = _ct.m_FollowOffset;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate velocity speed
        _velocity = _nav.velocity.x + _nav.velocity.z;
        // Get mouse pos
        _pos = Input.mousePosition;

        if(Input.GetMouseButtonDown(0) && CanMove)
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(_ray, out _hit, 300, _moveLayer))
            {
                _nav.destination = _hit.point;
            }
        }

        if (_velocity != 0)
        {
            _anim.SetBool("Sprinting", true);
            IsMoving = true;
        }
        else
        {
            _anim.SetBool("Sprinting", false);
            IsMoving = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            _newPos = Input.mousePosition;
            return;
        }

        if (Input.GetMouseButton(1))
        {
            float deltaX = (_pos.x - _newPos.x) / 200;
            float deltaY = (_pos.y - _newPos.y) / 200;
            if(deltaX != 0 || deltaY != 0)
            {
                float x = -7f <= _currentPos.x + deltaX && _currentPos.x + deltaX <= 7f ? _currentPos.x + deltaX : _currentPos.x;
                float y= 3f <= _currentPos.y + deltaY && _currentPos.y + deltaY <= 14f ? _currentPos.y + deltaY : _currentPos.y;
                _ct.m_FollowOffset = new Vector3(x, y, _currentPos.z);
            }
        }

        if(Input.GetMouseButtonUp(1))
        {
            _currentPos = _ct.m_FollowOffset;
        }

    }
}
