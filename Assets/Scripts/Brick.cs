using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {


	void Update () {
        //砖块掉落到平面下自动销毁
		if(this.transform.position.y<-0.5)
        {
            Destroy(this.gameObject);
        }
	}
}
