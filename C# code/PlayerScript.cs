using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    public LayerMask Interactable;
    private Vector2 input;

    // Animator object for player animation
    private Animator animator;

    // Define the boundaries of the camera view
    private float minX, maxX, minY, maxY;

    private void Awake()
    {
        // Initialize animator object
        animator = GetComponent<Animator>();

        // Get the boundaries of the camera view
        Camera camera = Camera.main;
        float cameraHeight = 2f * camera.orthographicSize;
        float cameraWidth = cameraHeight * camera.aspect;
        minX = camera.transform.position.x - cameraWidth + 4;
        maxX = camera.transform.position.x + cameraWidth - 4;
        minY = camera.transform.position.y - cameraHeight + 1;
        maxY = camera.transform.position.y + cameraHeight + 2;
    }

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // Prevent diagonal movement
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                // Find character pos
                var targetPos = transform.position + new Vector3(input.x, input.y, 0);

                if (IsWithinBoundaries(targetPos) && solidObject(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.X))
            Interact();
    }

    void Interact()
    {
        var charDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var posInteraction = transform.position + charDir;

        var collide = Physics2D.OverlapCircle(posInteraction, 0.3f, Interactable);
        if (collide != null)
        {
            collide.GetComponent<Interactable>()?.Interact();
        }

    }

    // Moving the player to a target position
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;

    }

    private bool solidObject(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, Interactable) != null)
        {
            return false;
        }

        return true;
    }

    // Check if a target position is within the camera view boundaries
    private bool IsWithinBoundaries(Vector3 targetPos)
    {
        return targetPos.x >= minX && targetPos.x <= maxX && targetPos.y >= minY && targetPos.y <= maxY;
    }
}
