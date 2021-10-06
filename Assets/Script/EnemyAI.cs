using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public float speed = 200f;
    public float nextWayPointDistance = 3f;
    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rigidbody2D;
    public Transform target;
    public Transform bird;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath",1f,0.5f);
    }
    void OnPathComplete(Path p){
        if(!p.error){
            path = p;
            currentWayPoint = 0;

        }
    }
    void UpdatePath(){
        if(seeker.IsDone()){
            seeker.StartPath(rigidbody2D.position,target.position,OnPathComplete);
        }
    }

    public void Update(){
        if(path == null) return;
        if(currentWayPoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
        }else{
            reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rigidbody2D.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rigidbody2D.AddForce(force);
        float distance = Vector2.Distance(rigidbody2D.position,path.vectorPath[currentWayPoint]);
        if(distance < nextWayPointDistance){
            currentWayPoint++;
        }

        if(force.x >= 0.01){
            bird.localScale = new Vector3(-1f,1f,1f);
        }else if(force.y <= 0.01){
            bird.localScale = new Vector3(1f,1f,1f);
        }
    }
}
