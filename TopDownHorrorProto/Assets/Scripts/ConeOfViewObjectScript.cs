using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeOfViewObjectScript : MonoBehaviour {


    [SerializeField]
    float timeToWait;

    [SerializeField]
    bool isVisible;
    MeshRenderer rend;
    SkinnedMeshRenderer skinRend;
    PlayerFOVScript playerFOV;
    GameObject player;

    // Use this for initialization
    void Start () {
        rend = GetComponent<MeshRenderer> ();
        skinRend = GetComponent<SkinnedMeshRenderer> ();
        player = GameManager.instance.player;
        playerFOV = player.GetComponent<PlayerFOVScript> ();
        isVisible = false;
        if (rend != null)
            rend.enabled = false;
        if (skinRend != null)
            skinRend.enabled = false;
    }

    void Update () {
        if (rend != null) {
            if (rend.enabled && !isVisible) {
                //rend.enabled = false;
            } else if (!rend.enabled && isVisible) {
                //check to see if line of sight between player and object is broken by an object
                Vector3 startPos = transform.position;
                Vector3 endPos = player.transform.position;
                Vector3 dir = endPos - startPos;

                RaycastHit hit;

                if (Physics.Raycast (transform.position, dir, out hit)) {
                    if (hit.collider.tag == "Player" || hit.collider.tag == "ConeOfView") {
                        rend.enabled = true;
                    } else {
                        rend.enabled = false;
                    }
                }

            }
        }

        if (skinRend != null) {
            if (skinRend.enabled && !isVisible) {
                //skinRend.enabled = false;
            } else if (!skinRend.enabled && isVisible) {
                //check to see if line of sight between player and object is broken by an object
                Vector3 startPos = transform.position;
                Vector3 endPos = player.transform.position;
                Vector3 dir = endPos - startPos;

                RaycastHit hit;

                if (Physics.Raycast (transform.position, dir, out hit)) {
                    if (hit.collider.tag == "Player" || hit.collider.tag == "ConeOfView" || hit.collider.tag == gameObject.tag) {
                        skinRend.enabled = true;
                    } else {
                        skinRend.enabled = false;
                    }
                }

            }
        }
    }

    void OnTriggerEnter (Collider other) {
        if (other.tag == "ConeOfView") {
            isVisible = true;
        }
    }

    void OnTriggerExit (Collider other) {
        if (other.tag == "ConeOfView") {
            StartCoroutine ("Disappear");
            isVisible = false;
        }
    }

    IEnumerator Disappear () {
        yield return new WaitForSeconds (timeToWait);
        if (rend != null)
            rend.enabled = false;
        if (skinRend != null)
            skinRend.enabled = false;
        isVisible = false;
    }
		
}
