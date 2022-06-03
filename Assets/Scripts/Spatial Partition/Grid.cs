using UnityEngine;

namespace SpatialPartition {
    public class Grid {
        public const int NUM_CELLS = 15;
        public const int CELL_SIZE = 5;

        Unit[,] cells = new Unit[NUM_CELLS, NUM_CELLS];

        /*void Init() {
            for (int x = 0; x < NUM_CELLS; ++x) {
                for (int y = 0; y < NUM_CELLS; ++y) {
                    cells[x, y] = null;
                }
            }
        }*/
        
        public void Add(Unit unit) {
            int cellX = (int)(unit.transform.position.x / CELL_SIZE);
            int cellY = (int)(unit.transform.position.y / CELL_SIZE);

            unit.prev = null;
            unit.next = cells[cellX, cellY];
            cells[cellX, cellY] = unit;

            if (unit.next != null) {
                unit.next.prev = unit;
            }
        }

        public void Move(Unit unit, Vector3 newPosition) {
            // see which cell it was in
            Vector2Int oldCellIndex = WorldPointToCellIndex(unit.transform.position);

            // see which cell it's moving to
            Vector2Int newCellIndex = WorldPointToCellIndex(newPosition);

            // if it didn't change cells, we're done
            if (oldCellIndex.x == newCellIndex.x && oldCellIndex.y == newCellIndex.y)
                return;

            // unlink it from the list of its old cell
            if (unit.prev != null)
                unit.prev.next = unit.next;

            if (unit.next != null)
                unit.next.prev = unit.prev;

            // if it's the head of a list, remove it
            if (cells[oldCellIndex.x, oldCellIndex.y] == unit)
                cells[newCellIndex.x, newCellIndex.y] = unit.next;

            Add(unit);
        }

        public void HandleMelee() {
            for (int x = 0; x < NUM_CELLS; ++x) {
                for (int y = 0; y < NUM_CELLS; ++y) {
                    HandleCell(x, y);
                }
            }
        }

        void HandleCell(int x, int y) {
            Unit unit = cells[x, y];
            while (unit != null) {
                // handle other units in this cell
                HandleUnit(unit, unit.next);

                // also try the neighboring cells
                // we inspect only 4 out of 8 adjacent cells because the outer double for-loop [HandleMelee] will handle other 4 neighboring cells from other unit
                if (x > 0 && y > 0) HandleUnit(unit, cells[x - 1, y - 1]);
                if (x > 0) HandleUnit(unit, cells[x - 1, y]);
                if (y > 0) HandleUnit(unit, cells[x, y - 1]);
                if (x > 0 && y < NUM_CELLS - 1) HandleUnit(unit, cells[x - 1, y + 1]);
                
                unit = unit.next;
            }
        }

        void HandleUnit(Unit unit, Unit other) {
            while (other != null) {
                if ((unit.transform.position - other.transform.position).sqrMagnitude < Unit.ATTACK_DISTANCE * Unit.ATTACK_DISTANCE) {
                    HandleAttack(unit, other);
                }

                other = other.next;
            }
        }

        void HandleAttack(Unit unit, Unit other) {
            unit.Attack();
            other.Attack();
        }

        public bool IsWithinBoundaries(Vector3 position) {
            Vector2Int positionIndex = WorldPointToCellIndex(position);
            
            return positionIndex.x is >= 0 and < NUM_CELLS && positionIndex.y is >= 0 and < NUM_CELLS;
        }

        static Vector2Int WorldPointToCellIndex(Vector3 position) {
            return new Vector2Int(Mathf.FloorToInt(position.x / CELL_SIZE), Mathf.FloorToInt(position.z / CELL_SIZE));
        }
    }
}
