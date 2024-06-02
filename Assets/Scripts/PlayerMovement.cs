using UnityEngine;

public class HeroMouvement : MonoBehaviour
{
    
    public float moveSpeed;
    private Vector3 velocity = Vector3.zero;
    public Rigidbody2D rb;
    public float jumpForce;    
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    private bool isJumping = false;
    private float horizontalMovement;    
    private bool isGrounded;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void FixedUpdate(){
        // vérifier si le player est au sol en créant une zone de collision
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // saut
        if(Input.GetButtonDown("Jump") && isGrounded){
            isJumping = true;
        }
        // mouvement du personnage
        MovePlayer(horizontalMovement);

        //
        Flip(rb.velocity.x);
        // valeur de la vitesse
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        // envoie de la vitesse à l'amination
        animator.SetFloat("Speed", characterVelocity);
    }

    void MovePlayer(float _horizontalMovement){
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        
        // si il saute
        if(isJumping == true){
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity){
        if(_velocity > 0.1f){
            spriteRenderer.flipX = false;
        } else if(_velocity < -0.1f){
            spriteRenderer.flipX = true;
        }
    }
}
