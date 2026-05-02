using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CupkekGames.VFX.MKToon
{
  public class DissolveGroup
  {
    private List<Dissolvable> _dissolvables;

    public void Add(Dissolvable dissolvable)
    {
      if (_dissolvables == null)
      {
        _dissolvables = new List<Dissolvable>();
      }
      _dissolvables.Add(dissolvable);
    }

    public void AddRange(List<Dissolvable> dissolvables)
    {
      if (_dissolvables == null)
      {
        _dissolvables = new List<Dissolvable>();
      }
      _dissolvables.AddRange(dissolvables);
    }

    public void FadeIn(bool check)
    {
      for (int i = 0; i < _dissolvables.Count; i++)
      {
        if (check && Mathf.Approximately(_dissolvables[i].Fadeable.Value, _dissolvables[i].Fadeable._in))
        {
          continue;
        }

        _dissolvables[i].Fadeable.FadeIn();
      }
    }

    public void FadeOut(bool check)
    {
      for (int i = 0; i < _dissolvables.Count; i++)
      {
        if (check && Mathf.Approximately(_dissolvables[i].Fadeable.Value, _dissolvables[i].Fadeable._out))
        {
          continue;
        }

        _dissolvables[i].Fadeable.FadeOut();
      }
    }

    public void SetFadedIn(bool check)
    {
      for (int i = 0; i < _dissolvables.Count; i++)
      {
        if (check && Mathf.Approximately(_dissolvables[i].Fadeable.Value, _dissolvables[i].Fadeable._in))
        {
          continue;
        }

        _dissolvables[i].Fadeable.SetFadedIn();
      }
    }

    public void SetFadedOut(bool check)
    {
      for (int i = 0; i < _dissolvables.Count; i++)
      {
        if (check && Mathf.Approximately(_dissolvables[i].Fadeable.Value, _dissolvables[i].Fadeable._out))
        {
          continue;
        }

        _dissolvables[i].Fadeable.SetFadedOut();
      }
    }
  }
}