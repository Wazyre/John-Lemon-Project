using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [Header ("Detection")]
    [SerializeField] float detectRadius = 2f;
    [SerializeField] float detectAngle = 90f;
    [SerializeField] RaycastHit raycastHit;
    
    [Header ("Components")]
    [SerializeField] Transform player;
    [SerializeField] GameEnding gameEnding;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        gameEnding = GameObject.Find("GameEnding").GetComponent<GameEnding>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirToPlayer = player.position - transform.position;

        if (dirToPlayer.magnitude <= detectRadius) {
            if (Vector3.Dot(dirToPlayer.normalized, transform.forward) > 
                Mathf.Cos(detectAngle * 0.5f * Mathf.Deg2Rad)) {
                    Ray ray = new Ray(transform.position, dirToPlayer);

                    if (Physics.Raycast(ray, out raycastHit)) {
                        if (raycastHit.collider.transform == player) {
                            gameEnding.CaughtPlayer();
                        }
                    }
            }
        }
    }
}
