using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        playerUI = GetComponent<PlayerUI>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);  
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.blue);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);

                if (Input.GetKeyDown(KeyCode.G))
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
