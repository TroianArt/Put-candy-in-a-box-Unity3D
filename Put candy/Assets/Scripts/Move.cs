using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform target;
    public GameObject GameManager;
    private Vector3 offset;
    private float distance;
    private float yCoord;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetTouch(0).phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Candy")
                    {
                        target = hit.transform;
                        offset = target.position - hit.point;
                        distance = hit.distance;
                        yCoord = target.position.y;
                    }
                }
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved && !(Input.GetTouch(0).phase == TouchPhase.Began) && target != null
                || Input.GetTouch(0).phase == TouchPhase.Stationary && !(Input.GetTouch(0).phase == TouchPhase.Began) && target != null)
            {
                if (!target.GetComponent<Candy>().isInPlace)
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    Vector3 newTargetPosition = ray.origin + ray.direction * distance + offset;
                    float extraDistance = Vector3.Distance(target.transform.position, newTargetPosition);
                    if (newTargetPosition.y < target.position.y) extraDistance = -extraDistance;
                    target.position = ray.origin + ray.direction * (distance + extraDistance) + offset;
                    target.position = new Vector3(target.position.x, yCoord, target.position.z);
                    target.GetComponent<Candy>().IsTaked = true;
                }
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (target) target.GetComponent<Candy>().IsTaked = false;
                target = null;
            }
        }
    }
}
