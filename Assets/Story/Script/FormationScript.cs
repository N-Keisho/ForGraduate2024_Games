using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] subCharacters;
    private List<GameObject> subCharactersInstance = new List<GameObject>();
    public int numSubCharacters = 0;
    void Start()
    {
        for(int i = 0; i < numSubCharacters; i++){
            Vector3 pos = new Vector3(0, 0, 0);
            pos.x = (i + 1) * 5;
            subCharactersInstance.Add(Instantiate(subCharacters[i], pos, Quaternion.identity));
            SubCharacterScript subCharacterScript = subCharactersInstance[i].GetComponent<SubCharacterScript>();
            if(i == 0){
                subCharacterScript.target = GameObject.Find("Riry");
            }else{
                subCharacterScript.target = subCharactersInstance[i - 1];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
