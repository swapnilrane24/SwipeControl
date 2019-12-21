using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float distBtwWalls; //distance we check before we can move towards that wall

    private Vector2 targetPos;  //position player has to move
    private float spriteX, spriteY; //sprite length and width half

    private void Awake()
    {
        //get the reference to the SpriteRenderer
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        spriteX = sprite.bounds.size.x / 2; //get the width half
        spriteY = sprite.bounds.size.y / 2; //get the height half
    }

    /// <summary>
    /// Method used to move the player
    /// </summary>
    /// <param name="direction">Defines the direction of movement</param>
    public void MovePlayer(Vector3 direction)
    {
        //create a raycast in the respective direction
        RaycastHit2D rayCast = Physics2D.Raycast(transform.position, direction);

        //check if collider is not null
        if (rayCast.collider != null)
        {
            //get the difference between hit point and object position
            float diff = Vector2.Distance(rayCast.point , transform.position);
            if (diff >= distBtwWalls)   //if its move or eqal to our requirement
            {
                //set the targetPos to transform position
                targetPos = transform.position;
                //On X Axis Y is COnstant
                if (direction == Vector3.left || direction == Vector3.right)
                {
                    //we then set the X value 
                    targetPos.x = rayCast.point.x - spriteX * direction.x;
                    //we are multiplying it with direction.x so we can decide to add or
                    //subtract the sprite width from the hit point
                }
                //On Y Axis X is COnstant
                else if (direction == Vector3.down || direction == Vector3.up)
                {
                    targetPos.y = rayCast.point.y - spriteY * direction.y;
                }

                GetMoveTarget();
            }
        }
    }

    void GetMoveTarget()
    {
        transform.position = targetPos;
    }

    
}
