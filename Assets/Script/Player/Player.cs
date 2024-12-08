using UnityEngine;

namespace Script.Player
{
    public class Player : MonoBehaviour
    {
        private Graphics graphics;
        private float moveSpeed = 5f;
        private float jumpForce = 10f;

        private Rigidbody2D rb;
        private void Awake()
        {
            graphics = GetComponent<Graphics>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);

            if (horizontal != 0)
            {
                graphics.IsWalking = true;
                Flip(horizontal);
            }
            else
            {
                graphics.IsWalking = false;
            }
            
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                Debug.Log("Jump");
                Jump();
            }
        }

        private void Flip(float horizontalDirection)
        {
            Vector3 currentScale = transform.localScale;

            if (horizontalDirection > 0)
            {
                currentScale.x = -Mathf.Abs(currentScale.x);
            }
            else if (horizontalDirection < 0)
            {
                currentScale.x = Mathf.Abs(currentScale.x);
            }

            transform.localScale = currentScale;
        }
        
        private void Jump()
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
        private bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
            return hit.collider != null;
        }
    }
}