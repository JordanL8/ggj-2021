using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGame : MonoBehaviour
{
    [System.Serializable]
    public class ListWrapper
    {       
        public List<Transform> listOfPoints;
    }

    public LineRenderer lineRenderer;
    public GameObject mousePoint;
    public List<ListWrapper> linePoints = new List<ListWrapper>();
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < linePoints.Count; i++)
        {
            int randomIndex = Random.Range(0, linePoints[i].listOfPoints.Count);
            lineRenderer.SetPosition(i, linePoints[i].listOfPoints[randomIndex].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
        newPos.z = mousePoint.transform.position.z;
        mousePoint.transform.position = newPos;


    }
}
