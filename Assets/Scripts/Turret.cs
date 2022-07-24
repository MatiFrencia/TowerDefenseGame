using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Instance of the class
    [Header("Turret Attributes")]
    public static Turret Instance;
    public Transform ShootPoint;
    public GameObject Bullet;

    [Header("Turret Properties")]
    public int Lives = 5;
    public int CurrentLives = 5;
    public float ViewDistance;
    public float FireRate;
    public float Force;
    public float Speed = 1.5f;
    public bool isChildTurret = false;

    private float nextTimeToFire = 0;
    private Transform Target;
    private Vector3 closeEnemyRef;
    private Vector2 Direction;
    private bool Detected = false;


    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentLives <= 0)
        {
            CurrentLives = 0;
            Destroy(gameObject);
            if (!isChildTurret)
            {
                Time.timeScale = 0;
                //scene management
                return;
            }
        }

        if (Target != null)
        {
            Vector2 targetPose = Target.position;
            Direction = targetPose - (Vector2)transform.position;
            RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, ViewDistance);
            if (rayInfo)
            {
                if (rayInfo.collider.gameObject.tag == "Unit")
                {

                }
            }
        }
    }
}
