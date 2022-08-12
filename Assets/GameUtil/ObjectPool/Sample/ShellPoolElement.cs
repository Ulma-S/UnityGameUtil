using UnityEngine;
using ulma;

public class ShellPoolElement : ObjectPoolElement
{
    private Renderer _Renderer;

    private float _ElapsedTime = 0f;

    private const float LifeTime = 3f;

    private void Awake()
    {
        _Renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (!IsActive)
        {
            return;
        }

        if(_ElapsedTime >= LifeTime)
        {
            Inactivate();
        }

        _ElapsedTime += Time.deltaTime;
    }


    protected override void OnActivate()
    {
        _Renderer.enabled = true;
        _ElapsedTime = 0f;
    }


    protected override void OnInactivate()
    {
        _Renderer.enabled = false;
    }
}
