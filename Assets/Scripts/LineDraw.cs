using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LineDraw : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

    public List<Vector2> fingerPositions;

    private Vector2 startPos;
    private Vector2 endPos;

    private float totalLineLength = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            CreateLine();
        }
        if(Input.GetMouseButton(0)){
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(fingerPositions.Count - 1 >= 0){
                if(Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f){
                    UpdateLine(tempFingerPos);
                }
            } 
        }
    }

    void CreateLine(){
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        
        totalLineLength = 0f;
        
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        //save start position of when line starts
        startPos = fingerPositions[0];        
        
        lineRenderer.SetPosition(0,fingerPositions[0]);
        
        //lineRenderer.SetPosition(1,fingerPositions[1]);
        edgeCollider.points = fingerPositions.ToArray();
    }

    void UpdateLine(Vector2 newFingerPos){

        totalLineLength = (totalLineLength +  (newFingerPos - startPos).magnitude);

        //put a limit on the length of the line
        if(totalLineLength < 150f){
            fingerPositions.Add(newFingerPos);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
            edgeCollider.points = fingerPositions.ToArray();
        }       
    }

    void OnTriggerEnter2d(Collider2D col){

        Debug.Log("check");
    }
}
