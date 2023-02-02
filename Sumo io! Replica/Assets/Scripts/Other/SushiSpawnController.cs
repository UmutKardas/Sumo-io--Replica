using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiSpawnController : MonoBehaviour
{

    public List<Vector3> sushiSpawnPoints = new List<Vector3>();
    private int spawnIndex;

    public void SetNewSushi()
    {
        this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.position.x, 20f, this.gameObject.transform.position.z);
        StartCoroutine(nameof(NewSushiTransform));
        spawnIndex++;
        if (spawnIndex is 3)
            spawnIndex = 0;
    }



    IEnumerator NewSushiTransform()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.transform.localPosition = sushiSpawnPoints[spawnIndex];
    }
}
