using UnityEngine;
using MK.Toon;
using CupkekGames.Fadeables;

namespace CupkekGames.VFX.MKToon
{
  public class Dissolvable : FadeableMono
  {
    private Renderer[] _renderers;

    protected override void Awake()
    {
      base.Awake();

      _renderers = GetComponentsInChildren<Renderer>();

      Fadeable.OnApply += Apply;
      Fadeable.OnFadeOutStart += FadeOutStart;
      Fadeable.OnFadeInComplete += FadeInComplete;
    }

    private void Apply()
    {
      for (int i = 0; i < _renderers.Length; i++)
      {
        for (int j = 0; j < _renderers[i].materials.Length; j++)
        {
          Material mat = _renderers[i].materials[j];
          Properties.dissolveAmount.SetValue(mat, Fadeable.Value);
        }
      }
    }

    private void FadeOutStart()
    {
      // Enable children
      for (int i = 0; i < transform.childCount; i++)
      {
        transform.GetChild(i).gameObject.SetActive(true);
      }
    }

    private void FadeInComplete()
    {
      // Disable children
      for (int i = 0; i < transform.childCount; i++)
      {
        transform.GetChild(i).gameObject.SetActive(false);
      }
    }
  }
}