using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewParticleManager : MonoBehaviour
{
    public static NewParticleManager instance { get; private set; }

    [Header("Click Effect")]
    [SerializeField] private ParticleSystem clickEffectPrefab;
    [SerializeField] private bool autoDestroy = true;
    [SerializeField] private float extraLifetime = 0.1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); ;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void PlayClick(Vector2 worldPos2D)
    {
        if (!clickEffectPrefab)
        {
            Debug.LogWarning("��ƼŬ �Ŵ����� ��ƼŬ ������ ��������");
            return;
        }

        var pos = new Vector3(worldPos2D.x, worldPos2D.y, 0f);
        var ps = Instantiate(clickEffectPrefab, pos, Quaternion.identity);
        ps.Play();

        if (autoDestroy) StartCoroutine(KillWhenDone(ps));
    }
    private IEnumerator KillWhenDone(ParticleSystem ps)
    {
        yield return new WaitWhile(() => ps != null && ps.IsAlive(true));
        if (ps) Destroy(ps.gameObject);
    }
}
