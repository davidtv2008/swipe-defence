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

    public GameObject particles;
    private GameObject currentParticles;
    public List<Vector2> fingerPositions;

    private Vector2 startPos;
    private Vector2 endPos;

    public int lineCountLimit = 3;

    
    private float totalLineLength = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){

            //first chech how many lines are currently onscreen, if 3, then cannot draw anymore, must wait for them to be destroyed or run out
            int LineCount = GameObject.FindGameObjectsWithTag("shield").Length;

            if(LineCount < 3){

                CreateLine();
            }

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

        lineCountLimit -= 1;



        //positions its text life in starting pos
        var lifeText = currentLine.transform.GetChild(0);

        totalLineLength = 0f;
        
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        //save start position of when line starts
        startPos = fingerPositions[0];        

        //currentParticles = Instantiate(particles,fingerPositions[0],Quaternion.identity);   
        //currentParticles.transform.SetParent(currentLine.transform);     
        
        
        lineRenderer.SetPosition(0,fingerPositions[0]);        
        
        lifeText.SetPositionAndRotation(new Vector3(startPos.x, startPos.y,0),Quaternion.identity);
        
        //lineRenderer.SetPosition(1,fingerPositions[1]);
        edgeCollider.points = fingerPositions.ToArray();
    }

    void UpdateLine(Vector2 newFingerPos){

        totalLineLength = (totalLineLength +  (newFingerPos - startPos).magnitude);

        //put a limit on the length of the line
        if(totalLineLength < 4f){

            //currentParticles = Instantiate(particles,newFingerPos,Quaternion.identity);        
            //currentParticles = Instantiate(particles,newFingerPos,Quaternion.identity);   
            //currentParticles.transform.SetParent(currentLine.transform);     

            fingerPositions.Add(newFingerPos);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
            edgeCollider.points = fingerPositions.ToArray();

            startPos = newFingerPos;
        }       
    }

}
