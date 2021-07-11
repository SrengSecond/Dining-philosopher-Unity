using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class Philosopher : MonoBehaviour
{
    public UIController uicontroller;
    
    public int averageDuration;
    public int PickDuration;
    public int DropDuration;
    
    public string philosopher_Name;
    public int grabResourcesSpeed = 30;

    public Transform leftTarget;
    public Transform rightTarget;

    public Transform oldleftTarget;
    public Transform oldrightTarget;

    public Resource leftResource;
    public Resource RightResource;
    
    private int random_thinking_time;
    private int random_eating_duration;
    private int random_drop_resource_duration; 
    private int random_pick_resource_duration;
    private Renderer current;
    public CubeAimation CubeAimation;
    public GameManager gameManager;

    private MeshRenderer meshRenderer;
    
    public bool handleLoop;
    public TextMeshProUGUI textMesh;
    public string actionlog = "idle";

    public Floater floating;

    public Material idleColor, thinkingColor, eatingColor,holdingColor;
    public Quaternion defaultRotation;

    /*Philosophers(object leftResource, object RightResource)
    {
        this.leftResource = leftResource;
        this.RightResource = RightResource;
    }*/

    private void Start()
    {
        uicontroller = GameObject.Find("UIDocument").GetComponent<UIController>();
        //Load Material Resource
        
        // idleColor =  Resources.Load<Material>("59 EMISSION-ORANGE");
        // eatingColor = Resources.Load<Material>("60 EMMISION-RED");
        // holdingColor = Resources.Load<Material>("61 EMISSION-ORANGE");
        // thinkingColor = Resources.Load<Material>("63 EMISSION-GREEN");
        // defaultRotation = transform.rotation;
        

        
        meshRenderer = GetComponent<MeshRenderer>();
        floating = GetComponent<Floater>();
        current = gameObject.GetComponent<Renderer>();
        CubeAimation = GetComponent<CubeAimation>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        floating.frequency = Random.Range(0.25f, 0.5f);

    }

    private void DoAction(string action)
    {
        actionlog = action;
        Thread.Sleep(random_thinking_time);
    }

    private void EatingAction()
    {
        actionlog = "Drinking" ;
        Thread.Sleep(random_eating_duration);
    }

    private void DropResouce(string resouceName)
    {
        actionlog = resouceName;
        // Debug.Log(actionlog);
        // Thread.Sleep(100);
        Thread.Sleep(random_drop_resource_duration);

    }
    private void PickUpResouce(string resouceName,Resource resource)
    {
        actionlog = resouceName;
        // Debug.Log(resource.Name);
        Thread.Sleep(random_pick_resource_duration);

    }

    private void restartAction()
    {
        actionlog = "Restart Action";
        Thread.Sleep(100);
    }

    private void Awake()
    {
        Debug.Log("Sleep time " + random_thinking_time);
    }
    public void startAction()
    {
        while (handleLoop)
        {
            restartAction();
            DoAction("Thinking");

            lock (leftResource)
            {
                PickUpResouce("Pick left Glass",leftResource);
                lock (RightResource)
                {
                    PickUpResouce("Pick right Glass",RightResource);
                    EatingAction();
                    DropResouce("Drop right Glass");
                }
            }
            DropResouce("Drop left Glass");
        }
    }
    void Update()
    {
        averageDuration = (int)uicontroller.ThinkingSlider.value;

        if (handleLoop & !uicontroller.DeadLockToggle.value) 
        {
            random_thinking_time = Random.Range(0, averageDuration);
            random_eating_duration = Random.Range(0, averageDuration);
            random_pick_resource_duration = PickDuration;
            random_drop_resource_duration = DropDuration;
        }
        else
        {
            random_thinking_time = Random.Range(averageDuration, averageDuration);
            random_eating_duration = Random.Range(averageDuration, averageDuration);
            random_pick_resource_duration = Random.Range(averageDuration, averageDuration);
            random_drop_resource_duration = Random.Range(averageDuration, averageDuration);
        }

        textMesh.text = actionlog;
        if (actionlog == "Restart Action")
        {
            IdleState();
        }
        
        if  (actionlog == "Thinking")
        {
            ThinkingState();
        }
        else if (actionlog == "Pick left Glass" || actionlog == "Pick right Glass" )
        {            
            MoveTowardsTO(leftResource,leftTarget);
            PickState();
            // GrabResources(leftResource);
        }
        else if (actionlog == "Drinking")
        {
            MoveTowardsTO(leftResource,leftTarget);
            MoveTowardsTO(RightResource,rightTarget);
            EatingState();
        }
        else if (actionlog == "Drop left Glass" || actionlog == "Drop right Glass")
        {
            MoveTowardsTO(leftResource,oldleftTarget);
            MoveTowardsTO(RightResource, oldrightTarget);
            IdleState();
        }
        else
        {
            IdleState();
        }

        // if (actionlog == "Pick right Glass")
        // {
        //     GrabResources(RightResource);
        // }
        // if (actionlog == "Pick left Glass")
        // {
        //     GrabResources(leftResource);
        // }
    }
    
    void MoveTowardsTO(Resource resource,Transform target)
    {
        resource.gameObject.transform.position =
            Vector3.MoveTowards(resource.gameObject.transform.position, target.position, grabResourcesSpeed * Time.deltaTime);
        // resource.transform.parent = gameObject.transform;
        // resource.gameObject.transform.position = new Vector3(0.7f, 0, 0.7f);

    }

    // void DropResouce(Resource resource,Transform target)
    // {
    //     resource.gameObject.transform.position =
    //         Vector3.MoveTowards(resource.gameObject.transform.position, target.position, 20 * Time.deltaTime);
    // }

    void EatingState()
    {
        meshRenderer.material = eatingColor;
        floating.degreesPerSecond = Random.Range(30, 60);
    }

    void PickState()
    {
        meshRenderer.material = holdingColor;
    }

    void ThinkingState()
    {
        meshRenderer.material = thinkingColor;
        floating.degreesPerSecond = 0;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        // DropResouce(leftResource);
        // DropResouce(RightResource);
    }

    void IdleState()
    {
        meshRenderer.material = idleColor;
        floating.degreesPerSecond = 0;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        MoveTowardsTO(leftResource,oldleftTarget);
        MoveTowardsTO(RightResource, oldrightTarget);
        // DropResouce(leftResource);
        // DropResouce(RightResource);
    }


}
