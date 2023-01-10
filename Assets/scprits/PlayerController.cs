using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController cc;
    // variable de deplacement
    public float moveSpeed;
    public float jumpForce;
    public float gravity;
    // Vecteur direction souhaitée
    private Vector3 moveDir;
    void Update()
    {
        // Calcul de la direction
        moveDir = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDir.y, Input.GetAxis("Vertical") * moveSpeed);
        
        //check de la touche espace
        if (Input.GetButtonDown("Jump"))
        {
            // on saute
            moveDir.y = jumpForce;
        }

        //on applique la gravité
        moveDir.y -= gravity * Time.deltaTime;

        // Si on se déplace (si mouvement != 0)
        if(moveDir.x != 0 || moveDir.z != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(moveDir.x, 0 ,moveDir.z)),0.15f);
        }
        
        cc.Move(moveDir * Time.deltaTime);
    }
}
