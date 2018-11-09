using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public GameObject BrickProfab;
    public GameObject BulletProfab;
    public Transform BrickParent;
    public Transform BulletParent;
    Ray ray;
    RaycastHit hit;

    private void Awake()
    {
        Screen.SetResolution(1366, 768, false);//限制分辨率
    }
    void Start()
    {
        CreateBrickWall();

    }


    void Update()
    {
        CreateBrickBullet();

    }

    /// <summary>
    /// 循环创建砖块墙
    /// </summary>
    void CreateBrickWall()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                GameObject _brick = Instantiate(BrickProfab, new Vector3(j, i, 0), Quaternion.identity);
                _brick.transform.parent = BrickParent;//创建砖块，放在BrickParent父对象下

                //给生成的砖块的 material组件的color 随机给色值
                _brick.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                _brick.AddComponent<Rigidbody>();//给砖块添加刚体组件
            }
        }
    }

    /// <summary>
    /// 创建子弹，并发射子弹方法
    /// </summary>
    void CreateBrickBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);//创建射线并保存给ray
            if (Physics.Raycast(ray, out hit))
            {
                GameObject _bullet = Instantiate(BulletProfab, this.transform.position, Quaternion.identity);//创建子弹对象
                _bullet.transform.parent = BulletParent;//移动到BulletParent的子对象。
                _bullet.AddComponent<Rigidbody>();                //添加刚体组件
                Vector3 point = hit.point - this.transform.position;//获取子弹发射方向，得到一个向量
                _bullet.GetComponent<Rigidbody>().AddForce(point * 130);//子弹发射的方向及力度

            }
        }


    }
}
