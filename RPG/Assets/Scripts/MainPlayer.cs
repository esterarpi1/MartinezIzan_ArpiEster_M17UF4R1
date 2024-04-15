using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainPlayer : MonoBehaviour
{
    public static MainPlayer Instance;
    public Character player;
    public float currentSpeed;
    public Transform _transform;
    public Animator _animator;
    public Rigidbody rb;
    public Camera cam;
    public IInteractable focus;
    public MeshFilter itemPlacement;
    public GameObject itemPositon;
    public float rotationSpeed = 50.0f;
    public bool isGrounded = true;
    public GameObject bolaDeFuegoPrefab;
    public float fuerzaDisparo = 10f;
    public Transform puntoDeDisparo;
    public float tiempoDeVida = 5f;

    public void setPlayer(float x, float y, float z, float health)
    {
        _transform.position = new Vector3(x, y, z);
        player.health = health;
    }
    private void Awake()
    {
        InputController.Run += RunHandler;
        InputController.Crouch += CrouchHandler;
        InputController.Interact += PickObject;
        InputController.Hit += Hit;

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = player.speed;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Mathf.Abs(rb.velocity.y) < 0.01)
        //{
        //    _animator.SetBool("isGrounded", false);
        //}
        //else
        //{
        //    _animator.SetBool("isGrounded", true);
        //}
        if(player.health <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
    void Hit()
    {
        DispararBolaDeFuego();
    }
    void DispararBolaDeFuego()
    {
        // Obtener la posición del ratón en el mundo
        Vector3 posicionMouse = Input.mousePosition;
        posicionMouse.z = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector3 puntoDeDestino = Camera.main.ScreenToWorldPoint(posicionMouse);

        // Calcular la dirección desde el punto de origen hacia el punto de destino
        Vector3 direccion = (puntoDeDestino - puntoDeDisparo.position).normalized;

        // Instanciar el prefab de la bola de fuego en el punto de origen del disparo
        GameObject bolaDeFuego = Instantiate(bolaDeFuegoPrefab, puntoDeDisparo.position, Quaternion.identity);

        // Obtener el Rigidbody de la bola de fuego y aplicarle una fuerza en la dirección calculada
        Rigidbody rb = bolaDeFuego.GetComponent<Rigidbody>();
        rb.AddForce(direccion * fuerzaDisparo, ForceMode.Impulse);

        // Iniciar la corrutina para destruir la bola de fuego después de un tiempo
        StartCoroutine(DestruirBolaDeFuego(bolaDeFuego));
    }

    IEnumerator DestruirBolaDeFuego(GameObject bola)
    {
        // Esperar el tiempo de vida de la bola de fuego
        yield return new WaitForSeconds(tiempoDeVida);

        // Destruir la bola de fuego
        Destroy(bola);
    }
    public void HandleRotation(Vector2 direction)
    {
        float rotationAmount = direction.x * rotationSpeed * Time.deltaTime;
        _transform.Rotate(new Vector3(0, rotationAmount, 0));
    }
    public void HandleMovement(Vector2 direction)
    {
        Vector3 smt = _transform.TransformVector(Vector3.right * direction.x * currentSpeed) + _transform.TransformVector(Vector3.forward * direction.y * currentSpeed);
        rb.velocity = smt;
    }
    void RunHandler()
    {
        if (currentSpeed == player.speed) currentSpeed = player.speed + 2;
        else currentSpeed = player.speed;
    }
    void CrouchHandler()
    {
        if (currentSpeed == player.speed) currentSpeed = player.speed - 2;
        else currentSpeed = player.speed;
    }
    void PickObject()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                SetFocus(interactable);
            }
        }
    }
    public void setWeapon(Item item)
    {
        itemPlacement.mesh = item.mesh;
    }
    void SetFocus(IInteractable newFocus)
    {
        if(newFocus != focus)
        {
            focus = newFocus;
        }
        
        newFocus.isFocus = true;
        newFocus.hasInteracted = false;
    }
}
