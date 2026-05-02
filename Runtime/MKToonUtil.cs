using UnityEngine;
using MK.Toon;
using System.Collections.Generic;

namespace CupkekGames.VFX.MKToon
{
  public class MKToonUtil
  {
    private List<GameObject> _transparentObjects = new List<GameObject>();
    public void MakeTransparent(GameObject gameObject, float alpha)
    {
      // Find all materials in all renderers
      Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
      foreach (Renderer renderer in renderers)
      {
        foreach (Material material in renderer.materials)
        {
          // Set the material to transparent
          Properties.surface.SetValue(material, Surface.Transparent);

          // Change the alpha value, keep color same
          Color currentColor = Properties.albedoColor.GetValue(material);
          currentColor.a = alpha;
          Properties.albedoColor.SetValue(material, currentColor);
        }
      }

      _transparentObjects.Add(gameObject);
    }

    private void MakeOpaque(GameObject gameObject)
    {
      // Find all materials in all renderers
      Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
      foreach (Renderer renderer in renderers)
      {
        foreach (Material material in renderer.materials)
        {
          // Set the material to opaque
          Properties.surface.SetValue(material, Surface.Opaque);

          // Change the alpha value, keep color same
          Color currentColor = Properties.albedoColor.GetValue(material);
          currentColor.a = 1f;
          Properties.albedoColor.SetValue(material, currentColor);
        }
      }
    }

    public void MakeOpaqueAll()
    {
      foreach (GameObject gameObject in _transparentObjects)
      {
        MakeOpaque(gameObject);
      }
      _transparentObjects.Clear();
    }

    public void SetColor(GameObject gameObject, Color color)
    {
      // Find all materials in all renderers
      Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
      foreach (Renderer renderer in renderers)
      {
        foreach (Material material in renderer.materials)
        {
          Properties.albedoColor.SetValue(material, color);
        }
      }
    }
  }
}
