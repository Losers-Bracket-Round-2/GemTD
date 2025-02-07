using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPun
{
    public float speed = 5f;
    private Vector3 target;
    private bool isMoving = false;

    void Update()
    {
        if (!photonView.IsMine)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                target = hit.point;
                isMoving = true;
            }
        }

        if (isMoving)
        {
            Vector3 direction = target - transform.position;
            direction.y = 0;

            if (direction.magnitude < 0.1f)
            {
                isMoving = false;
            }
            else
            {
                transform.position += direction.normalized * speed * Time.deltaTime;
            }
        }
    }
}
