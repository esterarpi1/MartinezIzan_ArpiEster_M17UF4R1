using GameInputs;
using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    protected Inputs _inputs;

    public static event Action Crouch = delegate { };
    public static event Action<bool> Walk = delegate { };
    public static event Action Run = delegate { };
    public static event Action Aim = delegate { };
    public static event Action Shoot = delegate { };
    public static event Action Jump = delegate { };
    public static event Action MiniMap = delegate { };
    public static event Action Interact = delegate { };
    public static event Action Inventory = delegate { };
    public static event Action ChangeCamera = delegate { };

    protected Vector2 currentMovement;

    private void Awake()
    {
        _inputs = new Inputs();
        _inputs.MainPlayer.Movement.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
            Walk.Invoke(currentMovement.magnitude > 0);
        }; 
        _inputs.MainPlayer.Run.performed += ctx =>
        {            
            Run.Invoke();
        };
        _inputs.MainPlayer.Crouch.performed += ctx =>
        {           
            Crouch.Invoke();
        };
        _inputs.MainPlayer.Aim.performed += ctx =>
        {
            Aim.Invoke();
        };
        _inputs.MainPlayer.Shoot.performed += ctx =>
        {
            Shoot.Invoke();
        };
        _inputs.MainPlayer.Jump.performed += ctx =>
        {
            Jump.Invoke();
        };
        _inputs.MainPlayer.Interact.performed += ctx =>
        {
            Interact.Invoke();
        };
        _inputs.MainPlayer.Inventory.performed += ctx =>
        {
            Inventory.Invoke();
        };
        _inputs.MainPlayer.MiniMap.performed += ctx =>
        {
            MiniMap.Invoke();
        };
        _inputs.MainPlayer.ChangeCamera.performed += ctx =>
        {
            ChangeCamera.Invoke();
        };

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else Destroy(this.gameObject);
    }
    private void OnEnable()
    {
        _inputs.MainPlayer.Enable();
    }
    private void OnDisable()
    {
        _inputs.MainPlayer.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        MainPlayer.Instance.HandleMovement(currentMovement);
        MainPlayer.Instance.HandleRotation(currentMovement);
    }
}
