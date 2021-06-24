using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LinePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

    public List<Vector2> fingerPositions;
    private static bool isMouseDown;

    public List<Vector3> pos;

    public Transform FingerPosEffect;
    Vector3[] positions;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
      

        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
            isMouseDown = true;
            new WaitForSeconds(5f);
            RemoveLine();
        }
      
        if (Input.GetMouseButton(0))
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            FingerPosEffect.position = tempFingerPos;
            if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > 0.5f)
            {
                UpdateLine(tempFingerPos);
                FingerPosEffect.gameObject.SetActive(true);
                FingerPosEffect.position = tempFingerPos;
            }
            else if (currentLine != null && isMouseDown)
            {
                FingerPosEffect.gameObject.SetActive(false);
                isMouseDown = false;
                RemoveLine();
            }
        }
      
    }
    private void RemoveLine()
    {
     
        currentLine.GetComponent<DestroyLine>().StartKilling();
    }
    void CreateLine()
    {
        currentLine = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);
        edgeCollider.points = fingerPositions.ToArray();
           
    }
    void UpdateLine(Vector2 newFingerPos)
    {
        if (currentLine != null ) { 
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        edgeCollider.points = fingerPositions.ToArray();
        }
    }

    
}
