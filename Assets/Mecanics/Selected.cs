using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 3.5f;
    public Texture2D indicator;
    public GameObject TextDetect;
    GameObject detected = null;
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Raycast Detect");
        TextDetect.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, distancia, mask))
        { Active(hit.transform);
            if(hit.collider.tag == "Objeto Interactivo"){
                if(Input.GetKeyDown(KeyCode.E))
                {hit.collider.transform.GetComponent<ObjetoInteractivo>().ActivarObjeto();}
            }
        } else
        {
            Inactive();
        }
    }
       void Active(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.blue;
        detected = transform.gameObject;
    }

    void Inactive()
    {
        if (detected) {
            detected.GetComponent<Renderer>().material.color = Color.gray;
            detected = null;
        }
    }

    private void OnGUI()
    {
        //Draw point 
        Rect rect = new Rect(Screen.width/ 2f, Screen.height / 2f, indicator.width, indicator.height);
        GUI.DrawTexture(rect, indicator);

        //Show text "Press 'E'..."
        TextDetect.SetActive(detected ? true : false);
    }
}
