using UnityEngine;
using UnityEngine.UI;

public class UI_Drag : MonoBehaviour
{

    [SerializeField]
    GameObject[] snapPoints;

    MagicManager manager;
    float snapSensitivity = 20f;
    bool startDrag;
    Vector2 startPos;
    
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<MagicManager>();
        startPos = transform.position;
    }
    
    void Update()
    {
        if(startDrag)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void StartDragUI()
    {
        startDrag = true;
    }

    public void StopDragUI()
    {
        startDrag = false;

        for(int i = 0; i < snapPoints.Length; i++)
        {
            if(Vector2.Distance(snapPoints[i].transform.position, transform.position) <= snapSensitivity)
            {
                Image img = gameObject.GetComponent<Image>();
                manager.SwapMagic(i, img.sprite);
                break;
            }
        }
        
        transform.position = startPos;
        
    }
}
