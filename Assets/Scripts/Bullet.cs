using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 2.6f);//子弹发射后2.6秒后自动销毁对象 ；
	}
	

}
