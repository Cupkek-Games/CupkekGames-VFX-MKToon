using UnityEngine;
using MK.Toon;

namespace CupkekGames.VFX.MKToon
{
    public class MkToonColorControllerMaterial : ColorController
    {
        [SerializeField] private RendererMaterialPair[] _materials;
        private Color[] _originalColors;
        private void Awake()
        {
            // Initialize the array to store original colors
            _originalColors = new Color[_materials.Length];
            // Store the original colors
            for (int i = 0; i < _materials.Length; i++)
            {
                _originalColors[i] = Properties.albedoColor.GetValue(_materials[i].GetMaterial());
            }
        }
        public Material GetMaterial(int index)
        {
            return _materials[index].GetMaterial();
        }

        private void ApplyOverlay(Color? overlay, float weight)
        {
            for (int i = 0; i < _materials.Length; i++)
            {
                if (overlay.HasValue)
                {
                    Properties.albedoColor.SetValue(GetMaterial(i),
                        ColorUtils.LerpColorsByWeights(_originalColors[i], OriginalColorWeight, overlay.Value, weight));
                }
                else
                {
                    Properties.albedoColor.SetValue(GetMaterial(i), _originalColors[i]);
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