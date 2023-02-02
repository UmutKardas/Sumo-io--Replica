using System.Collections.Generic;
using UnityEngine;

public class BotMovementController : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    [SerializeField] private float botMovementSpeed;

    public List<GameObject> targets = new List<GameObject>();
    public List<GameObject> sushis = new List<GameObject>();

    public GameObject targetSumo;
    public GameObject targetSushi;

    public bool inMotion;
    private int randomMovement;



    void Awake()
    {
        SetBotTarget();
    }



    void FixedUpdate()
    {
        if (gameManager.isStart)
        {
            if (inMotion)
            {
                if (randomMovement == 1)
                {
                    if (targetSumo.GetComponent<SumoCollisionController>().isGround)
                    {
                        if (targetSumo.name != "Player")
                        {
                            if (targetSumo.GetComponent<BotMovementController>().inMotion)
                            {
                                transform.Translate(Vector3.forward * botMovementSpeed * Time.fixedDeltaTime);
                                transform.LookAt(targetSumo.transform);
                            }
                        }

                        else
                        {
                            transform.Translate(Vector3.forward * botMovementSpeed * Time.fixedDeltaTime);
                            transform.LookAt(targetSumo.transform);
                        }
                    }
                    else
                    {
                        inMotion = false;
                        SetBotTarget();
                    }
                }

                else
                {
                    if (targetSushi.gameObject.transform.localPosition.y < 1f)
                    {
                        transform.Translate(Vector3.forward * botMovementSpeed * Time.fixedDeltaTime);
                        transform.LookAt(targetSushi.transform);
                    }

                    else
                    {
                        inMotion = false;
                        SetBotTarget();
                    }
                }
            }
        }
    }

    private void SetBotTarget()
    {
        randomMovement = Random.Range(0, 2);

        if (randomMovement == 1)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                int randomValue = Random.Range(0, targets.Count);

                if (targets[randomValue].GetComponent<SumoCollisionController>().isGround)
                {
                    if (targets[randomValue].name != "Player")
                    {
                        if (targets[randomValue].GetComponent<BotMovementController>().inMotion)
                        {
                            targetSumo = targets[randomValue].gameObject;
                            inMotion = true;
                            break;
                        }
                    }

                    else
                    {
                        targetSumo = targets[randomValue].gameObject;
                        inMotion = true;
                        break;
                    }

                }
            }
        }

        else
        {
            for (int i = 0; i < sushis.Count; i++)
            {
                int random = Random.Range(0, sushis.Count - 1);

                if (sushis[random].gameObject.transform.localPosition.y < 10f)
                {
                    targetSushi = sushis[random].gameObject;
                    inMotion = true;
                    break;
                }
            }
        }
    }
}
