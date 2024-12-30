using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    private BoolValueSO gameStart;

    public InputMaster actions;

    private Vector2 movementInput; // Stocke l'entrée du joueur
    public Vector2 minBounds; // Limites minimales (x, y)
    public Vector2 maxBounds; // Limites maximales (x, y)

    [SerializeField]
    private float speed = 4;

    [SerializeField]
    private FloatValueSO fieldSpeed;

    private float maxSpeed = 6;

    private bool isFreeze = false;
    private float coolDownFreeze = 0f;

    [SerializeField]
    private Animator animator;
    private void Awake()
    {
        actions = new InputMaster();
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void OnDestroy()
    {
        fieldSpeed.onValueChange -= OnFieldSpeedChange;
        actions.Player.Movement.performed -= OnMove;
        actions.Player.Movement.canceled -= OnMove;
    }

    // Start is called before the first frame update
    void Start()
    {
        actions.Player.Movement.performed += OnMove;
        actions.Player.Movement.canceled += OnMove;

        fieldSpeed.onValueChange += OnFieldSpeedChange;
    }

    public void OnFieldSpeedChange(float value)
    {
        if(speed <= maxSpeed)
        {
           speed += 0.1f;
           speed = Mathf.Clamp(speed, 4, 6);
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStart.Value)
        {
            return;
            
        }

        if (isFreeze)
        {
            coolDownFreeze -= Time.deltaTime;

            if (coolDownFreeze <= 0)
            {
                coolDownFreeze = 0;
                isFreeze = false;
            }
            else
            {
                return;
            }
        
        }

        // Calcule le déplacement basé sur l'entrée et la vitesse
        Vector3 move = new Vector3(movementInput.x, movementInput.y, 0) * speed * Time.deltaTime;

        // Applique le déplacement à la position du joueur
        transform.Translate(move);
        // Clamp la position pour rester dans les limites définies
        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y);

        // Met à jour la position pour respecter les limites
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    public void CallFreeze()
    {
        
        isFreeze = true;
        coolDownFreeze = 3;
        animator.Play("PlayerDamage", -1, 0f);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public Animator GetAnimator() { return animator; }

    public void SetAnimatorSpeed(float speed)
    {
        animator.SetFloat("animSpeed", speed);
       // animator.speed = speed;

    }


}
