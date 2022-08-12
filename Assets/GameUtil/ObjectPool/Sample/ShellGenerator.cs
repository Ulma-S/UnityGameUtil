using UnityEngine;
using ulma;

public class ShellGenerator : MonoBehaviour
{
    [SerializeField, InspectorName("ObjectPool�̐ݒ�f�[�^")]
    private ObjectPoolConfig _DataObject;

    private ObjectPool<ShellPoolElement> _ShellPool;

    private void Start()
    {
        //ObjectPool�𐶐��D
        _ShellPool = ObjectPoolGenerator.CreatePool<ShellPoolElement>(_DataObject, gameObject);

        //��������ObjectPool�����Ƃɏ������������s�D
        _ShellPool.InitialGenerate();
    }

    private void Update()
    {
        //���͂���邽�т�PoolElement�𐶐�����D
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _ShellPool.Generate();
        }
    }
}
