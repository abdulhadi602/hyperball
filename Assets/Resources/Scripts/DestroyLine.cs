using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLine : MonoBehaviour
{
    Vector3[] positions;
    public List<Vector3> pos;
    LineRenderer lineRenderer;
    EdgeCollider2D edgeCollider;

    private static bool isKilling;
    // Start is called before the first frame update
    void Start()
    {
        isKilling = false;
        lineRenderer =GetComponent<LineRenderer>();//GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
       // Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool getKilling()
    {
        return isKilling;
    }
    public void StartKilling()
    {
                 
            StartCoroutine(timer());
        
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);
        if (lineRenderer != null)
        {     
            while (lineRenderer.positionCount > 0)
            {
              
                lineRenderer.positionCount--;
                Vector3[] vec3 = new Vector3[lineRenderer.positionCount];
                    lineRenderer.GetPositions(vec3);
                Vector2[] vec2 = new Vector2[vec3.Length];
                for (int i = 0; i < vec3.GetLength(0); i++)
                {
                    vec2[i] = vec3[i];
                }

                edgeCollider.points = vec2;
                yield return new WaitForSeconds(0.01f);
            }
            Destroy(gameObject);
        }
    }
   /** IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);
        if (lineRenderer != null)
        {
            while (pos.Count > 0)
            {
                pos.RemoveAt(0);
                if (pos.Count == 0)
                {
                    Destroy(gameObject);
                    yield return null;
                }
                else
                {
                    lineRenderer.SetPositions(pos.ToArray());
                    Vector3[] vec3 = pos.ToArray();
                    Vector2[] vec2 = new Vector2[vec3.Length];
                    for (int i =0; i < vec3.GetLength(0); i++)
                    {                      
                            vec2 [i] = vec3[i];                        
                    }
                    
                    edgeCollider.points = vec2;
                    if (lineRenderer.positionCount > 30)
                    {
                        yield return new WaitForSeconds(0.1f);
                    }
                    else
                    {
                        yield return new WaitForSeconds(0.8f);
                    }
                }
            }
        }
    }**/
}
