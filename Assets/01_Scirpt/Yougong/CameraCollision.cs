using System.Numerics;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class CameraCollision : MonoBehaviour
{
    // Made by GmSoft ( You Gong )
    [Header("락온")] [SerializeField] private Transform _target;

    [Header("카메라 셋팅")]
    [SerializeField] CinemachineVirtualCamera _vcam;

    public CinemachineVirtualCamera _currentCam => _vcam;

    [SerializeField] private Transform _LookOnCam;

    private CinemachineVirtualCamera _cin;
    
    private Cinemachine3rdPersonFollow _body;
    [Header("카메라 정보 ( ESC 누르면 Lock모드 해제 되요 (")]
    [SerializeField] float _originrayX;
    [SerializeField] float _originrayY;
    [SerializeField] float _sense = 3;

    [Header("카메라 조정 ( 초기값 : -60, 30 )")]
    [SerializeField] float _bindCamMin = -60;
    [SerializeField] float _bindCamMax = 30;
    private float _camDistance;
    [SerializeField] float CameraMaxDistance = 5f;

    [FormerlySerializedAs("zxXxz")]
    [Header("반전")]
    [SerializeField] bool X = false;
    [SerializeField] bool Y = false;

    [Header("벽으로 계산하는 레이어 ( 통과 안됨 )")]
    [SerializeField] LayerMask layer;
    bool _setPos = false;

    int L = 1, U = 1;

    RaycastHit hit;
    Vector3 _hitVec;

    float shakeDuration = 0;
    float shakeAmount = 0.05f;
    float decreaseFactor = 1f;

    /// <summary>
    /// 카메라 쉐이킹
    /// </summary>
    /// <param name="a"></param> 지속시간
    /// <param name="b"></param> 떨림도
    /// <param name="c"></param> 지연 %
    public void shaking(float a = 0.1f, float b = 0.05f, float c = 1f)
    {
        shakeDuration = a;
        shakeAmount = b;
        decreaseFactor = c;

    }

    public void Awake()
    {
        _cin = _vcam.GetComponent<CinemachineVirtualCamera>();
        _body = _cin.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        _camDistance = CameraMaxDistance;
    }
    
    private Transform _player;
    public Transform Player
    {
        get
        {
            if (_player == null)
            {
                _player = GameObject.Find("Player").GetComponent<Transform>();
            }
            return _player;
        }
    }

    private void LateUpdate()
    {
        if (_target == null)
        {
            _target = Player;
        }
        
        //LookOnMod();
        CameraAltitude();
        shake();
    }

    void LookOnMod()
    {
        Vector3 vec = Player.position;
        transform.position = vec + new Vector3(0, 1f, 0);
        vec.y = 0;
        
        //_LookOnCam.rotation = Quaternion.LookRotation(vec);

        _body.CameraDistance = Vector3.Distance(_target.position, Player.position)/4 + 5;
        //_body.CameraDistance = _camDistance;
        transform.rotation = Quaternion.LookRotation(-vec);
    }

    void CameraAltitude()
    {

        // 플레이어 위치는 보통 발바닥임 + 1.4f
        transform.position = _target.position + new Vector3(0, 2f, 0);
        // 카메라 반전
        L = X ? -1 : 1;
        U = Y ? 1 : -1;

        Debug.DrawRay(transform.position, (_vcam.transform.position - transform.position).normalized * _camDistance, Color.red, 0.1f);
        if (Physics.Raycast(transform.position, (_vcam.transform.position - transform.position).normalized, out hit, CameraMaxDistance,layer))
        {
            _setPos = true;
            //_hitVec = hit.point;//Vector3.Lerp(_vcamFake.transform.position, hit.point, Time.deltaTime * 1500f);
            
            _camDistance = Vector3.Distance(transform.position, hit.point) - 0.4f;
//            Debug.Log(Vector3.Distance(transform.position, hit.point));

        }
        else if (Vector3.Distance(transform.position, _vcam.transform.position) > CameraMaxDistance)
        {
            _setPos = false;
            _camDistance = CameraMaxDistance;
            //_hitVec = _vcamFake.transform.position;
        }
        else
        {
            _camDistance = CameraMaxDistance;
        }

        _vcam.transform.position = _hitVec;
        
        _body.CameraDistance = _camDistance;


        
        _originrayY = Input.GetAxis("Mouse X") * _sense * L;
        _originrayX += Input.GetAxisRaw("Mouse Y") * _sense * U;

        _originrayX = Mathf.Clamp(_originrayX, _bindCamMin, _bindCamMax);

        float t = transform.localEulerAngles.y + _originrayY;
            
        transform.localEulerAngles = new Vector3(_originrayX, t, 0);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


        _setPos = false;
    }


    void shake()
    {
        if (shakeDuration > 0)
        {
            _vcam.transform.position = _hitVec + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
    }

}

