using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{

    public GameObject cube;
    public GameObject[] cubes = new GameObject[512];
    public float maxScale;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            GameObject instanceSampleCube = Instantiate(cube);
            instanceSampleCube.transform.position = this.transform.position;
            instanceSampleCube.transform.parent = this.transform;
            instanceSampleCube.name = "Sample Cube " + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            instanceSampleCube.transform.position = Vector3.forward * 100;
            cubes[i] = instanceSampleCube;


        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i < cubes.Length; i++)
        {
            if(cubes != null)
            {
                cubes[i].transform.localScale = new Vector3(10, (AudioPeer.samples[i] * maxScale) + 2, 10);
            }
        }
    }
}
