using System.Collections.Generic;
using UnityEngine;

namespace SpatialPartition {
    public class Game : MonoBehaviour {
        [SerializeField] Transform battlefield;
        [SerializeField] Unit unitPrefab;
        [SerializeField] int unitsCount;
        
        Grid grid;
        HashSet<Unit> units = new();

        // things to consider:
        // 1. let the num cells and cell size values set in inspector
        // 2. define the origin of the grid, so the battlefield does not need to be moved
        
        void OnEnable() {
            grid = new Grid();

            float battlefieldSize = Grid.NUM_CELLS * Grid.CELL_SIZE;
            battlefield.localScale = new Vector3(battlefieldSize, 1f, battlefieldSize);
            battlefield.position = new Vector3(battlefieldSize * .5f, 0f, battlefieldSize * .5f);

            Transform unitsHolder = new GameObject($"{unitPrefab.name} Holder").transform;
            for (int i = 0; i < unitsCount; ++i) {
                Vector3 randomPosition = new Vector3(Random.Range(0f, battlefieldSize), 1.5f, Random.Range(0f, battlefieldSize));
                
                Unit newUnit = Instantiate(unitPrefab, unitsHolder);
                newUnit.Init(grid, randomPosition);
                
                units.Add(newUnit);
            }
        }

        void Update() {
            foreach (Unit unit in units) {
                unit.Move(Time.deltaTime);
            }

            grid.HandleMelee();
        }
    }
}
