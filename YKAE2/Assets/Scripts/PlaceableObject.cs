using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    private GameObject objToMove;
    private GameObject objectHit;

    public LayerMask mask;
    public float LastPosY;
    public Vector3 mousePos;

    public Material matGrid, matDefault;
    public bool isDragging;
    public bool isClicked = false;

    private Renderer rend;
    

    // Start is called before the first frame update
    void Start()
    {
        rend = GameObject.Find("Ground").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DragMethod();
    }
    public void DragMethod()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 999f, LayerMask.GetMask("Draggable")))
        {
            if (Input.GetMouseButtonDown(0))
            {
                isClicked = !isClicked;
                isDragging = isClicked;
            }
        }
            

        if (isDragging)
        {
            if (Physics.Raycast(ray, out hit, 999f, LayerMask.GetMask("Draggable")))
            {
                int posX = (int)Mathf.Round(hit.point.x);
                int posZ = (int)Mathf.Round(hit.point.z);
                Vector3 position = new Vector3(posX, LastPosY, posZ);

                objectHit = hit.collider.gameObject;
                objToMove = objectHit;
                objToMove.transform.position = position;
                DataManager.Instance.UpdateItemPosition(objToMove.name,position);
            }

           
        }
    }
    
}
