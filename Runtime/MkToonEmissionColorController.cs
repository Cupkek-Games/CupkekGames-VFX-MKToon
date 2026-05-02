using UnityEngine;
using MK.Toon;

namespace CupkekGames.VFX.MKToon
{
    public class MkToonEmissionColorController : ColorController
    {
        private Renderer[] _renderers;
        private Color[][] _originalColors;
        private void Awake()
        {
            _renderers = gameObject.GetComponentsInChildren<Renderer>();

            // Initialize the array to store original colors
            _originalColors = new Color[_renderers.Length][];
            // Store the original colors
            for (int i = 0; i < _renderers.Length; i++)
            {
                Material[] materials = _renderers[i].materials;
                _originalColors[i] = new Color[materials.Length];

                for (int j = 0; j < materials.Length; j++)
                {
                    _originalColors[i][j] = Properties.emissionColor.GetValue(materials[j]);
                }
            }
        }
        private void ApplyOverlay(Color? overlay, float weight)
        {
            for (int i = 0; i < _renderers.Length; i++)
            {
                if (_renderers[i] == null)
                {
                    return;
                }

                Material[] materials = _renderers[i].materials;

                for (int j = 0; j < materials.Length; j++)
                {
                    if (overlay.HasValue)
                    {
                        Properties.emissionColor.SetValue(materials[j],
                            ColorUtils.LerpColorsByWeights(_originalColors[i][j], OriginalColorWeight, overlay.Value, weight));
                    }
                    else
                    {
                        Properties.emissionColor.SetValue(materials[j], _originalColors[i][j]);
                    }
                }
            }
        }

        public override void Revert()
        {
            ApplyOverlay(null, 0);
        }

        public override void LerpValue(Color color, float weight)
        {
            ApplyOverlay(color, weight);
        }
    }
}