using UnityEngine;
using ulma;

public class ShellGenerator : MonoBehaviour
{
    [SerializeField, InspectorName("ObjectPoolの設定データ")]
    private ObjectPoolConfig _DataObject;

    private ObjectPool<ShellPoolElement> _ShellPool;

    private void Start()
    {
        //ObjectPoolを生成．
        _ShellPool = ObjectPoolGenerator.CreatePool<ShellPoolElement>(_DataObject, gameObject);

        //生成したObjectPoolをもとに初期生成を実行．
        _ShellPool.InitialGenerate();
    }

    private void Update()
    {
        //入力されるたびにPoolElementを生成する．
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _ShellPool.Generate();
        }
    }
}
