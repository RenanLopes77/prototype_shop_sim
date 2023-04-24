using System.Collections;
using UnityEngine;

namespace Prototype.Plantation
{
    public class Seedling : MonoBehaviour
    {
        [SerializeField] private PlantationDataSO _plantationData = null;

        [SerializeField] private SpriteRenderer _spriteRenderer = null;
        private Plant _plant = null;
        
        private void Start()
        {
            GetPlant();
        }

        private void GetPlant()
        {
            _plant = _plantationData.GetRandom();
            StartCoroutine(GrowPlant());
        }

        private IEnumerator GrowPlant()
        {
            _spriteRenderer.enabled = true;
            int stage = 0;
            while (stage < _plant.Stages.Count - 1)
            {
                _spriteRenderer.sprite = _plant.Stages[stage];
                yield return new WaitForSeconds(_plant.TimePerStage);
                stage++;
            }
            _spriteRenderer.enabled = false;
            Grown();
        }

        private void Grown()
        {
            Instantiate(_plant.Prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
